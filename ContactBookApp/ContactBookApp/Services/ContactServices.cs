using ContactBookApp.Interfaces;
using ContactBookApp.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace ContactBookApp.Services
{
    public class ContactServices : IContactService
    {
        private ObservableCollection<Contact> _contacts;
        public ContactServices()
        {
            _contacts = new ObservableCollection<Contact>
            {
                new Contact { Id = 1, FirstName = "Jenny", LastName = "Blackpink", Phone = "081234567890", Email = "jenny@mail.com", IsBlocked = false},
                new Contact { Id = 1, FirstName = "Jisoo", LastName = "Blackpink", Phone = "081234567890", Email = "jisoo@mail.com", IsBlocked = false},
                new Contact { Id = 1, FirstName = "Rose", LastName = "Blackpink", Phone = "081234567890", Email = "rose@mail.com", IsBlocked = false},
                new Contact { Id = 1, FirstName = "Lisa", LastName = "Blackpink", Phone = "081234567890", Email = "lisa@mail.com", IsBlocked = false},
                new Contact { Id = 1, FirstName = "Sana", LastName = "Blackpink", Phone = "081234567890", Email = "sana@mail.com", IsBlocked = false}
            };
        }
        public ObservableCollection<Contact> GetContacts()
        {
            return _contacts;
        }

        public void AddContact(Contact contact)
        {
            var existingContact = _contacts.Where<Contact>(x => x.Id == contact.Id).FirstOrDefault();
            if(existingContact != null)
            {
                _contacts[_contacts.IndexOf(existingContact)] = contact;
            }
            else
            {
                _contacts.Add(contact);
            }
        }
    }
}
