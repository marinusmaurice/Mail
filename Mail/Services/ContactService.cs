using System;
using System.Collections.Generic;
using System.Linq;
using Mail.Models;

namespace Mail.Services
{
    public class ContactService
    {
        private List<Contact> _contacts = new List<Contact>();
        private List<ContactGroup> _contactGroups = new List<ContactGroup>();
        private int _nextContactId = 1;
        private int _nextGroupId = 1;

        public event EventHandler<Contact>? ContactAdded;
        public event EventHandler<Contact>? ContactUpdated;
        public event EventHandler<Contact>? ContactDeleted;

        public ContactService()
        {
            InitializeSampleData();
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts.ToList();
        }

        public Contact? GetContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public Contact? GetContactByEmail(string email)
        {
            return _contacts.FirstOrDefault(c => 
                c.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase) ||
                c.AlternateEmails.Any(ae => ae.Equals(email, StringComparison.OrdinalIgnoreCase)));
        }

        public void AddContact(Contact contact)
        {
            contact.Id = _nextContactId++;
            contact.DateCreated = DateTime.Now;
            contact.LastModified = DateTime.Now;
            _contacts.Add(contact);
            ContactAdded?.Invoke(this, contact);
        }

        public void UpdateContact(Contact contact)
        {
            var existingContact = GetContactById(contact.Id);
            if (existingContact != null)
            {
                var index = _contacts.IndexOf(existingContact);
                contact.LastModified = DateTime.Now;
                _contacts[index] = contact;
                ContactUpdated?.Invoke(this, contact);
            }
        }

        public void DeleteContact(Contact contact)
        {
            _contacts.Remove(contact);
            ContactDeleted?.Invoke(this, contact);
        }

        public List<Contact> SearchContacts(string searchTerm)
        {
            return _contacts.Where(c =>
                c.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.DisplayName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.EmailAddress.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.Company.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        public List<ContactGroup> GetAllContactGroups()
        {
            return _contactGroups.ToList();
        }

        public void AddContactGroup(ContactGroup group)
        {
            group.Id = _nextGroupId++;
            group.DateCreated = DateTime.Now;
            group.LastModified = DateTime.Now;
            _contactGroups.Add(group);
        }

        public void UpdateContactGroup(ContactGroup group)
        {
            var existingGroup = _contactGroups.FirstOrDefault(g => g.Id == group.Id);
            if (existingGroup != null)
            {
                var index = _contactGroups.IndexOf(existingGroup);
                group.LastModified = DateTime.Now;
                _contactGroups[index] = group;
            }
        }

        public void DeleteContactGroup(ContactGroup group)
        {
            _contactGroups.Remove(group);
        }

        private void InitializeSampleData()
        {
            _contacts.Add(new Contact
            {
                Id = _nextContactId++,
                FirstName = "John",
                LastName = "Doe",
                DisplayName = "John Doe",
                EmailAddress = "john.doe@company.com",
                Company = "Tech Company Inc.",
                JobTitle = "Software Engineer",
                PhoneNumber = "+1-555-123-4567",
                DateCreated = DateTime.Now.AddDays(-30),
                LastModified = DateTime.Now.AddDays(-30)
            });

            _contacts.Add(new Contact
            {
                Id = _nextContactId++,
                FirstName = "Jane",
                LastName = "Smith",
                DisplayName = "Jane Smith",
                EmailAddress = "jane.smith@company.com",
                Company = "Tech Company Inc.",
                JobTitle = "Project Manager",
                PhoneNumber = "+1-555-987-6543",
                DateCreated = DateTime.Now.AddDays(-25),
                LastModified = DateTime.Now.AddDays(-25)
            });
        }
    }
}