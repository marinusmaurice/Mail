using Mail.Models;
using Mail.Services;
using System.ComponentModel;

namespace Mail.Forms
{
    public partial class CalendarView : UserControl
    {
        private CalendarService? _calendarService;
        private DateTime _currentDate = DateTime.Now;
        private DateTime _selectedDate = DateTime.Now;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CalendarService? CalendarService
        {
            get => _calendarService;
            set
            {
                _calendarService = value;
                RefreshCalendar();
            }
        }

        public CalendarView()
        {
            InitializeComponent();
            SetupCalendar();
        }

        public CalendarView(CalendarService calendarService) : this()
        {
            _calendarService = calendarService;
            RefreshCalendar();
        }

        private void SetupCalendar()
        {
            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.DateSelected += MonthCalendar_DateSelected;
            monthCalendar.DateChanged += MonthCalendar_DateChanged;
            
            UpdateMonthLabel();
            LoadEventsForDate(_selectedDate);
        }

        private void MonthCalendar_DateSelected(object? sender, DateRangeEventArgs e)
        {
            _selectedDate = e.Start;
            LoadEventsForDate(_selectedDate);
            UpdateSelectedDateLabel();
        }

        private void MonthCalendar_DateChanged(object? sender, DateRangeEventArgs e)
        {
            _currentDate = e.Start;
            UpdateMonthLabel();
            RefreshCalendar();
        }

        private void UpdateMonthLabel()
        {
            monthLabel.Text = _currentDate.ToString("MMMM yyyy");
        }

        private void UpdateSelectedDateLabel()
        {
            selectedDateLabel.Text = _selectedDate.ToString("dddd, MMMM d, yyyy");
        }

        private void RefreshCalendar()
        {
            if (_calendarService == null) return;
            
            // Get events for the current month
            var monthEvents = _calendarService.GetEventsForMonth(_currentDate.Year, _currentDate.Month);
            
            // Highlight dates with events
            var eventDates = monthEvents.Select(e => e.StartTime.Date).Distinct().ToArray();
            monthCalendar.BoldedDates = eventDates;
            
            LoadEventsForDate(_selectedDate);
        }

        private void LoadEventsForDate(DateTime date)
        {
            if (_calendarService == null) return;

            eventsListView.Items.Clear();
            var events = _calendarService.GetEventsForDate(date);

            foreach (var evt in events.OrderBy(e => e.StartTime))
            {
                var item = new ListViewItem();
                item.Tag = evt;
                
                var timeText = evt.IsAllDay ? "All Day" : $"{evt.StartTime:h:mm tt} - {evt.EndTime:h:mm tt}";
                item.Text = timeText;
                item.SubItems.Add(evt.Subject);
                item.SubItems.Add(evt.Location);
                item.SubItems.Add(evt.Priority.ToString());

                // Color coding for priority
                switch (evt.Priority)
                {
                    case EventPriority.High:
                        item.ForeColor = Color.Red;
                        break;
                    case EventPriority.Low:
                        item.ForeColor = Color.Gray;
                        break;
                    default:
                        item.ForeColor = Color.Black;
                        break;
                }

                eventsListView.Items.Add(item);
            }
        }

        private void NewEventButton_Click(object? sender, EventArgs e)
        {
            if (_calendarService == null) return;

            var eventForm = new EventForm(_calendarService, null, _selectedDate);
            if (eventForm.ShowDialog() == DialogResult.OK)
            {
                RefreshCalendar();
            }
        }

        private void EditEventButton_Click(object? sender, EventArgs e)
        {
            if (_calendarService == null || eventsListView.SelectedItems.Count == 0) return;

            var selectedEvent = eventsListView.SelectedItems[0].Tag as CalendarEvent;
            if (selectedEvent != null)
            {
                var eventForm = new EventForm(_calendarService, selectedEvent);
                if (eventForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshCalendar();
                }
            }
        }

        private void DeleteEventButton_Click(object? sender, EventArgs e)
        {
            if (_calendarService == null || eventsListView.SelectedItems.Count == 0) return;

            var selectedEvent = eventsListView.SelectedItems[0].Tag as CalendarEvent;
            if (selectedEvent != null)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete the event '{selectedEvent.Subject}'?",
                    "Delete Event",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _calendarService.DeleteEvent(selectedEvent);
                    RefreshCalendar();
                }
            }
        }

        private void PreviousMonthButton_Click(object? sender, EventArgs e)
        {
            _currentDate = _currentDate.AddMonths(-1);
            monthCalendar.SelectionStart = _currentDate;
            UpdateMonthLabel();
            RefreshCalendar();
        }

        private void NextMonthButton_Click(object? sender, EventArgs e)
        {
            _currentDate = _currentDate.AddMonths(1);
            monthCalendar.SelectionStart = _currentDate;
            UpdateMonthLabel();
            RefreshCalendar();
        }

        private void TodayButton_Click(object? sender, EventArgs e)
        {
            _currentDate = DateTime.Now;
            _selectedDate = DateTime.Now;
            monthCalendar.SelectionStart = _currentDate;
            UpdateMonthLabel();
            UpdateSelectedDateLabel();
            RefreshCalendar();
        }

        private void EventsListView_DoubleClick(object? sender, EventArgs e)
        {
            EditEventButton_Click(sender, e);
        }

        private void ViewComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_calendarService == null) return;

            // Handle different calendar view modes (Day, Week, Month)
            switch (viewComboBox.SelectedIndex)
            {
                case 0: // Day view
                    ShowDayView();
                    break;
                case 1: // Week view
                    ShowWeekView();
                    break;
                case 2: // Month view
                    ShowMonthView();
                    break;
            }
        }

        private void ShowDayView()
        {
            // Focus on single day events
            LoadEventsForDate(_selectedDate);
        }

        private void ShowWeekView()
        {
            if (_calendarService == null) return;

            // Show events for the week containing the selected date
            var startOfWeek = _selectedDate.AddDays(-(int)_selectedDate.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(6);
            
            eventsListView.Items.Clear();
            var events = _calendarService.GetEventsForDateRange(startOfWeek, endOfWeek);

            foreach (var evt in events.OrderBy(e => e.StartTime))
            {
                var item = new ListViewItem();
                item.Tag = evt;
                
                var timeText = evt.IsAllDay ? "All Day" : $"{evt.StartTime:ddd h:mm tt} - {evt.EndTime:h:mm tt}";
                item.Text = timeText;
                item.SubItems.Add(evt.Subject);
                item.SubItems.Add(evt.Location);
                item.SubItems.Add(evt.Priority.ToString());

                eventsListView.Items.Add(item);
            }
        }

        private void ShowMonthView()
        {
            // Standard month view - already implemented
            RefreshCalendar();
        }
    }
}