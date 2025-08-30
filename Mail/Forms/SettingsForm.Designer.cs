namespace Mail.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TabControl mainTabControl;
        private TabPage accountsTabPage;
        private ListView accountsListView;
        private Panel accountButtonPanel;
        private Button addAccountButton;
        private Button editAccountButton;
        private Button deleteAccountButton;
        private Button setDefaultButton;
        private Button testConnectionButton;
        private Panel bottomPanel;
        private Button closeButton;

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
            this.accountsTabPage = new TabPage();
            this.accountsListView = new ListView();
            this.accountButtonPanel = new Panel();
            this.addAccountButton = new Button();
            this.editAccountButton = new Button();
            this.deleteAccountButton = new Button();
            this.setDefaultButton = new Button();
            this.testConnectionButton = new Button();
            this.bottomPanel = new Panel();
            this.closeButton = new Button();

            this.mainTabControl.SuspendLayout();
            this.accountsTabPage.SuspendLayout();
            this.accountButtonPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.accountsTabPage);
            this.mainTabControl.Dock = DockStyle.Fill;
            this.mainTabControl.Location = new Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new Size(700, 450);
            this.mainTabControl.TabIndex = 0;

            // 
            // accountsTabPage
            // 
            this.accountsTabPage.Controls.Add(this.accountsListView);
            this.accountsTabPage.Controls.Add(this.accountButtonPanel);
            this.accountsTabPage.Location = new Point(4, 22);
            this.accountsTabPage.Name = "accountsTabPage";
            this.accountsTabPage.Padding = new Padding(3);
            this.accountsTabPage.Size = new Size(692, 384);
            this.accountsTabPage.TabIndex = 0;
            this.accountsTabPage.Text = "Email Accounts";
            this.accountsTabPage.UseVisualStyleBackColor = true;

            // 
            // accountsListView
            // 
            this.accountsListView.Dock = DockStyle.Fill;
            this.accountsListView.FullRowSelect = true;
            this.accountsListView.GridLines = true;
            this.accountsListView.Location = new Point(3, 3);
            this.accountsListView.MultiSelect = false;
            this.accountsListView.Name = "accountsListView";
            this.accountsListView.Size = new Size(686, 338);
            this.accountsListView.TabIndex = 0;
            this.accountsListView.UseCompatibleStateImageBehavior = false;
            this.accountsListView.View = View.Details;

            // Add columns
            this.accountsListView.Columns.Add("Account Name", 150);
            this.accountsListView.Columns.Add("Email Address", 200);
            this.accountsListView.Columns.Add("Type", 100);
            this.accountsListView.Columns.Add("Default", 60);
            this.accountsListView.Columns.Add("Status", 80);

            // 
            // accountButtonPanel
            // 
            this.accountButtonPanel.Controls.Add(this.addAccountButton);
            this.accountButtonPanel.Controls.Add(this.editAccountButton);
            this.accountButtonPanel.Controls.Add(this.deleteAccountButton);
            this.accountButtonPanel.Controls.Add(this.setDefaultButton);
            this.accountButtonPanel.Controls.Add(this.testConnectionButton);
            this.accountButtonPanel.Dock = DockStyle.Bottom;
            this.accountButtonPanel.Location = new Point(3, 341);
            this.accountButtonPanel.Name = "accountButtonPanel";
            this.accountButtonPanel.Size = new Size(686, 40);
            this.accountButtonPanel.TabIndex = 1;

            // 
            // addAccountButton
            // 
            this.addAccountButton.Location = new Point(6, 8);
            this.addAccountButton.Name = "addAccountButton";
            this.addAccountButton.Size = new Size(90, 23);
            this.addAccountButton.TabIndex = 0;
            this.addAccountButton.Text = "Add Account";
            this.addAccountButton.UseVisualStyleBackColor = true;
            this.addAccountButton.Click += new EventHandler(this.AddAccountButton_Click);

            // 
            // editAccountButton
            // 
            this.editAccountButton.Location = new Point(102, 8);
            this.editAccountButton.Name = "editAccountButton";
            this.editAccountButton.Size = new Size(90, 23);
            this.editAccountButton.TabIndex = 1;
            this.editAccountButton.Text = "Edit Account";
            this.editAccountButton.UseVisualStyleBackColor = true;
            this.editAccountButton.Click += new EventHandler(this.EditAccountButton_Click);

            // 
            // deleteAccountButton
            // 
            this.deleteAccountButton.Location = new Point(198, 8);
            this.deleteAccountButton.Name = "deleteAccountButton";
            this.deleteAccountButton.Size = new Size(90, 23);
            this.deleteAccountButton.TabIndex = 2;
            this.deleteAccountButton.Text = "Delete Account";
            this.deleteAccountButton.UseVisualStyleBackColor = true;
            this.deleteAccountButton.Click += new EventHandler(this.DeleteAccountButton_Click);

            // 
            // setDefaultButton
            // 
            this.setDefaultButton.Location = new Point(294, 8);
            this.setDefaultButton.Name = "setDefaultButton";
            this.setDefaultButton.Size = new Size(90, 23);
            this.setDefaultButton.TabIndex = 3;
            this.setDefaultButton.Text = "Set Default";
            this.setDefaultButton.UseVisualStyleBackColor = true;
            this.setDefaultButton.Click += new EventHandler(this.SetDefaultButton_Click);

            // 
            // testConnectionButton
            // 
            this.testConnectionButton.Location = new Point(390, 8);
            this.testConnectionButton.Name = "testConnectionButton";
            this.testConnectionButton.Size = new Size(110, 23);
            this.testConnectionButton.TabIndex = 4;
            this.testConnectionButton.Text = "Test Connection";
            this.testConnectionButton.UseVisualStyleBackColor = true;
            this.testConnectionButton.Click += new EventHandler(this.TestConnectionButton_Click);

            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.closeButton);
            this.bottomPanel.Dock = DockStyle.Bottom;
            this.bottomPanel.Location = new Point(0, 410);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new Size(700, 40);
            this.bottomPanel.TabIndex = 1;

            // 
            // closeButton
            // 
            this.closeButton.Anchor = AnchorStyles.Right;
            this.closeButton.Location = new Point(613, 8);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new EventHandler(this.CloseButton_Click);

            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(700, 450);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.bottomPanel);
            this.Name = "SettingsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Settings";

            this.mainTabControl.ResumeLayout(false);
            this.accountsTabPage.ResumeLayout(false);
            this.accountButtonPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}