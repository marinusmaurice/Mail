using Mail.Models;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Mail.Services
{
    public interface IEmailProvider
    {
        Task<bool> TestConnectionAsync(Account account);
        Task<List<EmailMessage>> ReceiveEmailsAsync(Account account, EmailFolder folder = EmailFolder.Inbox);
        Task<bool> SendEmailAsync(Account account, EmailMessage email);
        Task<bool> DeleteEmailAsync(Account account, EmailMessage email);
        Task<bool> MoveEmailAsync(Account account, EmailMessage email, EmailFolder targetFolder);
    }

    public class RealImapSmtpProvider : IEmailProvider
    {
        public async Task<bool> TestConnectionAsync(Account account)
        {
            try
            {
                // Test IMAP connection
                using var client = new ImapClient();
                
                var secureOptions = account.IncomingServer.UseSSL 
                    ? SecureSocketOptions.SslOnConnect 
                    : SecureSocketOptions.StartTlsWhenAvailable;
                
                await client.ConnectAsync(account.IncomingServer.Server, account.IncomingServer.Port, secureOptions);
                await client.AuthenticateAsync(account.IncomingServer.Username, account.IncomingServer.Password);
                await client.DisconnectAsync(true);

                // Test SMTP connection
                using var smtp = new SmtpClient();
                var smtpSecureOptions = account.OutgoingServer.UseSSL 
                    ? SecureSocketOptions.SslOnConnect 
                    : SecureSocketOptions.StartTlsWhenAvailable;
                
                await smtp.ConnectAsync(account.OutgoingServer.Server, account.OutgoingServer.Port, smtpSecureOptions);
                await smtp.AuthenticateAsync(account.OutgoingServer.Username, account.OutgoingServer.Password);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"IMAP/SMTP connection test failed: {ex.Message}");
                return false;
            }
        }

        public async Task<List<EmailMessage>> ReceiveEmailsAsync(Account account, EmailFolder folder = EmailFolder.Inbox)
        {
            var emails = new List<EmailMessage>();

            try
            {
                using var client = new ImapClient();
                
                // Enable logging for debugging
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                
                var secureOptions = account.IncomingServer.UseSSL 
                    ? SecureSocketOptions.SslOnConnect 
                    : SecureSocketOptions.StartTlsWhenAvailable;
                
                System.Diagnostics.Debug.WriteLine($"Connecting to {account.IncomingServer.Server}:{account.IncomingServer.Port} with SSL={account.IncomingServer.UseSSL}");
                
                await client.ConnectAsync(account.IncomingServer.Server, account.IncomingServer.Port, secureOptions);
                await client.AuthenticateAsync(account.IncomingServer.Username, account.IncomingServer.Password);

                var folderName = await GetBestImapFolderName(client, folder);
                System.Diagnostics.Debug.WriteLine($"Opening folder: {folderName}");
                
                var mailFolder = await client.GetFolderAsync(folderName);
                await mailFolder.OpenAsync(MailKit.FolderAccess.ReadOnly);

                System.Diagnostics.Debug.WriteLine($"Folder {folderName} contains {mailFolder.Count} messages");

                var messageCount = Math.Min(20, mailFolder.Count); // Limit to 20 for better performance
                if (messageCount > 0)
                {
                    var startIndex = Math.Max(0, mailFolder.Count - messageCount);
                    System.Diagnostics.Debug.WriteLine($"Fetching messages from {startIndex} to {mailFolder.Count - 1}");
                    
                    var id = 1;
                    for (int i = mailFolder.Count - 1; i >= startIndex && id <= messageCount; i--, id++)
                    {
                        try
                        {
                            // Just get the full message directly for simplicity
                            var message = await mailFolder.GetMessageAsync(i);
                            
                            var emailMessage = new EmailMessage
                            {
                                Id = id,
                                Subject = message.Subject ?? "(No Subject)",
                                From = GetFirstEmailAddress(message.From) ?? "(Unknown Sender)",
                                To = string.Join("; ", message.To.Select(GetEmailFromAddress).Where(e => !string.IsNullOrEmpty(e))),
                                DateReceived = message.Date.DateTime,
                                DateSent = message.Date.DateTime,
                                IsRead = true, // Default to read for now
                                IsImportant = CheckIfImportant(message),
                                HasAttachments = message.Attachments.Any(),
                                Body = GetMessageBody(message),
                                Folder = folder
                            };

                            emails.Add(emailMessage);
                            System.Diagnostics.Debug.WriteLine($"Fetched email: {emailMessage.Subject}");
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Failed to fetch message {i}: {ex.Message}");
                            // Skip messages that can't be fetched but continue with others
                            continue;
                        }
                    }
                }

                await client.DisconnectAsync(true);
                System.Diagnostics.Debug.WriteLine($"Successfully fetched {emails.Count} emails from {folder}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"IMAP Error: {ex.Message}");
                throw new Exception($"Failed to receive emails from IMAP server ({account.IncomingServer.Server}): {ex.Message}", ex);
            }

            return emails;
        }

        public async Task<bool> SendEmailAsync(Account account, EmailMessage email)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(account.DisplayName, account.EmailAddress));
                
                // Add recipients
                AddRecipients(message.To, email.To);
                AddRecipients(message.Cc, email.Cc);
                AddRecipients(message.Bcc, email.Bcc);

                message.Subject = email.Subject;

                var bodyBuilder = new BodyBuilder
                {
                    TextBody = email.Body
                };

                message.Body = bodyBuilder.ToMessageBody();

                using var client = new SmtpClient();
                var secureOptions = account.OutgoingServer.UseSSL 
                    ? SecureSocketOptions.SslOnConnect 
                    : SecureSocketOptions.StartTlsWhenAvailable;
                
                System.Diagnostics.Debug.WriteLine($"Sending email via {account.OutgoingServer.Server}:{account.OutgoingServer.Port}");
                
                await client.ConnectAsync(account.OutgoingServer.Server, account.OutgoingServer.Port, secureOptions);
                await client.AuthenticateAsync(account.OutgoingServer.Username, account.OutgoingServer.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                System.Diagnostics.Debug.WriteLine("Email sent successfully");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SMTP Error: {ex.Message}");
                throw new Exception($"Failed to send email via SMTP ({account.OutgoingServer.Server}): {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteEmailAsync(Account account, EmailMessage email)
        {
            // Implementation would require storing IMAP UIDs
            await Task.Delay(1); // Placeholder
            return true;
        }

        public async Task<bool> MoveEmailAsync(Account account, EmailMessage email, EmailFolder targetFolder)
        {
            // Implementation would require storing IMAP UIDs
            await Task.Delay(1); // Placeholder
            return true;
        }

        private async Task<string> GetBestImapFolderName(ImapClient client, EmailFolder folder)
        {
            try
            {
                var defaultName = GetImapFolderName(folder);
                
                // Try to get the actual folder list and find the best match
                var namespaces = await client.GetFoldersAsync(client.PersonalNamespaces[0]);
                
                // Try exact match first
                var exactMatch = namespaces.FirstOrDefault(f => 
                    f.Name.Equals(defaultName, StringComparison.OrdinalIgnoreCase));
                if (exactMatch != null)
                    return exactMatch.FullName;

                // Try common variations
                var variations = GetFolderVariations(folder);
                foreach (var variation in variations)
                {
                    var match = namespaces.FirstOrDefault(f => 
                        f.Name.Equals(variation, StringComparison.OrdinalIgnoreCase));
                    if (match != null)
                        return match.FullName;
                }

                // Fall back to default
                return defaultName;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to get folder list: {ex.Message}");
                // If we can't get folder list, use default
                return GetImapFolderName(folder);
            }
        }

        private string GetImapFolderName(EmailFolder folder)
        {
            return folder switch
            {
                EmailFolder.Inbox => "INBOX",
                EmailFolder.SentItems => "Sent",
                EmailFolder.Drafts => "Drafts",
                EmailFolder.DeletedItems => "Trash",
                EmailFolder.Junk => "Junk",
                _ => "INBOX"
            };
        }

        private string[] GetFolderVariations(EmailFolder folder)
        {
            return folder switch
            {
                EmailFolder.SentItems => new[] { "Sent", "Sent Items", "Sent Mail", "Sent Messages", "[Gmail]/Sent Mail" },
                EmailFolder.Drafts => new[] { "Drafts", "Draft", "[Gmail]/Drafts" },
                EmailFolder.DeletedItems => new[] { "Trash", "Deleted Items", "Deleted", "[Gmail]/Trash" },
                EmailFolder.Junk => new[] { "Junk", "Spam", "Junk Email", "[Gmail]/Spam" },
                _ => new[] { "INBOX" }
            };
        }

        private string? GetFirstEmailAddress(InternetAddressList addresses)
        {
            var first = addresses.FirstOrDefault();
            return GetEmailFromAddress(first);
        }

        private string GetEmailFromAddress(InternetAddress? address)
        {
            return address switch
            {
                MailboxAddress mailbox => mailbox.Name != null && !string.IsNullOrEmpty(mailbox.Name) 
                    ? $"{mailbox.Name} <{mailbox.Address}>" 
                    : mailbox.Address,
                GroupAddress group => group.Name,
                _ => address?.ToString() ?? ""
            };
        }

        private string GetMessageBody(MimeMessage message)
        {
            try
            {
                // Prefer plain text, fall back to HTML
                if (!string.IsNullOrEmpty(message.TextBody))
                    return message.TextBody;
                
                if (!string.IsNullOrEmpty(message.HtmlBody))
                {
                    // Basic HTML to text conversion
                    return System.Text.RegularExpressions.Regex.Replace(
                        message.HtmlBody, "<.*?>", string.Empty);
                }
                
                return "(No content)";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to get message body: {ex.Message}");
                return "(Error loading message body)";
            }
        }

        private bool CheckIfImportant(MimeMessage message)
        {
            try
            {
                // Check for high priority or importance headers
                return message.Importance == MessageImportance.High ||
                       message.Priority == MessagePriority.Urgent ||
                       message.Headers.Contains("X-Priority") && message.Headers["X-Priority"].Contains("1");
            }
            catch
            {
                return false;
            }
        }

        private void AddRecipients(InternetAddressList list, string addresses)
        {
            if (string.IsNullOrWhiteSpace(addresses)) return;

            var emails = addresses.Split(';', ',').Where(e => !string.IsNullOrWhiteSpace(e));
            foreach (var email in emails)
            {
                try
                {
                    var trimmed = email.Trim();
                    // Try to parse as a proper email address
                    var mailAddress = MailboxAddress.Parse(trimmed);
                    list.Add(mailAddress);
                }
                catch
                {
                    // If parsing fails, try simple format
                    try
                    {
                        list.Add(new MailboxAddress("", email.Trim()));
                    }
                    catch
                    {
                        // Skip invalid email addresses
                        System.Diagnostics.Debug.WriteLine($"Skipping invalid email address: {email}");
                    }
                }
            }
        }
    }

    // Keep the old classes for backward compatibility but make them redirect to the real provider
    public class OutlookGraphProvider : IEmailProvider
    {
        private readonly RealImapSmtpProvider _realProvider = new RealImapSmtpProvider();

        public async Task<bool> TestConnectionAsync(Account account)
        {
            // For Outlook accounts, we still use IMAP if server settings are configured
            if (!string.IsNullOrEmpty(account.IncomingServer.Server))
            {
                return await _realProvider.TestConnectionAsync(account);
            }
            
            // If no server settings, we can't connect
            return false;
        }

        public async Task<List<EmailMessage>> ReceiveEmailsAsync(Account account, EmailFolder folder = EmailFolder.Inbox)
        {
            // Use real IMAP connection for Outlook accounts too
            if (!string.IsNullOrEmpty(account.IncomingServer.Server))
            {
                return await _realProvider.ReceiveEmailsAsync(account, folder);
            }
            
            throw new Exception("Outlook account not configured with IMAP settings. Please configure manually with outlook.office365.com settings.");
        }

        public async Task<bool> SendEmailAsync(Account account, EmailMessage email)
        {
            if (!string.IsNullOrEmpty(account.OutgoingServer.Server))
            {
                return await _realProvider.SendEmailAsync(account, email);
            }
            
            throw new Exception("Outlook account not configured with SMTP settings.");
        }

        public async Task<bool> DeleteEmailAsync(Account account, EmailMessage email)
        {
            return await _realProvider.DeleteEmailAsync(account, email);
        }

        public async Task<bool> MoveEmailAsync(Account account, EmailMessage email, EmailFolder targetFolder)
        {
            return await _realProvider.MoveEmailAsync(account, email, targetFolder);
        }
    }

    public class ImapSmtpProvider : IEmailProvider
    {
        private readonly RealImapSmtpProvider _realProvider = new RealImapSmtpProvider();

        public async Task<bool> TestConnectionAsync(Account account)
        {
            return await _realProvider.TestConnectionAsync(account);
        }

        public async Task<List<EmailMessage>> ReceiveEmailsAsync(Account account, EmailFolder folder = EmailFolder.Inbox)
        {
            return await _realProvider.ReceiveEmailsAsync(account, folder);
        }

        public async Task<bool> SendEmailAsync(Account account, EmailMessage email)
        {
            return await _realProvider.SendEmailAsync(account, email);
        }

        public async Task<bool> DeleteEmailAsync(Account account, EmailMessage email)
        {
            return await _realProvider.DeleteEmailAsync(account, email);
        }

        public async Task<bool> MoveEmailAsync(Account account, EmailMessage email, EmailFolder targetFolder)
        {
            return await _realProvider.MoveEmailAsync(account, email, targetFolder);
        }
    }
}