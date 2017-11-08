using ChildGrowth.Models.Vaccinations;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Persistence
{
    class VaccineDatabaseAccess : DatabaseAccess
    {
        override
        public async Task<Boolean> InitializeAsync()
        {
            _asyncConnection = SQLiteDatabase.GetConnection(DB_FILE_NAME);

            // Create MyEntity table if need be
            await _asyncConnection.CreateTableAsync<Vaccine>();
            IsConnected = true;
            return true;
        }

        public override void InitializeSync()
        {
            _syncConnection = SQLiteDatabase.GetSyncConnection(DB_FILE_NAME);

            // Create MyEntity table if need be
            _syncConnection.CreateTable<Vaccine>();
        }

        public Task<List<Vaccine>> GetAllVaccinesAsync()
        {
            return ReadOperations.GetAllWithChildrenAsync<Vaccine>(_asyncConnection);
        }

        public Task<Vaccine> GetVaccineAsync(int id)
        {
            return ReadOperations.GetWithChildrenAsync<Vaccine>(_asyncConnection, id);
        }

        public Task SaveAllVaccinesAsync(List<Vaccine> vaccines)
        {
            return WriteOperations.InsertOrReplaceAllWithChildrenAsync(_asyncConnection, vaccines);
        }

        public Task SaveVaccineAsync(Vaccine vaccine)
        {
            return WriteOperations.InsertOrReplaceWithChildrenAsync(_asyncConnection, vaccine);
        }

        public Task DeleteVaccineAsync(Vaccine vaccine)
        {
            return WriteOperations.DeleteAsync(_asyncConnection, vaccine, true);
        }

        public Task DeleteAllVaccinesAsync(List<Vaccine> vaccines)
        {
            return WriteOperations.DeleteAllAsync(_asyncConnection, vaccines);
        }

        public List<Vaccine> GetAllVaccinesSync()
        {
            return SQLiteNetExtensions.Extensions.ReadOperations.GetAllWithChildren<Vaccine>(_syncConnection);
        }

        public Vaccine GetVaccineSync(int id)
        {
            return SQLiteNetExtensions.Extensions.ReadOperations.GetWithChildren<Vaccine>(_syncConnection, id);
        }

        public void SaveAllVaccinesSync(List<Vaccine> vaccines)
        {
            SQLiteNetExtensions.Extensions.WriteOperations.InsertOrReplaceAllWithChildren(_syncConnection, vaccines);
        }

        public void SaveVaccineSync(Vaccine vaccine)
        {
            SQLiteNetExtensions.Extensions.WriteOperations.InsertOrReplaceWithChildren(_syncConnection, vaccine);
        }

        public void DeleteVaccineSync(Vaccine vaccine)
        {
            SQLiteNetExtensions.Extensions.WriteOperations.Delete(_syncConnection, vaccine, true);
        }

        public void DeleteAllVaccinesSync(List<Vaccine> vaccines)
        {
            SQLiteNetExtensions.Extensions.WriteOperations.DeleteAll(_syncConnection, vaccines);
        }

        private new readonly string DB_FILE_NAME = "VaccineDatabase.db3";
    }
}
