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

        public override void InitializeSync()
        {
            _syncConnection = SQLiteDatabase.GetSyncConnection(DB_FILE_NAME);

            // Create MyEntity table if need be
            _syncConnection.CreateTable<Child>();

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

        public List<Child> GetAllUserChildrenSync()
        {
            return SQLiteNetExtensions.Extensions.ReadOperations.GetAllWithChildren<Child>(_syncConnection);
        }

        public Child GetUserChildSync(int id)
        {
            return SQLiteNetExtensions.Extensions.ReadOperations.GetWithChildren<Child>(_syncConnection, id);
        }

        public void SaveUserChildSync(Child child)
        {
            SQLiteNetExtensions.Extensions.WriteOperations.InsertOrReplaceWithChildren(_syncConnection, child);
        }

        public void DeleteUserChild(Child child)
        {
            SQLiteNetExtensions.Extensions.WriteOperations.Delete(_syncConnection, child, true);
        }

        public void DeleteAllUserChildrenSync(List<Child> children)
        {
            SQLiteNetExtensions.Extensions.WriteOperations.DeleteAll(_syncConnection, children);
        }

        private new readonly string DB_FILE_NAME = "ChildDatabase.db3";

    }
}