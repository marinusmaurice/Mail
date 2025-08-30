namespace Mail.Forms
{
    partial class AccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TabControl mainTabControl;
        private TabPage generalTabPage;
        private TabPage incomingTabPage;
        private TabPage outgoingTabPage;
        
        // General tab controls
        private Label accountNameLabel;
        private TextBox accountNameTextBox;
        private Label emailAddressLabel;
        private TextBox emailAddressTextBox;
        private Label displayNameLabel;
        private TextBox displayNameTextBox;
        private Label accountTypeLabel;
        private ComboBox accountTypeComboBox;
        private CheckBox isDefaultCheckBox;
        private CheckBox isEnabledCheckBox;
        
        // Incoming server tab controls
        private Label incomingServerLabel;
        private TextBox incomingServerTextBox;
        private Label incomingPortLabel;
        private NumericUpDown incomingPortNumeric;
        private Label incomingUsernameLabel;
        private TextBox incomingUsernameTextBox;
        private Label incomingPasswordLabel;
        private TextBox incomingPasswordTextBox;
        private CheckBox incomingSSLCheckBox;
        private Label incomingAuthLabel;
        private ComboBox incomingAuthComboBox;
        
        // Outgoing server tab controls
        private Label outgoingServerLabel;
        private TextBox outgoingServerTextBox;
        private Label outgoingPortLabel;
        private NumericUpDown outgoingPortNumeric;
        private Label outgoingUsernameLabel;
        private TextBox outgoingUsernameTextBox;
        private Label outgoingPasswordLabel;
        private TextBox outgoingPasswordTextBox;
        private CheckBox outgoingSSLCheckBox;
        private Label outgoingAuthLabel;
        private ComboBox outgoingAuthComboBox;
        
        // Bottom panel
        private Panel bottomPanel;
        private Button okButton;
        private Button cancelButton;
        private Button testConnectionButton;

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
            this.mainTabControl = new TabControl();
            this.generalTabPage = new TabPage();
            this.incomingTabPage = new TabPage();
            this.outgoingTabPage = new TabPage();
            
            // General tab controls
            this.accountNameLabel = new Label();
            this.accountNameTextBox = new TextBox();
            this.emailAddressLabel = new Label();
            this.emailAddressTextBox = new TextBox();
            this.displayNameLabel = new Label();
            this.displayNameTextBox = new TextBox();
            this.accountTypeLabel = new Label();
            this.accountTypeComboBox = new ComboBox();
            this.isDefaultCheckBox = new CheckBox();
            this.isEnabledCheckBox = new CheckBox();
            
            // Incoming server tab controls
            this.incomingServerLabel = new Label();
            this.incomingServerTextBox = new TextBox();
            this.incomingPortLabel = new Label();
            this.incomingPortNumeric = new NumericUpDown();
            this.incomingUsernameLabel = new Label();
            this.incomingUsernameTextBox = new TextBox();
            this.incomingPasswordLabel = new Label();
            this.incomingPasswordTextBox = new TextBox();
            this.incomingSSLCheckBox = new CheckBox();
            this.incomingAuthLabel = new Label();
            this.incomingAuthComboBox = new ComboBox();
            
            // Outgoing server tab controls
            this.outgoingServerLabel = new Label();
            this.outgoingServerTextBox = new TextBox();
            this.outgoingPortLabel = new Label();
            this.outgoingPortNumeric = new NumericUpDown();
            this.outgoingUsernameLabel = new Label();
            this.outgoingUsernameTextBox = new TextBox();
            this.outgoingPasswordLabel = new Label();
            this.outgoingPasswordTextBox = new TextBox();
            this.outgoingSSLCheckBox = new CheckBox();
            this.outgoingAuthLabel = new Label();
            this.outgoingAuthComboBox = new ComboBox();
            
            // Bottom panel
            this.bottomPanel = new Panel();
            this.okButton = new Button();
            this.cancelButton = new Button();
            this.testConnectionButton = new Button();

            this.mainTabControl.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.incomingTabPage.SuspendLayout();
            this.outgoingTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.incomingPortNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outgoingPortNumeric)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.generalTabPage);
            this.mainTabControl.Controls.Add(this.incomingTabPage);
            this.mainTabControl.Controls.Add(this.outgoingTabPage);
            this.mainTabControl.Dock = DockStyle.Fill;
            this.mainTabControl.Location = new Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new Size(500, 400);
            this.mainTabControl.TabIndex = 0;

            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.isEnabledCheckBox);
            this.generalTabPage.Controls.Add(this.isDefaultCheckBox);
            this.generalTabPage.Controls.Add(this.accountTypeComboBox);
            this.generalTabPage.Controls.Add(this.accountTypeLabel);
            this.generalTabPage.Controls.Add(this.displayNameTextBox);
            this.generalTabPage.Controls.Add(this.displayNameLabel);
            this.generalTabPage.Controls.Add(this.emailAddressTextBox);
            this.generalTabPage.Controls.Add(this.emailAddressLabel);
            this.generalTabPage.Controls.Add(this.accountNameTextBox);
            this.generalTabPage.Controls.Add(this.accountNameLabel);
            this.generalTabPage.Location = new Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new Padding(10);
            this.generalTabPage.Size = new Size(492, 334);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;

            // 
            // accountNameLabel
            // 
            this.accountNameLabel.AutoSize = true;
            this.accountNameLabel.Location = new Point(13, 16);
            this.accountNameLabel.Name = "accountNameLabel";
            this.accountNameLabel.Size = new Size(81, 13);
            this.accountNameLabel.TabIndex = 0;
            this.accountNameLabel.Text = "Account Name:";

            // 
            // accountNameTextBox
            // 
            this.accountNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.accountNameTextBox.Location = new Point(120, 13);
            this.accountNameTextBox.Name = "accountNameTextBox";
            this.accountNameTextBox.Size = new Size(359, 20);
            this.accountNameTextBox.TabIndex = 1;

            // 
            // emailAddressLabel
            // 
            this.emailAddressLabel.AutoSize = true;
            this.emailAddressLabel.Location = new Point(13, 42);
            this.emailAddressLabel.Name = "emailAddressLabel";
            this.emailAddressLabel.Size = new Size(76, 13);
            this.emailAddressLabel.TabIndex = 2;
            this.emailAddressLabel.Text = "Email Address:";

            // 
            // emailAddressTextBox
            // 
            this.emailAddressTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.emailAddressTextBox.Location = new Point(120, 39);
            this.emailAddressTextBox.Name = "emailAddressTextBox";
            this.emailAddressTextBox.Size = new Size(359, 20);
            this.emailAddressTextBox.TabIndex = 3;

            // 
            // displayNameLabel
            // 
            this.displayNameLabel.AutoSize = true;
            this.displayNameLabel.Location = new Point(13, 68);
            this.displayNameLabel.Name = "displayNameLabel";
            this.displayNameLabel.Size = new Size(75, 13);
            this.displayNameLabel.TabIndex = 4;
            this.displayNameLabel.Text = "Display Name:";

            // 
            // displayNameTextBox
            // 
            this.displayNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.displayNameTextBox.Location = new Point(120, 65);
            this.displayNameTextBox.Name = "displayNameTextBox";
            this.displayNameTextBox.Size = new Size(359, 20);
            this.displayNameTextBox.TabIndex = 5;

            // 
            // accountTypeLabel
            // 
            this.accountTypeLabel.AutoSize = true;
            this.accountTypeLabel.Location = new Point(13, 95);
            this.accountTypeLabel.Name = "accountTypeLabel";
            this.accountTypeLabel.Size = new Size(77, 13);
            this.accountTypeLabel.TabIndex = 6;
            this.accountTypeLabel.Text = "Account Type:";

            // 
            // accountTypeComboBox
            // 
            this.accountTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.accountTypeComboBox.FormattingEnabled = true;
            this.accountTypeComboBox.Location = new Point(120, 92);
            this.accountTypeComboBox.Name = "accountTypeComboBox";
            this.accountTypeComboBox.Size = new Size(200, 21);
            this.accountTypeComboBox.TabIndex = 7;

            // 
            // isDefaultCheckBox
            // 
            this.isDefaultCheckBox.AutoSize = true;
            this.isDefaultCheckBox.Location = new Point(120, 130);
            this.isDefaultCheckBox.Name = "isDefaultCheckBox";
            this.isDefaultCheckBox.Size = new Size(137, 17);
            this.isDefaultCheckBox.TabIndex = 8;
            this.isDefaultCheckBox.Text = "Make default account";
            this.isDefaultCheckBox.UseVisualStyleBackColor = true;

            // 
            // isEnabledCheckBox
            // 
            this.isEnabledCheckBox.AutoSize = true;
            this.isEnabledCheckBox.Checked = true;
            this.isEnabledCheckBox.CheckState = CheckState.Checked;
            this.isEnabledCheckBox.Location = new Point(120, 153);
            this.isEnabledCheckBox.Name = "isEnabledCheckBox";
            this.isEnabledCheckBox.Size = new Size(65, 17);
            this.isEnabledCheckBox.TabIndex = 9;
            this.isEnabledCheckBox.Text = "Enabled";
            this.isEnabledCheckBox.UseVisualStyleBackColor = true;

            // 
            // incomingTabPage
            // 
            this.incomingTabPage.Controls.Add(this.incomingAuthComboBox);
            this.incomingTabPage.Controls.Add(this.incomingAuthLabel);
            this.incomingTabPage.Controls.Add(this.incomingSSLCheckBox);
            this.incomingTabPage.Controls.Add(this.incomingPasswordTextBox);
            this.incomingTabPage.Controls.Add(this.incomingPasswordLabel);
            this.incomingTabPage.Controls.Add(this.incomingUsernameTextBox);
            this.incomingTabPage.Controls.Add(this.incomingUsernameLabel);
            this.incomingTabPage.Controls.Add(this.incomingPortNumeric);
            this.incomingTabPage.Controls.Add(this.incomingPortLabel);
            this.incomingTabPage.Controls.Add(this.incomingServerTextBox);
            this.incomingTabPage.Controls.Add(this.incomingServerLabel);
            this.incomingTabPage.Location = new Point(4, 22);
            this.incomingTabPage.Name = "incomingTabPage";
            this.incomingTabPage.Padding = new Padding(10);
            this.incomingTabPage.Size = new Size(492, 334);
            this.incomingTabPage.TabIndex = 1;
            this.incomingTabPage.Text = "Incoming Server";
            this.incomingTabPage.UseVisualStyleBackColor = true;

            // 
            // incomingServerLabel
            // 
            this.incomingServerLabel.AutoSize = true;
            this.incomingServerLabel.Location = new Point(13, 16);
            this.incomingServerLabel.Name = "incomingServerLabel";
            this.incomingServerLabel.Size = new Size(41, 13);
            this.incomingServerLabel.TabIndex = 0;
            this.incomingServerLabel.Text = "Server:";

            // 
            // incomingServerTextBox
            // 
            this.incomingServerTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.incomingServerTextBox.Location = new Point(120, 13);
            this.incomingServerTextBox.Name = "incomingServerTextBox";
            this.incomingServerTextBox.Size = new Size(359, 20);
            this.incomingServerTextBox.TabIndex = 1;

            // 
            // incomingPortLabel
            // 
            this.incomingPortLabel.AutoSize = true;
            this.incomingPortLabel.Location = new Point(13, 42);
            this.incomingPortLabel.Name = "incomingPortLabel";
            this.incomingPortLabel.Size = new Size(29, 13);
            this.incomingPortLabel.TabIndex = 2;
            this.incomingPortLabel.Text = "Port:";

            // 
            // incomingPortNumeric
            // 
            this.incomingPortNumeric.Location = new Point(120, 40);
            this.incomingPortNumeric.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.incomingPortNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.incomingPortNumeric.Name = "incomingPortNumeric";
            this.incomingPortNumeric.Size = new Size(100, 20);
            this.incomingPortNumeric.TabIndex = 3;
            this.incomingPortNumeric.Value = new decimal(new int[] { 993, 0, 0, 0 });

            // 
            // incomingUsernameLabel
            // 
            this.incomingUsernameLabel.AutoSize = true;
            this.incomingUsernameLabel.Location = new Point(13, 68);
            this.incomingUsernameLabel.Name = "incomingUsernameLabel";
            this.incomingUsernameLabel.Size = new Size(58, 13);
            this.incomingUsernameLabel.TabIndex = 4;
            this.incomingUsernameLabel.Text = "Username:";

            // 
            // incomingUsernameTextBox
            // 
            this.incomingUsernameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.incomingUsernameTextBox.Location = new Point(120, 65);
            this.incomingUsernameTextBox.Name = "incomingUsernameTextBox";
            this.incomingUsernameTextBox.Size = new Size(359, 20);
            this.incomingUsernameTextBox.TabIndex = 5;

            // 
            // incomingPasswordLabel
            // 
            this.incomingPasswordLabel.AutoSize = true;
            this.incomingPasswordLabel.Location = new Point(13, 94);
            this.incomingPasswordLabel.Name = "incomingPasswordLabel";
            this.incomingPasswordLabel.Size = new Size(56, 13);
            this.incomingPasswordLabel.TabIndex = 6;
            this.incomingPasswordLabel.Text = "Password:";

            // 
            // incomingPasswordTextBox
            // 
            this.incomingPasswordTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.incomingPasswordTextBox.Location = new Point(120, 91);
            this.incomingPasswordTextBox.Name = "incomingPasswordTextBox";
            this.incomingPasswordTextBox.PasswordChar = '*';
            this.incomingPasswordTextBox.Size = new Size(359, 20);
            this.incomingPasswordTextBox.TabIndex = 7;

            // 
            // incomingSSLCheckBox
            // 
            this.incomingSSLCheckBox.AutoSize = true;
            this.incomingSSLCheckBox.Checked = true;
            this.incomingSSLCheckBox.CheckState = CheckState.Checked;
            this.incomingSSLCheckBox.Location = new Point(120, 126);
            this.incomingSSLCheckBox.Name = "incomingSSLCheckBox";
            this.incomingSSLCheckBox.Size = new Size(69, 17);
            this.incomingSSLCheckBox.TabIndex = 8;
            this.incomingSSLCheckBox.Text = "Use SSL";
            this.incomingSSLCheckBox.UseVisualStyleBackColor = true;

            // 
            // incomingAuthLabel
            // 
            this.incomingAuthLabel.AutoSize = true;
            this.incomingAuthLabel.Location = new Point(13, 152);
            this.incomingAuthLabel.Name = "incomingAuthLabel";
            this.incomingAuthLabel.Size = new Size(78, 13);
            this.incomingAuthLabel.TabIndex = 9;
            this.incomingAuthLabel.Text = "Authentication:";

            // 
            // incomingAuthComboBox
            // 
            this.incomingAuthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.incomingAuthComboBox.FormattingEnabled = true;
            this.incomingAuthComboBox.Location = new Point(120, 149);
            this.incomingAuthComboBox.Name = "incomingAuthComboBox";
            this.incomingAuthComboBox.Size = new Size(200, 21);
            this.incomingAuthComboBox.TabIndex = 10;

            // 
            // outgoingTabPage
            // 
            this.outgoingTabPage.Controls.Add(this.outgoingAuthComboBox);
            this.outgoingTabPage.Controls.Add(this.outgoingAuthLabel);
            this.outgoingTabPage.Controls.Add(this.outgoingSSLCheckBox);
            this.outgoingTabPage.Controls.Add(this.outgoingPasswordTextBox);
            this.outgoingTabPage.Controls.Add(this.outgoingPasswordLabel);
            this.outgoingTabPage.Controls.Add(this.outgoingUsernameTextBox);
            this.outgoingTabPage.Controls.Add(this.outgoingUsernameLabel);
            this.outgoingTabPage.Controls.Add(this.outgoingPortNumeric);
            this.outgoingTabPage.Controls.Add(this.outgoingPortLabel);
            this.outgoingTabPage.Controls.Add(this.outgoingServerTextBox);
            this.outgoingTabPage.Controls.Add(this.outgoingServerLabel);
            this.outgoingTabPage.Location = new Point(4, 22);
            this.outgoingTabPage.Name = "outgoingTabPage";
            this.outgoingTabPage.Padding = new Padding(10);
            this.outgoingTabPage.Size = new Size(492, 334);
            this.outgoingTabPage.TabIndex = 2;
            this.outgoingTabPage.Text = "Outgoing Server";
            this.outgoingTabPage.UseVisualStyleBackColor = true;

            // 
            // outgoingServerLabel
            // 
            this.outgoingServerLabel.AutoSize = true;
            this.outgoingServerLabel.Location = new Point(13, 16);
            this.outgoingServerLabel.Name = "outgoingServerLabel";
            this.outgoingServerLabel.Size = new Size(41, 13);
            this.outgoingServerLabel.TabIndex = 0;
            this.outgoingServerLabel.Text = "Server:";

            // 
            // outgoingServerTextBox
            // 
            this.outgoingServerTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.outgoingServerTextBox.Location = new Point(120, 13);
            this.outgoingServerTextBox.Name = "outgoingServerTextBox";
            this.outgoingServerTextBox.Size = new Size(359, 20);
            this.outgoingServerTextBox.TabIndex = 1;

            // 
            // outgoingPortLabel
            // 
            this.outgoingPortLabel.AutoSize = true;
            this.outgoingPortLabel.Location = new Point(13, 42);
            this.outgoingPortLabel.Name = "outgoingPortLabel";
            this.outgoingPortLabel.Size = new Size(29, 13);
            this.outgoingPortLabel.TabIndex = 2;
            this.outgoingPortLabel.Text = "Port:";

            // 
            // outgoingPortNumeric
            // 
            this.outgoingPortNumeric.Location = new Point(120, 40);
            this.outgoingPortNumeric.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.outgoingPortNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.outgoingPortNumeric.Name = "outgoingPortNumeric";
            this.outgoingPortNumeric.Size = new Size(100, 20);
            this.outgoingPortNumeric.TabIndex = 3;
            this.outgoingPortNumeric.Value = new decimal(new int[] { 587, 0, 0, 0 });

            // 
            // outgoingUsernameLabel
            // 
            this.outgoingUsernameLabel.AutoSize = true;
            this.outgoingUsernameLabel.Location = new Point(13, 68);
            this.outgoingUsernameLabel.Name = "outgoingUsernameLabel";
            this.outgoingUsernameLabel.Size = new Size(58, 13);
            this.outgoingUsernameLabel.TabIndex = 4;
            this.outgoingUsernameLabel.Text = "Username:";

            // 
            // outgoingUsernameTextBox
            // 
            this.outgoingUsernameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.outgoingUsernameTextBox.Location = new Point(120, 65);
            this.outgoingUsernameTextBox.Name = "outgoingUsernameTextBox";
            this.outgoingUsernameTextBox.Size = new Size(359, 20);
            this.outgoingUsernameTextBox.TabIndex = 5;

            // 
            // outgoingPasswordLabel
            // 
            this.outgoingPasswordLabel.AutoSize = true;
            this.outgoingPasswordLabel.Location = new Point(13, 94);
            this.outgoingPasswordLabel.Name = "outgoingPasswordLabel";
            this.outgoingPasswordLabel.Size = new Size(56, 13);
            this.outgoingPasswordLabel.TabIndex = 6;
            this.outgoingPasswordLabel.Text = "Password:";

            // 
            // outgoingPasswordTextBox
            // 
            this.outgoingPasswordTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.outgoingPasswordTextBox.Location = new Point(120, 91);
            this.outgoingPasswordTextBox.Name = "outgoingPasswordTextBox";
            this.outgoingPasswordTextBox.PasswordChar = '*';
            this.outgoingPasswordTextBox.Size = new Size(359, 20);
            this.outgoingPasswordTextBox.TabIndex = 7;

            // 
            // outgoingSSLCheckBox
            // 
            this.outgoingSSLCheckBox.AutoSize = true;
            this.outgoingSSLCheckBox.Checked = true;
            this.outgoingSSLCheckBox.CheckState = CheckState.Checked;
            this.outgoingSSLCheckBox.Location = new Point(120, 126);
            this.outgoingSSLCheckBox.Name = "outgoingSSLCheckBox";
            this.outgoingSSLCheckBox.Size = new Size(69, 17);
            this.outgoingSSLCheckBox.TabIndex = 8;
            this.outgoingSSLCheckBox.Text = "Use SSL";
            this.outgoingSSLCheckBox.UseVisualStyleBackColor = true;

            // 
            // outgoingAuthLabel
            // 
            this.outgoingAuthLabel.AutoSize = true;
            this.outgoingAuthLabel.Location = new Point(13, 152);
            this.outgoingAuthLabel.Name = "outgoingAuthLabel";
            this.outgoingAuthLabel.Size = new Size(78, 13);
            this.outgoingAuthLabel.TabIndex = 9;
            this.outgoingAuthLabel.Text = "Authentication:";

            // 
            // outgoingAuthComboBox
            // 
            this.outgoingAuthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.outgoingAuthComboBox.FormattingEnabled = true;
            this.outgoingAuthComboBox.Location = new Point(120, 149);
            this.outgoingAuthComboBox.Name = "outgoingAuthComboBox";
            this.outgoingAuthComboBox.Size = new Size(200, 21);
            this.outgoingAuthComboBox.TabIndex = 10;

            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.testConnectionButton);
            this.bottomPanel.Controls.Add(this.okButton);
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Dock = DockStyle.Bottom;
            this.bottomPanel.Location = new Point(0, 360);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new Size(500, 40);
            this.bottomPanel.TabIndex = 1;

            // 
            // testConnectionButton
            // 
            this.testConnectionButton.Location = new Point(12, 8);
            this.testConnectionButton.Name = "testConnectionButton";
            this.testConnectionButton.Size = new Size(110, 23);
            this.testConnectionButton.TabIndex = 0;
            this.testConnectionButton.Text = "Test Connection";
            this.testConnectionButton.UseVisualStyleBackColor = true;
            this.testConnectionButton.Click += new EventHandler(this.TestConnectionButton_Click);

            // 
            // okButton
            // 
            this.okButton.Anchor = AnchorStyles.Right;
            this.okButton.Location = new Point(332, 8);
            this.okButton.Name = "okButton";
            this.okButton.Size = new Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new EventHandler(this.OkButton_Click);

            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = AnchorStyles.Right;
            this.cancelButton.Location = new Point(413, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new EventHandler(this.CancelButton_Click);

            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 400);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.bottomPanel);
            this.Name = "AccountForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Account";

            this.mainTabControl.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.generalTabPage.PerformLayout();
            this.incomingTabPage.ResumeLayout(false);
            this.incomingTabPage.PerformLayout();
            this.outgoingTabPage.ResumeLayout(false);
            this.outgoingTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.incomingPortNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outgoingPortNumeric)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}