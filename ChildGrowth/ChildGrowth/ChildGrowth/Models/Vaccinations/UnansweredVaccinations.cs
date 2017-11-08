using ChildGrowth.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChildGrowth.Models.Vaccinations
{
    public class UnansweredVaccinations
    {
        public UnansweredVaccinations()
        {

        }

        /**
         *  Return number of unanswered vaccines.
         **/
        public int GetUnansweredVaccinationsListSize()
        {
            int sum = 0;
            foreach(List<int> unanswered_vaccines in this._unansweredVaccinations.Values)
            {
                if(unanswered_vaccines != null)
                {
                    sum += unanswered_vaccines.Count;
                }
            }
            return sum;
        }

        public UnansweredVaccinations GenerateNewUnansweredVaccinations()
        {
            this._unansweredVaccinations = new Dictionary<VaccinationDueDate, List<int>>();

            // Generate empyty lists of milestone IDs for holding unanswered milestones for a Child.
            foreach (VaccinationDueDate dueDate in Enum.GetValues(typeof(VaccinationDueDate)))
            {
                List<int> vaccinesByAge = new List<int>();
                _unansweredVaccinations[dueDate] = vaccinesByAge;
            }

            // Populate Dictionary of unansweredMilestones questions with milestones separated by AgeRange.
            VaccineDatabaseAccess vaccineDatabaseAccess = new VaccineDatabaseAccess();
            vaccineDatabaseAccess.InitializeSync();
            List<Vaccine> vaccines = vaccineDatabaseAccess.GetAllVaccinesSync();
            foreach (Vaccine vaccine in vaccines)
            {
                List<int> vaccinesByAge = _unansweredVaccinations[(VaccinationDueDate)vaccine.VaccineDueDate];
                vaccinesByAge.Add(vaccine.ID);
            }
            vaccineDatabaseAccess.CloseSyncConnection();
            return this;
        }

        // Removal takes O(n) time, where n is the length of the unanswered vaccines list from which the id of the input vaccine is being removed.
        public Boolean RemoveVaccination(Vaccine vaccine)
        {
            if (vaccine == null)
            {
                return false;
            }
            int dueDate = vaccine.VaccineDueDate;
            if (this._unansweredVaccinations != null && this._unansweredVaccinations[(VaccinationDueDate)dueDate] != null)
            {
                return this._unansweredVaccinations[(VaccinationDueDate)dueDate].Remove(vaccine.ID);
            }
            return false;
        }

        // Removal takes O(n) time, where n is the length of the unanswered vaccines list from which the id of the input vaccine is being removed.
        public Boolean AddVaccination(Vaccine vaccine)
        {
            if (vaccine == null)
            {
                return false;
            }
            int dueDate = vaccine.VaccineDueDate;
            if (this._unansweredVaccinations != null && this._unansweredVaccinations[(VaccinationDueDate)dueDate] != null)
            {
                _unansweredVaccinations[(VaccinationDueDate)dueDate].Add(vaccine.ID);
                return true;
            }
            return false;
        }

        /**
         *  Based off child's age in months, find any milestones questions that need to be answered and return list of IDs.
         **/
        public List<int> GetDueVaccinations(int childAgeInMonths)
        {
            List<int> dueVaccines = new List<int>();
            foreach (VaccinationDueDate dueDate in Enum.GetValues(typeof(VaccinationDueDate)))
            {
                if (childAgeInMonths >= (int)dueDate)
                {
                    List<int> vaccinesForDueDate = _unansweredVaccinations[dueDate];
                    if (vaccinesForDueDate != null && vaccinesForDueDate.Count > 0)
                    {
                        foreach (int vaccineID in vaccinesForDueDate)
                        {
                            dueVaccines.Add(vaccineID);
                        }
                    }
                }
            }
            return dueVaccines;
        }

        public Dictionary<VaccinationDueDate, List<int>> _unansweredVaccinations;

    }

}
