using System.Collections.Generic;
using System.Threading.Tasks;
using SQLiteNetExtensionsAsync.Extensions;
using SQLiteNetExtensions.Extensions;
using ChildGrowth.Models.Settings;
using System;

namespace ChildGrowth.Persistence
{
    public class ContextDatabaseAccess : DatabaseAccess
    {

        // Must call InitializeAsync before using any accessor methods.
        public override async Task<Boolean> InitializeAsync()
        {
            _asyncConnection = SQLiteDatabase.GetConnection(DB_FILE_NAME);

            // Create MyEntity table if need be
            var test = _asyncConnection.CreateTableAsync<Context>().Result;
            IsConnected = true;
            return IsConnected;
        }

        public override void InitializeSync()
        {
            _syncConnection = SQLiteDatabase.GetSyncConnection(DB_FILE_NAME);
        }

        public void CloseSyncConnection()
        {
            _syncConnection.Close();
        }

        public Task<Context> GetContextAsync()
        {
            return SQLiteNetExtensionsAsync.Extensions.ReadOperations.GetWithChildrenAsync<Context>(_asyncConnection, CONTEXT_ID_NUMBER);
        }

        public Task SaveContextAsync(Context context)
        {
            context.ID = CONTEXT_ID_NUMBER;
            context.DateSaved = DateTime.Now;
            return SQLiteNetExtensionsAsync.Extensions.WriteOperations.InsertOrReplaceWithChildrenAsync(_asyncConnection, context);
        }

        public void SaveFirstContextAsync(Context context)
        {
            context.ID = CONTEXT_ID_NUMBER;
            context.DateSaved = DateTime.Now;
            SQLiteNetExtensionsAsync.Extensions.WriteOperations.InsertWithChildrenAsync(_asyncConnection, context);
        }

        public Task DeleteContextAsync(Context context)
        {
            context.ID = CONTEXT_ID_NUMBER;
            return SQLiteNetExtensionsAsync.Extensions.WriteOperations.DeleteAsync(_asyncConnection, context, true);
        }

        public Context GetContextSync()
        {
            return SQLiteNetExtensions.Extensions.ReadOperations.GetWithChildren<Context>(_syncConnection, CONTEXT_ID_NUMBER);
        }

        public void SaveContextSync(Context context)
        {
            context.ID = CONTEXT_ID_NUMBER;
            context.DateSaved = DateTime.Now;
            SQLiteNetExtensions.Extensions.WriteOperations.InsertOrReplaceWithChildren(_syncConnection, context);
        }

        public void SaveFirstContextSync(Context context)
        {
            context.ID = CONTEXT_ID_NUMBER;
            context.DateSaved = DateTime.Now;
            SQLiteNetExtensions.Extensions.WriteOperations.InsertWithChildren(_syncConnection, context);
        }

        public void DeleteContextSync(Context context)
        {
            context.ID = CONTEXT_ID_NUMBER;
            SQLiteNetExtensions.Extensions.WriteOperations.Delete(_syncConnection, context, true);
        }

        private new readonly string DB_FILE_NAME = "ContextDatabase.db3";
        private readonly int CONTEXT_ID_NUMBER = 1;

    }
}
