using SQLite.Net.Async;
using SQLite.Net;

namespace SqliteAsync
{
    // <summary>
    // SQLite.Net-PCL
    // 
    // https://github.com/oysteinkrog/SQLite.Net-PCL
    // http://www.xamarinhelp.com/local-storage-day-10/
    // https://github.com/michaeldimoudis/xam-forms-sqlitenet-async/blob/master/SqliteAsyncExample/SqliteAsyncExample/ISQLite.cs
    // </summary>
    public interface ISQLite
    {
        void CloseConnection();
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetAsyncConnection();
        void DeleteDatabase();
    }
}
