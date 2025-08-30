using System;
using System.Collections.Generic;

namespace Mail.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public AccountType Type { get; set; }
        public ServerSettings IncomingServer { get; set; } = new ServerSettings();
        public ServerSettings OutgoingServer { get; set; } = new ServerSettings();
        public bool IsDefault { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime LastSync { get; set; }
    }

    public class ServerSettings
    {
        public string Server { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool UseSSL { get; set; } = true;
        public AuthenticationType Authentication { get; set; } = AuthenticationType.Password;
    }

    public enum AccountType
    {
        Exchange,
        IMAP,
        POP3,
        Outlook,
        Gmail,
        Yahoo,
        Other
    }

    public enum AuthenticationType
    {
        Password,
        OAuth2,
        NTLM,
        Kerberos
    }
}