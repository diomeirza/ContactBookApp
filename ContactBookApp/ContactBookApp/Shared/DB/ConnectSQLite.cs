using ContactBookApp.Interfaces;
using SQLite;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(ContactBookApp.Shared.DB.ConnectSQLite))]
namespace ContactBookApp.Shared.DB
{
    public class ConnectSQLite
    {
        public static SQLiteAsyncConnection GetConnection()
        {
            return new SQLiteAsyncConnection(DbConstant.DatabasePath, DbConstant.Flags);
        }

        public static SQLiteAsyncConnection GetLazyConnection()
        {
            Lazy<SQLiteAsyncConnection> lazyConn = new Lazy<SQLiteAsyncConnection>(() => GetConnection());
            return lazyConn.Value;
        }

    }
}
