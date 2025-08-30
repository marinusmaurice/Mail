using Mail.Services;
using Mail.Models;
using Mail.Forms;

namespace Mail
{
    public partial class Form1 : Form
    {
        private EmailService _emailService = null!;
        private ContactService _contactService = null!;
        private CalendarService _calendarService = null!;
        private AccountService _accountService = null!;
        
        // View controls
        private CalendarView _calendarView = null!;
        private ContactsView _contactsView = null!;

        public Form1()
        {
            InitializeComponent();
            InitializeServices();
            SetupOutlookInterface();
            SetupMenu();
            InitializeViews();
            
            // Subscribe to the Load event to check account setup after form is fully loaded
            this.Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            // Now it's safe to check account setup after the form is fully loaded
            CheckAccountSetup();
        }

        private void InitializeServices()
        {
            _accountService = new AccountService();
            _emailService = new EmailService(_accountService);
            _contactService = new ContactService();
            _calendarService = new CalendarService();

            // Subscribe to events
            _emailService.NewEmailReceived += OnNewEmailReceived;
            _emailService.EmailSent += OnEmailSent;
        }

        private void SetupOutlookInterface()
        {
            this.Text = "Mail - Outlook Clone";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
        }

        private void InitializeViews()
        {
            // Only initialize views if the controls exist
            try
            {
                // Initialize calendar view
                _calendarView = new CalendarView(_calendarService)
                {
                    Dock = DockStyle.Fill,
                    Visible = false
                };

                // Initialize contacts view
                _contactsView = new ContactsView(_contactService)
                {
                    Dock = DockStyle.Fill,
                    Visible = false
                };

                // Add to container when it's safe to do so
                this.Load += (s, e) =>
                {
                    if (rightSplitContainer?.Panel1 != null)
                    {
                        rightSplitContainer.Panel1.Controls.Add(_calendarView);
                        rightSplitContainer.Panel1.Controls.Add(_contactsView);
                    }
                };
            }
            catch
            {
                // Handle cases where controls don't exist yet
            }
        }

