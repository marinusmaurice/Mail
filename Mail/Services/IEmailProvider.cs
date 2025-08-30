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

    public class OutlookGraphProvider : IEmailProvider
    {
        public async Task<bool> TestConnectionAsync(Account account)
        {
            try
            {
                // For now, just return true for Outlook accounts
                // In a real implementation, you would implement OAuth2 flow
                return await Task.FromResult(true);
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<EmailMessage>> ReceiveEmailsAsync(Account account, EmailFolder folder = EmailFolder.Inbox)
        {
            try
            {
                // For now, return empty list for Graph provider
                // In a real implementation, you would use Microsoft Graph API
                return await Task.FromResult(new List<EmailMessage>());
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to receive emails: {ex.Message}", ex);
            }
        }

        public async Task<bool> SendEmailAsync(Account account, EmailMessage email)
        {
            try
            {
                // For now, just simulate success
                // In a real implementation, you would use Microsoft Graph API
                await Task.Delay(500); // Simulate API call
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send email: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteEmailAsync(Account account, EmailMessage email)
        {
            try
            {
                await Task.Delay(1); // Placeholder
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> MoveEmailAsync(Account account, EmailMessage email, EmailFolder targetFolder)
        {
            try
            {
                await Task.Delay(1); // Placeholder
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public class ImapSmtpProvider : IEmailProvider
    {
        public async Task<bool> TestConnectionAsync(Account account)
        {
            try
            {
                // Test IMAP connection
                using var client = new ImapClient();
                await client.ConnectAsync(account.IncomingServer.Server, account.IncomingServer.Port, 
                    account.IncomingServer.UseSSL ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(account.IncomingServer.Username, account.IncomingServer.Password);
                await client.DisconnectAsync(true);

                // Test SMTP connection
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(account.OutgoingServer.Server, account.OutgoingServer.Port,
                    account.OutgoingServer.UseSSL ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(account.OutgoingServer.Username, account.OutgoingServer.Password);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<EmailMessage>> ReceiveEmailsAsync(Account account, EmailFolder folder = EmailFolder.Inbox)
        {
            var emails = new List<EmailMessage>();

            try
            {
                using var client = new ImapClient();
                await client.ConnectAsync(account.IncomingServer.Server, account.IncomingServer.Port,
                    account.IncomingServer.UseSSL ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(account.IncomingServer.Username, account.IncomingServer.Password);

                var folderName = GetImapFolderName(folder);
                var mailFolder = await client.GetFolderAsync(folderName);
                await mailFolder.OpenAsync(MailKit.FolderAccess.ReadOnly);

                var messageCount = Math.Min(20, mailFolder.Count); // Limit to 20 messages for simplicity
                if (messageCount > 0)
                {
                    var startIndex = Math.Max(0, mailFolder.Count - messageCount);
                    
                    var id = 1;
                    for (int i = mailFolder.Count - 1; i >= startIndex && id <= messageCount; i--, id++)
                    {
                        try
                        {
                            var message = await mailFolder.GetMessageAsync(i);
                            
                            var emailMessage = new EmailMessage
                            {
                                Id = id,
                                Subject = message.Subject ?? "",
                                From = message.From.FirstOrDefault()?.ToString() ?? "",
                                To = string.Join("; ", message.To.Select(t => t.ToString())),
                                Body = message.TextBody ?? message.HtmlBody ?? "",
                                DateReceived = message.Date.DateTime,
                                DateSent = message.Date.DateTime,
                                IsRead = true, // Default to read for now
                                IsImportant = false, // Default for now
                                HasAttachments = message.Attachments.Any(),
                                Folder = folder
                            };

                            emails.Add(emailMessage);
                        }
                        catch
                        {
                            // Skip messages that can't be fetched
                            continue;
                        }
                    }
                }

                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to receive emails: {ex.Message}", ex);
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
                await client.ConnectAsync(account.OutgoingServer.Server, account.OutgoingServer.Port,
                    account.OutgoingServer.UseSSL ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(account.OutgoingServer.Username, account.OutgoingServer.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send email: {ex.Message}", ex);
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

        private void AddRecipients(InternetAddressList list, string addresses)
        {
            if (string.IsNullOrWhiteSpace(addresses)) return;

            var emails = addresses.Split(';', ',').Where(e => !string.IsNullOrWhiteSpace(e));
            foreach (var email in emails)
            {
                try
                {
                    list.Add(new MailboxAddress("", email.Trim()));
                }
                catch
                {
                    // Skip invalid email addresses
                }
            }
        }
    }
}