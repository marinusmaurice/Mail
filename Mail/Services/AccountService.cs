using Mail.Models;
using Mail.Services;

namespace Mail.Services
{
    public class AccountService
    {
        private List<Account> _accounts = new List<Account>();
        private int _nextId = 1;

        public event EventHandler<Account>? AccountAdded;
        public event EventHandler<Account>? AccountUpdated;
        public event EventHandler<Account>? AccountDeleted;

        public AccountService()
        {
            InitializeSampleData();
        }

        public List<Account> GetAllAccounts()
        {
            return _accounts.ToList();
        }

        public Account? GetDefaultAccount()
        {
            return _accounts.FirstOrDefault(a => a.IsDefault);
        }

        public Account? GetAccountById(int id)
        {
            return _accounts.FirstOrDefault(a => a.Id == id);
        }

        public void AddAccount(Account account)
        {
            account.Id = _nextId++;
            
            // If this is the first account, make it default
            if (!_accounts.Any())
            {
                account.IsDefault = true;
            }
            
            // Set default server settings based on account type
            SetDefaultServerSettings(account);
            
            _accounts.Add(account);
            AccountAdded?.Invoke(this, account);
        }

        public void UpdateAccount(Account account)
        {
            var existingAccount = GetAccountById(account.Id);
            if (existingAccount != null)
            {
                var index = _accounts.IndexOf(existingAccount);
                _accounts[index] = account;
                AccountUpdated?.Invoke(this, account);
            }
        }

        public void DeleteAccount(Account account)
        {
            _accounts.Remove(account);
            
            // If we deleted the default account, make another one default
            if (account.IsDefault && _accounts.Any())
            {
                _accounts.First().IsDefault = true;
            }
            
            AccountDeleted?.Invoke(this, account);
        }

        public void SetDefaultAccount(Account account)
        {
            // Remove default from all accounts
            foreach (var acc in _accounts)
            {
                acc.IsDefault = false;
            }
            
            // Set new default
            account.IsDefault = true;
        }

        public async Task<bool> TestConnectionAsync(Account account)
        {
            try
            {
                var emailService = new EmailService(this);
                return await emailService.TestAccountConnectionAsync(account);
            }
            catch
            {
                return false;
            }
        }

        public bool TestConnection(Account account)
        {
            // Synchronous wrapper for backward compatibility
            return Task.Run(async () => await TestConnectionAsync(account)).Result;
        }

        private void SetDefaultServerSettings(Account account)
        {
            switch (account.Type)
            {
                case AccountType.Outlook:
                case AccountType.Exchange:
                    // Modern Outlook uses OAuth2 with Graph API
                    account.IncomingServer = new ServerSettings
                    {
                        Server = "outlook.office365.com",
                        Port = 993,
                        UseSSL = true,
                        Authentication = AuthenticationType.OAuth2
                    };
                    account.OutgoingServer = new ServerSettings
                    {
                        Server = "smtp.office365.com",
                        Port = 587,
                        UseSSL = true,
                        Authentication = AuthenticationType.OAuth2
                    };
                    break;

                case AccountType.Gmail:
                    account.IncomingServer = new ServerSettings
                    {
                        Server = "imap.gmail.com",
                        Port = 993,
                        UseSSL = true,
                        Authentication = AuthenticationType.Password
                    };
                    account.OutgoingServer = new ServerSettings
                    {
                        Server = "smtp.gmail.com",
                        Port = 587,
                        UseSSL = true,
                        Authentication = AuthenticationType.Password
                    };
                    break;

                case AccountType.Yahoo:
                    account.IncomingServer = new ServerSettings
                    {
                        Server = "imap.mail.yahoo.com",
                        Port = 993,
                        UseSSL = true,
                        Authentication = AuthenticationType.Password
                    };
                    account.OutgoingServer = new ServerSettings
                    {
                        Server = "smtp.mail.yahoo.com",
                        Port = 587,
                        UseSSL = true,
                        Authentication = AuthenticationType.Password
                    };
                    break;

                case AccountType.IMAP:
                    // Generic IMAP defaults
                    account.IncomingServer = new ServerSettings
                    {
                        Port = 993,
                        UseSSL = true,
                        Authentication = AuthenticationType.Password
                    };
                    account.OutgoingServer = new ServerSettings
                    {
                        Port = 587,
                        UseSSL = true,
                        Authentication = AuthenticationType.Password
                    };
                    break;

                case AccountType.POP3:
                    account.IncomingServer = new ServerSettings
                    {
                        Port = 995,
                        UseSSL = true,
                        Authentication = AuthenticationType.Password
                    };
                    account.OutgoingServer = new ServerSettings
                    {
                        Port = 587,
                        UseSSL = true,
                        Authentication = AuthenticationType.Password
                    };
                    break;
            }

            // Set username to email address if not specified
            if (string.IsNullOrEmpty(account.IncomingServer.Username))
            {
                account.IncomingServer.Username = account.EmailAddress;
            }
            if (string.IsNullOrEmpty(account.OutgoingServer.Username))
            {
                account.OutgoingServer.Username = account.EmailAddress;
            }
        }

        public void ApplyQuickSetup(Account account, string emailAddress, string password)
        {
            account.EmailAddress = emailAddress;
            account.IncomingServer.Username = emailAddress;
            account.IncomingServer.Password = password;
            account.OutgoingServer.Username = emailAddress;
            account.OutgoingServer.Password = password;

            // Auto-detect provider based on email domain
            var domain = emailAddress.Split('@').LastOrDefault()?.ToLower();
            account.Type = domain switch
            {
                "outlook.com" or "hotmail.com" or "live.com" or "msn.com" => AccountType.Outlook,
                "gmail.com" or "googlemail.com" => AccountType.Gmail,
                "yahoo.com" or "yahoo.co.uk" or "yahoo.ca" => AccountType.Yahoo,
                _ when domain?.Contains("outlook") == true => AccountType.Exchange,
                _ => AccountType.IMAP
            };

            // Apply default settings for the detected type
            SetDefaultServerSettings(account);
        }

        private void InitializeSampleData()
        {
            // Don't add any default accounts - let user configure their own
            // This encourages proper setup of real email accounts
        }
    }
}