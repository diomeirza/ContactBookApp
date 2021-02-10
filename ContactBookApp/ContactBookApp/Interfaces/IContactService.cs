using ContactBookApp.Models;
using System.Collections.ObjectModel;

namespace ContactBookApp.Interfaces
{
    public interface IContactService
    {
        ObservableCollection<Contact> GetContacts();
        int AddContact(Contact contact);
    }
}
