using ContactBookApp.Interfaces;
using ContactBookApp.Models;
using ContactBookApp.Shared.DB;
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookApp.Services
{
    public class ContactServices : IContactService
    {
        private SQLiteAsyncConnection _conn;
        public ContactServices()
        {
            if (_conn == null)
                _conn = new ConnectSQLite().GetConnection();
        }
        public async Task<List<Contact>> GetContacts()
        {
            return await _conn.Table<Contact>().ToListAsync();
        }

        public async Task<int> AddContact(Contact contact)
        {
            return await _conn.InsertAsync(contact);
        }
        public async Task<int> UpdateContact(Contact contact)
        {
            return await _conn.UpdateAsync(contact);
        }
        public async Task<int> DeleteContact(int id)
        {
            return await _conn.DeleteAsync<Contact>(id);
        }
    }
}
