namespace Mail.Forms
{
    partial class ContactsView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel topPanel;
        private Label searchLabel;
        private TextBox searchTextBox;
        private TabControl tabControl;
        private TabPage contactsTabPage;
        private TabPage groupsTabPage;
        private SplitContainer contactsSplitContainer;
        private ListView contactsListView;
        private Panel contactDetailsPanel;
        private Panel contactButtonPanel;
        private Button newContactButton;
        private Button editContactButton;
        private Button deleteContactButton;
        private Button sendEmailButton;
        
        // Contact details controls
        private Label nameLabel;
        private Label emailLabel;
        private Label companyLabel;
        private Label jobTitleLabel;
        private Label phoneLabel;
        private Label mobileLabel;
        private Label addressLabel;
        private TextBox notesTextBox;
        private ListBox alternateEmailsListBox;
        private CheckBox favoriteCheckBox;
        
        // Groups tab controls
        private SplitContainer groupsSplitContainer;
        private ListView groupsListView;
        private Panel groupButtonPanel;
        private Button newGroupButton;
        private Button editGroupButton;
        private Button deleteGroupButton;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.topPanel = new Panel();
            this.searchLabel = new Label();
            this.searchTextBox = new TextBox();
            this.tabControl = new TabControl();
            this.contactsTabPage = new TabPage();
            this.groupsTabPage = new TabPage();
            this.contactsSplitContainer = new SplitContainer();
            this.contactsListView = new ListView();
            this.contactDetailsPanel = new Panel();
            this.contactButtonPanel = new Panel();
            this.newContactButton = new Button();
            this.editContactButton = new Button();
            this.deleteContactButton = new Button();
            this.sendEmailButton = new Button();
            
            // Contact details controls
            this.nameLabel = new Label();
            this.emailLabel = new Label();
            this.companyLabel = new Label();
            this.jobTitleLabel = new Label();
            this.phoneLabel = new Label();
            this.mobileLabel = new Label();
            this.addressLabel = new Label();
            this.notesTextBox = new TextBox();
            this.alternateEmailsListBox = new ListBox();
            this.favoriteCheckBox = new CheckBox();
            
            // Groups tab controls
            this.groupsSplitContainer = new SplitContainer();
            this.groupsListView = new ListView();
            this.groupButtonPanel = new Panel();
            this.newGroupButton = new Button();
            this.editGroupButton = new Button();
            this.deleteGroupButton = new Button();

