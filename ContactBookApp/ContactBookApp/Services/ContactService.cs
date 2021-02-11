using ContactBookApp.Interfaces;
using ContactBookApp.Models;
using ContactBookApp.Shared;
using ContactBookApp.Shared.DB;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookApp.Services
{
    public class ContactService : IContactService
    {
       
        private SQLiteAsyncConnection _database = ConnectSQLite.GetLazyConnection();
        static bool initialized = false;
        public ContactService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!_database.TableMappings.Any(m => m.MappedType.Name == typeof(Contact).Name))
                {
                    await _database.CreateTablesAsync(CreateFlags.None, typeof(Contact)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public async Task<List<Contact>> GetContacts()
        {
            return await _database.Table<Contact>().ToListAsync();
        }

        public async Task<int> AddContact(Contact contact)
        {
            return await _database.InsertAsync(contact);
        }

        public async Task<int> UpdateContact(Contact contact)
        {
            return await _database.UpdateAsync(contact);
        }

        public async Task<int> DeleteContact(int id)
        {
            return await _database.DeleteAsync<Contact>(id);
        }
    }
}
