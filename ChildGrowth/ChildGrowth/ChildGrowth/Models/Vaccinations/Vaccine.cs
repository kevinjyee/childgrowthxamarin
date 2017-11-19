using SQLite.Net.Attributes;
using System.Collections.Generic;

namespace ChildGrowth.Models.Vaccinations
{
    [Table("Vaccine")]
    public class Vaccine
    {
        [PrimaryKey]
        public int ID { get; set; }

        // VaccineDueDate is in units of months.
        [Indexed]
        public int VaccineDueDate { get; set; }

        public string VaccineName { get; set; }

        public string Info { get; set; }

        private Vaccine(int id, int vaccineDueDate, string vaccineName, string info)
        {
            this.ID = id;
            this.VaccineDueDate = vaccineDueDate;
            this.VaccineName = vaccineName;
            this.Info = info;
        }

        /**
         *  Sort a list of Vaccines by due date in order of increasing due date.
         * */
        public static List<Vaccine> SortVaccineListByDueDate(List<Vaccine> Vaccines)
        {
            List<Vaccine> Result = new List<Vaccine>();
            Vaccines.Sort(delegate (Vaccine x, Vaccine y)
            {
                if (x.VaccineDueDate == -1 && y.VaccineDueDate == -1) return 0;
                else if (x.VaccineDueDate == -1) return -1;
                else if (y.VaccineDueDate == -1) return 1;
                else if (x.VaccineDueDate.Equals(y.VaccineDueDate))
                {
                    return x.VaccineName.CompareTo(y.VaccineName);
                }
                else return x.VaccineDueDate.CompareTo(y.VaccineDueDate);
            });
            return Vaccines;
        }

        public Vaccine()
        {

        }

        /**
         * Builder class for Milestones objects. Use this to avoid annoying constructors with a bunch of parameters.
         * 
         */
        public class VaccineBuilder
        {
            private int _id;
            private int _vaccineDueDate;
            private string _vaccineName;
            private string _info;

            public VaccineBuilder()
            {

            }

            public Vaccine Build()
            {
                return new Vaccine(_id, _vaccineDueDate, _vaccineName, _info);
            }

            public VaccineBuilder WithID(int id)
            {
                this._id = id;
                return this;
            }

            public VaccineBuilder WithVaccineDueDate(int vaccineDueDate)
            {
                this._vaccineDueDate = vaccineDueDate;
                return this;
            }

            public VaccineBuilder WithVaccineName(string vaccineName)
            {
                this._vaccineName = vaccineName;
                return this;
            }

            public VaccineBuilder WithInfo(string info)
            {
                this._info = info;
                return this;
            }
        }
    }
}