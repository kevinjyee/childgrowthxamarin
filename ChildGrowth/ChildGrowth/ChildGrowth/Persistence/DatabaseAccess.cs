using System;
using SQLite.Net.Async;
using System.Threading.Tasks;

namespace ChildGrowth.Persistence
{
    public abstract class DatabaseAccess
    {
        protected SQLiteAsyncConnection _connection;
        protected Boolean _isConnected = false;

        public Boolean IsConnected { get { return _isConnected; } set { _isConnected = value; } }

        // Must call InitializeAsync before using any accessor methods.
        public abstract Task<Boolean> InitializeAsync();

        protected readonly string DB_FILE_NAME;
    }
}
