using Mail.Models;
using Mail.Services;

namespace Mail.Forms
{
    public partial class QuickSetupForm : Form
    {
        private AccountService _accountService;

        public QuickSetupForm(AccountService accountService)
        {
            InitializeComponent();
            _accountService = accountService;
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Quick Email Setup";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Auto-detect account type when email changes
            emailTextBox.TextChanged += EmailTextBox_TextChanged;
        }

        private void EmailTextBox_TextChanged(object? sender, EventArgs e)
        {
            var email = emailTextBox.Text.ToLower();
            var domain = email.Split('@').LastOrDefault();

            if (!string.IsNullOrEmpty(domain))
            {
                var detectedType = domain switch
                {
                    "outlook.com" or "hotmail.com" or "live.com" or "msn.com" => "Outlook.com",
                    "gmail.com" or "googlemail.com" => "Gmail",
                    "yahoo.com" or "yahoo.co.uk" or "yahoo.ca" => "Yahoo Mail",
                    _ when domain.Contains("outlook") => "Exchange Server",
                    _ => "Other (IMAP/SMTP)"
                };

                detectedTypeLabel.Text = $"Detected: {detectedType}";
                detectedTypeLabel.Visible = true;

                // Show OAuth info for Outlook
                if (domain.Contains("outlook") || domain.Contains("hotmail") || domain.Contains("live") || domain.Contains("msn"))
                {
                    oauthInfoLabel.Text = "Note: Outlook accounts use secure OAuth2 authentication. You'll be redirected to Microsoft's login page.";
                    oauthInfoLabel.Visible = true;
                    passwordTextBox.Enabled = false;
                    passwordLabel.Text = "Password: (OAuth2 - will be handled automatically)";
                }
                else
                {
                    oauthInfoLabel.Visible = false;
                    passwordTextBox.Enabled = true;
                    passwordLabel.Text = "Password:";
                }
            }
            else
            {
                detectedTypeLabel.Visible = false;
                oauthInfoLabel.Visible = false;
                passwordTextBox.Enabled = true;
                passwordLabel.Text = "Password:";
            }
        }

        private async void SetupButton_Click(object? sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            setupButton.Enabled = false;
            progressLabel.Text = "Setting up account...";
            progressLabel.Visible = true;

            try
            {
                var account = new Account
                {
                    Name = string.IsNullOrWhiteSpace(nameTextBox.Text) ? emailTextBox.Text : nameTextBox.Text,
                    EmailAddress = emailTextBox.Text,
                    DisplayName = displayNameTextBox.Text
                };

                // Apply quick setup
                _accountService.ApplyQuickSetup(account, emailTextBox.Text, passwordTextBox.Text);

                progressLabel.Text = "Testing connection...";
                Application.DoEvents();

                // Test the connection
                var connectionSuccess = await _accountService.TestConnectionAsync(account);

                if (connectionSuccess)
                {
                    _accountService.AddAccount(account);
                    progressLabel.Text = "Account setup complete!";
                    
                    MessageBox.Show("Email account configured successfully!", "Setup Complete", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    progressLabel.Text = "Connection failed. Please check your settings.";
                    
                    var result = MessageBox.Show(
                        "Could not connect to the email server. Would you like to configure advanced settings manually?",
                        "Connection Failed",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Open advanced account form
                        var accountForm = new AccountForm(_accountService, account);
                        if (accountForm.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                progressLabel.Text = "Setup failed.";
                MessageBox.Show($"Failed to set up email account: {ex.Message}", "Setup Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                setupButton.Enabled = true;
                progressLabel.Visible = false;
            }
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AdvancedButton_Click(object? sender, EventArgs e)
        {
            var accountForm = new AccountForm(_accountService);
            if (accountForm.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Please enter your email address.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailTextBox.Focus();
                return false;
            }

            if (!IsValidEmail(emailTextBox.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(displayNameTextBox.Text))
            {
                MessageBox.Show("Please enter your display name.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                displayNameTextBox.Focus();
                return false;
            }

            // For non-OAuth accounts, password is required
            var domain = emailTextBox.Text.Split('@').LastOrDefault()?.ToLower();
            var isOAuth = domain?.Contains("outlook") == true || domain?.Contains("hotmail") == true || 
                         domain?.Contains("live") == true || domain?.Contains("msn") == true;

            if (!isOAuth && string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Please enter your password.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passwordTextBox.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}