        private void CheckAccountSetup()
        {
            try
            {
                var accounts = _accountService.GetAllAccounts();
                if (!accounts.Any())
                {
                    // Use Timer to delay the message slightly to ensure form is fully rendered
                    var timer = new System.Windows.Forms.Timer();
                    timer.Interval = 100; // 100ms delay
                    timer.Tick += (s, e) =>
                    {
                        timer.Stop();
                        timer.Dispose();
                        
                        var result = MessageBox.Show(
                            "Welcome to your new Outlook-compatible email client!\n\n" +
                            "To get started, you need to set up an email account. " +
                            "Would you like to set up an account now?",
                            "Welcome - Email Setup Required",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            ShowQuickSetup();
                        }
                    };
                    timer.Start();
                }
                else
                {
                    LoadInboxEmails();
                    // Start receiving emails in the background
                    Task.Run(async () =>
                    {
                        try
                        {
                            await _emailService.RefreshEmailsAsync();
                            if (this.IsHandleCreated && !this.IsDisposed)
                            {
                                this.Invoke(() => LoadInboxEmails());
                            }
                        }
                        catch
                        {
                            // Ignore errors during background refresh
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                // Handle any errors gracefully
                System.Diagnostics.Debug.WriteLine($"Error in CheckAccountSetup: {ex.Message}");
            }
        }

        private void ShowQuickSetup()
        {
            try
            {
                var quickSetupForm = new QuickSetupForm(_accountService);
                if (quickSetupForm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadInboxEmails();
                    UpdateFolderCounts();
                    
                    // Start receiving emails
                    Task.Run(async () =>
                    {
                        try
                        {
                            await _emailService.RefreshEmailsAsync();
                            if (this.IsHandleCreated && !this.IsDisposed)
                            {
                                this.Invoke(() => 
                                {
                                    LoadInboxEmails();
                                    UpdateFolderCounts();
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            if (this.IsHandleCreated && !this.IsDisposed)
                            {
                                this.Invoke(() =>
                                {
                                    if (statusLabel != null)
                                        statusLabel.Text = $"Error receiving emails: {ex.Message}";
                                });
                            }
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening quick setup: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupMenu()
        {
            try
            {
                // File menu
                var fileMenu = new ToolStripMenuItem("&File");
                fileMenu.DropDownItems.Add("&New Email", null, (s, e) => NewEmailButton_Click(s, e));
                fileMenu.DropDownItems.Add("New &Contact", null, (s, e) => NewContact());
                fileMenu.DropDownItems.Add("New &Event", null, (s, e) => NewEvent());
                fileMenu.DropDownItems.Add(new ToolStripSeparator());
                fileMenu.DropDownItems.Add("&Add Account", null, (s, e) => ShowQuickSetup());
                fileMenu.DropDownItems.Add("&Settings", null, (s, e) => ShowSettings());
                fileMenu.DropDownItems.Add(new ToolStripSeparator());
                fileMenu.DropDownItems.Add("E&xit", null, (s, e) => this.Close());

                // Edit menu
                var editMenu = new ToolStripMenuItem("&Edit");
                editMenu.DropDownItems.Add("&Select All", null, (s, e) => SelectAllEmails());
                editMenu.DropDownItems.Add("&Delete", null, (s, e) => DeleteButton_Click(s, e));

                // View menu
                var viewMenu = new ToolStripMenuItem("&View");
                viewMenu.DropDownItems.Add("&Inbox", null, (s, e) => LoadEmailsForFolder(EmailFolder.Inbox));
                viewMenu.DropDownItems.Add("&Sent Items", null, (s, e) => LoadEmailsForFolder(EmailFolder.SentItems));
                viewMenu.DropDownItems.Add("&Drafts", null, (s, e) => LoadEmailsForFolder(EmailFolder.Drafts));
                viewMenu.DropDownItems.Add(new ToolStripSeparator());
                viewMenu.DropDownItems.Add("&Calendar", null, (s, e) => ShowCalendarView());
                viewMenu.DropDownItems.Add("C&ontacts", null, (s, e) => ShowContactsView());

                // Tools menu
                var toolsMenu = new ToolStripMenuItem("&Tools");
                toolsMenu.DropDownItems.Add("&Send/Receive All", null, (s, e) => SendReceiveAll());
                toolsMenu.DropDownItems.Add("&Account Settings", null, (s, e) => ShowSettings());

                // Help menu
                var helpMenu = new ToolStripMenuItem("&Help");
                helpMenu.DropDownItems.Add("&About", null, (s, e) => ShowAbout());

                if (mainMenuStrip != null)
                {
                    mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, editMenu, viewMenu, toolsMenu, helpMenu });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error setting up menu: {ex.Message}");
            }
        }

        private void LoadInboxEmails()
        {
            try
            {
                var emails = _emailService.GetEmails(EmailFolder.Inbox);
                UpdateEmailList(emails);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading inbox emails: {ex.Message}");
            }
        }

        private void UpdateEmailList(List<EmailMessage> emails)
        {
            try
            {
                if (emailListView == null) return;

                emailListView.Items.Clear();
                
                foreach (var email in emails.OrderByDescending(e => e.DateReceived))
                {
                    var item = new ListViewItem();
                    item.Tag = email;
                    item.Font = email.IsRead ? new Font(this.Font, FontStyle.Regular) : new Font(this.Font, FontStyle.Bold);
                    item.ForeColor = email.IsRead ? Color.Black : Color.Blue;

                    // Add subitems for different columns
                    item.Text = email.IsImportant ? "?? " + email.From : email.From;
                    item.SubItems.Add(email.Subject);
                    item.SubItems.Add(email.DateReceived.ToString("M/d/yyyy h:mm tt"));
                    item.SubItems.Add(email.HasAttachments ? "??" : "");

                    emailListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating email list: {ex.Message}");
            }
        }

        private void OnNewEmailReceived(object? sender, EmailMessage email)
        {
            try
            {
                // Update UI when new email arrives
                if (folderTreeView?.SelectedNode?.Text == "Inbox")
                {
                    LoadInboxEmails();
                }
                UpdateFolderCounts();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error handling new email: {ex.Message}");
            }
        }

        private void OnEmailSent(object? sender, EmailMessage email)
        {
            try
            {
                // Update UI when email is sent
                UpdateFolderCounts();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error handling sent email: {ex.Message}");
            }
        }

        private void UpdateFolderCounts()
        {
            try
            {
                if (folderTreeView == null) return;

                // Update unread counts in folder tree
                var inboxCount = _emailService.GetEmails(EmailFolder.Inbox).Count(e => !e.IsRead);
                var draftsCount = _emailService.GetEmails(EmailFolder.Drafts).Count();
                
                // Update tree node text with counts
                foreach (TreeNode node in folderTreeView.Nodes)
                {
                    if (node.Text.StartsWith("Inbox"))
                    {
                        node.Text = inboxCount > 0 ? $"Inbox ({inboxCount})" : "Inbox";
                    }
                    else if (node.Text.StartsWith("Drafts"))
                    {
                        node.Text = draftsCount > 0 ? $"Drafts ({draftsCount})" : "Drafts";
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating folder counts: {ex.Message}");
            }
        }

        private void FolderTreeView_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            var folderName = e.Node.Text.Split('(')[0].Trim();
            
            switch (folderName)
            {
                case "Inbox":
                    LoadEmailsForFolder(EmailFolder.Inbox);
                    break;
                case "Sent Items":
                    LoadEmailsForFolder(EmailFolder.SentItems);
                    break;
                case "Drafts":
                    LoadEmailsForFolder(EmailFolder.Drafts);
                    break;
                case "Deleted Items":
                    LoadEmailsForFolder(EmailFolder.DeletedItems);
                    break;
                case "Junk Email":
                    LoadEmailsForFolder(EmailFolder.Junk);
                    break;
                case "Outbox":
                    LoadEmailsForFolder(EmailFolder.Outbox);
                    break;
                case "Calendar":
                    ShowCalendarView();
                    break;
                case "Contacts":
                    ShowContactsView();
                    break;
            }
        }

        private void LoadEmailsForFolder(EmailFolder folder)
        {
            var emails = _emailService.GetEmails(folder);
            UpdateEmailList(emails);
            ShowEmailListView();
        }

        private void ShowEmailListView()
        {
            try
            {
                // Hide other views
                if (_calendarView != null) _calendarView.Visible = false;
                if (_contactsView != null) _contactsView.Visible = false;
                
                // Show email view
                if (emailListView != null) emailListView.Visible = true;
                if (emailPreviewPanel != null) emailPreviewPanel.Visible = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error showing email list view: {ex.Message}");
            }
        }

        private void ShowCalendarView()
        {
            try
            {
                // Hide email and contacts views
                if (emailListView != null) emailListView.Visible = false;
                if (emailPreviewPanel != null) emailPreviewPanel.Visible = false;
                if (_contactsView != null) _contactsView.Visible = false;
                
                // Show calendar view
                if (_calendarView != null)
                {
                    _calendarView.Visible = true;
                    _calendarView.BringToFront();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error showing calendar view: {ex.Message}");
            }
        }

        private void ShowContactsView()
        {
            try
            {
                // Hide email and calendar views
                if (emailListView != null) emailListView.Visible = false;
                if (emailPreviewPanel != null) emailPreviewPanel.Visible = false;
                if (_calendarView != null) _calendarView.Visible = false;
                
                // Show contacts view
                if (_contactsView != null)
                {
                    _contactsView.Visible = true;
                    _contactsView.BringToFront();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error showing contacts view: {ex.Message}");
            }
        }

        private void EmailListView_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                if (emailListView?.SelectedItems.Count > 0)
                {
                    var selectedEmail = emailListView.SelectedItems[0].Tag as EmailMessage;
                    if (selectedEmail != null)
                    {
                        DisplayEmailPreview(selectedEmail);
                        
                        // Mark as read if not already
                        if (!selectedEmail.IsRead)
                        {
                            _emailService.MarkAsRead(selectedEmail);
                            LoadEmailsForFolder(selectedEmail.Folder);
                            UpdateFolderCounts();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error handling email selection: {ex.Message}");
            }
        }

        private void DisplayEmailPreview(EmailMessage email)
        {
            try
            {
                if (emailSubjectLabel != null) emailSubjectLabel.Text = email.Subject;
                if (emailFromLabel != null) emailFromLabel.Text = $"From: {email.From}";
                if (emailDateLabel != null) emailDateLabel.Text = email.DateReceived.ToString("dddd, MMMM d, yyyy h:mm tt");
                if (emailBodyTextBox != null) emailBodyTextBox.Text = email.Body;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error displaying email preview: {ex.Message}");
            }
        }

        private void NewEmailButton_Click(object? sender, EventArgs e)
        {
            var defaultAccount = _accountService.GetDefaultAccount();
            if (defaultAccount == null)
            {
                MessageBox.Show("Please set up an email account first.", "No Account", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowQuickSetup();
                return;
            }

            var composeForm = new ComposeEmailForm(_emailService, _contactService);
            composeForm.ShowDialog();
            
            // Refresh the current view
            if (folderTreeView?.SelectedNode != null)
            {
                FolderTreeView_AfterSelect(folderTreeView, new TreeViewEventArgs(folderTreeView.SelectedNode));
            }
        }

        private void ReplyButton_Click(object? sender, EventArgs e)
        {
            if (emailListView?.SelectedItems.Count > 0)
            {
                var selectedEmail = emailListView.SelectedItems[0].Tag as EmailMessage;
                if (selectedEmail != null)
                {
                    var composeForm = new ComposeEmailForm(_emailService, _contactService, selectedEmail, ComposeMode.Reply);
                    composeForm.ShowDialog();
                }
            }
        }

        private void ForwardButton_Click(object? sender, EventArgs e)
        {
            if (emailListView?.SelectedItems.Count > 0)
            {
                var selectedEmail = emailListView.SelectedItems[0].Tag as EmailMessage;
                if (selectedEmail != null)
                {
                    var composeForm = new ComposeEmailForm(_emailService, _contactService, selectedEmail, ComposeMode.Forward);
                    composeForm.ShowDialog();
                }
            }
        }

        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            if (emailListView?.SelectedItems.Count > 0)
            {
                var selectedEmail = emailListView.SelectedItems[0].Tag as EmailMessage;
                if (selectedEmail != null)
                {
                    _emailService.DeleteEmail(selectedEmail);
                    LoadEmailsForFolder(selectedEmail.Folder);
                    UpdateFolderCounts();
                }
            }
        }

        // Menu event handlers
        private void ShowSettings()
        {
            var settingsForm = new SettingsForm(_accountService);
            settingsForm.ShowDialog();
        }

        private void NewContact()
        {
            var contactForm = new ContactForm(_contactService);
            if (contactForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh contacts view if it's currently visible
                if (_contactsView?.Visible == true)
                {
                    _contactsView.ContactService = _contactService; // This will trigger a refresh
                }
            }
        }

        private void NewEvent()
        {
            var eventForm = new EventForm(_calendarService);
            if (eventForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh calendar view if it's currently visible
                if (_calendarView?.Visible == true)
                {
                    _calendarView.CalendarService = _calendarService; // This will trigger a refresh
                }
            }
        }

        private void SelectAllEmails()
        {
            if (emailListView != null)
            {
                foreach (ListViewItem item in emailListView.Items)
                {
                    item.Selected = true;
                }
            }
        }

        private void SendReceiveAll()
        {
            var defaultAccount = _accountService.GetDefaultAccount();
            if (defaultAccount == null)
            {
                MessageBox.Show("Please set up an email account first.", "No Account", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (statusLabel != null) statusLabel.Text = "Sending and receiving emails...";
            
            Task.Run(async () =>
            {
                try
                {
                    await _emailService.RefreshEmailsAsync();
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        this.Invoke(() =>
                        {
                            if (statusLabel != null) statusLabel.Text = "Ready";
                            LoadInboxEmails();
                            UpdateFolderCounts();
                            MessageBox.Show("Send/Receive completed successfully!", "Mail", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        });
                    }
                }
                catch (Exception ex)
                {
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        this.Invoke(() =>
                        {
                            if (statusLabel != null) statusLabel.Text = "Ready";
                            MessageBox.Show($"Send/Receive failed: {ex.Message}", "Mail Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }
            });
        }

        private void ShowAbout()
        {
            MessageBox.Show(
                "Mail - Outlook Clone\n\nA comprehensive email client with all Outlook features including:\n" +
                "• Real email integration with Outlook, Gmail, Yahoo, and more\n" +
                "• Calendar with events and reminders\n" +
                "• Contact management with groups\n" +
                "• Account settings and quick setup\n" +
                "• OAuth2 authentication for secure access\n\n" +
                "Built with .NET 9, Windows Forms, MailKit, and Microsoft Graph.",
                "About Mail",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
