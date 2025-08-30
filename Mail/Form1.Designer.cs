namespace Mail
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private MenuStrip mainMenuStrip;
        private ToolStrip mainToolStrip;
        private SplitContainer mainSplitContainer;
        private SplitContainer leftSplitContainer;
        private SplitContainer rightSplitContainer;
        private TreeView folderTreeView;
        private ListView emailListView;
        private Panel emailPreviewPanel;
        private Label emailSubjectLabel;
        private Label emailFromLabel;
        private Label emailDateLabel;
        private TextBox emailBodyTextBox;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        
        // Toolbar buttons
        private ToolStripButton newEmailButton;
        private ToolStripButton replyButton;
        private ToolStripButton replyAllButton;
        private ToolStripButton forwardButton;
        private ToolStripButton deleteButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton markReadButton;
        private ToolStripButton markUnreadButton;
        private ToolStripButton flagButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripTextBox searchTextBox;
        private ToolStripButton searchButton;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            
            // Initialize controls
            this.mainMenuStrip = new MenuStrip();
            this.mainToolStrip = new ToolStrip();
            this.mainSplitContainer = new SplitContainer();
            this.leftSplitContainer = new SplitContainer();
            this.rightSplitContainer = new SplitContainer();
            this.folderTreeView = new TreeView();
            this.emailListView = new ListView();
            this.emailPreviewPanel = new Panel();
            this.emailSubjectLabel = new Label();
            this.emailFromLabel = new Label();
            this.emailDateLabel = new Label();
            this.emailBodyTextBox = new TextBox();
            this.statusStrip = new StatusStrip();
            this.statusLabel = new ToolStripStatusLabel();
            
            // Toolbar buttons
            this.newEmailButton = new ToolStripButton();
            this.replyButton = new ToolStripButton();
            this.replyAllButton = new ToolStripButton();
            this.forwardButton = new ToolStripButton();
            this.deleteButton = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.markReadButton = new ToolStripButton();
            this.markUnreadButton = new ToolStripButton();
            this.flagButton = new ToolStripButton();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.searchTextBox = new ToolStripTextBox();
            this.searchButton = new ToolStripButton();

            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftSplitContainer)).BeginInit();
            this.leftSplitContainer.Panel1.SuspendLayout();
            this.leftSplitContainer.Panel2.SuspendLayout();
            this.leftSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightSplitContainer)).BeginInit();
            this.rightSplitContainer.Panel1.SuspendLayout();
            this.rightSplitContainer.Panel2.SuspendLayout();
            this.rightSplitContainer.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.emailPreviewPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();

            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Location = new Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new Size(1200, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";

            // 
            // mainToolStrip
            // 
            this.mainToolStrip.ImageScalingSize = new Size(20, 20);
            this.mainToolStrip.Items.AddRange(new ToolStripItem[] {
                this.newEmailButton,
                this.toolStripSeparator1,
                this.replyButton,
                this.replyAllButton,
                this.forwardButton,
                this.deleteButton,
                this.toolStripSeparator2,
                this.markReadButton,
                this.markUnreadButton,
                this.flagButton,
                this.toolStripSeparator2,
                this.searchTextBox,
                this.searchButton});
            this.mainToolStrip.Location = new Point(0, 24);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new Size(1200, 27);
            this.mainToolStrip.TabIndex = 1;
            this.mainToolStrip.Text = "toolStrip1";

            // 
            // newEmailButton
            // 
            this.newEmailButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.newEmailButton.Name = "newEmailButton";
            this.newEmailButton.Size = new Size(72, 24);
            this.newEmailButton.Text = "New Email";
            this.newEmailButton.Click += new EventHandler(this.NewEmailButton_Click);

            // 
            // replyButton
            // 
            this.replyButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.replyButton.Name = "replyButton";
            this.replyButton.Size = new Size(43, 24);
            this.replyButton.Text = "Reply";
            this.replyButton.Click += new EventHandler(this.ReplyButton_Click);

            // 
            // replyAllButton
            // 
            this.replyAllButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.replyAllButton.Name = "replyAllButton";
            this.replyAllButton.Size = new Size(63, 24);
            this.replyAllButton.Text = "Reply All";

            // 
            // forwardButton
            // 
            this.forwardButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new Size(57, 24);
            this.forwardButton.Text = "Forward";
            this.forwardButton.Click += new EventHandler(this.ForwardButton_Click);

            // 
            // deleteButton
            // 
            this.deleteButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new Size(48, 24);
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new EventHandler(this.DeleteButton_Click);

            // 
            // markReadButton
            // 
            this.markReadButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.markReadButton.Name = "markReadButton";
            this.markReadButton.Size = new Size(69, 24);
            this.markReadButton.Text = "Mark Read";

            // 
            // markUnreadButton
            // 
            this.markUnreadButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.markUnreadButton.Name = "markUnreadButton";
            this.markUnreadButton.Size = new Size(83, 24);
            this.markUnreadButton.Text = "Mark Unread";

            // 
            // flagButton
            // 
            this.flagButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.flagButton.Name = "flagButton";
            this.flagButton.Size = new Size(33, 24);
            this.flagButton.Text = "Flag";

            // 
            // searchTextBox
            // 
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new Size(150, 27);

            // 
            // searchButton
            // 
            this.searchButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new Size(46, 24);
            this.searchButton.Text = "Search";

            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = DockStyle.Fill;
            this.mainSplitContainer.Location = new Point(0, 51);
            this.mainSplitContainer.Name = "mainSplitContainer";
            this.mainSplitContainer.Size = new Size(1200, 627);
            this.mainSplitContainer.SplitterDistance = 250;
            this.mainSplitContainer.TabIndex = 2;

            // 
            // leftSplitContainer (not used in this layout)
            // 
            this.leftSplitContainer.Dock = DockStyle.Fill;
            this.leftSplitContainer.Location = new Point(0, 0);
            this.leftSplitContainer.Name = "leftSplitContainer";
            this.leftSplitContainer.Orientation = Orientation.Horizontal;
            this.leftSplitContainer.Size = new Size(250, 627);
            this.leftSplitContainer.SplitterDistance = 400;
            this.leftSplitContainer.TabIndex = 0;

            // 
            // folderTreeView
            // 
            this.folderTreeView.Dock = DockStyle.Fill;
            this.folderTreeView.Location = new Point(0, 0);
            this.folderTreeView.Name = "folderTreeView";
            this.folderTreeView.Size = new Size(250, 627);
            this.folderTreeView.TabIndex = 0;
            this.folderTreeView.AfterSelect += new TreeViewEventHandler(this.FolderTreeView_AfterSelect);

            // 
            // rightSplitContainer
            // 
            this.rightSplitContainer.Dock = DockStyle.Fill;
            this.rightSplitContainer.Location = new Point(0, 0);
            this.rightSplitContainer.Name = "rightSplitContainer";
            this.rightSplitContainer.Orientation = Orientation.Horizontal;
            this.rightSplitContainer.Size = new Size(946, 627);
            this.rightSplitContainer.SplitterDistance = 300;
            this.rightSplitContainer.TabIndex = 0;

            // 
            // emailListView
            // 
            this.emailListView.Dock = DockStyle.Fill;
            this.emailListView.FullRowSelect = true;
            this.emailListView.GridLines = true;
            this.emailListView.Location = new Point(0, 0);
            this.emailListView.MultiSelect = false;
            this.emailListView.Name = "emailListView";
            this.emailListView.Size = new Size(946, 300);
            this.emailListView.TabIndex = 0;
            this.emailListView.UseCompatibleStateImageBehavior = false;
            this.emailListView.View = View.Details;
            this.emailListView.SelectedIndexChanged += new EventHandler(this.EmailListView_SelectedIndexChanged);

            // Add columns
            this.emailListView.Columns.Add("From", 200);
            this.emailListView.Columns.Add("Subject", 300);
            this.emailListView.Columns.Add("Received", 150);
            this.emailListView.Columns.Add("", 30); // Attachment icon

            // 
            // emailPreviewPanel
            // 
            this.emailPreviewPanel.Controls.Add(this.emailBodyTextBox);
            this.emailPreviewPanel.Controls.Add(this.emailDateLabel);
            this.emailPreviewPanel.Controls.Add(this.emailFromLabel);
            this.emailPreviewPanel.Controls.Add(this.emailSubjectLabel);
            this.emailPreviewPanel.Dock = DockStyle.Fill;
            this.emailPreviewPanel.Location = new Point(0, 0);
            this.emailPreviewPanel.Name = "emailPreviewPanel";
            this.emailPreviewPanel.Padding = new Padding(10);
            this.emailPreviewPanel.Size = new Size(946, 323);
            this.emailPreviewPanel.TabIndex = 0;

            // 
            // emailSubjectLabel
            // 
            this.emailSubjectLabel.Dock = DockStyle.Top;
            this.emailSubjectLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            this.emailSubjectLabel.Location = new Point(10, 10);
            this.emailSubjectLabel.Name = "emailSubjectLabel";
            this.emailSubjectLabel.Size = new Size(926, 25);
            this.emailSubjectLabel.TabIndex = 0;
            this.emailSubjectLabel.Text = "Subject";

            // 
            // emailFromLabel
            // 
            this.emailFromLabel.Dock = DockStyle.Top;
            this.emailFromLabel.Location = new Point(10, 35);
            this.emailFromLabel.Name = "emailFromLabel";
            this.emailFromLabel.Size = new Size(926, 20);
            this.emailFromLabel.TabIndex = 1;
            this.emailFromLabel.Text = "From:";

            // 
            // emailDateLabel
            // 
            this.emailDateLabel.Dock = DockStyle.Top;
            this.emailDateLabel.Location = new Point(10, 55);
            this.emailDateLabel.Name = "emailDateLabel";
            this.emailDateLabel.Size = new Size(926, 20);
            this.emailDateLabel.TabIndex = 2;
            this.emailDateLabel.Text = "Date:";

            // 
            // emailBodyTextBox
            // 
            this.emailBodyTextBox.Dock = DockStyle.Fill;
            this.emailBodyTextBox.Location = new Point(10, 75);
            this.emailBodyTextBox.Multiline = true;
            this.emailBodyTextBox.Name = "emailBodyTextBox";
            this.emailBodyTextBox.ReadOnly = true;
            this.emailBodyTextBox.ScrollBars = ScrollBars.Vertical;
            this.emailBodyTextBox.Size = new Size(926, 238);
            this.emailBodyTextBox.TabIndex = 3;

            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.statusLabel});
            this.statusStrip.Location = new Point(0, 678);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(1200, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";

            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new Size(39, 17);
            this.statusLabel.Text = "Ready";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 700);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.statusStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "Form1";
            this.Text = "Mail - Outlook Clone";

            // Setup layout
            this.mainSplitContainer.Panel1.Controls.Add(this.folderTreeView);
            this.mainSplitContainer.Panel2.Controls.Add(this.rightSplitContainer);
            this.rightSplitContainer.Panel1.Controls.Add(this.emailListView);
            this.rightSplitContainer.Panel2.Controls.Add(this.emailPreviewPanel);

            // Add folder tree nodes
            this.folderTreeView.Nodes.Add("Inbox");
            this.folderTreeView.Nodes.Add("Outbox");
            this.folderTreeView.Nodes.Add("Sent Items");
            this.folderTreeView.Nodes.Add("Drafts");
            this.folderTreeView.Nodes.Add("Deleted Items");
            this.folderTreeView.Nodes.Add("Junk Email");
            var separator = this.folderTreeView.Nodes.Add("────────────");
            separator.ForeColor = Color.Gray;
            this.folderTreeView.Nodes.Add("Calendar");
            this.folderTreeView.Nodes.Add("Contacts");

            this.mainSplitContainer.ResumeLayout(false);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.leftSplitContainer.ResumeLayout(false);
            this.leftSplitContainer.Panel1.ResumeLayout(false);
            this.leftSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftSplitContainer)).EndInit();
            this.rightSplitContainer.ResumeLayout(false);
            this.rightSplitContainer.Panel1.ResumeLayout(false);
            this.rightSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightSplitContainer)).EndInit();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.emailPreviewPanel.ResumeLayout(false);
            this.emailPreviewPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
