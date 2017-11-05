using ChildGrowth.Models.Milestones;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChildGrowth.Persistence
{
    class MilestoneDatabaseAccess : DatabaseAccess
    {
        override
        public async Task<Boolean> InitializeAsync()
        {
            _connection = SQLiteDatabase.GetConnection(DB_FILE_NAME);

            // Create MyEntity table if need be
            await _connection.CreateTableAsync<Milestone>();
            IsConnected = true;
            return IsConnected;
        }

        public Task<List<Milestone>> GetAllMilestonesAsync()
        {
            return ReadOperations.GetAllWithChildrenAsync<Milestone>(_connection);
        }

        public Task<Milestone> GetMilestoneByIdAsync(int id)
        {
            return ReadOperations.GetWithChildrenAsync<Milestone>(_connection, id);
        }

        public Task SaveMilestoneAsync(Milestone milestone)
        {
            return WriteOperations.InsertOrReplaceWithChildrenAsync(_connection, milestone);
        }

        public Task SaveAllMilestonesAsync(List<Milestone> milestones)
        {
            return WriteOperations.InsertOrReplaceAllWithChildrenAsync(_connection, milestones);
        }

        public Task DeleteMilestoneAsync(Milestone milestone)
        {
            return WriteOperations.DeleteAsync(_connection, milestone, true);
        }

        public Task DeleteAllMilestonesAsync(List<Milestone> milestones)
        {
            return WriteOperations.DeleteAllAsync(_connection, milestones);
        }

        private readonly string DB_FILE_NAME = "MilestoneDatabase.db3";
    }
}
