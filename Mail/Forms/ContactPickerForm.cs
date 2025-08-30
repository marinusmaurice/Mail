using Mail.Models;
using Mail.Services;

namespace Mail.Forms
{
    public partial class ContactPickerForm : Form
    {
        private ContactService _contactService;
        private List<Contact> _selectedContacts = new List<Contact>();

        public List<Contact> SelectedContacts => _selectedContacts;

        public ContactPickerForm(ContactService contactService)
        {
            InitializeComponent();
            _contactService = contactService;
            LoadContacts();
        }

        private void LoadContacts()
        {
            contactsListView.Items.Clear();
            var contacts = _contactService.GetAllContacts();

            foreach (var contact in contacts)
            {
                var item = new ListViewItem();
                item.Tag = contact;
                item.Text = contact.DisplayName;
                item.SubItems.Add(contact.EmailAddress);
                item.SubItems.Add(contact.Company);
                
                contactsListView.Items.Add(item);
            }
        }

        private void SearchTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                LoadContacts();
                return;
            }

            var filteredContacts = _contactService.SearchContacts(searchTextBox.Text);
            contactsListView.Items.Clear();

            foreach (var contact in filteredContacts)
            {
                var item = new ListViewItem();
                item.Tag = contact;
                item.Text = contact.DisplayName;
                item.SubItems.Add(contact.EmailAddress);
                item.SubItems.Add(contact.Company);
                
                contactsListView.Items.Add(item);
            }
        }

        private void OkButton_Click(object? sender, EventArgs e)
        {
            _selectedContacts.Clear();
            
            foreach (ListViewItem item in contactsListView.CheckedItems)
            {
                if (item.Tag is Contact contact)
                {
                    _selectedContacts.Add(contact);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SelectAllButton_Click(object? sender, EventArgs e)
        {
            foreach (ListViewItem item in contactsListView.Items)
            {
                item.Checked = true;
            }
        }

        private void ClearAllButton_Click(object? sender, EventArgs e)
        {
            foreach (ListViewItem item in contactsListView.Items)
            {
                item.Checked = false;
            }
        }
    }
}