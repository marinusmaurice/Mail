namespace Mail.Forms
{
    partial class ContactForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel mainTableLayout;
        private Label firstNameLabel;
        private TextBox firstNameTextBox;
        private Label lastNameLabel;
        private TextBox lastNameTextBox;
        private Label displayNameLabel;
        private TextBox displayNameTextBox;
        private Label emailLabel;
        private TextBox emailTextBox;
        private Label companyLabel;
        private TextBox companyTextBox;
        private Label jobTitleLabel;
        private TextBox jobTitleTextBox;
        private Label phoneLabel;
        private TextBox phoneTextBox;
        private Label mobileLabel;
        private TextBox mobileTextBox;
        private Label addressLabel;
        private TextBox addressTextBox;
        private Label notesLabel;
        private TextBox notesTextBox;
        private Label alternateEmailsLabel;
        private TextBox alternateEmailTextBox;
        private Button addAlternateEmailButton;
        private ListBox alternateEmailsListBox;
        private Button removeAlternateEmailButton;
        private CheckBox favoriteCheckBox;
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
            this.firstNameLabel = new Label();
            this.firstNameTextBox = new TextBox();
            this.lastNameLabel = new Label();
            this.lastNameTextBox = new TextBox();
            this.displayNameLabel = new Label();
            this.displayNameTextBox = new TextBox();
            this.emailLabel = new Label();
            this.emailTextBox = new TextBox();
            this.companyLabel = new Label();
            this.companyTextBox = new TextBox();
            this.jobTitleLabel = new Label();
            this.jobTitleTextBox = new TextBox();
            this.phoneLabel = new Label();
            this.phoneTextBox = new TextBox();
            this.mobileLabel = new Label();
            this.mobileTextBox = new TextBox();
            this.addressLabel = new Label();
            this.addressTextBox = new TextBox();
            this.notesLabel = new Label();
            this.notesTextBox = new TextBox();
            this.alternateEmailsLabel = new Label();
            this.alternateEmailTextBox = new TextBox();
            this.addAlternateEmailButton = new Button();
            this.alternateEmailsListBox = new ListBox();
            this.removeAlternateEmailButton = new Button();
            this.favoriteCheckBox = new CheckBox();
            this.bottomPanel = new Panel();
            this.saveButton = new Button();
            this.cancelButton = new Button();

            this.mainTableLayout.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // mainTableLayout
            // 
            this.mainTableLayout.ColumnCount = 3;
            this.mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            this.mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            this.mainTableLayout.Controls.Add(this.firstNameLabel, 0, 0);
            this.mainTableLayout.Controls.Add(this.firstNameTextBox, 1, 0);
            this.mainTableLayout.Controls.Add(this.lastNameLabel, 0, 1);
            this.mainTableLayout.Controls.Add(this.lastNameTextBox, 1, 1);
            this.mainTableLayout.Controls.Add(this.displayNameLabel, 0, 2);
            this.mainTableLayout.Controls.Add(this.displayNameTextBox, 1, 2);
            this.mainTableLayout.Controls.Add(this.emailLabel, 0, 3);
            this.mainTableLayout.Controls.Add(this.emailTextBox, 1, 3);
            this.mainTableLayout.Controls.Add(this.companyLabel, 0, 4);
            this.mainTableLayout.Controls.Add(this.companyTextBox, 1, 4);
            this.mainTableLayout.Controls.Add(this.jobTitleLabel, 0, 5);
            this.mainTableLayout.Controls.Add(this.jobTitleTextBox, 1, 5);
            this.mainTableLayout.Controls.Add(this.phoneLabel, 0, 6);
            this.mainTableLayout.Controls.Add(this.phoneTextBox, 1, 6);
            this.mainTableLayout.Controls.Add(this.mobileLabel, 0, 7);
            this.mainTableLayout.Controls.Add(this.mobileTextBox, 1, 7);
            this.mainTableLayout.Controls.Add(this.addressLabel, 0, 8);
            this.mainTableLayout.Controls.Add(this.addressTextBox, 1, 8);
            this.mainTableLayout.Controls.Add(this.alternateEmailsLabel, 0, 9);
            this.mainTableLayout.Controls.Add(this.alternateEmailTextBox, 1, 9);
            this.mainTableLayout.Controls.Add(this.addAlternateEmailButton, 2, 9);
            this.mainTableLayout.Controls.Add(this.alternateEmailsListBox, 1, 10);
            this.mainTableLayout.Controls.Add(this.removeAlternateEmailButton, 2, 10);
            this.mainTableLayout.Controls.Add(this.notesLabel, 0, 11);
            this.mainTableLayout.Controls.Add(this.notesTextBox, 1, 11);
            this.mainTableLayout.Controls.Add(this.favoriteCheckBox, 1, 12);
            this.mainTableLayout.Dock = DockStyle.Fill;
            this.mainTableLayout.Location = new Point(0, 0);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.Padding = new Padding(10);
            this.mainTableLayout.RowCount = 13;
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.Size = new Size(500, 530);
            this.mainTableLayout.TabIndex = 0;

            // 
            // firstNameLabel
            // 
            this.firstNameLabel.Anchor = AnchorStyles.Left;
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new Point(13, 18);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new Size(60, 13);
            this.firstNameLabel.TabIndex = 0;
            this.firstNameLabel.Text = "First Name:";

            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.firstNameTextBox.Location = new Point(133, 15);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new Size(254, 20);
            this.firstNameTextBox.TabIndex = 1;
            this.firstNameTextBox.TextChanged += new EventHandler(this.FirstNameTextBox_TextChanged);

            // 
            // lastNameLabel
            // 
            this.lastNameLabel.Anchor = AnchorStyles.Left;
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new Point(13, 48);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new Size(61, 13);
            this.lastNameLabel.TabIndex = 2;
            this.lastNameLabel.Text = "Last Name:";

            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.lastNameTextBox.Location = new Point(133, 45);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new Size(254, 20);
            this.lastNameTextBox.TabIndex = 3;
            this.lastNameTextBox.TextChanged += new EventHandler(this.LastNameTextBox_TextChanged);

            // 
            // displayNameLabel
            // 
            this.displayNameLabel.Anchor = AnchorStyles.Left;
            this.displayNameLabel.AutoSize = true;
            this.displayNameLabel.Location = new Point(13, 78);
            this.displayNameLabel.Name = "displayNameLabel";
            this.displayNameLabel.Size = new Size(75, 13);
            this.displayNameLabel.TabIndex = 4;
            this.displayNameLabel.Text = "Display Name:";

            // 
            // displayNameTextBox
            // 
            this.displayNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.displayNameTextBox.Location = new Point(133, 75);
            this.displayNameTextBox.Name = "displayNameTextBox";
            this.displayNameTextBox.Size = new Size(254, 20);
            this.displayNameTextBox.TabIndex = 5;

            // 
            // emailLabel
            // 
            this.emailLabel.Anchor = AnchorStyles.Left;
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new Point(13, 108);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new Size(35, 13);
            this.emailLabel.TabIndex = 6;
            this.emailLabel.Text = "Email:";

            // 
            // emailTextBox
            // 
            this.emailTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.emailTextBox.Location = new Point(133, 105);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new Size(254, 20);
            this.emailTextBox.TabIndex = 7;

            // 
            // companyLabel
            // 
            this.companyLabel.Anchor = AnchorStyles.Left;
            this.companyLabel.AutoSize = true;
            this.companyLabel.Location = new Point(13, 138);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new Size(54, 13);
            this.companyLabel.TabIndex = 8;
            this.companyLabel.Text = "Company:";

            // 
            // companyTextBox
            // 
            this.companyTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.companyTextBox.Location = new Point(133, 135);
            this.companyTextBox.Name = "companyTextBox";
            this.companyTextBox.Size = new Size(254, 20);
            this.companyTextBox.TabIndex = 9;

            // 
            // jobTitleLabel
            // 
            this.jobTitleLabel.Anchor = AnchorStyles.Left;
            this.jobTitleLabel.AutoSize = true;
            this.jobTitleLabel.Location = new Point(13, 168);
            this.jobTitleLabel.Name = "jobTitleLabel";
            this.jobTitleLabel.Size = new Size(51, 13);
            this.jobTitleLabel.TabIndex = 10;
            this.jobTitleLabel.Text = "Job Title:";

            // 
            // jobTitleTextBox
            // 
            this.jobTitleTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.jobTitleTextBox.Location = new Point(133, 165);
            this.jobTitleTextBox.Name = "jobTitleTextBox";
            this.jobTitleTextBox.Size = new Size(254, 20);
            this.jobTitleTextBox.TabIndex = 11;

            // 
            // phoneLabel
            // 
            this.phoneLabel.Anchor = AnchorStyles.Left;
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new Point(13, 198);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new Size(41, 13);
            this.phoneLabel.TabIndex = 12;
            this.phoneLabel.Text = "Phone:";

            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.phoneTextBox.Location = new Point(133, 195);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new Size(254, 20);
            this.phoneTextBox.TabIndex = 13;

            // 
            // mobileLabel
            // 
            this.mobileLabel.Anchor = AnchorStyles.Left;
            this.mobileLabel.AutoSize = true;
            this.mobileLabel.Location = new Point(13, 228);
            this.mobileLabel.Name = "mobileLabel";
            this.mobileLabel.Size = new Size(41, 13);
            this.mobileLabel.TabIndex = 14;
            this.mobileLabel.Text = "Mobile:";

            // 
            // mobileTextBox
            // 
            this.mobileTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.mobileTextBox.Location = new Point(133, 225);
            this.mobileTextBox.Name = "mobileTextBox";
            this.mobileTextBox.Size = new Size(254, 20);
            this.mobileTextBox.TabIndex = 15;

            // 
            // addressLabel
            // 
            this.addressLabel.Anchor = AnchorStyles.Left;
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new Point(13, 258);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new Size(48, 13);
            this.addressLabel.TabIndex = 16;
            this.addressLabel.Text = "Address:";

            // 
            // addressTextBox
            // 
            this.addressTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.addressTextBox.Location = new Point(133, 255);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new Size(254, 20);
            this.addressTextBox.TabIndex = 17;

            // 
            // alternateEmailsLabel
            // 
            this.alternateEmailsLabel.Anchor = AnchorStyles.Left;
            this.alternateEmailsLabel.AutoSize = true;
            this.alternateEmailsLabel.Location = new Point(13, 288);
            this.alternateEmailsLabel.Name = "alternateEmailsLabel";
            this.alternateEmailsLabel.Size = new Size(86, 13);
            this.alternateEmailsLabel.TabIndex = 18;
            this.alternateEmailsLabel.Text = "Alternate Emails:";

            // 
            // alternateEmailTextBox
            // 
            this.alternateEmailTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.alternateEmailTextBox.Location = new Point(133, 285);
            this.alternateEmailTextBox.Name = "alternateEmailTextBox";
            this.alternateEmailTextBox.Size = new Size(254, 20);
            this.alternateEmailTextBox.TabIndex = 19;
            this.alternateEmailTextBox.KeyDown += new KeyEventHandler(this.AlternateEmailTextBox_KeyDown);

            // 
            // addAlternateEmailButton
            // 
            this.addAlternateEmailButton.Anchor = AnchorStyles.Left;
            this.addAlternateEmailButton.Location = new Point(393, 283);
            this.addAlternateEmailButton.Name = "addAlternateEmailButton";
            this.addAlternateEmailButton.Size = new Size(94, 23);
            this.addAlternateEmailButton.TabIndex = 20;
            this.addAlternateEmailButton.Text = "Add";
            this.addAlternateEmailButton.UseVisualStyleBackColor = true;
            this.addAlternateEmailButton.Click += new EventHandler(this.AddAlternateEmailButton_Click);

            // 
            // alternateEmailsListBox
            // 
            this.alternateEmailsListBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.alternateEmailsListBox.FormattingEnabled = true;
            this.alternateEmailsListBox.Location = new Point(133, 315);
            this.alternateEmailsListBox.Name = "alternateEmailsListBox";
            this.alternateEmailsListBox.Size = new Size(254, 69);
            this.alternateEmailsListBox.TabIndex = 21;

            // 
            // removeAlternateEmailButton
            // 
            this.removeAlternateEmailButton.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.removeAlternateEmailButton.Location = new Point(393, 315);
            this.removeAlternateEmailButton.Name = "removeAlternateEmailButton";
            this.removeAlternateEmailButton.Size = new Size(94, 23);
            this.removeAlternateEmailButton.TabIndex = 22;
            this.removeAlternateEmailButton.Text = "Remove";
            this.removeAlternateEmailButton.UseVisualStyleBackColor = true;
            this.removeAlternateEmailButton.Click += new EventHandler(this.RemoveAlternateEmailButton_Click);

            // 
            // notesLabel
            // 
            this.notesLabel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.notesLabel.AutoSize = true;
            this.notesLabel.Location = new Point(13, 405);
            this.notesLabel.Name = "notesLabel";
            this.notesLabel.Size = new Size(38, 13);
            this.notesLabel.TabIndex = 23;
            this.notesLabel.Text = "Notes:";

            // 
            // notesTextBox
            // 
            this.notesTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.mainTableLayout.SetColumnSpan(this.notesTextBox, 2);
            this.notesTextBox.Location = new Point(133, 405);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.ScrollBars = ScrollBars.Vertical;
            this.notesTextBox.Size = new Size(354, 74);
            this.notesTextBox.TabIndex = 24;

            // 
            // favoriteCheckBox
            // 
            this.favoriteCheckBox.Anchor = AnchorStyles.Left;
            this.favoriteCheckBox.AutoSize = true;
            this.favoriteCheckBox.Location = new Point(133, 491);
            this.favoriteCheckBox.Name = "favoriteCheckBox";
            this.favoriteCheckBox.Size = new Size(65, 17);
            this.favoriteCheckBox.TabIndex = 25;
            this.favoriteCheckBox.Text = "Favorite";
            this.favoriteCheckBox.UseVisualStyleBackColor = true;

            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.saveButton);
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Dock = DockStyle.Bottom;
            this.bottomPanel.Location = new Point(0, 490);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new Size(500, 40);
            this.bottomPanel.TabIndex = 1;

            // 
            // saveButton
            // 
            this.saveButton.Anchor = AnchorStyles.Right;
            this.saveButton.Location = new Point(338, 8);
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
            this.cancelButton.Location = new Point(419, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new EventHandler(this.CancelButton_Click);

            // 
            // ContactForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 530);
            this.Controls.Add(this.mainTableLayout);
            this.Controls.Add(this.bottomPanel);
            this.Name = "ContactForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Contact";

            this.mainTableLayout.ResumeLayout(false);
            this.mainTableLayout.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}