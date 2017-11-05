using System.Collections.Generic;
using System.Threading.Tasks;
using SQLiteNetExtensionsAsync.Extensions;
using ChildGrowth.Models.Settings;
using System;

namespace ChildGrowth.Persistence
{
    public class ContextDatabaseAccess : DatabaseAccess
    {

        // Must call InitializeAsync before using any accessor methods.
        override
        public async Task<Boolean> InitializeAsync()
        {
            _connection = SQLiteDatabase.GetConnection(DB_FILE_NAME);

            // Create MyEntity table if need be
            await _connection.CreateTableAsync<Context>();
            IsConnected = true;
            return IsConnected;
        }

        public Task<Context> GetContextAsync()
        {
            return ReadOperations.GetWithChildrenAsync<Context>(_connection, CONTEXT_ID_NUMBER);
        }

        public Task SaveContextAsync(Context context)
        {
            context.ID = CONTEXT_ID_NUMBER;
            context.DateSaved = DateTime.Now;
            return WriteOperations.InsertOrReplaceWithChildrenAsync(_connection, context);
        }

        public Task DeleteContextAsync(Context context)
        {
            context.ID = CONTEXT_ID_NUMBER;
            return WriteOperations.DeleteAsync(_connection, context, true);
        }

        private new readonly string DB_FILE_NAME = "ContextDatabase.db3";
        private readonly int CONTEXT_ID_NUMBER = 1;

    }
}
