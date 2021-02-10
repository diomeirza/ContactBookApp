using ContactBookApp.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(ContactBookApp.Shared.DB.ConnectSQLite))]
namespace ContactBookApp.Shared.DB
{
    public class ConnectSQLite : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            return new SQLiteAsyncConnection(DbConstant.DatabasePath, DbConstant.Flags);
        }
    }
}
