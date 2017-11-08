using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensionsAsync.Extensions;
using SQLiteNetExtensions.Extensions;
using SQLite.Net.Async;
using SQLite.Net;

namespace ChildGrowth.Persistence
{
    public abstract class DatabaseAccess
    {
        protected SQLiteAsyncConnection _asyncConnection;
        protected SQLiteConnection _syncConnection;

        protected Boolean _isConnected = false;

        public Boolean IsConnected { get { return _isConnected; } set { _isConnected = value; } }

        public void CloseSyncConnection()
        {
            _syncConnection.Close();
        }

        // Must call InitializeAsync before using any accessor methods.
        public abstract Task<Boolean> InitializeAsync();

        public abstract void InitializeSync();

        protected readonly string DB_FILE_NAME;
    }
}
