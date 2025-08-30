using Mail.Models;
using Mail.Services;

namespace Mail.Forms
{
    public partial class EventForm : Form
    {
        private CalendarService _calendarService;
        private CalendarEvent? _event;
        private bool _isEditing;

        public EventForm(CalendarService calendarService, CalendarEvent? calendarEvent = null, DateTime? selectedDate = null)
        {
            InitializeComponent();
            _calendarService = calendarService;
            _event = calendarEvent;
            _isEditing = calendarEvent != null;
            
            SetupForm();
            if (_isEditing)
            {
                PopulateFields();
            }
            else if (selectedDate.HasValue)
            {
                startDateTimePicker.Value = selectedDate.Value;
                endDateTimePicker.Value = selectedDate.Value.AddHours(1);
            }
        }

        private void SetupForm()
        {
            this.Text = _isEditing ? "Edit Event" : "New Event";
            
            // Setup combo boxes
            recurrenceComboBox.Items.Clear();
            foreach (EventRecurrence recurrence in Enum.GetValues<EventRecurrence>())
            {
                recurrenceComboBox.Items.Add(recurrence);
            }
            recurrenceComboBox.SelectedIndex = 0;

            reminderComboBox.Items.Clear();
            foreach (EventReminder reminder in Enum.GetValues<EventReminder>())
            {
                reminderComboBox.Items.Add(reminder);
            }
            reminderComboBox.SelectedIndex = 0;

            priorityComboBox.Items.Clear();
            foreach (EventPriority priority in Enum.GetValues<EventPriority>())
            {
                priorityComboBox.Items.Add(priority);
            }
            priorityComboBox.SelectedIndex = 1; // Normal

            statusComboBox.Items.Clear();
            foreach (EventStatus status in Enum.GetValues<EventStatus>())
            {
                statusComboBox.Items.Add(status);
            }
            statusComboBox.SelectedIndex = 1; // Busy

            // Set default times
            if (!_isEditing)
            {
                var now = DateTime.Now;
                var roundedTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
                startDateTimePicker.Value = roundedTime;
                endDateTimePicker.Value = roundedTime.AddHours(1);
            }
        }

        private void PopulateFields()
        {
            if (_event == null) return;

            subjectTextBox.Text = _event.Subject;
            locationTextBox.Text = _event.Location;
            descriptionTextBox.Text = _event.Description;
            organizerTextBox.Text = _event.Organizer;
            categoriesTextBox.Text = _event.Categories;
            
            startDateTimePicker.Value = _event.StartTime;
            endDateTimePicker.Value = _event.EndTime;
            allDayCheckBox.Checked = _event.IsAllDay;
            
            recurrenceComboBox.SelectedItem = _event.Recurrence;
            reminderComboBox.SelectedItem = _event.Reminder;
            priorityComboBox.SelectedItem = _event.Priority;
            statusComboBox.SelectedItem = _event.Status;

            // Populate attendees
            attendeesListBox.Items.Clear();
            foreach (var attendee in _event.Attendees)
            {
                attendeesListBox.Items.Add(attendee);
            }
        }

        private void AllDayCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            // Enable/disable time portion of date pickers
            startDateTimePicker.ShowUpDown = !allDayCheckBox.Checked;
            endDateTimePicker.ShowUpDown = !allDayCheckBox.Checked;
            
            if (allDayCheckBox.Checked)
            {
                startDateTimePicker.Format = DateTimePickerFormat.Short;
                endDateTimePicker.Format = DateTimePickerFormat.Short;
            }
            else
            {
                startDateTimePicker.Format = DateTimePickerFormat.Custom;
                startDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
                endDateTimePicker.Format = DateTimePickerFormat.Custom;
                endDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            }
        }

        private void AddAttendeeButton_Click(object? sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(attendeeTextBox.Text))
            {
                attendeesListBox.Items.Add(attendeeTextBox.Text);
                attendeeTextBox.Clear();
            }
        }

        private void RemoveAttendeeButton_Click(object? sender, EventArgs e)
        {
            if (attendeesListBox.SelectedItem != null)
            {
                attendeesListBox.Items.Remove(attendeesListBox.SelectedItem);
            }
        }

        private void AttendeeTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddAttendeeButton_Click(sender, e);
                e.Handled = true;
            }
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var calendarEvent = _event ?? new CalendarEvent();
                
                calendarEvent.Subject = subjectTextBox.Text;
                calendarEvent.Location = locationTextBox.Text;
                calendarEvent.Description = descriptionTextBox.Text;
                calendarEvent.Organizer = organizerTextBox.Text;
                calendarEvent.Categories = categoriesTextBox.Text;
                
                calendarEvent.StartTime = startDateTimePicker.Value;
                calendarEvent.EndTime = endDateTimePicker.Value;
                calendarEvent.IsAllDay = allDayCheckBox.Checked;
                
                calendarEvent.Recurrence = (EventRecurrence)recurrenceComboBox.SelectedItem!;
                calendarEvent.Reminder = (EventReminder)reminderComboBox.SelectedItem!;
                calendarEvent.Priority = (EventPriority)priorityComboBox.SelectedItem!;
                calendarEvent.Status = (EventStatus)statusComboBox.SelectedItem!;

                // Update attendees
                calendarEvent.Attendees.Clear();
                foreach (string attendee in attendeesListBox.Items)
                {
                    calendarEvent.Attendees.Add(attendee);
                }

                if (_isEditing)
                {
                    _calendarService.UpdateEvent(calendarEvent);
                }
                else
                {
                    _calendarService.AddEvent(calendarEvent);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(subjectTextBox.Text))
            {
                MessageBox.Show("Please enter a subject for the event.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                subjectTextBox.Focus();
                return false;
            }

            if (endDateTimePicker.Value <= startDateTimePicker.Value)
            {
                MessageBox.Show("End time must be after start time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                endDateTimePicker.Focus();
                return false;
            }

            return true;
        }
    }
}