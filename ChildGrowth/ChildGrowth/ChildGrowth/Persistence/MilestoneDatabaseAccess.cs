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
            _asyncConnection = SQLiteDatabase.GetConnection(DB_FILE_NAME);

            // Create MyEntity table if need be
            await _asyncConnection.CreateTableAsync<Milestone>();
            IsConnected = true;
            return IsConnected;
        }

        public Task<List<Milestone>> GetAllMilestonesAsync()
        {
            return ReadOperations.GetAllWithChildrenAsync<Milestone>(_asyncConnection);
        }

        public Task<Milestone> GetMilestoneByIdAsync(int id)
        {
            return ReadOperations.GetWithChildrenAsync<Milestone>(_asyncConnection, id);
        }

        public Task SaveMilestoneAsync(Milestone milestone)
        {
            return WriteOperations.InsertOrReplaceWithChildrenAsync(_asyncConnection, milestone);
        }

        public Task SaveAllMilestonesAsync(List<Milestone> milestones)
        {
            return WriteOperations.InsertOrReplaceAllWithChildrenAsync(_asyncConnection, milestones);
        }

        public Task DeleteMilestoneAsync(Milestone milestone)
        {
            return WriteOperations.DeleteAsync(_asyncConnection, milestone, true);
        }

        public Task DeleteAllMilestonesAsync(List<Milestone> milestones)
        {
            return WriteOperations.DeleteAllAsync(_asyncConnection, milestones);
        }

        public override void InitializeSync()
        {
            throw new NotImplementedException();
        }

        private readonly string DB_FILE_NAME = "MilestoneDatabase.db3";
    }
}
