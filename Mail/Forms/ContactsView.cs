using Mail.Models;
using Mail.Services;
using System.ComponentModel;

namespace Mail.Forms
{
    public partial class ContactsView : UserControl
    {
        private ContactService? _contactService;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContactService? ContactService
        {
            get => _contactService;
            set
            {
                _contactService = value;
                RefreshContacts();
            }
        }

        public ContactsView()
        {
            InitializeComponent();
        }

        public ContactsView(ContactService contactService) : this()
        {
            _contactService = contactService;
            RefreshContacts();
        }

        private void RefreshContacts()
        {
            if (_contactService == null) return;

            contactsListView.Items.Clear();
            var contacts = _contactService.GetAllContacts();

            foreach (var contact in contacts.OrderBy(c => c.LastName).ThenBy(c => c.FirstName))
            {
                var item = new ListViewItem();
                item.Tag = contact;
                
                item.Text = contact.DisplayName;
                item.SubItems.Add(contact.EmailAddress);
                item.SubItems.Add(contact.Company);
                item.SubItems.Add(contact.JobTitle);
                item.SubItems.Add(contact.PhoneNumber);

                // Highlight favorites
                if (contact.IsFavorite)
                {
                    item.Font = new Font(contactsListView.Font, FontStyle.Bold);
                    item.ForeColor = Color.Blue;
                }

                contactsListView.Items.Add(item);
            }

            // Update contact groups
            RefreshContactGroups();
        }

        private void RefreshContactGroups()
        {
            if (_contactService == null) return;

            groupsListView.Items.Clear();
            var groups = _contactService.GetAllContactGroups();

            foreach (var group in groups.OrderBy(g => g.Name))
            {
                var item = new ListViewItem();
                item.Tag = group;
                
                item.Text = group.Name;
                item.SubItems.Add(group.Members.Count.ToString());
                item.SubItems.Add(group.Description);

                groupsListView.Items.Add(item);
            }
        }

        private void DisplayContactDetails(Contact contact)
        {
            contactDetailsPanel.Visible = true;
            
            nameLabel.Text = contact.DisplayName;
            emailLabel.Text = contact.EmailAddress;
            companyLabel.Text = contact.Company;
            jobTitleLabel.Text = contact.JobTitle;
            phoneLabel.Text = contact.PhoneNumber;
            mobileLabel.Text = contact.MobileNumber;
            addressLabel.Text = contact.Address;
            notesTextBox.Text = contact.Notes;

            // Display alternate emails
            alternateEmailsListBox.Items.Clear();
            foreach (var email in contact.AlternateEmails)
            {
                alternateEmailsListBox.Items.Add(email);
            }

            favoriteCheckBox.Checked = contact.IsFavorite;
            favoriteCheckBox.Enabled = true;
        }

        private void ContactsListView_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (contactsListView.SelectedItems.Count > 0)
            {
                var selectedContact = contactsListView.SelectedItems[0].Tag as Contact;
                if (selectedContact != null)
                {
                    DisplayContactDetails(selectedContact);
                }
            }
            else
            {
                contactDetailsPanel.Visible = false;
            }
        }

        private void ContactsListView_DoubleClick(object? sender, EventArgs e)
        {
            EditContactButton_Click(sender, e);
        }

        private void NewContactButton_Click(object? sender, EventArgs e)
        {
            if (_contactService == null) return;

            var contactForm = new ContactForm(_contactService);
            if (contactForm.ShowDialog() == DialogResult.OK)
            {
                RefreshContacts();
            }
        }

        private void EditContactButton_Click(object? sender, EventArgs e)
        {
            if (_contactService == null || contactsListView.SelectedItems.Count == 0) return;

            var selectedContact = contactsListView.SelectedItems[0].Tag as Contact;
            if (selectedContact != null)
            {
                var contactForm = new ContactForm(_contactService, selectedContact);
                if (contactForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshContacts();
                    // Reselect the contact to refresh details
                    DisplayContactDetails(selectedContact);
                }
            }
        }

