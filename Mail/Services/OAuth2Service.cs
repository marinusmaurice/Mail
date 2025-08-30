using Mail.Models;
using Mail.Forms;
using Microsoft.Identity.Client;
using System.Diagnostics;

namespace Mail.Services
{
    public interface IOAuth2Service
    {
        Task<bool> AuthenticateAsync(Account account);
        Task<string?> GetAccessTokenAsync(Account account);
        bool IsOAuth2Account(Account account);
    }

    public class MicrosoftOAuth2Service : IOAuth2Service
    {
        // For a real implementation, you would register your app with Microsoft and get these IDs
        private const string ClientId = "your-app-client-id-here";
        private const string TenantId = "common";
        private readonly string[] Scopes = { "https://outlook.office.com/IMAP.AccessAsUser.All", "https://outlook.office.com/SMTP.Send" };

        public bool IsOAuth2Account(Account account)
        {
            return account.IncomingServer.Authentication == AuthenticationType.OAuth2 ||
                   account.OutgoingServer.Authentication == AuthenticationType.OAuth2;
        }

        public async Task<bool> AuthenticateAsync(Account account)
        {
            try
            {
                // For demo purposes, show information about OAuth2 setup
                var result = MessageBox.Show(
                    "Microsoft Account Authentication\n\n" +
                    "Microsoft accounts can be set up in two ways:\n\n" +
                    "1. OAuth2 (Recommended but requires app registration)\n" +
                    "2. App Password (Simpler for personal use)\n\n" +
                    "Would you like to use the App Password method?\n\n" +
                    "• Yes: Use app password setup (recommended)\n" +
                    "• No: Cancel setup",
                    "Microsoft Account Setup",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    // Launch manual setup form
                    var manualForm = new MicrosoftManualSetupForm(account);
                    return manualForm.ShowDialog() == DialogResult.OK;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Microsoft account setup failed: {ex.Message}", "Setup Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<string?> GetAccessTokenAsync(Account account)
        {
            // In a real implementation, this would:
            // 1. Check if we have a valid cached token
            // 2. If not, refresh using refresh token
            // 3. If refresh fails, re-authenticate
            
            // For demo, return a placeholder
            await Task.Delay(100);
            return "oauth2_access_token_placeholder";
        }

        // Method to open browser for OAuth2 (for future implementation)
        private void OpenBrowser(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open browser: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}