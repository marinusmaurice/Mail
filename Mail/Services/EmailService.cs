using System;
using System.Collections.Generic;
using System.Linq;
using Mail.Models;

namespace Mail.Services
{
    public class EmailService
    {
        private List<EmailMessage> _emails = new List<EmailMessage>();
        private List<Account> _accounts = new List<Account>();
        private AccountService _accountService;
        private IEmailProvider? _currentProvider;
        private int _nextId = 1;

        // Progress tracking
        public event EventHandler<string>? SyncProgressChanged;
        public event EventHandler<EmailMessage>? NewEmailReceived;
        public event EventHandler<EmailMessage>? EmailSent;
        public event EventHandler<EmailMessage>? EmailDeleted;

        public EmailService(AccountService? accountService = null)
        {
            _accountService = accountService ?? new AccountService();
            InitializeSampleData();
        }

        public List<EmailMessage> GetEmails(EmailFolder folder = EmailFolder.Inbox)
        {
            return _emails.Where(e => e.Folder == folder && !e.IsDeleted).ToList();
        }

        public List<EmailMessage> GetEmailsByAccount(int accountId)
        {
            // In a real implementation, this would filter by account
            return _emails.Where(e => !e.IsDeleted).ToList();
        }

        public EmailMessage? GetEmailById(int id)
        {
            return _emails.FirstOrDefault(e => e.Id == id);
        }

        public async Task<bool> SendEmailAsync(EmailMessage email)
        {
            try
            {
                var account = _accountService.GetDefaultAccount();
                if (account == null)
                {
                    throw new InvalidOperationException("No default email account configured. Please set up an email account first.");
                }

                SyncProgressChanged?.Invoke(this, "Sending email...");
                var provider = GetEmailProvider(account);
                var success = await provider.SendEmailAsync(account, email);

                if (success)
                {
                    email.Id = _nextId++;
                    email.DateSent = DateTime.Now;
                    email.Folder = EmailFolder.SentItems;
                    email.From = account.EmailAddress;
                    _emails.Add(email);
                    EmailSent?.Invoke(this, email);
                    SyncProgressChanged?.Invoke(this, "Email sent successfully");
                }

                return success;
            }
            catch (Exception ex)
            {
                SyncProgressChanged?.Invoke(this, $"Failed to send email: {ex.Message}");
                throw new Exception($"Failed to send email: {ex.Message}", ex);
            }
        }

