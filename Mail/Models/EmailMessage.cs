using System;
using System.Collections.Generic;

namespace Mail.Models
{
    public class EmailMessage
    {
        public int Id { get; set; }
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public string Cc { get; set; } = string.Empty;
        public string Bcc { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public DateTime DateSent { get; set; }
        public DateTime DateReceived { get; set; }
        public bool IsRead { get; set; }
        public bool IsImportant { get; set; }
        public bool HasAttachments { get; set; }
        public List<EmailAttachment> Attachments { get; set; } = new List<EmailAttachment>();
        public EmailFolder Folder { get; set; } = EmailFolder.Inbox;
        public int Size { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsFlagged { get; set; }
        public EmailPriority Priority { get; set; } = EmailPriority.Normal;
    }

    public class EmailAttachment
    {
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string ContentType { get; set; } = string.Empty;
    }

    public enum EmailFolder
    {
        Inbox,
        Outbox,
        SentItems,
        Drafts,
        DeletedItems,
        Junk,
        Custom
    }

    public enum EmailPriority
    {
        Low,
        Normal,
        High
    }
}