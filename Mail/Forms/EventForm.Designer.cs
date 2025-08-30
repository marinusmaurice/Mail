namespace Mail.Forms
{
    partial class EventForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TabControl mainTabControl;
        private TabPage generalTabPage;
        private TabPage detailsTabPage;
        private TabPage attendeesTabPage;
        
        // General tab controls
        private Label subjectLabel;
        private TextBox subjectTextBox;
        private Label locationLabel;
        private TextBox locationTextBox;
        private Label startTimeLabel;
        private DateTimePicker startDateTimePicker;
        private Label endTimeLabel;
        private DateTimePicker endDateTimePicker;
        private CheckBox allDayCheckBox;
        
        // Details tab controls
        private Label descriptionLabel;
        private TextBox descriptionTextBox;
        private Label organizerLabel;
        private TextBox organizerTextBox;
        private Label categoriesLabel;
        private TextBox categoriesTextBox;
        private Label recurrenceLabel;
        private ComboBox recurrenceComboBox;
        private Label reminderLabel;
        private ComboBox reminderComboBox;
        private Label priorityLabel;
        private ComboBox priorityComboBox;
        private Label statusLabel;
        private ComboBox statusComboBox;
        
        // Attendees tab controls
        private Label attendeeLabel;
        private TextBox attendeeTextBox;
        private Button addAttendeeButton;
        private ListBox attendeesListBox;
        private Button removeAttendeeButton;
        
        // Bottom panel
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
            this.mainTabControl = new TabControl();
            this.generalTabPage = new TabPage();
            this.detailsTabPage = new TabPage();
            this.attendeesTabPage = new TabPage();
            
            // General tab controls
            this.subjectLabel = new Label();
            this.subjectTextBox = new TextBox();
            this.locationLabel = new Label();
            this.locationTextBox = new TextBox();
            this.startTimeLabel = new Label();
            this.startDateTimePicker = new DateTimePicker();
            this.endTimeLabel = new Label();
            this.endDateTimePicker = new DateTimePicker();
            this.allDayCheckBox = new CheckBox();
            
            // Details tab controls
            this.descriptionLabel = new Label();
            this.descriptionTextBox = new TextBox();
            this.organizerLabel = new Label();
            this.organizerTextBox = new TextBox();
            this.categoriesLabel = new Label();
            this.categoriesTextBox = new TextBox();
            this.recurrenceLabel = new Label();
            this.recurrenceComboBox = new ComboBox();
            this.reminderLabel = new Label();
            this.reminderComboBox = new ComboBox();
            this.priorityLabel = new Label();
            this.priorityComboBox = new ComboBox();
            this.statusLabel = new Label();
            this.statusComboBox = new ComboBox();
            
            // Attendees tab controls
            this.attendeeLabel = new Label();
            this.attendeeTextBox = new TextBox();
            this.addAttendeeButton = new Button();
            this.attendeesListBox = new ListBox();
            this.removeAttendeeButton = new Button();
            
            // Bottom panel
            this.bottomPanel = new Panel();
            this.saveButton = new Button();
            this.cancelButton = new Button();

            this.mainTabControl.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.detailsTabPage.SuspendLayout();
            this.attendeesTabPage.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.generalTabPage);
            this.mainTabControl.Controls.Add(this.detailsTabPage);
            this.mainTabControl.Controls.Add(this.attendeesTabPage);
            this.mainTabControl.Dock = DockStyle.Fill;
            this.mainTabControl.Location = new Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new Size(600, 450);
            this.mainTabControl.TabIndex = 0;

            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.allDayCheckBox);
            this.generalTabPage.Controls.Add(this.endDateTimePicker);
            this.generalTabPage.Controls.Add(this.endTimeLabel);
            this.generalTabPage.Controls.Add(this.startDateTimePicker);
            this.generalTabPage.Controls.Add(this.startTimeLabel);
            this.generalTabPage.Controls.Add(this.locationTextBox);
            this.generalTabPage.Controls.Add(this.locationLabel);
            this.generalTabPage.Controls.Add(this.subjectTextBox);
            this.generalTabPage.Controls.Add(this.subjectLabel);
            this.generalTabPage.Location = new Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new Padding(10);
            this.generalTabPage.Size = new Size(592, 384);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;

            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new Point(13, 16);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new Size(46, 13);
            this.subjectLabel.TabIndex = 0;
            this.subjectLabel.Text = "Subject:";

            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.subjectTextBox.Location = new Point(100, 13);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new Size(479, 20);
            this.subjectTextBox.TabIndex = 1;

            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new Point(13, 42);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new Size(51, 13);
            this.locationLabel.TabIndex = 2;
            this.locationLabel.Text = "Location:";

            // 
            // locationTextBox
            // 
            this.locationTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.locationTextBox.Location = new Point(100, 39);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new Size(479, 20);
            this.locationTextBox.TabIndex = 3;

            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new Point(13, 68);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new Size(58, 13);
            this.startTimeLabel.TabIndex = 4;
            this.startTimeLabel.Text = "Start Time:";

            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.startDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.startDateTimePicker.Location = new Point(100, 65);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new Size(200, 20);
            this.startDateTimePicker.TabIndex = 5;

            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new Point(13, 94);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new Size(55, 13);
            this.endTimeLabel.TabIndex = 6;
            this.endTimeLabel.Text = "End Time:";

            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.endDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.endDateTimePicker.Location = new Point(100, 91);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new Size(200, 20);
            this.endDateTimePicker.TabIndex = 7;

            // 
            // allDayCheckBox
            // 
            this.allDayCheckBox.AutoSize = true;
            this.allDayCheckBox.Location = new Point(100, 126);
            this.allDayCheckBox.Name = "allDayCheckBox";
            this.allDayCheckBox.Size = new Size(63, 17);
            this.allDayCheckBox.TabIndex = 8;
            this.allDayCheckBox.Text = "All Day";
            this.allDayCheckBox.UseVisualStyleBackColor = true;
            this.allDayCheckBox.CheckedChanged += new EventHandler(this.AllDayCheckBox_CheckedChanged);

            // 
            // detailsTabPage
            // 
            this.detailsTabPage.Controls.Add(this.statusComboBox);
            this.detailsTabPage.Controls.Add(this.statusLabel);
            this.detailsTabPage.Controls.Add(this.priorityComboBox);
            this.detailsTabPage.Controls.Add(this.priorityLabel);
            this.detailsTabPage.Controls.Add(this.reminderComboBox);
            this.detailsTabPage.Controls.Add(this.reminderLabel);
            this.detailsTabPage.Controls.Add(this.recurrenceComboBox);
            this.detailsTabPage.Controls.Add(this.recurrenceLabel);
            this.detailsTabPage.Controls.Add(this.categoriesTextBox);
            this.detailsTabPage.Controls.Add(this.categoriesLabel);
            this.detailsTabPage.Controls.Add(this.organizerTextBox);
            this.detailsTabPage.Controls.Add(this.organizerLabel);
            this.detailsTabPage.Controls.Add(this.descriptionTextBox);
            this.detailsTabPage.Controls.Add(this.descriptionLabel);
            this.detailsTabPage.Location = new Point(4, 22);
            this.detailsTabPage.Name = "detailsTabPage";
            this.detailsTabPage.Padding = new Padding(10);
            this.detailsTabPage.Size = new Size(592, 384);
            this.detailsTabPage.TabIndex = 1;
            this.detailsTabPage.Text = "Details";
            this.detailsTabPage.UseVisualStyleBackColor = true;

            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new Point(13, 16);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new Size(63, 13);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Description:";

            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.descriptionTextBox.Location = new Point(100, 13);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = ScrollBars.Vertical;
            this.descriptionTextBox.Size = new Size(479, 80);
            this.descriptionTextBox.TabIndex = 1;

            // 
            // organizerLabel
            // 
            this.organizerLabel.AutoSize = true;
            this.organizerLabel.Location = new Point(13, 108);
            this.organizerLabel.Name = "organizerLabel";
            this.organizerLabel.Size = new Size(55, 13);
            this.organizerLabel.TabIndex = 2;
            this.organizerLabel.Text = "Organizer:";

            // 
            // organizerTextBox
            // 
            this.organizerTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.organizerTextBox.Location = new Point(100, 105);
            this.organizerTextBox.Name = "organizerTextBox";
            this.organizerTextBox.Size = new Size(479, 20);
            this.organizerTextBox.TabIndex = 3;

            // 
            // categoriesLabel
            // 
            this.categoriesLabel.AutoSize = true;
            this.categoriesLabel.Location = new Point(13, 134);
            this.categoriesLabel.Name = "categoriesLabel";
            this.categoriesLabel.Size = new Size(60, 13);
            this.categoriesLabel.TabIndex = 4;
            this.categoriesLabel.Text = "Categories:";

            // 
            // categoriesTextBox
            // 
            this.categoriesTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.categoriesTextBox.Location = new Point(100, 131);
            this.categoriesTextBox.Name = "categoriesTextBox";
            this.categoriesTextBox.Size = new Size(479, 20);
            this.categoriesTextBox.TabIndex = 5;

            // 
            // recurrenceLabel
            // 
            this.recurrenceLabel.AutoSize = true;
            this.recurrenceLabel.Location = new Point(13, 160);
            this.recurrenceLabel.Name = "recurrenceLabel";
            this.recurrenceLabel.Size = new Size(64, 13);
            this.recurrenceLabel.TabIndex = 6;
            this.recurrenceLabel.Text = "Recurrence:";

            // 
            // recurrenceComboBox
            // 
            this.recurrenceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.recurrenceComboBox.FormattingEnabled = true;
            this.recurrenceComboBox.Location = new Point(100, 157);
            this.recurrenceComboBox.Name = "recurrenceComboBox";
            this.recurrenceComboBox.Size = new Size(150, 21);
            this.recurrenceComboBox.TabIndex = 7;

            // 
            // reminderLabel
            // 
            this.reminderLabel.AutoSize = true;
            this.reminderLabel.Location = new Point(13, 186);
            this.reminderLabel.Name = "reminderLabel";
            this.reminderLabel.Size = new Size(53, 13);
            this.reminderLabel.TabIndex = 8;
            this.reminderLabel.Text = "Reminder:";

            // 
            // reminderComboBox
            // 
            this.reminderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.reminderComboBox.FormattingEnabled = true;
            this.reminderComboBox.Location = new Point(100, 183);
            this.reminderComboBox.Name = "reminderComboBox";
            this.reminderComboBox.Size = new Size(150, 21);
            this.reminderComboBox.TabIndex = 9;

            // 
            // priorityLabel
            // 
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Location = new Point(13, 212);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new Size(41, 13);
            this.priorityLabel.TabIndex = 10;
            this.priorityLabel.Text = "Priority:";

            // 
            // priorityComboBox
            // 
            this.priorityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.priorityComboBox.FormattingEnabled = true;
            this.priorityComboBox.Location = new Point(100, 209);
            this.priorityComboBox.Name = "priorityComboBox";
            this.priorityComboBox.Size = new Size(150, 21);
            this.priorityComboBox.TabIndex = 11;

            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new Point(13, 238);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new Size(40, 13);
            this.statusLabel.TabIndex = 12;
            this.statusLabel.Text = "Status:";

            // 
            // statusComboBox
            // 
            this.statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new Point(100, 235);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new Size(150, 21);
            this.statusComboBox.TabIndex = 13;

            // 
            // attendeesTabPage
            // 
            this.attendeesTabPage.Controls.Add(this.removeAttendeeButton);
            this.attendeesTabPage.Controls.Add(this.attendeesListBox);
            this.attendeesTabPage.Controls.Add(this.addAttendeeButton);
            this.attendeesTabPage.Controls.Add(this.attendeeTextBox);
            this.attendeesTabPage.Controls.Add(this.attendeeLabel);
            this.attendeesTabPage.Location = new Point(4, 22);
            this.attendeesTabPage.Name = "attendeesTabPage";
            this.attendeesTabPage.Padding = new Padding(10);
            this.attendeesTabPage.Size = new Size(592, 384);
            this.attendeesTabPage.TabIndex = 2;
            this.attendeesTabPage.Text = "Attendees";
            this.attendeesTabPage.UseVisualStyleBackColor = true;

            // 
            // attendeeLabel
            // 
            this.attendeeLabel.AutoSize = true;
            this.attendeeLabel.Location = new Point(13, 16);
            this.attendeeLabel.Name = "attendeeLabel";
            this.attendeeLabel.Size = new Size(74, 13);
            this.attendeeLabel.TabIndex = 0;
            this.attendeeLabel.Text = "Add Attendee:";

            // 
            // attendeeTextBox
            // 
            this.attendeeTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.attendeeTextBox.Location = new Point(100, 13);
            this.attendeeTextBox.Name = "attendeeTextBox";
            this.attendeeTextBox.Size = new Size(379, 20);
            this.attendeeTextBox.TabIndex = 1;
            this.attendeeTextBox.KeyDown += new KeyEventHandler(this.AttendeeTextBox_KeyDown);

            // 
            // addAttendeeButton
            // 
            this.addAttendeeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.addAttendeeButton.Location = new Point(485, 11);
            this.addAttendeeButton.Name = "addAttendeeButton";
            this.addAttendeeButton.Size = new Size(94, 23);
            this.addAttendeeButton.TabIndex = 2;
            this.addAttendeeButton.Text = "Add";
            this.addAttendeeButton.UseVisualStyleBackColor = true;
            this.addAttendeeButton.Click += new EventHandler(this.AddAttendeeButton_Click);

            // 
            // attendeesListBox
            // 
            this.attendeesListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.attendeesListBox.FormattingEnabled = true;
            this.attendeesListBox.Location = new Point(13, 45);
            this.attendeesListBox.Name = "attendeesListBox";
            this.attendeesListBox.Size = new Size(566, 290);
            this.attendeesListBox.TabIndex = 3;

            // 
            // removeAttendeeButton
            // 
            this.removeAttendeeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.removeAttendeeButton.Location = new Point(485, 348);
            this.removeAttendeeButton.Name = "removeAttendeeButton";
            this.removeAttendeeButton.Size = new Size(94, 23);
            this.removeAttendeeButton.TabIndex = 4;
            this.removeAttendeeButton.Text = "Remove";
            this.removeAttendeeButton.UseVisualStyleBackColor = true;
            this.removeAttendeeButton.Click += new EventHandler(this.RemoveAttendeeButton_Click);

            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.saveButton);
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Dock = DockStyle.Bottom;
            this.bottomPanel.Location = new Point(0, 410);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new Size(600, 40);
            this.bottomPanel.TabIndex = 1;

            // 
            // saveButton
            // 
            this.saveButton.Anchor = AnchorStyles.Right;
            this.saveButton.Location = new Point(438, 8);
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
            this.cancelButton.Location = new Point(519, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new EventHandler(this.CancelButton_Click);

            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(600, 450);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.bottomPanel);
            this.Name = "EventForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Event";

            this.mainTabControl.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.generalTabPage.PerformLayout();
            this.detailsTabPage.ResumeLayout(false);
            this.detailsTabPage.PerformLayout();
            this.attendeesTabPage.ResumeLayout(false);
            this.attendeesTabPage.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}