            this.topPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.contactsTabPage.SuspendLayout();
            this.groupsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactsSplitContainer)).BeginInit();
            this.contactsSplitContainer.Panel1.SuspendLayout();
            this.contactsSplitContainer.Panel2.SuspendLayout();
            this.contactsSplitContainer.SuspendLayout();
            this.contactDetailsPanel.SuspendLayout();
            this.contactButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupsSplitContainer)).BeginInit();
            this.groupsSplitContainer.Panel1.SuspendLayout();
            this.groupsSplitContainer.Panel2.SuspendLayout();
            this.groupsSplitContainer.SuspendLayout();
            this.groupButtonPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.searchTextBox);
            this.topPanel.Controls.Add(this.searchLabel);
            this.topPanel.Dock = DockStyle.Top;
            this.topPanel.Location = new Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new Size(800, 40);
            this.topPanel.TabIndex = 0;

            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new Point(12, 15);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new Size(44, 13);
            this.searchLabel.TabIndex = 0;
            this.searchLabel.Text = "Search:";

            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.searchTextBox.Location = new Point(62, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new Size(300, 20);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.TextChanged += new EventHandler(this.SearchTextBox_TextChanged);

            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.contactsTabPage);
            this.tabControl.Controls.Add(this.groupsTabPage);
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Location = new Point(0, 40);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new Size(800, 560);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new EventHandler(this.TabControl_SelectedIndexChanged);

            // 
            // contactsTabPage
            // 
            this.contactsTabPage.Controls.Add(this.contactsSplitContainer);
            this.contactsTabPage.Location = new Point(4, 22);
            this.contactsTabPage.Name = "contactsTabPage";
            this.contactsTabPage.Padding = new Padding(3);
            this.contactsTabPage.Size = new Size(792, 534);
            this.contactsTabPage.TabIndex = 0;
            this.contactsTabPage.Text = "Contacts";
            this.contactsTabPage.UseVisualStyleBackColor = true;

            // 
            // contactsSplitContainer
            // 
            this.contactsSplitContainer.Dock = DockStyle.Fill;
            this.contactsSplitContainer.Location = new Point(3, 3);
            this.contactsSplitContainer.Name = "contactsSplitContainer";
            this.contactsSplitContainer.Size = new Size(786, 528);
            this.contactsSplitContainer.SplitterDistance = 400;
            this.contactsSplitContainer.TabIndex = 0;

            // 
            // contactsListView
            // 
            this.contactsListView.Dock = DockStyle.Fill;
            this.contactsListView.FullRowSelect = true;
            this.contactsListView.GridLines = true;
            this.contactsListView.Location = new Point(0, 0);
            this.contactsListView.MultiSelect = false;
            this.contactsListView.Name = "contactsListView";
            this.contactsListView.Size = new Size(400, 488);
            this.contactsListView.TabIndex = 0;
            this.contactsListView.UseCompatibleStateImageBehavior = false;
            this.contactsListView.View = View.Details;
            this.contactsListView.SelectedIndexChanged += new EventHandler(this.ContactsListView_SelectedIndexChanged);
            this.contactsListView.DoubleClick += new EventHandler(this.ContactsListView_DoubleClick);

            // Add columns
            this.contactsListView.Columns.Add("Name", 150);
            this.contactsListView.Columns.Add("Email", 200);
            this.contactsListView.Columns.Add("Company", 120);
            this.contactsListView.Columns.Add("Job Title", 100);
            this.contactsListView.Columns.Add("Phone", 120);

            // 
            // contactButtonPanel
            // 
            this.contactButtonPanel.Controls.Add(this.newContactButton);
            this.contactButtonPanel.Controls.Add(this.editContactButton);
            this.contactButtonPanel.Controls.Add(this.deleteContactButton);
            this.contactButtonPanel.Controls.Add(this.sendEmailButton);
            this.contactButtonPanel.Dock = DockStyle.Bottom;
            this.contactButtonPanel.Location = new Point(0, 488);
            this.contactButtonPanel.Name = "contactButtonPanel";
            this.contactButtonPanel.Size = new Size(400, 40);
            this.contactButtonPanel.TabIndex = 1;

            // 
            // newContactButton
            // 
            this.newContactButton.Location = new Point(6, 8);
            this.newContactButton.Name = "newContactButton";
            this.newContactButton.Size = new Size(90, 23);
            this.newContactButton.TabIndex = 0;
            this.newContactButton.Text = "New Contact";
            this.newContactButton.UseVisualStyleBackColor = true;
            this.newContactButton.Click += new EventHandler(this.NewContactButton_Click);

            // 
            // editContactButton
            // 
            this.editContactButton.Location = new Point(102, 8);
            this.editContactButton.Name = "editContactButton";
            this.editContactButton.Size = new Size(90, 23);
            this.editContactButton.TabIndex = 1;
            this.editContactButton.Text = "Edit Contact";
            this.editContactButton.UseVisualStyleBackColor = true;
            this.editContactButton.Click += new EventHandler(this.EditContactButton_Click);

            // 
            // deleteContactButton
            // 
            this.deleteContactButton.Location = new Point(198, 8);
            this.deleteContactButton.Name = "deleteContactButton";
            this.deleteContactButton.Size = new Size(90, 23);
            this.deleteContactButton.TabIndex = 2;
            this.deleteContactButton.Text = "Delete";
            this.deleteContactButton.UseVisualStyleBackColor = true;
            this.deleteContactButton.Click += new EventHandler(this.DeleteContactButton_Click);

            // 
            // sendEmailButton
            // 
            this.sendEmailButton.Location = new Point(294, 8);
            this.sendEmailButton.Name = "sendEmailButton";
            this.sendEmailButton.Size = new Size(90, 23);
            this.sendEmailButton.TabIndex = 3;
            this.sendEmailButton.Text = "Send Email";
            this.sendEmailButton.UseVisualStyleBackColor = true;
            this.sendEmailButton.Click += new EventHandler(this.SendEmailButton_Click);

            // 
            // contactDetailsPanel
            // 
            this.contactDetailsPanel.Controls.Add(this.favoriteCheckBox);
            this.contactDetailsPanel.Controls.Add(this.alternateEmailsListBox);
            this.contactDetailsPanel.Controls.Add(this.notesTextBox);
            this.contactDetailsPanel.Controls.Add(this.addressLabel);
            this.contactDetailsPanel.Controls.Add(this.mobileLabel);
            this.contactDetailsPanel.Controls.Add(this.phoneLabel);
            this.contactDetailsPanel.Controls.Add(this.jobTitleLabel);
            this.contactDetailsPanel.Controls.Add(this.companyLabel);
            this.contactDetailsPanel.Controls.Add(this.emailLabel);
            this.contactDetailsPanel.Controls.Add(this.nameLabel);
            this.contactDetailsPanel.Dock = DockStyle.Fill;
            this.contactDetailsPanel.Location = new Point(0, 0);
            this.contactDetailsPanel.Name = "contactDetailsPanel";
            this.contactDetailsPanel.Padding = new Padding(10);
            this.contactDetailsPanel.Size = new Size(382, 528);
            this.contactDetailsPanel.TabIndex = 0;
            this.contactDetailsPanel.Visible = false;

            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            this.nameLabel.Location = new Point(13, 13);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new Size(55, 20);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";

            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new Point(13, 43);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new Size(32, 13);
            this.emailLabel.TabIndex = 1;
            this.emailLabel.Text = "Email";

            // 
            // companyLabel
            // 
            this.companyLabel.AutoSize = true;
            this.companyLabel.Location = new Point(13, 66);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new Size(51, 13);
            this.companyLabel.TabIndex = 2;
            this.companyLabel.Text = "Company";

            // 
            // jobTitleLabel
            // 
            this.jobTitleLabel.AutoSize = true;
            this.jobTitleLabel.Location = new Point(13, 89);
            this.jobTitleLabel.Name = "jobTitleLabel";
            this.jobTitleLabel.Size = new Size(48, 13);
            this.jobTitleLabel.TabIndex = 3;
            this.jobTitleLabel.Text = "Job Title";

            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new Point(13, 112);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new Size(38, 13);
            this.phoneLabel.TabIndex = 4;
            this.phoneLabel.Text = "Phone";

            // 
            // mobileLabel
            // 
            this.mobileLabel.AutoSize = true;
            this.mobileLabel.Location = new Point(13, 135);
            this.mobileLabel.Name = "mobileLabel";
            this.mobileLabel.Size = new Size(38, 13);
            this.mobileLabel.TabIndex = 5;
            this.mobileLabel.Text = "Mobile";

            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new Point(13, 158);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new Size(45, 13);
            this.addressLabel.TabIndex = 6;
            this.addressLabel.Text = "Address";

            // 
            // notesTextBox
            // 
            this.notesTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.notesTextBox.Location = new Point(13, 250);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.ReadOnly = true;
            this.notesTextBox.ScrollBars = ScrollBars.Vertical;
            this.notesTextBox.Size = new Size(356, 100);
            this.notesTextBox.TabIndex = 7;

            // 
            // alternateEmailsListBox
            // 
            this.alternateEmailsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.alternateEmailsListBox.FormattingEnabled = true;
            this.alternateEmailsListBox.Location = new Point(13, 181);
            this.alternateEmailsListBox.Name = "alternateEmailsListBox";
            this.alternateEmailsListBox.Size = new Size(356, 56);
            this.alternateEmailsListBox.TabIndex = 8;

            // 
            // favoriteCheckBox
            // 
            this.favoriteCheckBox.AutoSize = true;
            this.favoriteCheckBox.Enabled = false;
            this.favoriteCheckBox.Location = new Point(13, 365);
            this.favoriteCheckBox.Name = "favoriteCheckBox";
            this.favoriteCheckBox.Size = new Size(65, 17);
            this.favoriteCheckBox.TabIndex = 9;
            this.favoriteCheckBox.Text = "Favorite";
            this.favoriteCheckBox.UseVisualStyleBackColor = true;
            this.favoriteCheckBox.CheckedChanged += new EventHandler(this.FavoriteCheckBox_CheckedChanged);

            // 
            // groupsTabPage
            // 
            this.groupsTabPage.Controls.Add(this.groupsSplitContainer);
            this.groupsTabPage.Location = new Point(4, 22);
            this.groupsTabPage.Name = "groupsTabPage";
            this.groupsTabPage.Padding = new Padding(3);
            this.groupsTabPage.Size = new Size(792, 534);
            this.groupsTabPage.TabIndex = 1;
            this.groupsTabPage.Text = "Groups";
            this.groupsTabPage.UseVisualStyleBackColor = true;

            // 
            // groupsSplitContainer
            // 
            this.groupsSplitContainer.Dock = DockStyle.Fill;
            this.groupsSplitContainer.Location = new Point(3, 3);
            this.groupsSplitContainer.Name = "groupsSplitContainer";
            this.groupsSplitContainer.Orientation = Orientation.Horizontal;
            this.groupsSplitContainer.Size = new Size(786, 528);
            this.groupsSplitContainer.SplitterDistance = 450;
            this.groupsSplitContainer.TabIndex = 0;

            // 
            // groupsListView
            // 
            this.groupsListView.Dock = DockStyle.Fill;
            this.groupsListView.FullRowSelect = true;
            this.groupsListView.GridLines = true;
            this.groupsListView.Location = new Point(0, 0);
            this.groupsListView.MultiSelect = false;
            this.groupsListView.Name = "groupsListView";
            this.groupsListView.Size = new Size(786, 450);
            this.groupsListView.TabIndex = 0;
            this.groupsListView.UseCompatibleStateImageBehavior = false;
            this.groupsListView.View = View.Details;

            // Add columns
            this.groupsListView.Columns.Add("Group Name", 200);
            this.groupsListView.Columns.Add("Members", 80);
            this.groupsListView.Columns.Add("Description", 300);

            // 
            // groupButtonPanel
            // 
            this.groupButtonPanel.Controls.Add(this.newGroupButton);
            this.groupButtonPanel.Controls.Add(this.editGroupButton);
            this.groupButtonPanel.Controls.Add(this.deleteGroupButton);
            this.groupButtonPanel.Dock = DockStyle.Fill;
            this.groupButtonPanel.Location = new Point(0, 0);
            this.groupButtonPanel.Name = "groupButtonPanel";
            this.groupButtonPanel.Size = new Size(786, 74);
            this.groupButtonPanel.TabIndex = 0;

            // 
            // newGroupButton
            // 
            this.newGroupButton.Location = new Point(6, 8);
            this.newGroupButton.Name = "newGroupButton";
            this.newGroupButton.Size = new Size(90, 23);
            this.newGroupButton.TabIndex = 0;
            this.newGroupButton.Text = "New Group";
            this.newGroupButton.UseVisualStyleBackColor = true;
            this.newGroupButton.Click += new EventHandler(this.NewGroupButton_Click);

            // 
            // editGroupButton
            // 
            this.editGroupButton.Location = new Point(102, 8);
            this.editGroupButton.Name = "editGroupButton";
            this.editGroupButton.Size = new Size(90, 23);
            this.editGroupButton.TabIndex = 1;
            this.editGroupButton.Text = "Edit Group";
            this.editGroupButton.UseVisualStyleBackColor = true;
            this.editGroupButton.Click += new EventHandler(this.EditGroupButton_Click);

            // 
            // deleteGroupButton
            // 
            this.deleteGroupButton.Location = new Point(198, 8);
            this.deleteGroupButton.Name = "deleteGroupButton";
            this.deleteGroupButton.Size = new Size(90, 23);
            this.deleteGroupButton.TabIndex = 2;
            this.deleteGroupButton.Text = "Delete Group";
            this.deleteGroupButton.UseVisualStyleBackColor = true;
            this.deleteGroupButton.Click += new EventHandler(this.DeleteGroupButton_Click);

            // 
            // ContactsView
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.topPanel);
            this.Name = "ContactsView";
            this.Size = new Size(800, 600);

            // Setup layout
            this.contactsSplitContainer.Panel1.Controls.Add(this.contactsListView);
            this.contactsSplitContainer.Panel1.Controls.Add(this.contactButtonPanel);
            this.contactsSplitContainer.Panel2.Controls.Add(this.contactDetailsPanel);
            
            this.groupsSplitContainer.Panel1.Controls.Add(this.groupsListView);
            this.groupsSplitContainer.Panel2.Controls.Add(this.groupButtonPanel);

            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.contactsTabPage.ResumeLayout(false);
            this.groupsTabPage.ResumeLayout(false);
            this.contactsSplitContainer.Panel1.ResumeLayout(false);
            this.contactsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contactsSplitContainer)).EndInit();
            this.contactsSplitContainer.ResumeLayout(false);
            this.contactDetailsPanel.ResumeLayout(false);
            this.contactDetailsPanel.PerformLayout();
            this.contactButtonPanel.ResumeLayout(false);
            this.groupsSplitContainer.Panel1.ResumeLayout(false);
            this.groupsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupsSplitContainer)).EndInit();
            this.groupsSplitContainer.ResumeLayout(false);
            this.groupButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}