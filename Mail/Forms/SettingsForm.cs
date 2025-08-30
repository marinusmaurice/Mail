using Mail.Models;
using Mail.Services;

namespace Mail.Forms
{
    public partial class SettingsForm : Form
    {
        private AccountService _accountService;

        public SettingsForm(AccountService accountService)
        {
            InitializeComponent();
            _accountService = accountService;
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            accountsListView.Items.Clear();
            var accounts = _accountService.GetAllAccounts();

            foreach (var account in accounts)
            {
                var item = new ListViewItem();
                item.Tag = account;
                item.Text = account.Name;
                item.SubItems.Add(account.EmailAddress);
                item.SubItems.Add(account.Type.ToString());
                item.SubItems.Add(account.IsDefault ? "Yes" : "No");
                item.SubItems.Add(account.IsEnabled ? "Enabled" : "Disabled");
                
                accountsListView.Items.Add(item);
            }
        }

        private void AddAccountButton_Click(object? sender, EventArgs e)
        {
            var accountForm = new AccountForm(_accountService);
            if (accountForm.ShowDialog() == DialogResult.OK)
            {
                LoadAccounts();
            }
        }

        private void EditAccountButton_Click(object? sender, EventArgs e)
        {
            if (accountsListView.SelectedItems.Count > 0)
            {
                var selectedAccount = accountsListView.SelectedItems[0].Tag as Account;
                if (selectedAccount != null)
                {
                    var accountForm = new AccountForm(_accountService, selectedAccount);
                    if (accountForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadAccounts();
                    }
                }
            }
        }

        private void DeleteAccountButton_Click(object? sender, EventArgs e)
        {
            if (accountsListView.SelectedItems.Count > 0)
            {
                var selectedAccount = accountsListView.SelectedItems[0].Tag as Account;
                if (selectedAccount != null)
                {
                    var result = MessageBox.Show(
                        $"Are you sure you want to delete the account '{selectedAccount.Name}'?",
                        "Delete Account",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        _accountService.DeleteAccount(selectedAccount);
                        LoadAccounts();
                    }
                }
            }
        }

        private void SetDefaultButton_Click(object? sender, EventArgs e)
        {
            if (accountsListView.SelectedItems.Count > 0)
            {
                var selectedAccount = accountsListView.SelectedItems[0].Tag as Account;
                if (selectedAccount != null)
                {
                    _accountService.SetDefaultAccount(selectedAccount);
                    LoadAccounts();
                }
            }
        }

        private void TestConnectionButton_Click(object? sender, EventArgs e)
        {
            if (accountsListView.SelectedItems.Count > 0)
            {
                var selectedAccount = accountsListView.SelectedItems[0].Tag as Account;
                if (selectedAccount != null)
                {
                    var isConnected = _accountService.TestConnection(selectedAccount);
                    var message = isConnected ? "Connection successful!" : "Connection failed!";
                    var icon = isConnected ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                    
                    MessageBox.Show(message, "Connection Test", MessageBoxButtons.OK, icon);
                }
            }
        }

        private void CloseButton_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}