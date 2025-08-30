namespace Mail.Forms
{
    partial class ContactGroupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel mainTableLayout;
        private Label nameLabel;
        private TextBox nameTextBox;
        private Label descriptionLabel;
        private TextBox descriptionTextBox;
        private Panel contactsPanel;
        private SplitContainer contactsSplitContainer;
        private Panel availablePanel;
        private Label availableLabel;
        private TextBox searchAvailableTextBox;
        private ListBox availableContactsListBox;
        private Panel buttonPanel;
        private Button addContactButton;
        private Button removeContactButton;
        private Panel membersPanel;
        private Label membersLabel;
        private ListBox groupMembersListBox;
        private Panel bottomPanel;
        private Button saveButton;
        private Button cancelButton;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTableLayout = new TableLayoutPanel();
            this.nameLabel = new Label();
            this.nameTextBox = new TextBox();
            this.descriptionLabel = new Label();
            this.descriptionTextBox = new TextBox();
            this.contactsPanel = new Panel();
            this.contactsSplitContainer = new SplitContainer();
            this.availablePanel = new Panel();
            this.availableLabel = new Label();
            this.searchAvailableTextBox = new TextBox();
            this.availableContactsListBox = new ListBox();
            this.buttonPanel = new Panel();
            this.addContactButton = new Button();
            this.removeContactButton = new Button();
            this.membersPanel = new Panel();
            this.membersLabel = new Label();
            this.groupMembersListBox = new ListBox();
            this.bottomPanel = new Panel();
            this.saveButton = new Button();
            this.cancelButton = new Button();

            this.mainTableLayout.SuspendLayout();
            this.contactsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactsSplitContainer)).BeginInit();
            this.contactsSplitContainer.Panel1.SuspendLayout();
            this.contactsSplitContainer.Panel2.SuspendLayout();
            this.contactsSplitContainer.SuspendLayout();
            this.availablePanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.membersPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // mainTableLayout
            // 
            this.mainTableLayout.ColumnCount = 2;
            this.mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            this.mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.mainTableLayout.Controls.Add(this.nameLabel, 0, 0);
            this.mainTableLayout.Controls.Add(this.nameTextBox, 1, 0);
            this.mainTableLayout.Controls.Add(this.descriptionLabel, 0, 1);
            this.mainTableLayout.Controls.Add(this.descriptionTextBox, 1, 1);
            this.mainTableLayout.Controls.Add(this.contactsPanel, 0, 2);
            this.mainTableLayout.Dock = DockStyle.Fill;
            this.mainTableLayout.Location = new Point(0, 0);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.Padding = new Padding(10);
            this.mainTableLayout.RowCount = 3;
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.mainTableLayout.Size = new Size(700, 450);
            this.mainTableLayout.TabIndex = 0;

            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = AnchorStyles.Left;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new Point(13, 18);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new Size(69, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Group Name:";

            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.nameTextBox.Location = new Point(113, 15);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new Size(574, 20);
            this.nameTextBox.TabIndex = 1;

            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new Point(13, 43);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new Size(63, 13);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "Description:";

            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.descriptionTextBox.Location = new Point(113, 43);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = ScrollBars.Vertical;
            this.descriptionTextBox.Size = new Size(574, 54);
            this.descriptionTextBox.TabIndex = 3;

            // 
            // contactsPanel
            // 
            this.mainTableLayout.SetColumnSpan(this.contactsPanel, 2);
            this.contactsPanel.Controls.Add(this.contactsSplitContainer);
            this.contactsPanel.Dock = DockStyle.Fill;
            this.contactsPanel.Location = new Point(13, 103);
            this.contactsPanel.Name = "contactsPanel";
            this.contactsPanel.Size = new Size(674, 334);
            this.contactsPanel.TabIndex = 4;

            // 
            // contactsSplitContainer
            // 
            this.contactsSplitContainer.Dock = DockStyle.Fill;
            this.contactsSplitContainer.Location = new Point(0, 0);
            this.contactsSplitContainer.Name = "contactsSplitContainer";
            this.contactsSplitContainer.Size = new Size(674, 334);
            this.contactsSplitContainer.SplitterDistance = 280;
            this.contactsSplitContainer.TabIndex = 0;

            // 
            // availablePanel
            // 
            this.availablePanel.Controls.Add(this.availableContactsListBox);
            this.availablePanel.Controls.Add(this.searchAvailableTextBox);
            this.availablePanel.Controls.Add(this.availableLabel);
            this.availablePanel.Dock = DockStyle.Fill;
            this.availablePanel.Location = new Point(0, 0);
            this.availablePanel.Name = "availablePanel";
            this.availablePanel.Padding = new Padding(5);
            this.availablePanel.Size = new Size(280, 334);
            this.availablePanel.TabIndex = 0;

            // 
            // availableLabel
            // 
            this.availableLabel.AutoSize = true;
            this.availableLabel.Dock = DockStyle.Top;
            this.availableLabel.Location = new Point(5, 5);
            this.availableLabel.Name = "availableLabel";
            this.availableLabel.Size = new Size(99, 13);
            this.availableLabel.TabIndex = 0;
            this.availableLabel.Text = "Available Contacts:";

            // 
            // searchAvailableTextBox
            // 
            this.searchAvailableTextBox.Dock = DockStyle.Top;
            this.searchAvailableTextBox.Location = new Point(5, 18);
            this.searchAvailableTextBox.Name = "searchAvailableTextBox";
            this.searchAvailableTextBox.Size = new Size(270, 20);
            this.searchAvailableTextBox.TabIndex = 1;
            this.searchAvailableTextBox.TextChanged += new EventHandler(this.SearchAvailableTextBox_TextChanged);

            // 
            // availableContactsListBox
            // 
            this.availableContactsListBox.Dock = DockStyle.Fill;
            this.availableContactsListBox.FormattingEnabled = true;
            this.availableContactsListBox.Location = new Point(5, 38);
            this.availableContactsListBox.Name = "availableContactsListBox";
            this.availableContactsListBox.Size = new Size(270, 291);
            this.availableContactsListBox.TabIndex = 2;
            this.availableContactsListBox.DoubleClick += new EventHandler(this.AvailableContactsListBox_DoubleClick);

            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.removeContactButton);
            this.buttonPanel.Controls.Add(this.addContactButton);
            this.buttonPanel.Dock = DockStyle.Fill;
            this.buttonPanel.Location = new Point(0, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new Size(390, 334);
            this.buttonPanel.TabIndex = 0;

            // 
            // addContactButton
            // 
            this.addContactButton.Anchor = AnchorStyles.None;
            this.addContactButton.Location = new Point(158, 140);
            this.addContactButton.Name = "addContactButton";
            this.addContactButton.Size = new Size(75, 23);
            this.addContactButton.TabIndex = 0;
            this.addContactButton.Text = "Add >>";
            this.addContactButton.UseVisualStyleBackColor = true;
            this.addContactButton.Click += new EventHandler(this.AddContactButton_Click);

            // 
            // removeContactButton
            // 
            this.removeContactButton.Anchor = AnchorStyles.None;
            this.removeContactButton.Location = new Point(158, 170);
            this.removeContactButton.Name = "removeContactButton";
            this.removeContactButton.Size = new Size(75, 23);
            this.removeContactButton.TabIndex = 1;
            this.removeContactButton.Text = "<< Remove";
            this.removeContactButton.UseVisualStyleBackColor = true;
            this.removeContactButton.Click += new EventHandler(this.RemoveContactButton_Click);

            // 
            // membersPanel
            // 
            this.membersPanel.Controls.Add(this.groupMembersListBox);
            this.membersPanel.Controls.Add(this.membersLabel);
            this.membersPanel.Dock = DockStyle.Fill;
            this.membersPanel.Location = new Point(0, 0);
            this.membersPanel.Name = "membersPanel";
            this.membersPanel.Padding = new Padding(5);
            this.membersPanel.Size = new Size(390, 334);
            this.membersPanel.TabIndex = 0;

            // 
            // membersLabel
            // 
            this.membersLabel.AutoSize = true;
            this.membersLabel.Dock = DockStyle.Top;
            this.membersLabel.Location = new Point(5, 5);
            this.membersLabel.Name = "membersLabel";
            this.membersLabel.Size = new Size(85, 13);
            this.membersLabel.TabIndex = 0;
            this.membersLabel.Text = "Group Members:";

            // 
            // groupMembersListBox
            // 
            this.groupMembersListBox.Dock = DockStyle.Fill;
            this.groupMembersListBox.FormattingEnabled = true;
            this.groupMembersListBox.Location = new Point(5, 18);
            this.groupMembersListBox.Name = "groupMembersListBox";
            this.groupMembersListBox.Size = new Size(380, 311);
            this.groupMembersListBox.TabIndex = 1;
            this.groupMembersListBox.DoubleClick += new EventHandler(this.GroupMembersListBox_DoubleClick);

            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.saveButton);
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Dock = DockStyle.Bottom;
            this.bottomPanel.Location = new Point(0, 410);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new Size(700, 40);
            this.bottomPanel.TabIndex = 1;

            // 
            // saveButton
            // 
            this.saveButton.Anchor = AnchorStyles.Right;
            this.saveButton.Location = new Point(538, 8);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new EventHandler(this.SaveButton_Click);

            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = AnchorStyles.Right;
            this.cancelButton.Location = new Point(619, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new EventHandler(this.CancelButton_Click);

            // 
            // ContactGroupForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(700, 450);
            this.Controls.Add(this.mainTableLayout);
            this.Controls.Add(this.bottomPanel);
            this.Name = "ContactGroupForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Contact Group";

            // Setup layout - this needs to be done manually since the designer doesn't handle this properly
            this.contactsSplitContainer.Panel1.Controls.Add(this.availablePanel);
            this.contactsSplitContainer.Panel2.Controls.Add(this.membersPanel);
            this.contactsSplitContainer.Panel2.Controls.Add(this.buttonPanel);

            this.mainTableLayout.ResumeLayout(false);
            this.mainTableLayout.PerformLayout();
            this.contactsPanel.ResumeLayout(false);
            this.contactsSplitContainer.Panel1.ResumeLayout(false);
            this.contactsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contactsSplitContainer)).EndInit();
            this.contactsSplitContainer.ResumeLayout(false);
            this.availablePanel.ResumeLayout(false);
            this.availablePanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.membersPanel.ResumeLayout(false);
            this.membersPanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}