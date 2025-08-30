namespace Mail.Forms
{
    partial class ComposeEmailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel mainTableLayout;
        private Label toLabel;
        private TextBox toTextBox;
        private Button toButton;
        private Label ccLabel;
        private TextBox ccTextBox;
        private Button ccButton;
        private Label bccLabel;
        private TextBox bccTextBox;
        private Label subjectLabel;
        private TextBox subjectTextBox;
        private Label attachmentLabel;
        private ListBox attachmentListBox;
        private Button attachButton;
        private Button removeAttachmentButton;
        private RichTextBox bodyRichTextBox;
        private Panel buttonPanel;
        private Button sendButton;
        private Button saveDraftButton;
        private Button cancelButton;
        private Panel priorityPanel;
        private RadioButton normalPriorityButton;
        private RadioButton highPriorityButton;
        private RadioButton lowPriorityButton;
        private Label priorityLabel;

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
            this.toLabel = new Label();
            this.toTextBox = new TextBox();
            this.toButton = new Button();
            this.ccLabel = new Label();
            this.ccTextBox = new TextBox();
            this.ccButton = new Button();
            this.bccLabel = new Label();
            this.bccTextBox = new TextBox();
            this.subjectLabel = new Label();
            this.subjectTextBox = new TextBox();
            this.attachmentLabel = new Label();
            this.attachmentListBox = new ListBox();
            this.attachButton = new Button();
            this.removeAttachmentButton = new Button();
            this.bodyRichTextBox = new RichTextBox();
            this.buttonPanel = new Panel();
            this.sendButton = new Button();
            this.saveDraftButton = new Button();
            this.cancelButton = new Button();
            this.priorityPanel = new Panel();
            this.normalPriorityButton = new RadioButton();
            this.highPriorityButton = new RadioButton();
            this.lowPriorityButton = new RadioButton();
            this.priorityLabel = new Label();

            this.mainTableLayout.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.priorityPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // mainTableLayout
            // 
            this.mainTableLayout.ColumnCount = 3;
            this.mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            this.mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            this.mainTableLayout.Controls.Add(this.toLabel, 0, 0);
            this.mainTableLayout.Controls.Add(this.toTextBox, 1, 0);
            this.mainTableLayout.Controls.Add(this.toButton, 2, 0);
            this.mainTableLayout.Controls.Add(this.ccLabel, 0, 1);
            this.mainTableLayout.Controls.Add(this.ccTextBox, 1, 1);
            this.mainTableLayout.Controls.Add(this.ccButton, 2, 1);
            this.mainTableLayout.Controls.Add(this.bccLabel, 0, 2);
            this.mainTableLayout.Controls.Add(this.bccTextBox, 1, 2);
            this.mainTableLayout.Controls.Add(this.subjectLabel, 0, 3);
            this.mainTableLayout.Controls.Add(this.subjectTextBox, 1, 3);
            this.mainTableLayout.Controls.Add(this.priorityLabel, 0, 4);
            this.mainTableLayout.Controls.Add(this.priorityPanel, 1, 4);
            this.mainTableLayout.Controls.Add(this.attachmentLabel, 0, 5);
            this.mainTableLayout.Controls.Add(this.attachmentListBox, 1, 5);
            this.mainTableLayout.Controls.Add(this.attachButton, 2, 5);
            this.mainTableLayout.Controls.Add(this.bodyRichTextBox, 0, 6);
            this.mainTableLayout.Dock = DockStyle.Fill;
            this.mainTableLayout.Location = new Point(0, 0);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.Padding = new Padding(10);
            this.mainTableLayout.RowCount = 7;
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.mainTableLayout.Size = new Size(800, 600);
            this.mainTableLayout.TabIndex = 0;

            // 
            // toLabel
            // 
            this.toLabel.Anchor = AnchorStyles.Left;
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new Point(13, 18);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new Size(23, 13);
            this.toLabel.TabIndex = 0;
            this.toLabel.Text = "To:";

            // 
            // toTextBox
            // 
            this.toTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.toTextBox.Location = new Point(93, 15);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new Size(614, 20);
            this.toTextBox.TabIndex = 1;

            // 
            // toButton
            // 
            this.toButton.Anchor = AnchorStyles.Left;
            this.toButton.Location = new Point(713, 13);
            this.toButton.Name = "toButton";
            this.toButton.Size = new Size(75, 23);
            this.toButton.TabIndex = 2;
            this.toButton.Text = "To...";
            this.toButton.UseVisualStyleBackColor = true;
            this.toButton.Click += new EventHandler(this.ToButton_Click);

            // 
            // ccLabel
            // 
            this.ccLabel.Anchor = AnchorStyles.Left;
            this.ccLabel.AutoSize = true;
            this.ccLabel.Location = new Point(13, 48);
            this.ccLabel.Name = "ccLabel";
            this.ccLabel.Size = new Size(22, 13);
            this.ccLabel.TabIndex = 3;
            this.ccLabel.Text = "Cc:";

            // 
            // ccTextBox
            // 
            this.ccTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.ccTextBox.Location = new Point(93, 45);
            this.ccTextBox.Name = "ccTextBox";
            this.ccTextBox.Size = new Size(614, 20);
            this.ccTextBox.TabIndex = 4;

            // 
            // ccButton
            // 
            this.ccButton.Anchor = AnchorStyles.Left;
            this.ccButton.Location = new Point(713, 43);
            this.ccButton.Name = "ccButton";
            this.ccButton.Size = new Size(75, 23);
            this.ccButton.TabIndex = 5;
            this.ccButton.Text = "Cc...";
            this.ccButton.UseVisualStyleBackColor = true;
            this.ccButton.Click += new EventHandler(this.CcButton_Click);

            // 
            // bccLabel
            // 
            this.bccLabel.Anchor = AnchorStyles.Left;
            this.bccLabel.AutoSize = true;
            this.bccLabel.Location = new Point(13, 78);
            this.bccLabel.Name = "bccLabel";
            this.bccLabel.Size = new Size(26, 13);
            this.bccLabel.TabIndex = 6;
            this.bccLabel.Text = "Bcc:";

            // 
            // bccTextBox
            // 
            this.bccTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.bccTextBox.Location = new Point(93, 75);
            this.bccTextBox.Name = "bccTextBox";
            this.bccTextBox.Size = new Size(614, 20);
            this.bccTextBox.TabIndex = 7;

            // 
            // subjectLabel
            // 
            this.subjectLabel.Anchor = AnchorStyles.Left;
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new Point(13, 108);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new Size(46, 13);
            this.subjectLabel.TabIndex = 8;
            this.subjectLabel.Text = "Subject:";

            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.mainTableLayout.SetColumnSpan(this.subjectTextBox, 2);
            this.subjectTextBox.Location = new Point(93, 105);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new Size(694, 20);
            this.subjectTextBox.TabIndex = 9;

            // 
            // priorityLabel
            // 
            this.priorityLabel.Anchor = AnchorStyles.Left;
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Location = new Point(13, 138);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new Size(41, 13);
            this.priorityLabel.TabIndex = 10;
            this.priorityLabel.Text = "Priority:";

            // 
            // priorityPanel
            // 
            this.priorityPanel.Controls.Add(this.normalPriorityButton);
            this.priorityPanel.Controls.Add(this.highPriorityButton);
            this.priorityPanel.Controls.Add(this.lowPriorityButton);
            this.priorityPanel.Dock = DockStyle.Fill;
            this.priorityPanel.Location = new Point(93, 133);
            this.priorityPanel.Name = "priorityPanel";
            this.priorityPanel.Size = new Size(614, 24);
            this.priorityPanel.TabIndex = 11;

            // 
            // normalPriorityButton
            // 
            this.normalPriorityButton.AutoSize = true;
            this.normalPriorityButton.Checked = true;
            this.normalPriorityButton.Location = new Point(3, 3);
            this.normalPriorityButton.Name = "normalPriorityButton";
            this.normalPriorityButton.Size = new Size(58, 17);
            this.normalPriorityButton.TabIndex = 0;
            this.normalPriorityButton.TabStop = true;
            this.normalPriorityButton.Text = "Normal";
            this.normalPriorityButton.UseVisualStyleBackColor = true;

            // 
            // highPriorityButton
            // 
            this.highPriorityButton.AutoSize = true;
            this.highPriorityButton.Location = new Point(67, 3);
            this.highPriorityButton.Name = "highPriorityButton";
            this.highPriorityButton.Size = new Size(47, 17);
            this.highPriorityButton.TabIndex = 1;
            this.highPriorityButton.Text = "High";
            this.highPriorityButton.UseVisualStyleBackColor = true;

            // 
            // lowPriorityButton
            // 
            this.lowPriorityButton.AutoSize = true;
            this.lowPriorityButton.Location = new Point(120, 3);
            this.lowPriorityButton.Name = "lowPriorityButton";
            this.lowPriorityButton.Size = new Size(45, 17);
            this.lowPriorityButton.TabIndex = 2;
            this.lowPriorityButton.Text = "Low";
            this.lowPriorityButton.UseVisualStyleBackColor = true;

            // 
            // attachmentLabel
            // 
            this.attachmentLabel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.attachmentLabel.AutoSize = true;
            this.attachmentLabel.Location = new Point(13, 163);
            this.attachmentLabel.Name = "attachmentLabel";
            this.attachmentLabel.Size = new Size(69, 13);
            this.attachmentLabel.TabIndex = 12;
            this.attachmentLabel.Text = "Attachments:";

            // 
            // attachmentListBox
            // 
            this.attachmentListBox.Dock = DockStyle.Fill;
            this.attachmentListBox.FormattingEnabled = true;
            this.attachmentListBox.Location = new Point(93, 163);
            this.attachmentListBox.Name = "attachmentListBox";
            this.attachmentListBox.Size = new Size(614, 74);
            this.attachmentListBox.TabIndex = 13;

            // 
            // attachButton
            // 
            this.attachButton.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.attachButton.Location = new Point(713, 163);
            this.attachButton.Name = "attachButton";
            this.attachButton.Size = new Size(75, 23);
            this.attachButton.TabIndex = 14;
            this.attachButton.Text = "Attach...";
            this.attachButton.UseVisualStyleBackColor = true;
            this.attachButton.Click += new EventHandler(this.AttachButton_Click);

            // 
            // bodyRichTextBox
            // 
            this.mainTableLayout.SetColumnSpan(this.bodyRichTextBox, 3);
            this.bodyRichTextBox.Dock = DockStyle.Fill;
            this.bodyRichTextBox.Location = new Point(13, 243);
            this.bodyRichTextBox.Name = "bodyRichTextBox";
            this.bodyRichTextBox.Size = new Size(774, 304);
            this.bodyRichTextBox.TabIndex = 15;
            this.bodyRichTextBox.Text = "";

            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.sendButton);
            this.buttonPanel.Controls.Add(this.saveDraftButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Dock = DockStyle.Bottom;
            this.buttonPanel.Location = new Point(0, 560);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new Size(800, 40);
            this.buttonPanel.TabIndex = 1;

            // 
            // sendButton
            // 
            this.sendButton.Anchor = AnchorStyles.Right;
            this.sendButton.Location = new Point(550, 8);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new Size(75, 23);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new EventHandler(this.SendButton_Click);

            // 
            // saveDraftButton
            // 
            this.saveDraftButton.Anchor = AnchorStyles.Right;
            this.saveDraftButton.Location = new Point(631, 8);
            this.saveDraftButton.Name = "saveDraftButton";
            this.saveDraftButton.Size = new Size(75, 23);
            this.saveDraftButton.TabIndex = 1;
            this.saveDraftButton.Text = "Save Draft";
            this.saveDraftButton.UseVisualStyleBackColor = true;
            this.saveDraftButton.Click += new EventHandler(this.SaveDraftButton_Click);

            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = AnchorStyles.Right;
            this.cancelButton.Location = new Point(712, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new EventHandler(this.CancelButton_Click);

            // 
            // ComposeEmailForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 600);
            this.Controls.Add(this.mainTableLayout);
            this.Controls.Add(this.buttonPanel);
            this.Name = "ComposeEmailForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "New Message";

            this.mainTableLayout.ResumeLayout(false);
            this.mainTableLayout.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.priorityPanel.ResumeLayout(false);
            this.priorityPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}