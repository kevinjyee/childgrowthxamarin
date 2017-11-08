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

        public override void InitializeSync()
        {
            throw new NotImplementedException();
        }

        private new readonly string DB_FILE_NAME = "VaccineDatabase.db3";
    }
}
