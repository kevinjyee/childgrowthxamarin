using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Models.Vaccinations
{
    public class VaccinationHistory
    {
        public VaccinationHistory()
        {

        }

        // Create new milestone history dictionary of dictionaries.
        public VaccinationHistory GenerateNewVaccinationHistory()
        {
            this._vaccinationHistory = new Dictionary<int, int>();
            return this;
        }

        public void UpdateOrInsertToVaccineHistory(int vaccineId)
        {
            _vaccinationHistory[vaccineId] = vaccineId;
        }

        /**
         * Get the number of received vaccines.
         **/
        public int GetVaccinationHistoryListSize()
        {
            if (_vaccinationHistory != null)
            {
                return _vaccinationHistory.Count;
            }
            else return 0;
        }

        /**
         *  Return true if VaccinationHistory contains vaccineId.
         **/
        public Boolean HasVaccine(int vaccineId)
        {
            return _vaccinationHistory.ContainsKey(vaccineId);
        }

        public void RemoveFromVaccineHistory(int vaccineId)
        {
            _vaccinationHistory.Remove(vaccineId);
        }

        public Dictionary<int, int> GetVaccinationHistory()
        {
            return _vaccinationHistory;
        }

        // Key and value are both vaccine.ID.
        public Dictionary<int, int> _vaccinationHistory;
    }
}
