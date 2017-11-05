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
            _connection = SQLiteDatabase.GetConnection(DB_FILE_NAME);

            // Create MyEntity table if need be
            await _connection.CreateTableAsync<Vaccine>();
            IsConnected = true;
            return true;
        }

        public Task<List<Vaccine>> GetAllVaccinesAsync()
        {
            return ReadOperations.GetAllWithChildrenAsync<Vaccine>(_connection);
        }

        public Task<Vaccine> GetVaccineAsync(int id)
        {
            return ReadOperations.GetWithChildrenAsync<Vaccine>(_connection, id);
        }

        public Task SaveVaccineAsync(Vaccine vaccine)
        {
            return WriteOperations.InsertOrReplaceWithChildrenAsync(_connection, vaccine);
        }

        public Task DeleteVaccineAsync(Vaccine vaccine)
        {
            return WriteOperations.DeleteAsync(_connection, vaccine, true);
        }

        public Task DeleteAllVaccinesAsync(List<Vaccine> vaccines)
        {
            return WriteOperations.DeleteAllAsync(_connection, vaccines);
        }

        private new readonly string DB_FILE_NAME = "VaccineDatabase.db3";
    }
}
