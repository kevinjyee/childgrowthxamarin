using ChildGrowth.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChildGrowth.Models.Vaccinations
{
    public class VaccinationResponses
    {

        /**
         * Record the milestone BinaryAnswer for the given milestone ID and then remove it from the unanswered milestones list.
         */
        public void AddOrUpdateVaccinationHistory(int vaccineID)
        {
            VaccineDatabaseAccess vaccineDatabaseAccess = new VaccineDatabaseAccess();
            Boolean initialized = vaccineDatabaseAccess.InitializeAsync().Result;
            Vaccine vaccine = vaccineDatabaseAccess.GetVaccineAsync(vaccineID).Result;
            VaccinationHistory.UpdateOrInsertToVaccineHistory(vaccineID);
            Boolean vaccineRemoved = UnansweredVaccinations.RemoveVaccination(vaccine);
        }

        /**
         * Return list of due vaccines based on child age and questions answered.
         **/
        public List<Vaccine> GetListOfDueVaccines(int childAgeInMonths)
        {
            List<int> dueVaccineIds = UnansweredVaccinations.GetDueVaccinations(childAgeInMonths);
            if (dueVaccineIds != null && dueVaccineIds.Count > 0)
            {
                return GetVaccinationsByIds(dueVaccineIds);
            }
            else
            {
                return null;
            }
        }

        /**
         * Return list of vaccines already received.
         **/
        public List<Vaccine> GetVaccineHistory()
        {
            List<int> receivedVaccineIds = new List<int>();
            receivedVaccineIds.AddRange(_vaccinationHistory.GetVaccinationHistory().Values);
            receivedVaccineIds.Sort();
            return GetVaccinationsByIds(receivedVaccineIds);
        }

        /**
         * Retrieve a list of Vaccine objects from storage corresponding to the input list of vaccine ids.
         **/
        private List<Vaccine> GetVaccinationsByIds(List<int> ids)
        {
            VaccineDatabaseAccess vaccineDatabaseAccess = new VaccineDatabaseAccess();
            Boolean initialized = vaccineDatabaseAccess.InitializeAsync().Result;
            List<Task<Vaccine>> readTasks = new List<Task<Vaccine>>();
            List<Vaccine> vaccines = new List<Vaccine>();
            if (ids != null && ids.Count > 0)
            {
                foreach (int vaccineID in ids)
                {
                    readTasks.Add(vaccineDatabaseAccess.GetVaccineAsync(vaccineID));
                }
            }
            if (readTasks != null && readTasks.Count > 0)
            {
                foreach (Task<Vaccine> task in readTasks)
                {
                    vaccines.Add(task.Result);
                }
            }
            return vaccines;
        }

        public VaccinationResponses()
        {
            this._vaccinationHistory = new VaccinationHistory().GenerateNewVaccinationHistory();
            this._unansweredVaccinations = new UnansweredVaccinations().GenerateNewUnansweredVaccinations().Result;
        }

        public VaccinationHistory VaccinationHistory { get { return _vaccinationHistory; } set { this._vaccinationHistory = value; } }
        public UnansweredVaccinations UnansweredVaccinations { get { return _unansweredVaccinations; } set { this._unansweredVaccinations = value; } }

        public VaccinationHistory _vaccinationHistory { get; set; }
        public UnansweredVaccinations _unansweredVaccinations { get; set; }
    }
}