using System;
using System.Collections.Generic;

namespace Mail.Models
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAllDay { get; set; }
        public EventRecurrence Recurrence { get; set; } = EventRecurrence.None;
        public List<string> Attendees { get; set; } = new List<string>();
        public EventReminder Reminder { get; set; } = EventReminder.None;
        public EventPriority Priority { get; set; } = EventPriority.Normal;
        public EventStatus Status { get; set; } = EventStatus.Free;
        public string Organizer { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public string Categories { get; set; } = string.Empty;
    }

    public enum EventRecurrence
    {
        None,
        Daily,
        Weekly,
        Monthly,
        Yearly,
        Custom
    }

    public enum EventReminder
    {
        None,
        Minutes15,
        Minutes30,
        Hour1,
        Hours2,
        Day1,
        Days2,
        Week1
    }

    public enum EventPriority
    {
        Low,
        Normal,
        High
    }

    public enum EventStatus
    {
        Free,
        Busy,
        Tentative,
        OutOfOffice
    }
}