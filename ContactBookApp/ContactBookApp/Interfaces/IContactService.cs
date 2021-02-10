using ContactBookApp.Models;
using System.Collections.ObjectModel;

namespace ContactBookApp.Interfaces
{
    public interface IContactService
    {
        ObservableCollection<Contact> GetContacts();
        void AddContact(Contact contact);
    }
}
