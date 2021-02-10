using ContactBookApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactBookApp.Interfaces
{
    public interface IContactService
    {
        Task<List<Contact>> GetContacts();
        Task<int> AddContact(Contact contact);
        Task<int> UpdateContact(Contact contact);
        Task<int> DeleteContact(int id); 
    }
}