        private void DeleteContactButton_Click(object? sender, EventArgs e)
        {
            if (_contactService == null || contactsListView.SelectedItems.Count == 0) return;

            var selectedContact = contactsListView.SelectedItems[0].Tag as Contact;
            if (selectedContact != null)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete the contact '{selectedContact.DisplayName}'?",
                    "Delete Contact",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _contactService.DeleteContact(selectedContact);
                    RefreshContacts();
                    contactDetailsPanel.Visible = false;
                }
            }
        }

        private void SearchTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (_contactService == null) return;

            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                RefreshContacts();
                return;
            }

            var filteredContacts = _contactService.SearchContacts(searchTextBox.Text);
            contactsListView.Items.Clear();

            foreach (var contact in filteredContacts.OrderBy(c => c.LastName).ThenBy(c => c.FirstName))
            {
                var item = new ListViewItem();
                item.Tag = contact;
                
                item.Text = contact.DisplayName;
                item.SubItems.Add(contact.EmailAddress);
                item.SubItems.Add(contact.Company);
                item.SubItems.Add(contact.JobTitle);
                item.SubItems.Add(contact.PhoneNumber);

                if (contact.IsFavorite)
                {
                    item.Font = new Font(contactsListView.Font, FontStyle.Bold);
                    item.ForeColor = Color.Blue;
                }

                contactsListView.Items.Add(item);
            }
        }

        private void NewGroupButton_Click(object? sender, EventArgs e)
        {
            if (_contactService == null) return;

            var groupForm = new ContactGroupForm(_contactService);
            if (groupForm.ShowDialog() == DialogResult.OK)
            {
                RefreshContactGroups();
            }
        }

        private void EditGroupButton_Click(object? sender, EventArgs e)
        {
            if (_contactService == null || groupsListView.SelectedItems.Count == 0) return;

            var selectedGroup = groupsListView.SelectedItems[0].Tag as ContactGroup;
            if (selectedGroup != null)
            {
                var groupForm = new ContactGroupForm(_contactService, selectedGroup);
                if (groupForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshContactGroups();
                }
            }
        }

        private void DeleteGroupButton_Click(object? sender, EventArgs e)
        {
            if (_contactService == null || groupsListView.SelectedItems.Count == 0) return;

            var selectedGroup = groupsListView.SelectedItems[0].Tag as ContactGroup;
            if (selectedGroup != null)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete the group '{selectedGroup.Name}'?",
                    "Delete Group",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _contactService.DeleteContactGroup(selectedGroup);
                    RefreshContactGroups();
                }
            }
        }

        private void SendEmailButton_Click(object? sender, EventArgs e)
        {
            if (contactsListView.SelectedItems.Count > 0)
            {
                var selectedContact = contactsListView.SelectedItems[0].Tag as Contact;
                if (selectedContact != null)
                {
                    // This would open a compose email form with the contact's email pre-filled
                    MessageBox.Show($"Send email to {selectedContact.EmailAddress}", "Send Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FavoriteCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (_contactService == null || contactsListView.SelectedItems.Count == 0) return;

            var selectedContact = contactsListView.SelectedItems[0].Tag as Contact;
            if (selectedContact != null)
            {
                selectedContact.IsFavorite = favoriteCheckBox.Checked;
                _contactService.UpdateContact(selectedContact);
                RefreshContacts();
                
                // Reselect the contact
                foreach (ListViewItem item in contactsListView.Items)
                {
                    if (item.Tag == selectedContact)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }

        private void TabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Refresh the appropriate view when tab changes
            if (tabControl.SelectedIndex == 0) // Contacts tab
            {
                RefreshContacts();
            }
            else if (tabControl.SelectedIndex == 1) // Groups tab
            {
                RefreshContactGroups();
            }
        }
    }
}