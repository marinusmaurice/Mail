using Mail.Models;
using Mail.Services;

namespace Mail.Tests
{
    /// <summary>
    /// Test class for verifying Gmail configuration
    /// </summary>
    public class GmailConfigTest
    {
        private AccountService _accountService;

        public GmailConfigTest()
        {
            _accountService = new AccountService();
        }

        /// <summary>
        /// Test Gmail Configuration - Verifies that Gmail settings are properly configured
        /// </summary>
        public void TestGmailConfiguration()
        {
            var testAccount = new Account
            {
                EmailAddress = "test@gmail.com",
                Type = AccountType.Gmail
            };

            // Apply Gmail settings
            _accountService.ApplyQuickSetup(testAccount, "test@gmail.com", "dummy_password");

            // Verify Gmail configuration
            System.Diagnostics.Debug.WriteLine($"Gmail Configuration Test:");
            System.Diagnostics.Debug.WriteLine($"Account Type: {testAccount.Type}");
            System.Diagnostics.Debug.WriteLine($"IMAP Server: {testAccount.IncomingServer.Server}:{testAccount.IncomingServer.Port}");
            System.Diagnostics.Debug.WriteLine($"IMAP SSL: {testAccount.IncomingServer.UseSSL}");
            System.Diagnostics.Debug.WriteLine($"SMTP Server: {testAccount.OutgoingServer.Server}:{testAccount.OutgoingServer.Port}");
            System.Diagnostics.Debug.WriteLine($"SMTP SSL: {testAccount.OutgoingServer.UseSSL}");
            System.Diagnostics.Debug.WriteLine($"Username: {testAccount.IncomingServer.Username}");
            
            // Expected output:
            // Account Type: Gmail
            // IMAP Server: imap.gmail.com:993
            // IMAP SSL: True
            // SMTP Server: smtp.gmail.com:587
            // SMTP SSL: True
            // Username: test@gmail.com

            // Verify the configuration is correct
            VerifyGmailSettings(testAccount);
        }

        private void VerifyGmailSettings(Account account)
        {
            System.Diagnostics.Debug.WriteLine("Verifying Gmail settings...");
            
            // Check IMAP settings
            if (account.IncomingServer.Server == "imap.gmail.com" && 
                account.IncomingServer.Port == 993 && 
                account.IncomingServer.UseSSL)
            {
                System.Diagnostics.Debug.WriteLine("? IMAP settings correct");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("? IMAP settings incorrect");
            }

            // Check SMTP settings
            if (account.OutgoingServer.Server == "smtp.gmail.com" && 
                account.OutgoingServer.Port == 587 && 
                account.OutgoingServer.UseSSL)
            {
                System.Diagnostics.Debug.WriteLine("? SMTP settings correct");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("? SMTP settings incorrect");
            }

            // Check authentication
            if (account.IncomingServer.Authentication == AuthenticationType.Password &&
                account.OutgoingServer.Authentication == AuthenticationType.Password)
            {
                System.Diagnostics.Debug.WriteLine("? Authentication type correct");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("? Authentication type incorrect");
            }
        }

        /// <summary>
        /// Run all Gmail configuration tests
        /// </summary>
        public static void RunTests()
        {
            var test = new GmailConfigTest();
            test.TestGmailConfiguration();
        }
    }
}