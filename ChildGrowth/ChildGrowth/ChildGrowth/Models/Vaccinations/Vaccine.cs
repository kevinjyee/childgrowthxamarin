using SQLite.Net.Attributes;

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

        private Vaccine(int id, int vaccineDueDate, string vaccineName)
        {
            this.ID = id;
            this.VaccineDueDate = vaccineDueDate;
            this.VaccineName = vaccineName;
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

            public VaccineBuilder()
            {

            }

            public Vaccine Build()
            {
                return new Vaccine(_id, _vaccineDueDate, _vaccineName);
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

        }
    }
}
