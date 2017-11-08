using ChildGrowth.Models.Vaccinations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChildGrowth.Models.Vaccinations.Vaccine;

namespace ChildGrowth.Persistence
{
    class VaccineTableConstructor
    {
        public async static Task ConstructVaccineTable()
        {
            List<Vaccine> Vaccines = new List<Vaccine>();
            Vaccines.Add( new VaccineBuilder().WithID(1).WithVaccineDueDate(0).WithInfo(" ").WithVaccineName("Hepatitis B (HepB)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(2).WithVaccineDueDate(1).WithInfo(" ").WithVaccineName("Hepatitis B (HepB)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(3).WithVaccineDueDate(2).WithInfo(" ").WithVaccineName("Rotavirus (RV)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(4).WithVaccineDueDate(2).WithInfo(" ").WithVaccineName("Diphtheria and tetanus toxoids and acellular pertussis (DTaP)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(5).WithVaccineDueDate(2).WithInfo(" ").WithVaccineName("Haemophilus influenzae type b (Hib)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(6).WithVaccineDueDate(2).WithInfo(" ").WithVaccineName("Pneumococcal conjugate (PCV13)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(7).WithVaccineDueDate(2).WithInfo(" ").WithVaccineName("Inactivated poliovirus (IPV:<18 yrs)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(8).WithVaccineDueDate(4).WithInfo(" ").WithVaccineName("Rotavirus (RV)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(9).WithVaccineDueDate(4).WithInfo(" ").WithVaccineName("Diphtheria and tetanus toxoids and acellular pertussis (DTaP)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(10).WithVaccineDueDate(4).WithInfo(" ").WithVaccineName("Haemophilus influenzae type b (Hib)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(11).WithVaccineDueDate(4).WithInfo(" ").WithVaccineName("Pneumococcal conjugate (PCV13)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(12).WithVaccineDueDate(4).WithInfo(" ").WithVaccineName("Inactivated poliovirus (IPV:<18 yrs)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(13).WithVaccineDueDate(6).WithInfo(" ").WithVaccineName("Hepatitis B (HepB)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(14).WithVaccineDueDate(6).WithInfo(" ").WithVaccineName("Diphtheria and tetanus toxoids and acellular pertussis (DTaP)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(15).WithVaccineDueDate(6).WithInfo(" ").WithVaccineName("Pneumococcal conjugate (PCV13)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(16).WithVaccineDueDate(6).WithInfo(" ").WithVaccineName("Inactivated poliovirus (IPV:<18 yrs)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(17).WithVaccineDueDate(6).WithInfo(" ").WithVaccineName("Influenza (IIV)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(18).WithVaccineDueDate(12).WithInfo(" ").WithVaccineName("Haemophilus influenzae type b (Hib)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(19).WithVaccineDueDate(12).WithInfo(" ").WithVaccineName("Pneumococcal conjugate (PCV13)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(20).WithVaccineDueDate(12).WithInfo(" ").WithVaccineName("Measles, mumps, rubella (MMR)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(21).WithVaccineDueDate(12).WithInfo(" ").WithVaccineName("Varicella (VAR)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(22).WithVaccineDueDate(12).WithInfo(" ").WithVaccineName("Hepatitis A (HepA)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(23).WithVaccineDueDate(15).WithInfo(" ").WithVaccineName("Diphtheria and tetanus toxoids and acellular pertussis (DTaP)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(24).WithVaccineDueDate(18).WithInfo(" ").WithVaccineName("Influenza (IIV)").Build());
            Vaccines.Add(new VaccineBuilder().WithID(25).WithVaccineDueDate(24).WithInfo(" ").WithVaccineName("Hepatitis A (HepA) - Second Dose").Build());
            Vaccines.Add(new VaccineBuilder().WithID(26).WithVaccineDueDate(30).WithInfo(" ").WithVaccineName("Influenza (IIV)").Build());

            VaccineDatabaseAccess vaccineDatabaseAccess = new VaccineDatabaseAccess();
            await vaccineDatabaseAccess.InitializeAsync();
            await vaccineDatabaseAccess.SaveAllVaccinesAsync(Vaccines);
        }
       

    }
}
