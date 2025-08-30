namespace Mail.Forms
{
    partial class CalendarView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel topPanel;
        private Label monthLabel;
        private Button previousMonthButton;
        private Button nextMonthButton;
        private Button todayButton;
        private ComboBox viewComboBox;
        private SplitContainer mainSplitContainer;
        private MonthCalendar monthCalendar;
        private Panel rightPanel;
        private Label selectedDateLabel;
        private ListView eventsListView;
        private Panel eventButtonPanel;
        private Button newEventButton;
        private Button editEventButton;
        private Button deleteEventButton;

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
            this.monthLabel = new Label();
            this.previousMonthButton = new Button();
            this.nextMonthButton = new Button();
            this.todayButton = new Button();
            this.viewComboBox = new ComboBox();
            this.mainSplitContainer = new SplitContainer();
            this.monthCalendar = new MonthCalendar();
            this.rightPanel = new Panel();
            this.selectedDateLabel = new Label();
            this.eventsListView = new ListView();
            this.eventButtonPanel = new Panel();
            this.newEventButton = new Button();
            this.editEventButton = new Button();
            this.deleteEventButton = new Button();

            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.eventButtonPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.viewComboBox);
            this.topPanel.Controls.Add(this.todayButton);
            this.topPanel.Controls.Add(this.nextMonthButton);
            this.topPanel.Controls.Add(this.previousMonthButton);
            this.topPanel.Controls.Add(this.monthLabel);
            this.topPanel.Dock = DockStyle.Top;
            this.topPanel.Location = new Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new Size(800, 40);
            this.topPanel.TabIndex = 0;

            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            this.monthLabel.Location = new Point(12, 12);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new Size(53, 20);
            this.monthLabel.TabIndex = 0;
            this.monthLabel.Text = "Month";

            // 
            // previousMonthButton
            // 
            this.previousMonthButton.Location = new Point(200, 8);
            this.previousMonthButton.Name = "previousMonthButton";
            this.previousMonthButton.Size = new Size(30, 25);
            this.previousMonthButton.TabIndex = 1;
            this.previousMonthButton.Text = "<";
            this.previousMonthButton.UseVisualStyleBackColor = true;
            this.previousMonthButton.Click += new EventHandler(this.PreviousMonthButton_Click);

            // 
            // nextMonthButton
            // 
            this.nextMonthButton.Location = new Point(236, 8);
            this.nextMonthButton.Name = "nextMonthButton";
            this.nextMonthButton.Size = new Size(30, 25);
            this.nextMonthButton.TabIndex = 2;
            this.nextMonthButton.Text = ">";
            this.nextMonthButton.UseVisualStyleBackColor = true;
            this.nextMonthButton.Click += new EventHandler(this.NextMonthButton_Click);

            // 
            // todayButton
            // 
            this.todayButton.Location = new Point(280, 8);
            this.todayButton.Name = "todayButton";
            this.todayButton.Size = new Size(60, 25);
            this.todayButton.TabIndex = 3;
            this.todayButton.Text = "Today";
            this.todayButton.UseVisualStyleBackColor = true;
            this.todayButton.Click += new EventHandler(this.TodayButton_Click);

            // 
            // viewComboBox
            // 
            this.viewComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.viewComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.viewComboBox.FormattingEnabled = true;
            this.viewComboBox.Items.AddRange(new object[] { "Day", "Week", "Month" });
            this.viewComboBox.Location = new Point(700, 10);
            this.viewComboBox.Name = "viewComboBox";
            this.viewComboBox.SelectedIndex = 2;
            this.viewComboBox.Size = new Size(90, 21);
            this.viewComboBox.TabIndex = 4;
            this.viewComboBox.SelectedIndexChanged += new EventHandler(this.ViewComboBox_SelectedIndexChanged);

            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = DockStyle.Fill;
            this.mainSplitContainer.Location = new Point(0, 40);
            this.mainSplitContainer.Name = "mainSplitContainer";
            this.mainSplitContainer.Size = new Size(800, 560);
            this.mainSplitContainer.SplitterDistance = 300;
            this.mainSplitContainer.TabIndex = 1;

            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new Point(12, 12);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;

            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.eventsListView);
            this.rightPanel.Controls.Add(this.eventButtonPanel);
            this.rightPanel.Controls.Add(this.selectedDateLabel);
            this.rightPanel.Dock = DockStyle.Fill;
            this.rightPanel.Location = new Point(0, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Padding = new Padding(10);
            this.rightPanel.Size = new Size(496, 560);
            this.rightPanel.TabIndex = 0;

            // 
            // selectedDateLabel
            // 
            this.selectedDateLabel.Dock = DockStyle.Top;
            this.selectedDateLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            this.selectedDateLabel.Location = new Point(10, 10);
            this.selectedDateLabel.Name = "selectedDateLabel";
            this.selectedDateLabel.Size = new Size(476, 25);
            this.selectedDateLabel.TabIndex = 0;
            this.selectedDateLabel.Text = "Selected Date";

            // 
            // eventsListView
            // 
            this.eventsListView.Dock = DockStyle.Fill;
            this.eventsListView.FullRowSelect = true;
            this.eventsListView.GridLines = true;
            this.eventsListView.Location = new Point(10, 35);
            this.eventsListView.MultiSelect = false;
            this.eventsListView.Name = "eventsListView";
            this.eventsListView.Size = new Size(476, 475);
            this.eventsListView.TabIndex = 1;
            this.eventsListView.UseCompatibleStateImageBehavior = false;
            this.eventsListView.View = View.Details;
            this.eventsListView.DoubleClick += new EventHandler(this.EventsListView_DoubleClick);

            // Add columns
            this.eventsListView.Columns.Add("Time", 120);
            this.eventsListView.Columns.Add("Subject", 200);
            this.eventsListView.Columns.Add("Location", 120);
            this.eventsListView.Columns.Add("Priority", 80);

            // 
            // eventButtonPanel
            // 
            this.eventButtonPanel.Controls.Add(this.newEventButton);
            this.eventButtonPanel.Controls.Add(this.editEventButton);
            this.eventButtonPanel.Controls.Add(this.deleteEventButton);
            this.eventButtonPanel.Dock = DockStyle.Bottom;
            this.eventButtonPanel.Location = new Point(10, 510);
            this.eventButtonPanel.Name = "eventButtonPanel";
            this.eventButtonPanel.Size = new Size(476, 40);
            this.eventButtonPanel.TabIndex = 2;

            // 
            // newEventButton
            // 
            this.newEventButton.Location = new Point(6, 8);
            this.newEventButton.Name = "newEventButton";
            this.newEventButton.Size = new Size(90, 23);
            this.newEventButton.TabIndex = 0;
            this.newEventButton.Text = "New Event";
            this.newEventButton.UseVisualStyleBackColor = true;
            this.newEventButton.Click += new EventHandler(this.NewEventButton_Click);

            // 
            // editEventButton
            // 
            this.editEventButton.Location = new Point(102, 8);
            this.editEventButton.Name = "editEventButton";
            this.editEventButton.Size = new Size(90, 23);
            this.editEventButton.TabIndex = 1;
            this.editEventButton.Text = "Edit Event";
            this.editEventButton.UseVisualStyleBackColor = true;
            this.editEventButton.Click += new EventHandler(this.EditEventButton_Click);

            // 
            // deleteEventButton
            // 
            this.deleteEventButton.Location = new Point(198, 8);
            this.deleteEventButton.Name = "deleteEventButton";
            this.deleteEventButton.Size = new Size(90, 23);
            this.deleteEventButton.TabIndex = 2;
            this.deleteEventButton.Text = "Delete Event";
            this.deleteEventButton.UseVisualStyleBackColor = true;
            this.deleteEventButton.Click += new EventHandler(this.DeleteEventButton_Click);

            // 
            // CalendarView
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.topPanel);
            this.Name = "CalendarView";
            this.Size = new Size(800, 600);

            // Setup layout
            this.mainSplitContainer.Panel1.Controls.Add(this.monthCalendar);
            this.mainSplitContainer.Panel2.Controls.Add(this.rightPanel);

            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.eventButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}