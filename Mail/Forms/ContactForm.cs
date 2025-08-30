using Mail.Models;
using Mail.Services;

namespace Mail.Forms
{
    public partial class ContactForm : Form
    {
        private ContactService _contactService;
        private Contact? _contact;
        private bool _isEditing;

        public ContactForm(ContactService contactService, Contact? contact = null)
        {
            InitializeComponent();
            _contactService = contactService;
            _contact = contact;
            _isEditing = contact != null;
            
            SetupForm();
            if (_isEditing)
            {
                PopulateFields();
            }
        }

        private void SetupForm()
        {
            this.Text = _isEditing ? "Edit Contact" : "New Contact";
        }

        private void PopulateFields()
        {
            if (_contact == null) return;

            firstNameTextBox.Text = _contact.FirstName;
            lastNameTextBox.Text = _contact.LastName;
            displayNameTextBox.Text = _contact.DisplayName;
            emailTextBox.Text = _contact.EmailAddress;
            companyTextBox.Text = _contact.Company;
            jobTitleTextBox.Text = _contact.JobTitle;
            phoneTextBox.Text = _contact.PhoneNumber;
            mobileTextBox.Text = _contact.MobileNumber;
            addressTextBox.Text = _contact.Address;
            notesTextBox.Text = _contact.Notes;
            favoriteCheckBox.Checked = _contact.IsFavorite;

            // Populate alternate emails
            alternateEmailsListBox.Items.Clear();
            foreach (var email in _contact.AlternateEmails)
            {
                alternateEmailsListBox.Items.Add(email);
            }
        }

        private void AddAlternateEmailButton_Click(object? sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(alternateEmailTextBox.Text))
            {
                alternateEmailsListBox.Items.Add(alternateEmailTextBox.Text);
                alternateEmailTextBox.Clear();
            }
        }

        private void RemoveAlternateEmailButton_Click(object? sender, EventArgs e)
        {
            if (alternateEmailsListBox.SelectedItem != null)
            {
                alternateEmailsListBox.Items.Remove(alternateEmailsListBox.SelectedItem);
            }
        }

        private void AlternateEmailTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddAlternateEmailButton_Click(sender, e);
                e.Handled = true;
            }
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var contact = _contact ?? new Contact();
                
                contact.FirstName = firstNameTextBox.Text;
                contact.LastName = lastNameTextBox.Text;
                contact.DisplayName = string.IsNullOrWhiteSpace(displayNameTextBox.Text) 
                    ? $"{firstNameTextBox.Text} {lastNameTextBox.Text}".Trim() 
                    : displayNameTextBox.Text;
                contact.EmailAddress = emailTextBox.Text;
                contact.Company = companyTextBox.Text;
                contact.JobTitle = jobTitleTextBox.Text;
                contact.PhoneNumber = phoneTextBox.Text;
                contact.MobileNumber = mobileTextBox.Text;
                contact.Address = addressTextBox.Text;
                contact.Notes = notesTextBox.Text;
                contact.IsFavorite = favoriteCheckBox.Checked;

                // Update alternate emails
                contact.AlternateEmails.Clear();
                foreach (string email in alternateEmailsListBox.Items)
                {
                    contact.AlternateEmails.Add(email);
                }

                if (_isEditing)
                {
                    _contactService.UpdateContact(contact);
                }
                else
                {
                    _contactService.AddContact(contact);
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
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) && string.IsNullOrWhiteSpace(lastNameTextBox.Text))
            {
                MessageBox.Show("Please enter at least a first name or last name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                firstNameTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Please enter an email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailTextBox.Focus();
                return false;
            }

            // Basic email validation
            if (!IsValidEmail(emailTextBox.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailTextBox.Focus();
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

        private void FirstNameTextBox_TextChanged(object? sender, EventArgs e)
        {
            UpdateDisplayName();
        }

        private void LastNameTextBox_TextChanged(object? sender, EventArgs e)
        {
            UpdateDisplayName();
        }

        private void UpdateDisplayName()
        {
            if (string.IsNullOrWhiteSpace(displayNameTextBox.Text) || 
                displayNameTextBox.Text == $"{_contact?.FirstName} {_contact?.LastName}".Trim())
            {
                displayNameTextBox.Text = $"{firstNameTextBox.Text} {lastNameTextBox.Text}".Trim();
            }
        }
    }
}