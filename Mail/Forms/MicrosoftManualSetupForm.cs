using Mail.Models;
using System.Diagnostics;

namespace Mail.Forms
{
    public partial class MicrosoftManualSetupForm : Form
    {
        private Account _account;
        private TextBox passwordTextBox;
        private Label instructionLabel;
        private Button okButton;
        private Button cancelButton;
        private LinkLabel linkLabel;

        public MicrosoftManualSetupForm(Account account)
        {
            _account = account;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(550, 350);
            this.Text = "Microsoft Account Manual Setup";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            instructionLabel = new Label
            {
                Text = $"Setting up: {_account.EmailAddress}\n\n" +
                       "Microsoft accounts require special authentication. You have two options:\n\n" +
                       "OPTION 1 - App Password (Recommended):\n" +
                       "1. Go to account.microsoft.com ? Security\n" +
                       "2. Enable 2-factor authentication if not enabled\n" +
                       "3. Go to 'Advanced security options'\n" +
                       "4. Click 'App passwords' ? 'Create new app password'\n" +
                       "5. Enter the generated app password below\n\n" +
                       "OPTION 2 - Regular Password:\n" +
                       "Use your regular Microsoft account password (less secure)\n\n" +
                       "Enter your password or app password:",
                Location = new Point(15, 15),
                Size = new Size(510, 200),
                AutoSize = false
            };

            linkLabel = new LinkLabel
            {
                Text = "Open Microsoft Account Security Settings",
                Location = new Point(15, 220),
                Size = new Size(300, 20),
                TabStop = true
            };
            linkLabel.Click += (s, e) => {
                try
                {
                    Process.Start(new ProcessStartInfo("https://account.microsoft.com/security") { UseShellExecute = true });
                }
                catch { }
            };

            passwordTextBox = new TextBox
            {
                Location = new Point(15, 250),
                Size = new Size(510, 23),
                UseSystemPasswordChar = true,
                PlaceholderText = "Enter your Microsoft password or app password"
            };

            okButton = new Button
            {
                Text = "Set Up Account",
                Location = new Point(370, 285),
                Size = new Size(75, 23),
                DialogResult = DialogResult.OK
            };
            okButton.Click += OkButton_Click;

            cancelButton = new Button
            {
                Text = "Cancel",
                Location = new Point(450, 285),
                Size = new Size(75, 23),
                DialogResult = DialogResult.Cancel
            };

            this.Controls.AddRange(new Control[] { instructionLabel, linkLabel, passwordTextBox, okButton, cancelButton });
            this.AcceptButton = okButton;
            this.CancelButton = cancelButton;
        }

        private void OkButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Please enter your Microsoft password or app password.", "Password Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passwordTextBox.Focus();
                return;
            }

            // Configure the account with correct Microsoft IMAP/SMTP settings
            _account.Type = AccountType.Outlook;
            _account.IncomingServer = new ServerSettings
            {
                Server = "outlook.office365.com",
                Port = 993,
                UseSSL = true,
                Username = _account.EmailAddress,
                Password = passwordTextBox.Text,
                Authentication = AuthenticationType.Password // Use password auth, not OAuth2
            };
            _account.OutgoingServer = new ServerSettings
            {
                Server = "smtp.office365.com",
                Port = 587,
                UseSSL = true,
                Username = _account.EmailAddress,
                Password = passwordTextBox.Text,
                Authentication = AuthenticationType.Password
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}