        public void SendEmail(EmailMessage email)
        {
            // Synchronous wrapper for backward compatibility
            Task.Run(async () =>
            {
                try
                {
                    await SendEmailAsync(email);
                }
                catch (Exception ex)
                {
                    // Log error or show message
                    System.Windows.Forms.MessageBox.Show($"Failed to send email: {ex.Message}", "Send Error", 
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            });
        }

        public async Task<List<EmailMessage>> ReceiveEmailsAsync(EmailFolder folder = EmailFolder.Inbox, bool showProgress = true)
        {
            try
            {
                var account = _accountService.GetDefaultAccount();
                if (account == null)
                {
                    // Return local emails if no account is configured
                    return GetEmails(folder);
                }

                if (showProgress)
                    SyncProgressChanged?.Invoke(this, $"Connecting to {account.IncomingServer.Server}...");

                var provider = GetEmailProvider(account);
                
                // Retry logic
                List<EmailMessage> receivedEmails = new List<EmailMessage>();
                var maxRetries = 3;
                var retryCount = 0;
                
                while (retryCount < maxRetries)
                {
                    try
                    {
                        if (showProgress)
                            SyncProgressChanged?.Invoke(this, $"Fetching emails from {folder}...");
                        
                        receivedEmails = await provider.ReceiveEmailsAsync(account, folder);
                        break; // Success, exit retry loop
                    }
                    catch (Exception ex) when (retryCount < maxRetries - 1)
                    {
                        retryCount++;
                        if (showProgress)
                            SyncProgressChanged?.Invoke(this, $"Retry {retryCount}/{maxRetries}: {ex.Message}");
                        await Task.Delay(2000 * retryCount); // Exponential backoff
                    }
                }

                if (showProgress)
                    SyncProgressChanged?.Invoke(this, $"Processing {receivedEmails.Count} emails...");

                // Update local storage with improved duplicate detection
                var newEmailsCount = 0;
                foreach (var email in receivedEmails)
                {
                    var existing = _emails.FirstOrDefault(e => 
                        IsDuplicate(e, email));
                    
                    if (existing == null)
                    {
                        email.Id = _nextId++;
                        _emails.Add(email);
                        newEmailsCount++;
                        
                        if (folder == EmailFolder.Inbox && !email.IsRead)
                        {
                            NewEmailReceived?.Invoke(this, email);
                        }
                    }
                    else
                    {
                        // Update existing email with potentially newer information
                        existing.IsRead = email.IsRead;
                        existing.IsImportant = email.IsImportant;
                        existing.IsFlagged = email.IsFlagged;
                    }
                }

                if (showProgress)
                    SyncProgressChanged?.Invoke(this, $"Sync complete: {newEmailsCount} new emails added");

                return GetEmails(folder);
            }
            catch (Exception ex)
            {
                var errorMsg = $"Failed to receive emails from {folder}: {ex.Message}";
                SyncProgressChanged?.Invoke(this, errorMsg);
                throw new Exception(errorMsg, ex);
            }
        }

        public async Task<bool> TestAccountConnectionAsync(Account account)
        {
            try
            {
                SyncProgressChanged?.Invoke(this, "Testing connection...");
                var provider = GetEmailProvider(account);
                var result = await provider.TestConnectionAsync(account);
                SyncProgressChanged?.Invoke(this, result ? "Connection successful" : "Connection failed");
                return result;
            }
            catch (Exception ex)
            {
                SyncProgressChanged?.Invoke(this, $"Connection test failed: {ex.Message}");
                return false;
            }
        }

        public void SaveDraft(EmailMessage email)
        {
            if (email.Id == 0)
            {
                email.Id = _nextId++;
                _emails.Add(email);
            }
            email.Folder = EmailFolder.Drafts;
        }

        public void DeleteEmail(EmailMessage email)
        {
            email.IsDeleted = true;
            email.Folder = EmailFolder.DeletedItems;
            EmailDeleted?.Invoke(this, email);
        }

        public void MoveToFolder(EmailMessage email, EmailFolder folder)
        {
            email.Folder = folder;
        }

        public void MarkAsRead(EmailMessage email)
        {
            email.IsRead = true;
        }

        public void MarkAsUnread(EmailMessage email)
        {
            email.IsRead = false;
        }

        public void ToggleFlag(EmailMessage email)
        {
            email.IsFlagged = !email.IsFlagged;
        }

        public void ToggleImportant(EmailMessage email)
        {
            email.IsImportant = !email.IsImportant;
        }

        public List<EmailMessage> SearchEmails(string searchTerm)
        {
            return _emails.Where(e => 
                e.Subject.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                e.From.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                e.Body.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        public async Task RefreshEmailsAsync()
        {
            try
            {
                SyncProgressChanged?.Invoke(this, "Starting email synchronization...");
                
                // Refresh all folders sequentially to avoid overwhelming the server
                var folders = new[] { EmailFolder.Inbox, EmailFolder.SentItems, EmailFolder.Drafts };
                
                foreach (var folder in folders)
                {
                    try
                    {
                        await ReceiveEmailsAsync(folder, true);
                        // Small delay between folders to be gentle on the server
                        await Task.Delay(500);
                    }
                    catch (Exception ex)
                    {
                        SyncProgressChanged?.Invoke(this, $"Warning: Failed to sync {folder}: {ex.Message}");
                        // Continue with other folders even if one fails
                    }
                }
                
                SyncProgressChanged?.Invoke(this, "Email synchronization completed");
            }
            catch (Exception ex)
            {
                var errorMsg = $"Failed to refresh emails: {ex.Message}";
                SyncProgressChanged?.Invoke(this, errorMsg);
                throw new Exception(errorMsg, ex);
            }
        }

        private IEmailProvider GetEmailProvider(Account account)
        {
            if (_currentProvider == null || NeedsProviderChange(account))
            {
                _currentProvider = account.Type switch
                {
                    AccountType.Outlook or AccountType.Exchange => new OutlookGraphProvider(),
                    AccountType.IMAP or AccountType.POP3 or AccountType.Gmail or AccountType.Yahoo => new ImapSmtpProvider(),
                    _ => new ImapSmtpProvider()
                };
            }

            return _currentProvider;
        }

        private bool NeedsProviderChange(Account account)
        {
            return _currentProvider switch
            {
                OutlookGraphProvider => account.Type != AccountType.Outlook && account.Type != AccountType.Exchange,
                ImapSmtpProvider => account.Type == AccountType.Outlook || account.Type == AccountType.Exchange,
                _ => true
            };
        }

        private bool IsDuplicate(EmailMessage existing, EmailMessage newEmail)
        {
            // More sophisticated duplicate detection
            return existing.Subject == newEmail.Subject &&
                   existing.From == newEmail.From &&
                   Math.Abs((existing.DateReceived - newEmail.DateReceived).TotalSeconds) < 60; // Within 1 minute
        }

        private void InitializeSampleData()
        {
            // Only add sample emails if NO accounts are configured
            // Once real accounts are set up, we should rely on real email sync
            var accounts = _accountService.GetAllAccounts();
            if (!accounts.Any())
            {
                _emails.Add(new EmailMessage
                {
                    Id = _nextId++,
                    From = "setup@emailclient.local",
                    To = "user@localhost",
                    Subject = "Welcome - Please Set Up Your Email Account",
                    Body = "Welcome to your email client!\n\nTo start receiving real emails:\n\n1. Go to File ? Add Account\n2. Enter your email provider settings (Gmail, Yahoo, Outlook, etc.)\n3. Use real IMAP/SMTP servers to sync your actual emails\n\nThis welcome message will disappear once you configure a real email account.",
                    DateReceived = DateTime.Now.AddMinutes(-5),
                    IsRead = false,
                    Folder = EmailFolder.Inbox
                });
            }
            // DO NOT add sample data if accounts exist - use real emails only!
        }
    }
}