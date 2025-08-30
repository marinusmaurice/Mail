using Mail.Models;
using Mail.Services;

namespace Mail.Forms
{
    public partial class QuickSetupForm : Form
    {
        private AccountService _accountService;
        private MicrosoftOAuth2Service _oauthService;

        public QuickSetupForm(AccountService accountService)
        {
            InitializeComponent();
            _accountService = accountService;
            _oauthService = new MicrosoftOAuth2Service();
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

                // Show different setup options based on provider
                if (domain.Contains("outlook") || domain.Contains("hotmail") || domain.Contains("live") || domain.Contains("msn"))
                {
                    oauthInfoLabel.Text = "Note: Microsoft accounts require special authentication. Click 'Set Up' for guided setup.";
                    oauthInfoLabel.Visible = true;
                    passwordTextBox.Enabled = false;
                    passwordTextBox.Text = "";
                    passwordLabel.Text = "Password: (Will be handled during setup)";
                }
                else if (domain.Contains("gmail") || domain.Contains("googlemail"))
                {
                    oauthInfoLabel.Text = "Note: Gmail requires an App Password for security. Use your Gmail App Password, not your regular password.";
                    oauthInfoLabel.Visible = true;
                    passwordTextBox.Enabled = true;
                    passwordLabel.Text = "App Password: (Generate at myaccount.google.com/security)";
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

                var domain = emailTextBox.Text.Split('@').LastOrDefault()?.ToLower();
                var isMicrosoftAccount = domain?.Contains("outlook") == true || domain?.Contains("hotmail") == true || 
                                       domain?.Contains("live") == true || domain?.Contains("msn") == true;

                if (isMicrosoftAccount)
                {
                    // Handle Microsoft account setup
                    progressLabel.Text = "Setting up Microsoft account...";
                    Application.DoEvents();

                    var success = await _oauthService.AuthenticateAsync(account);
                    if (success)
                    {
                        // Test the connection
                        progressLabel.Text = "Testing connection...";
                        var connectionSuccess = await _accountService.TestConnectionAsync(account);
                        
                        if (connectionSuccess)
                        {
                            _accountService.AddAccount(account);
                            progressLabel.Text = "Microsoft account setup complete!";
                            
                            MessageBox.Show("Microsoft account configured successfully!", "Setup Complete", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            progressLabel.Text = "Connection failed.";
                            MessageBox.Show("Account configured but connection test failed. Please check your credentials.", 
                                "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        progressLabel.Text = "Setup cancelled.";
                    }
                }
                else
                {
                    // Handle regular IMAP/SMTP setup
                    _accountService.ApplyQuickSetup(account, emailTextBox.Text, passwordTextBox.Text);

                    progressLabel.Text = "Testing connection...";
                    Application.DoEvents();

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
                            var accountForm = new AccountForm(_accountService, account);
                            if (accountForm.ShowDialog() == DialogResult.OK)
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
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

            // Check if password is needed
            var domain = emailTextBox.Text.Split('@').LastOrDefault()?.ToLower();
            var isMicrosoftAccount = domain?.Contains("outlook") == true || domain?.Contains("hotmail") == true || 
                                   domain?.Contains("live") == true || domain?.Contains("msn") == true;

            // For non-Microsoft accounts, password is required
            if (!isMicrosoftAccount && string.IsNullOrWhiteSpace(passwordTextBox.Text))
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