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

        public override void InitializeSync()
        {
            _syncConnection = SQLiteDatabase.GetSyncConnection(DB_FILE_NAME);

            // Create MyEntity table if need be
            _syncConnection.CreateTable<Milestone>();
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

        public List<Milestone> GetAllMilestonesSync()
        {
            return SQLiteNetExtensions.Extensions.ReadOperations.GetAllWithChildren<Milestone>(_syncConnection);
        }

        public Milestone GetMilestoneByIdSync(int id)
        {
            return SQLiteNetExtensions.Extensions.ReadOperations.GetWithChildren<Milestone>(_syncConnection, id);
        }

        public void SaveMilestoneSync(Milestone milestone)
        {
            SQLiteNetExtensions.Extensions.WriteOperations.InsertOrReplaceWithChildren(_syncConnection, milestone);
        }

        public void SaveAllMilestonesSync(List<Milestone> milestones)
        {
            SQLiteNetExtensions.Extensions.WriteOperations.InsertOrReplaceAllWithChildren(_syncConnection, milestones);
        }

        public void DeleteMilestoneSync(Milestone milestone)
        {
            SQLiteNetExtensions.Extensions.WriteOperations.Delete(_syncConnection, milestone, true);
        }

        public void DeleteAllMilestonesSync(List<Milestone> milestones)
        {
            SQLiteNetExtensions.Extensions.WriteOperations.DeleteAll(_syncConnection, milestones);
        }

        private new readonly string DB_FILE_NAME = "MilestoneDatabase.db3";
    }
}
