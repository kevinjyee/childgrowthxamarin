using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChildGrowth.Pages.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChildGrowth.Models.Settings;
using ChildGrowth.Persistence;
using ChildGrowth.Models.Milestones;
using ChildGrowth.Models.Vaccinations;

namespace ChildGrowth.Pages.Insights
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insights : ContentPage
    {
        public Child CurrentChild { get; set; }
        public Context CurrentContext { get; set; }

        override
        protected void OnAppearing()
        {
            Task Load = Task.Run(async () => { await LoadContext(); });
            Load.Wait();
            if (CurrentContext.CurrentLanguage == Language.ENGLISH)
            {
                MainTitle.Text = "Insights";
                AlertsTitle.Text = "Alerts";
                MeasurementsTitle.Text = "Measurements";
                MeasurementsAlert.Text = "Height, weight, head circumference needed";
                MilestonesTitle.Text = "Milestones";
                VaccinationsTitle.Text = "Vaccinations";
                SummaryTitle.Text = "Summary";
                HeightLebel.Text = "Height: ";
                WeightLabel.Text = "Weight: ";
                HeadLabel.Text = "Head Circumference: ";
                BirthLabel.Text = "Birthday";
                MeasurementsLabel.Text = "Measurements";
                MilestonesSummary.Text = "Milestones";
                PGLabel.Text = "Physical Growth";
                TRLabel.Text = "Thinking & Reasoning";
                ESDLabel.Text = "Emotional & Social Development";
                LDLabel.Text = "Language Development";
                SMLabel.Text = "Sensory & Motory Development";
            }
            else
            {
                MainTitle.Text = "Resumen";
                AlertsTitle.Text = "Notificaciones";
                MeasurementsTitle.Text = "Medidas";
                MeasurementsAlert.Text = "Falta Estatura, peso, circunferencia de la cabeza";
                MilestonesTitle.Text = "Hitos";
                VaccinationsTitle.Text = "Vacunas";
                SummaryTitle.Text = "Resumen";
                HeightLebel.Text = "Estatura: ";
                WeightLabel.Text = "Peso: ";
                HeadLabel.Text = "Circunferencia de la Cabeza: ";
                BirthLabel.Text = "Cumpleaños";
                MeasurementsLabel.Text = "Medidas";
                MilestonesSummary.Text = "Hitos";
                PGLabel.Text = "Crecimiento Físico";
                TRLabel.Text = "Pensamiento y Razonamiento";
                ESDLabel.Text = "Desarrollo Emocional y Social";
                LDLabel.Text = "Desarrollo del Lenguage";
                SMLabel.Text = "Desarrollo Sensor y Motor";
            }

            if (CurrentChild != null)
            {
                this.Title = CurrentChild.Name;
                updateFields();
            }
            else
            {
                if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                {
                    this.Title = "Please Select a Child";
                }
                else
                {
                    this.Title = "Porfavor Seleccione un niño";
                }
                updateFields();

            }
        }

        // Load context and set value for current child if it exists.
        private async Task<Boolean> LoadContext()
        {
            ContextDatabaseAccess contextDB = new ContextDatabaseAccess();
            await contextDB.InitializeAsync();
            try
            {
                CurrentContext = contextDB.GetContextAsync().Result;
            }
            // Can't find definitions for SQLiteNetExtensions exceptions, so catch generic Exception e and assume there is no context.
            catch (Exception e)
            {
                CurrentContext = null;
                //contextDB.CloseSyncConnection();
            }
            // If context doesn't exist, create it, save it, and populate vaccine/milestones databases.
            if (CurrentContext == null)
            {
                CurrentContext = new Context();
                // Exception probably broke the synchronous connection.
                //contextDB.InitializeSync();
                ContextDatabaseAccess newContextDB = new ContextDatabaseAccess();
                await newContextDB.InitializeAsync();
                newContextDB.SaveFirstContextAsync(CurrentContext);
                //newContextDB.CloseSyncConnection();
                CurrentChild = null;
                Task tVaccine = VaccineTableConstructor.ConstructVaccineTable();
                Task tMilestone = MilestonesTableConstructor.ConstructMilestonesTable();
                await tVaccine;
                await tMilestone;
                return true;
            }
            else
            {
                CurrentChild = CurrentContext.GetSelectedChild();
                return true;
            }

        }
        public Insights()
        {
            InitializeComponent();
        }

        private void updateFields()
        {
            if(CurrentChild == null)
            {
                childBirthday.Text = "NaN";
                heightMeasurement.Text = "NaN";
                weightMeasurement.Text = "NaN";
                headCircumferenceMeasurement.Text = "NaN";
            }
            else
            {
                // Get last input dates
                
                DateTime maxDateofWeight = CurrentChild.Measurements.weightData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.weightData.Keys.Max();
                DateTime maxDateofHeight = CurrentChild.Measurements.heightData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.heightData.Keys.Max();
                DateTime maxDateofHead = CurrentChild.Measurements.headCircumferenceData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.headCircumferenceData.Keys.Max();

                // Check if these dates matches today
                if(maxDateofHead.Date == DateTime.Today.Date
                    && maxDateofHeight.Date == DateTime.Today.Date
                    && maxDateofWeight.Date == DateTime.Today.Date)
                {
                    measurementsImage.Source = "check_1";
                    if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                    {
                        MeasurementsAlert.Text = "All Measurements Completed For Today";
                    }
                    else
                    {
                        MeasurementsAlert.Text = "Todas las medidas estan al día";
                    }
                }

                // Check if Milestones Completed
                List<Milestone> milestoneList = CurrentChild.GetListOfDueMilestones();
                if(milestoneList == null || milestoneList.Count == 1)
                {
                    milestonesImage.Source = "check_1";
                    if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                    {
                        milestonesAlert.Text = "All Milestones Completed For Today";
                    }
                    else
                    {
                        milestonesAlert.Text = "Todos los hitos estan al día";
                    }
                }
                else
                {
                    int count = milestoneList.Count - 1;
                    if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                    {
                        milestonesAlert.Text = count.ToString() + " milestones unanswered";
                    }
                    else
                    {
                        milestonesAlert.Text = count.ToString() + " hitos sin responder";
                    }
                }

                //Check if Vaccination Completed
                List<Vaccine> vaccineList = CurrentChild.GetListOfDueVaccines();
                if (vaccineList == null || vaccineList.Count == 0)
                {
                    vaccinationsImage.Source = "check_1";
                    if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                    {
                        vaccinationsAlert.Text = "All Vaccinations Completed For Today";
                    }
                    else
                    {
                        vaccinationsAlert.Text = "Todas las vacunas estan al día";
                    }
                }
                else
                {
                    if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                    {
                        vaccinationsAlert.Text = vaccineList.Count.ToString() + " vaccinations pending";
                    }
                    else
                    {
                        vaccinationsAlert.Text = vaccineList.Count.ToString() + " vacunas pendientes";
                    }
                }
                childBirthday.Text = CurrentChild.Birthday.ToString();

                if (CurrentContext.CurrentUnits.DistanceUnits == DistanceUnits.CM)
                {
                    weightMeasurement.Text = maxDateofWeight == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofWeight, MeasurementType.WEIGHT).Value.ToString() + " oz";
                    heightMeasurement.Text = maxDateofHeight == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofHeight, MeasurementType.HEIGHT).Value.ToString() + " cm";
                    headCircumferenceMeasurement.Text = maxDateofHead == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofHead, MeasurementType.HEAD_CIRCUMFERENCE).Value.ToString() + " cm";
                }
                else
                {
                    weightMeasurement.Text = maxDateofWeight == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofWeight, MeasurementType.WEIGHT).Value.ToString() + " lbs";
                    heightMeasurement.Text = maxDateofHeight == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofHeight, MeasurementType.HEIGHT).Value.ToString() + " in";
                    headCircumferenceMeasurement.Text = maxDateofHead == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofHead, MeasurementType.HEAD_CIRCUMFERENCE).Value.ToString() + " in";   
                }
            }
            
        }

        void OnSettingsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }
    }
}