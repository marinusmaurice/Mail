using Mail.Models;
using Mail.Services;

namespace Mail.Forms
{
    public enum ComposeMode
    {
        New,
        Reply,
        ReplyAll,
        Forward
    }

    public partial class ComposeEmailForm : Form
    {
        private EmailService _emailService;
        private ContactService _contactService;
        private EmailMessage? _originalEmail;
        private ComposeMode _mode;

        public ComposeEmailForm(EmailService emailService, ContactService contactService, EmailMessage? originalEmail = null, ComposeMode mode = ComposeMode.New)
        {
            InitializeComponent();
            _emailService = emailService;
            _contactService = contactService;
            _originalEmail = originalEmail;
            _mode = mode;
            
            SetupForm();
            PopulateFields();
        }

        private void SetupForm()
        {
            switch (_mode)
            {
                case ComposeMode.New:
                    this.Text = "New Message";
                    break;
                case ComposeMode.Reply:
                    this.Text = "Reply";
                    break;
                case ComposeMode.ReplyAll:
                    this.Text = "Reply All";
                    break;
                case ComposeMode.Forward:
                    this.Text = "Forward";
                    break;
            }
        }

        private void PopulateFields()
        {
            if (_originalEmail == null) return;

            switch (_mode)
            {
                case ComposeMode.Reply:
                    toTextBox.Text = _originalEmail.From;
                    subjectTextBox.Text = _originalEmail.Subject.StartsWith("Re:") ? _originalEmail.Subject : "Re: " + _originalEmail.Subject;
                    bodyRichTextBox.Text = $"\n\n--- Original Message ---\nFrom: {_originalEmail.From}\nSent: {_originalEmail.DateSent:F}\nTo: {_originalEmail.To}\nSubject: {_originalEmail.Subject}\n\n{_originalEmail.Body}";
                    break;

                case ComposeMode.ReplyAll:
                    toTextBox.Text = _originalEmail.From;
                    ccTextBox.Text = _originalEmail.Cc;
                    subjectTextBox.Text = _originalEmail.Subject.StartsWith("Re:") ? _originalEmail.Subject : "Re: " + _originalEmail.Subject;
                    bodyRichTextBox.Text = $"\n\n--- Original Message ---\nFrom: {_originalEmail.From}\nSent: {_originalEmail.DateSent:F}\nTo: {_originalEmail.To}\nSubject: {_originalEmail.Subject}\n\n{_originalEmail.Body}";
                    break;

                case ComposeMode.Forward:
                    subjectTextBox.Text = _originalEmail.Subject.StartsWith("Fwd:") ? _originalEmail.Subject : "Fwd: " + _originalEmail.Subject;
                    bodyRichTextBox.Text = $"\n\n--- Forwarded Message ---\nFrom: {_originalEmail.From}\nSent: {_originalEmail.DateSent:F}\nTo: {_originalEmail.To}\nSubject: {_originalEmail.Subject}\n\n{_originalEmail.Body}";
                    break;
            }
        }

        private async void SendButton_Click(object? sender, EventArgs e)
        {
            if (ValidateForm())
            {
                sendButton.Enabled = false;
                sendButton.Text = "Sending...";

                try
                {
                    var email = new EmailMessage
                    {
                        To = toTextBox.Text,
                        Cc = ccTextBox.Text,
                        Bcc = bccTextBox.Text,
                        Subject = subjectTextBox.Text,
                        Body = bodyRichTextBox.Text,
                        Priority = GetSelectedPriority()
                    };

                    // Use async send method
                    var success = await _emailService.SendEmailAsync(email);
                    
                    if (success)
                    {
                        MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to send email. Please check your account settings.", "Send Failed", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to send email: {ex.Message}", "Send Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sendButton.Enabled = true;
                    sendButton.Text = "Send";
                }
            }
        }

        private void SaveDraftButton_Click(object? sender, EventArgs e)
        {
            var email = new EmailMessage
            {
                To = toTextBox.Text,
                Cc = ccTextBox.Text,
                Bcc = bccTextBox.Text,
                Subject = subjectTextBox.Text,
                Body = bodyRichTextBox.Text,
                From = "me@outlook.com",
                Priority = GetSelectedPriority()
            };

            _emailService.SaveDraft(email);
            MessageBox.Show("Draft saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(toTextBox.Text))
            {
                MessageBox.Show("Please enter at least one recipient.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(subjectTextBox.Text))
            {
                var result = MessageBox.Show("Send this message without a subject?", "No Subject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    subjectTextBox.Focus();
                    return false;
                }
            }

            return true;
        }

        private EmailPriority GetSelectedPriority()
        {
            if (highPriorityButton.Checked) return EmailPriority.High;
            if (lowPriorityButton.Checked) return EmailPriority.Low;
            return EmailPriority.Normal;
        }

        private void ToButton_Click(object? sender, EventArgs e)
        {
            // Open contact picker dialog
            var contactPicker = new ContactPickerForm(_contactService);
            if (contactPicker.ShowDialog() == DialogResult.OK)
            {
                var selectedContacts = contactPicker.SelectedContacts;
                if (selectedContacts.Any())
                {
                    var emails = selectedContacts.Select(c => c.EmailAddress);
                    toTextBox.Text = string.Join("; ", emails);
                }
            }
        }

        private void CcButton_Click(object? sender, EventArgs e)
        {
            var contactPicker = new ContactPickerForm(_contactService);
            if (contactPicker.ShowDialog() == DialogResult.OK)
            {
                var selectedContacts = contactPicker.SelectedContacts;
                if (selectedContacts.Any())
                {
                    var emails = selectedContacts.Select(c => c.EmailAddress);
                    ccTextBox.Text = string.Join("; ", emails);
                }
            }
        }

        private void AttachButton_Click(object? sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Select files to attach";
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var fileName in openFileDialog.FileNames)
                    {
                        attachmentListBox.Items.Add(Path.GetFileName(fileName));
                    }
                }
            }
        }

        private void RemoveAttachmentButton_Click(object? sender, EventArgs e)
        {
            if (attachmentListBox.SelectedItem != null)
            {
                attachmentListBox.Items.Remove(attachmentListBox.SelectedItem);
            }
        }
    }
}