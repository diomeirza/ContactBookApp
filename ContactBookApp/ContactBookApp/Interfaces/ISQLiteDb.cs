using SQLite;

namespace ContactBookApp.Interfaces
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
