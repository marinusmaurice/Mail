using System;
using System.Collections.Generic;

namespace Mail.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public List<string> AlternateEmails { get; set; } = new List<string>();
        public string Company { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsFavorite { get; set; }
        public string PhotoPath { get; set; } = string.Empty;
    }

    public class ContactGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Contact> Members { get; set; } = new List<Contact>();
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}