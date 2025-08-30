using Mail.Models;
using Mail.Services;

namespace Mail.Forms
{
    public partial class AccountForm : Form
    {
        private AccountService _accountService;
        private Account? _account;
        private bool _isEditing;

        public AccountForm(AccountService accountService, Account? account = null)
        {
            InitializeComponent();
            _accountService = accountService;
            _account = account;
            _isEditing = account != null;
            
            SetupForm();
            if (_isEditing)
            {
                PopulateFields();
            }
        }

        private void SetupForm()
        {
            this.Text = _isEditing ? "Edit Account" : "Add Account";
            
            // Populate account type combo box
            accountTypeComboBox.Items.Clear();
            foreach (AccountType type in Enum.GetValues<AccountType>())
            {
                accountTypeComboBox.Items.Add(type);
            }
            accountTypeComboBox.SelectedIndex = 0;

            // Populate authentication type combo boxes
            incomingAuthComboBox.Items.Clear();
            outgoingAuthComboBox.Items.Clear();
            foreach (AuthenticationType type in Enum.GetValues<AuthenticationType>())
            {
                incomingAuthComboBox.Items.Add(type);
                outgoingAuthComboBox.Items.Add(type);
            }
            incomingAuthComboBox.SelectedIndex = 0;
            outgoingAuthComboBox.SelectedIndex = 0;
        }

        private void PopulateFields()
        {
            if (_account == null) return;

            accountNameTextBox.Text = _account.Name;
            emailAddressTextBox.Text = _account.EmailAddress;
            displayNameTextBox.Text = _account.DisplayName;
            accountTypeComboBox.SelectedItem = _account.Type;
            isDefaultCheckBox.Checked = _account.IsDefault;
            isEnabledCheckBox.Checked = _account.IsEnabled;

            // Incoming server settings
            incomingServerTextBox.Text = _account.IncomingServer.Server;
            incomingPortNumeric.Value = _account.IncomingServer.Port;
            incomingUsernameTextBox.Text = _account.IncomingServer.Username;
            incomingPasswordTextBox.Text = _account.IncomingServer.Password;
            incomingSSLCheckBox.Checked = _account.IncomingServer.UseSSL;
            incomingAuthComboBox.SelectedItem = _account.IncomingServer.Authentication;

            // Outgoing server settings
            outgoingServerTextBox.Text = _account.OutgoingServer.Server;
            outgoingPortNumeric.Value = _account.OutgoingServer.Port;
            outgoingUsernameTextBox.Text = _account.OutgoingServer.Username;
            outgoingPasswordTextBox.Text = _account.OutgoingServer.Password;
            outgoingSSLCheckBox.Checked = _account.OutgoingServer.UseSSL;
            outgoingAuthComboBox.SelectedItem = _account.OutgoingServer.Authentication;
        }

        private void OkButton_Click(object? sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var account = _account ?? new Account();
                
                account.Name = accountNameTextBox.Text;
                account.EmailAddress = emailAddressTextBox.Text;
                account.DisplayName = displayNameTextBox.Text;
                account.Type = (AccountType)accountTypeComboBox.SelectedItem!;
                account.IsDefault = isDefaultCheckBox.Checked;
                account.IsEnabled = isEnabledCheckBox.Checked;

                account.IncomingServer.Server = incomingServerTextBox.Text;
                account.IncomingServer.Port = (int)incomingPortNumeric.Value;
                account.IncomingServer.Username = incomingUsernameTextBox.Text;
                account.IncomingServer.Password = incomingPasswordTextBox.Text;
                account.IncomingServer.UseSSL = incomingSSLCheckBox.Checked;
                account.IncomingServer.Authentication = (AuthenticationType)incomingAuthComboBox.SelectedItem!;

                account.OutgoingServer.Server = outgoingServerTextBox.Text;
                account.OutgoingServer.Port = (int)outgoingPortNumeric.Value;
                account.OutgoingServer.Username = outgoingUsernameTextBox.Text;
                account.OutgoingServer.Password = outgoingPasswordTextBox.Text;
                account.OutgoingServer.UseSSL = outgoingSSLCheckBox.Checked;
                account.OutgoingServer.Authentication = (AuthenticationType)outgoingAuthComboBox.SelectedItem!;

                if (_isEditing)
                {
                    _accountService.UpdateAccount(account);
                }
                else
                {
                    _accountService.AddAccount(account);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(accountNameTextBox.Text))
            {
                MessageBox.Show("Please enter an account name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                accountNameTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(emailAddressTextBox.Text))
            {
                MessageBox.Show("Please enter an email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailAddressTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(displayNameTextBox.Text))
            {
                MessageBox.Show("Please enter a display name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                displayNameTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(incomingServerTextBox.Text))
            {
                MessageBox.Show("Please enter an incoming server.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                incomingServerTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(outgoingServerTextBox.Text))
            {
                MessageBox.Show("Please enter an outgoing server.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                outgoingServerTextBox.Focus();
                return false;
            }

            return true;
        }

        private void TestConnectionButton_Click(object? sender, EventArgs e)
        {
            var tempAccount = new Account
            {
                EmailAddress = emailAddressTextBox.Text,
                IncomingServer = new ServerSettings
                {
                    Server = incomingServerTextBox.Text,
                    Port = (int)incomingPortNumeric.Value,
                    Username = incomingUsernameTextBox.Text,
                    Password = incomingPasswordTextBox.Text,
                    UseSSL = incomingSSLCheckBox.Checked,
                    Authentication = (AuthenticationType)incomingAuthComboBox.SelectedItem!
                },
                OutgoingServer = new ServerSettings
                {
                    Server = outgoingServerTextBox.Text,
                    Port = (int)outgoingPortNumeric.Value,
                    Username = outgoingUsernameTextBox.Text,
                    Password = outgoingPasswordTextBox.Text,
                    UseSSL = outgoingSSLCheckBox.Checked,
                    Authentication = (AuthenticationType)outgoingAuthComboBox.SelectedItem!
                }
            };

            var isConnected = _accountService.TestConnection(tempAccount);
            var message = isConnected ? "Connection test successful!" : "Connection test failed!";
            var icon = isConnected ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            
            MessageBox.Show(message, "Connection Test", MessageBoxButtons.OK, icon);
        }
    }
}