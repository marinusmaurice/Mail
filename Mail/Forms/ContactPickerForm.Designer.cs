namespace Mail.Forms
{
    partial class ContactPickerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TextBox searchTextBox;
        private Label searchLabel;
        private ListView contactsListView;
        private Panel buttonPanel;
        private Button okButton;
        private Button cancelButton;
        private Button selectAllButton;
        private Button clearAllButton;

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
            this.searchTextBox = new TextBox();
            this.searchLabel = new Label();
            this.contactsListView = new ListView();
            this.buttonPanel = new Panel();
            this.okButton = new Button();
            this.cancelButton = new Button();
            this.selectAllButton = new Button();
            this.clearAllButton = new Button();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();

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
            this.searchTextBox.Size = new Size(330, 20);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.TextChanged += new EventHandler(this.SearchTextBox_TextChanged);

            // 
            // contactsListView
            // 
            this.contactsListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.contactsListView.CheckBoxes = true;
            this.contactsListView.FullRowSelect = true;
            this.contactsListView.GridLines = true;
            this.contactsListView.Location = new Point(12, 38);
            this.contactsListView.Name = "contactsListView";
            this.contactsListView.Size = new Size(560, 350);
            this.contactsListView.TabIndex = 2;
            this.contactsListView.UseCompatibleStateImageBehavior = false;
            this.contactsListView.View = View.Details;

            // Add columns
            this.contactsListView.Columns.Add("Name", 200);
            this.contactsListView.Columns.Add("Email", 250);
            this.contactsListView.Columns.Add("Company", 110);

            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.selectAllButton);
            this.buttonPanel.Controls.Add(this.clearAllButton);
            this.buttonPanel.Controls.Add(this.okButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Dock = DockStyle.Bottom;
            this.buttonPanel.Location = new Point(0, 394);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new Size(584, 40);
            this.buttonPanel.TabIndex = 3;

            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new Point(12, 8);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new Size(75, 23);
            this.selectAllButton.TabIndex = 0;
            this.selectAllButton.Text = "Select All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new EventHandler(this.SelectAllButton_Click);

            // 
            // clearAllButton
            // 
            this.clearAllButton.Location = new Point(93, 8);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new Size(75, 23);
            this.clearAllButton.TabIndex = 1;
            this.clearAllButton.Text = "Clear All";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new EventHandler(this.ClearAllButton_Click);

            // 
            // okButton
            // 
            this.okButton.Anchor = AnchorStyles.Right;
            this.okButton.Location = new Point(415, 8);
            this.okButton.Name = "okButton";
            this.okButton.Size = new Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new EventHandler(this.OkButton_Click);

            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = AnchorStyles.Right;
            this.cancelButton.Location = new Point(496, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new EventHandler(this.CancelButton_Click);

            // 
            // ContactPickerForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 434);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.contactsListView);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchLabel);
            this.Name = "ContactPickerForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Select Contacts";
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}