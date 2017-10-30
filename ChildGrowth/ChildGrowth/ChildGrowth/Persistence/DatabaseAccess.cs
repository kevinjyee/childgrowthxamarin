using System;
using SQLite.Net.Async;

namespace ChildGrowth.Persistence
{
    public abstract class DatabaseAccess
    {
        protected SQLiteAsyncConnection _connection;
        protected Boolean _isConnected = false;

        public Boolean IsConnected { get { return _isConnected; } set { _isConnected = value; } }

        protected readonly string DB_FILE_NAME;
    }
}
