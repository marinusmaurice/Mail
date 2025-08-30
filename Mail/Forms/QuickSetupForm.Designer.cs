namespace Mail.Forms
{
    partial class QuickSetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel mainTableLayout;
        private Label titleLabel;
        private Label subtitleLabel;
        private Label emailLabel;
        private TextBox emailTextBox;
        private Label detectedTypeLabel;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private Label displayNameLabel;
        private TextBox displayNameTextBox;
        private Label nameLabel;
        private TextBox nameTextBox;
        private Label oauthInfoLabel;
        private Label progressLabel;
        private Panel buttonPanel;
        private Button setupButton;
        private Button advancedButton;
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
            this.titleLabel = new Label();
            this.subtitleLabel = new Label();
            this.emailLabel = new Label();
            this.emailTextBox = new TextBox();
            this.detectedTypeLabel = new Label();
            this.passwordLabel = new Label();
            this.passwordTextBox = new TextBox();
            this.displayNameLabel = new Label();
            this.displayNameTextBox = new TextBox();
            this.nameLabel = new Label();
            this.nameTextBox = new TextBox();
            this.oauthInfoLabel = new Label();
            this.progressLabel = new Label();
            this.buttonPanel = new Panel();
            this.setupButton = new Button();
            this.advancedButton = new Button();
            this.cancelButton = new Button();

            this.mainTableLayout.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // mainTableLayout
            // 
            this.mainTableLayout.ColumnCount = 2;
            this.mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            this.mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.mainTableLayout.Controls.Add(this.titleLabel, 0, 0);
            this.mainTableLayout.Controls.Add(this.subtitleLabel, 0, 1);
            this.mainTableLayout.Controls.Add(this.emailLabel, 0, 2);
            this.mainTableLayout.Controls.Add(this.emailTextBox, 1, 2);
            this.mainTableLayout.Controls.Add(this.detectedTypeLabel, 1, 3);
            this.mainTableLayout.Controls.Add(this.passwordLabel, 0, 4);
            this.mainTableLayout.Controls.Add(this.passwordTextBox, 1, 4);
            this.mainTableLayout.Controls.Add(this.displayNameLabel, 0, 5);
            this.mainTableLayout.Controls.Add(this.displayNameTextBox, 1, 5);
            this.mainTableLayout.Controls.Add(this.nameLabel, 0, 6);
            this.mainTableLayout.Controls.Add(this.nameTextBox, 1, 6);
            this.mainTableLayout.Controls.Add(this.oauthInfoLabel, 0, 7);
            this.mainTableLayout.Controls.Add(this.progressLabel, 0, 8);
            this.mainTableLayout.Dock = DockStyle.Fill;
            this.mainTableLayout.Location = new Point(0, 0);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.Padding = new Padding(15);
            this.mainTableLayout.RowCount = 9;
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            this.mainTableLayout.Size = new Size(500, 350);
            this.mainTableLayout.TabIndex = 0;

            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = AnchorStyles.Left;
            this.titleLabel.AutoSize = true;
            this.mainTableLayout.SetColumnSpan(this.titleLabel, 2);
            this.titleLabel.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            this.titleLabel.Location = new Point(18, 23);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new Size(197, 24);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Add Email Account";

            // 
            // subtitleLabel
            // 
            this.subtitleLabel.Anchor = AnchorStyles.Left;
            this.subtitleLabel.AutoSize = true;
            this.mainTableLayout.SetColumnSpan(this.subtitleLabel, 2);
            this.subtitleLabel.ForeColor = Color.Gray;
            this.subtitleLabel.Location = new Point(18, 63);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new Size(272, 13);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Enter your email credentials to get started quickly.";

            // 
            // emailLabel
            // 
            this.emailLabel.Anchor = AnchorStyles.Left;
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new Point(18, 101);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new Size(76, 13);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Email Address:";

            // 
            // emailTextBox
            // 
            this.emailTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.emailTextBox.Location = new Point(138, 98);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new Size(344, 20);
            this.emailTextBox.TabIndex = 3;
            this.emailTextBox.PlaceholderText = "your.email@example.com";

            // 
            // detectedTypeLabel
            // 
            this.detectedTypeLabel.Anchor = AnchorStyles.Left;
            this.detectedTypeLabel.AutoSize = true;
            this.detectedTypeLabel.ForeColor = Color.Blue;
            this.detectedTypeLabel.Location = new Point(138, 131);
            this.detectedTypeLabel.Name = "detectedTypeLabel";
            this.detectedTypeLabel.Size = new Size(55, 13);
            this.detectedTypeLabel.TabIndex = 4;
            this.detectedTypeLabel.Text = "Detected:";
            this.detectedTypeLabel.Visible = false;

            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = AnchorStyles.Left;
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new Point(18, 163);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new Size(56, 13);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "Password:";

            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.passwordTextBox.Location = new Point(138, 160);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new Size(344, 20);
            this.passwordTextBox.TabIndex = 6;

            // 
            // displayNameLabel
            // 
            this.displayNameLabel.Anchor = AnchorStyles.Left;
            this.displayNameLabel.AutoSize = true;
            this.displayNameLabel.Location = new Point(18, 193);
            this.displayNameLabel.Name = "displayNameLabel";
            this.displayNameLabel.Size = new Size(75, 13);
            this.displayNameLabel.TabIndex = 7;
            this.displayNameLabel.Text = "Display Name:";

            // 
            // displayNameTextBox
            // 
            this.displayNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.displayNameTextBox.Location = new Point(138, 190);
            this.displayNameTextBox.Name = "displayNameTextBox";
            this.displayNameTextBox.Size = new Size(344, 20);
            this.displayNameTextBox.TabIndex = 8;
            this.displayNameTextBox.PlaceholderText = "Your Name";

            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = AnchorStyles.Left;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new Point(18, 223);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new Size(81, 13);
            this.nameLabel.TabIndex = 9;
            this.nameLabel.Text = "Account Name:";

            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.nameTextBox.Location = new Point(138, 220);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new Size(344, 20);
            this.nameTextBox.TabIndex = 10;
            this.nameTextBox.PlaceholderText = "Optional - defaults to email address";

            // 
            // oauthInfoLabel
            // 
            this.oauthInfoLabel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.oauthInfoLabel.AutoSize = true;
            this.mainTableLayout.SetColumnSpan(this.oauthInfoLabel, 2);
            this.oauthInfoLabel.ForeColor = Color.DarkGreen;
            this.oauthInfoLabel.Location = new Point(18, 250);
            this.oauthInfoLabel.Name = "oauthInfoLabel";
            this.oauthInfoLabel.Size = new Size(66, 13);
            this.oauthInfoLabel.TabIndex = 11;
            this.oauthInfoLabel.Text = "OAuth Info";
            this.oauthInfoLabel.Visible = false;

            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = AnchorStyles.Left;
            this.progressLabel.AutoSize = true;
            this.mainTableLayout.SetColumnSpan(this.progressLabel, 2);
            this.progressLabel.ForeColor = Color.Blue;
            this.progressLabel.Location = new Point(18, 306);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new Size(54, 13);
            this.progressLabel.TabIndex = 12;
            this.progressLabel.Text = "Progress...";
            this.progressLabel.Visible = false;

            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.setupButton);
            this.buttonPanel.Controls.Add(this.advancedButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Dock = DockStyle.Bottom;
            this.buttonPanel.Location = new Point(0, 310);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new Size(500, 40);
            this.buttonPanel.TabIndex = 1;

            // 
            // setupButton
            // 
            this.setupButton.Anchor = AnchorStyles.Right;
            this.setupButton.BackColor = Color.FromArgb(0, 120, 215);
            this.setupButton.FlatStyle = FlatStyle.Flat;
            this.setupButton.ForeColor = Color.White;
            this.setupButton.Location = new Point(250, 8);
            this.setupButton.Name = "setupButton";
            this.setupButton.Size = new Size(75, 23);
            this.setupButton.TabIndex = 0;
            this.setupButton.Text = "Set Up";
            this.setupButton.UseVisualStyleBackColor = false;
            this.setupButton.Click += new EventHandler(this.SetupButton_Click);

            // 
            // advancedButton
            // 
            this.advancedButton.Anchor = AnchorStyles.Right;
            this.advancedButton.Location = new Point(331, 8);
            this.advancedButton.Name = "advancedButton";
            this.advancedButton.Size = new Size(75, 23);
            this.advancedButton.TabIndex = 1;
            this.advancedButton.Text = "Advanced";
            this.advancedButton.UseVisualStyleBackColor = true;
            this.advancedButton.Click += new EventHandler(this.AdvancedButton_Click);

            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = AnchorStyles.Right;
            this.cancelButton.Location = new Point(412, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new EventHandler(this.CancelButton_Click);

            // 
            // QuickSetupForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 350);
            this.Controls.Add(this.mainTableLayout);
            this.Controls.Add(this.buttonPanel);
            this.Name = "QuickSetupForm";
            this.Text = "Quick Email Setup";

            this.mainTableLayout.ResumeLayout(false);
            this.mainTableLayout.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}