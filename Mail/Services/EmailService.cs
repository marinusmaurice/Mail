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
                }

                return success;
            }
            catch (Exception ex)
            {
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

        public async Task<List<EmailMessage>> ReceiveEmailsAsync(EmailFolder folder = EmailFolder.Inbox)
        {
            try
            {
                var account = _accountService.GetDefaultAccount();
                if (account == null)
                {
                    // Return local emails if no account is configured
                    return GetEmails(folder);
                }

                var provider = GetEmailProvider(account);
                var receivedEmails = await provider.ReceiveEmailsAsync(account, folder);

                // Update local storage
                foreach (var email in receivedEmails)
                {
                    var existing = _emails.FirstOrDefault(e => e.Subject == email.Subject && 
                                                               e.From == email.From && 
                                                               e.DateReceived == email.DateReceived);
                    if (existing == null)
                    {
                        email.Id = _nextId++;
                        _emails.Add(email);
                        
                        if (folder == EmailFolder.Inbox && !email.IsRead)
                        {
                            NewEmailReceived?.Invoke(this, email);
                        }
                    }
                }

                return GetEmails(folder);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to receive emails: {ex.Message}", ex);
            }
        }

        public async Task<bool> TestAccountConnectionAsync(Account account)
        {
            try
            {
                var provider = GetEmailProvider(account);
                return await provider.TestConnectionAsync(account);
            }
            catch
            {
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
                // Refresh all folders
                await ReceiveEmailsAsync(EmailFolder.Inbox);
                await ReceiveEmailsAsync(EmailFolder.SentItems);
                await ReceiveEmailsAsync(EmailFolder.Drafts);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to refresh emails: {ex.Message}", ex);
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

        private void InitializeSampleData()
        {
            // Add some sample emails only if no accounts are configured
            var accounts = _accountService.GetAllAccounts();
            if (!accounts.Any())
            {
                _emails.Add(new EmailMessage
                {
                    Id = _nextId++,
                    From = "john.doe@company.com",
                    To = "me@outlook.com",
                    Subject = "Welcome to Your New Email Client",
                    Body = "Hi there!\n\nWelcome to your new Outlook-compatible email client. To get started:\n\n1. Go to File > Settings to add your email account\n2. Configure your Outlook, Gmail, or other email account\n3. Start sending and receiving real emails!\n\nBest regards,\nThe Email Team",
                    DateReceived = DateTime.Now.AddHours(-1),
                    IsRead = false,
                    Folder = EmailFolder.Inbox
                });

                _emails.Add(new EmailMessage
                {
                    Id = _nextId++,
                    From = "support@emailclient.com",
                    To = "me@outlook.com",
                    Subject = "Getting Started Guide",
                    Body = "Here's how to configure your email accounts:\n\nFor Outlook/Exchange:\n- Account Type: Outlook\n- Authentication: OAuth2 (recommended)\n\nFor Gmail:\n- Account Type: IMAP\n- Incoming Server: imap.gmail.com (Port 993, SSL)\n- Outgoing Server: smtp.gmail.com (Port 587, STARTTLS)\n\nFor other providers, check their documentation for IMAP/SMTP settings.",
                    DateReceived = DateTime.Now.AddHours(-2),
                    IsRead = true,
                    Folder = EmailFolder.Inbox
                });
            }
        }
    }
}