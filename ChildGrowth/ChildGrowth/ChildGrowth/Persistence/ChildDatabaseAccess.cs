using System.Collections.Generic;
using System.Threading.Tasks;
using SQLiteNetExtensionsAsync.Extensions;
using System;

namespace ChildGrowth.Persistence
{
    public class ChildDatabaseAccess : DatabaseAccess
    {
        override
        public async Task<Boolean> InitializeAsync()
        {
            _asyncConnection = SQLiteDatabase.GetConnection(DB_FILE_NAME);

            // Create MyEntity table if need be
            await _asyncConnection.CreateTableAsync<Child>();
            IsConnected = true;
            return IsConnected;
        }

        public Task<List<Child>> GetAllUserChildrenAsync()
        {
            return ReadOperations.GetAllWithChildrenAsync<Child>(_asyncConnection);
        }

        public Task<Child> GetUserChildAsync(int id)
        {
            return ReadOperations.GetWithChildrenAsync<Child>(_asyncConnection, id);
        }

        public Task SaveUserChildAsync(Child child)
        {
            return WriteOperations.InsertOrReplaceWithChildrenAsync(_asyncConnection, child);
        }

        public Task DeleteUserChildAsync(Child child)
        {
            return WriteOperations.DeleteAsync(_asyncConnection, child, true);
        }

        public Task DeleteAllUserChildrenAsync(List<Child> children)
        {
            return WriteOperations.DeleteAllAsync(_asyncConnection, children);
        }

        public override void InitializeSync()
        {
            throw new NotImplementedException();
        }

        private new readonly string DB_FILE_NAME = "ChildDatabase.db3";

    }
}
