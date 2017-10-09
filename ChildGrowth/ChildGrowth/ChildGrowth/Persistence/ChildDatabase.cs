using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using SQLiteNetExtensionsAsync.Extensions;
using System;

namespace ChildGrowth.Persistence
{
    public class ChildDatabase
    {
        private SQLiteAsyncConnection _connection;
        private Boolean _isConnected = false;

        public Boolean IsConnected { get { return _isConnected; } set { _isConnected = value; } }

        // Must call InitializeAsync before using any accessor methods.
        public async Task InitializeAsync()
        {
            _connection = SQLiteDatabase.GetConnection(CHILD_DB_FILE_NAME);

            // Create MyEntity table if need be
            await _connection.CreateTableAsync<Child>();
            IsConnected = true;
        }

        public Task<List<Child>> GetAllUserChildrenAsync()
        {
            return ReadOperations.GetAllWithChildrenAsync<Child>(_connection);
        }

        public Task<Child> GetUserChildAsync(int id)
        {
            return ReadOperations.GetWithChildrenAsync<Child>(_connection, id);
        }

        public Task SaveUserChildAsync(Child child)
        {
            return WriteOperations.InsertOrReplaceWithChildrenAsync(_connection, child);
        }

        public Task DeleteUserChildAsync(Child child)
        {
            return WriteOperations.DeleteAsync(_connection, child, true);
        }

        public Task DeleteAllUserChildrenAsync(List<Child> children)
        {
            return WriteOperations.DeleteAllAsync(_connection, children);
        }

        private readonly string CHILD_DB_FILE_NAME = "ChildDatabase.db3";

    }
}
