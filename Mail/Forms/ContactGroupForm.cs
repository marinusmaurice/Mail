using Mail.Models;
using Mail.Services;

namespace Mail.Forms
{
    public partial class ContactGroupForm : Form
    {
        private ContactService _contactService;
        private ContactGroup? _group;
        private bool _isEditing;

        public ContactGroupForm(ContactService contactService, ContactGroup? group = null)
        {
            InitializeComponent();
            _contactService = contactService;
            _group = group;
            _isEditing = group != null;
            
            SetupForm();
            LoadAvailableContacts();
            if (_isEditing)
            {
                PopulateFields();
            }
        }

        private void SetupForm()
        {
            this.Text = _isEditing ? "Edit Contact Group" : "New Contact Group";
        }

        private void LoadAvailableContacts()
        {
            availableContactsListBox.Items.Clear();
            var contacts = _contactService.GetAllContacts();

            foreach (var contact in contacts.OrderBy(c => c.DisplayName))
            {
                availableContactsListBox.Items.Add(contact);
            }
            availableContactsListBox.DisplayMember = "DisplayName";
        }

        private void PopulateFields()
        {
            if (_group == null) return;

            nameTextBox.Text = _group.Name;
            descriptionTextBox.Text = _group.Description;

            // Populate group members
            groupMembersListBox.Items.Clear();
            foreach (var member in _group.Members)
            {
                groupMembersListBox.Items.Add(member);
                
                // Remove from available list
                for (int i = availableContactsListBox.Items.Count - 1; i >= 0; i--)
                {
                    if (availableContactsListBox.Items[i] is Contact contact && contact.Id == member.Id)
                    {
                        availableContactsListBox.Items.RemoveAt(i);
                        break;
                    }
                }
            }
            groupMembersListBox.DisplayMember = "DisplayName";
        }

        private void AddContactButton_Click(object? sender, EventArgs e)
        {
            if (availableContactsListBox.SelectedItem is Contact selectedContact)
            {
                groupMembersListBox.Items.Add(selectedContact);
                availableContactsListBox.Items.Remove(selectedContact);
                
                groupMembersListBox.DisplayMember = "DisplayName";
            }
        }

        private void RemoveContactButton_Click(object? sender, EventArgs e)
        {
            if (groupMembersListBox.SelectedItem is Contact selectedContact)
            {
                availableContactsListBox.Items.Add(selectedContact);
                groupMembersListBox.Items.Remove(selectedContact);
                
                availableContactsListBox.DisplayMember = "DisplayName";
                
                // Sort available contacts
                var sortedContacts = availableContactsListBox.Items.Cast<Contact>()
                    .OrderBy(c => c.DisplayName).ToList();
                availableContactsListBox.Items.Clear();
                foreach (var contact in sortedContacts)
                {
                    availableContactsListBox.Items.Add(contact);
                }
                availableContactsListBox.DisplayMember = "DisplayName";
            }
        }

        private void AvailableContactsListBox_DoubleClick(object? sender, EventArgs e)
        {
            AddContactButton_Click(sender, e);
        }

        private void GroupMembersListBox_DoubleClick(object? sender, EventArgs e)
        {
            RemoveContactButton_Click(sender, e);
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var group = _group ?? new ContactGroup();
                
                group.Name = nameTextBox.Text;
                group.Description = descriptionTextBox.Text;

                // Update group members
                group.Members.Clear();
                foreach (Contact member in groupMembersListBox.Items)
                {
                    group.Members.Add(member);
                }

                if (_isEditing)
                {
                    _contactService.UpdateContactGroup(group);
                }
                else
                {
                    _contactService.AddContactGroup(group);
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
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Please enter a group name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBox.Focus();
                return false;
            }

            return true;
        }

        private void SearchAvailableTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchAvailableTextBox.Text))
            {
                LoadAvailableContacts();
                // Remove current group members if editing
                if (_isEditing && _group != null)
                {
                    foreach (var member in _group.Members)
                    {
                        for (int i = availableContactsListBox.Items.Count - 1; i >= 0; i--)
                        {
                            if (availableContactsListBox.Items[i] is Contact contact && contact.Id == member.Id)
                            {
                                availableContactsListBox.Items.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
                return;
            }

            var filteredContacts = _contactService.SearchContacts(searchAvailableTextBox.Text);
            
            // Remove contacts that are already in the group
            var currentMembers = groupMembersListBox.Items.Cast<Contact>().ToList();
            filteredContacts = filteredContacts.Where(c => !currentMembers.Any(m => m.Id == c.Id)).ToList();

            availableContactsListBox.Items.Clear();
            foreach (var contact in filteredContacts.OrderBy(c => c.DisplayName))
            {
                availableContactsListBox.Items.Add(contact);
            }
            availableContactsListBox.DisplayMember = "DisplayName";
        }
    }
}