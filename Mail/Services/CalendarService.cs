using System;
using System.Collections.Generic;
using System.Linq;
using Mail.Models;

namespace Mail.Services
{
    public class CalendarService
    {
        private List<CalendarEvent> _events = new List<CalendarEvent>();
        private int _nextId = 1;

        public event EventHandler<CalendarEvent>? EventAdded;
        public event EventHandler<CalendarEvent>? EventUpdated;
        public event EventHandler<CalendarEvent>? EventDeleted;

        public CalendarService()
        {
            InitializeSampleData();
        }

        public List<CalendarEvent> GetEventsForDate(DateTime date)
        {
            return _events.Where(e => e.StartTime.Date == date.Date).ToList();
        }

        public List<CalendarEvent> GetEventsForDateRange(DateTime startDate, DateTime endDate)
        {
            return _events.Where(e => 
                e.StartTime.Date >= startDate.Date && 
                e.StartTime.Date <= endDate.Date).ToList();
        }

        public List<CalendarEvent> GetEventsForMonth(int year, int month)
        {
            return _events.Where(e => 
                e.StartTime.Year == year && 
                e.StartTime.Month == month).ToList();
        }

        public CalendarEvent? GetEventById(int id)
        {
            return _events.FirstOrDefault(e => e.Id == id);
        }

        public void AddEvent(CalendarEvent calendarEvent)
        {
            calendarEvent.Id = _nextId++;
            calendarEvent.DateCreated = DateTime.Now;
            calendarEvent.LastModified = DateTime.Now;
            _events.Add(calendarEvent);
            EventAdded?.Invoke(this, calendarEvent);
        }

        public void UpdateEvent(CalendarEvent calendarEvent)
        {
            var existingEvent = GetEventById(calendarEvent.Id);
            if (existingEvent != null)
            {
                var index = _events.IndexOf(existingEvent);
                calendarEvent.LastModified = DateTime.Now;
                _events[index] = calendarEvent;
                EventUpdated?.Invoke(this, calendarEvent);
            }
        }

        public void DeleteEvent(CalendarEvent calendarEvent)
        {
            _events.Remove(calendarEvent);
            EventDeleted?.Invoke(this, calendarEvent);
        }

        public List<CalendarEvent> SearchEvents(string searchTerm)
        {
            return _events.Where(e =>
                e.Subject.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                e.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                e.Location.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        public List<CalendarEvent> GetUpcomingEvents(int days = 7)
        {
            var endDate = DateTime.Now.AddDays(days);
            return _events.Where(e => 
                e.StartTime >= DateTime.Now && 
                e.StartTime <= endDate).OrderBy(e => e.StartTime).ToList();
        }

        private void InitializeSampleData()
        {
            _events.Add(new CalendarEvent
            {
                Id = _nextId++,
                Subject = "Team Meeting",
                Description = "Weekly team sync meeting",
                Location = "Conference Room A",
                StartTime = DateTime.Now.AddDays(1).Date.AddHours(10),
                EndTime = DateTime.Now.AddDays(1).Date.AddHours(11),
                Organizer = "john.doe@company.com",
                Attendees = new List<string> { "jane.smith@company.com", "bob.jones@company.com" },
                Reminder = EventReminder.Minutes15,
                DateCreated = DateTime.Now.AddDays(-7),
                LastModified = DateTime.Now.AddDays(-7)
            });

            _events.Add(new CalendarEvent
            {
                Id = _nextId++,
                Subject = "Project Deadline",
                Description = "Q4 Project delivery deadline",
                StartTime = DateTime.Now.AddDays(5).Date.AddHours(17),
                EndTime = DateTime.Now.AddDays(5).Date.AddHours(18),
                IsAllDay = false,
                Priority = EventPriority.High,
                Reminder = EventReminder.Day1,
                DateCreated = DateTime.Now.AddDays(-14),
                LastModified = DateTime.Now.AddDays(-14)
            });
        }
    }
}