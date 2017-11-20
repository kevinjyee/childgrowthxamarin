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
using ChildGrowth.Pages.Menu;
using System.Collections.ObjectModel;

namespace ChildGrowth.Pages.Insights
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insights : ContentPage
    {
        private MenuMasterDetailPage MasterPage { get; set; }

        private Child _currentChild;

        public Child CurrentChild
        {
            get
            {
                return _currentChild;
            }
            set
            {
                if (_currentChild?.ID != value?.ID)
                {
                    _currentChild = value;
                    OnPropertyChanged("CurrentChild");
                    UpdateTitle();
                    UpdateInsights();
                }
            }
        }

        private Language _currentLanguage { get; set; }

        public Language CurrentLanguage
        {
            get
            {
                return _currentLanguage;
            }
            set
            {
                if (value != _currentLanguage)
                {
                    OnPropertyChanged("CurrentLanguage");
                }
                if (value == Language.ENGLISH)
                {
                    _currentLanguage = value;
                    SetEnglish();
                }
                else
                {
                    SetSpanish();
                }
                updateFields();
            }
        }

        public Context CurrentContext { get; set; }
        ObservableCollection<Warning> warning = new ObservableCollection<Warning>();

        override
        protected void OnAppearing()
        {
            Task Load = Task.Run(async () => { await LoadContext(); });
            Load.Wait();
            if (CurrentContext.CurrentLanguage == Language.ENGLISH)
            {
                SetEnglish();
            }
            else
            {
                SetSpanish();
            }

            UpdateTitle();
            UpdateInsights();
        }

        private void SetEnglish()
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
            VacProgressLabel.Text = "Vaccinations";
            WarningLabel.Text = "Warnings";
        }

        private void SetSpanish()
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
            VacProgressLabel.Text = "Vacunas";
            WarningLabel.Text = "Advertencias"; // TODO: Verify this translation with Juan
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

        public Insights(MenuMasterDetailPage Page)
        {
            InitializeComponent();
            MasterPage = Page;
        }

        private void UpdateInsights()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                updateFields();
            });
        }

        void UpdateTitle()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (CurrentContext == null)
                {
                    CurrentContext = Context.LoadCurrentContext();
                }
                if (CurrentChild != null)
                {
                    this.Title = CurrentChild.Name;
                }
                else
                {
                    if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                    {
                        this.Title = "Please Select a Child";
                    }
                    else
                    {
                        this.Title = "Porfavor Seleccione un Niño";
                    }
                }
            });
        }

        private void updateFields()
        {
            if (CurrentChild == null)
            {
                childBirthday.Text = "NaN";
                heightMeasurement.Text = "NaN";
                weightMeasurement.Text = "NaN";
                headCircumferenceMeasurement.Text = "NaN";
                MeasurementsAlert.Text = "N/A";
                milestonesAlert.Text = "N/A";
                vaccinationsAlert.Text = "N/A";
                emotionalAndSocial.Text = "0%";
                physicalGrowth.Text = "0%";
                LanguageDevelopment.Text = "0%";
                ThinkingAndReasoning.Text = "0%";

                progressBar1.Progress = 0;
                warning.Clear();
            }
            else
            {
                // Get last input dates

                DateTime maxDateofWeight = CurrentChild.Measurements.weightData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.weightData.Keys.Max();
                DateTime maxDateofHeight = CurrentChild.Measurements.heightData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.heightData.Keys.Max();
                DateTime maxDateofHead = CurrentChild.Measurements.headCircumferenceData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.headCircumferenceData.Keys.Max();

                // Check if these dates matches today
                if (maxDateofHead.Date == DateTime.Today.Date
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
                if (milestoneList == null || milestoneList.Count == 1)
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

                /*
                if (CurrentContext.CurrentUnits.DistanceUnits == DistanceUnits.CM)
                {
                    weightMeasurement.Text = maxDateofWeight == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofWeight, MeasurementType.WEIGHT).Value.ToString() + " oz";
                    heightMeasurement.Text = maxDateofHeight == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofHeight, MeasurementType.HEIGHT).Value.ToString() + " cm";
                    headCircumferenceMeasurement.Text = maxDateofHead == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofHead, MeasurementType.HEAD_CIRCUMFERENCE).Value.ToString() + " cm";
                }
                else
                {
                */
                weightMeasurement.Text = maxDateofWeight == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofWeight, MeasurementType.WEIGHT).Value.ToString() + " lbs";
                heightMeasurement.Text = maxDateofHeight == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofHeight, MeasurementType.HEIGHT).Value.ToString() + " in";
                headCircumferenceMeasurement.Text = maxDateofHead == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofHead, MeasurementType.HEAD_CIRCUMFERENCE).Value.ToString() + " in";

                childBirthday.Text = CurrentChild.Birthday.ToString();

                // Update weights
                weightMeasurement.Text = maxDateofWeight == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofWeight, MeasurementType.WEIGHT).Value.ToString() + " oz";
                heightMeasurement.Text = maxDateofHeight == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofHeight, MeasurementType.HEIGHT).Value.ToString() + " cm";
                headCircumferenceMeasurement.Text = maxDateofHead == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofHead, MeasurementType.HEAD_CIRCUMFERENCE).Value.ToString() + " cm";

                Dictionary<Models.MilestoneCategory, List<MilestoneWithResponse>> milestonesPercDict = CurrentChild.GetMilestoneHistory();

                List<MilestoneWithResponse> socialMilestones;
                List<MilestoneWithResponse> cognitiveMilestones;
                List<MilestoneWithResponse> commMilestones;
                List<MilestoneWithResponse> movementMilestones;

                milestonesPercDict.TryGetValue(Models.MilestoneCategory.SOCIAL_AND_EMOTIONAL, out socialMilestones);
                milestonesPercDict.TryGetValue(Models.MilestoneCategory.COGNITIVE, out cognitiveMilestones);
                milestonesPercDict.TryGetValue(Models.MilestoneCategory.COMMUNICATION, out commMilestones);
                milestonesPercDict.TryGetValue(Models.MilestoneCategory.MOVEMENT, out movementMilestones);

                emotionalAndSocial.Text = returnMilestonesPerc(socialMilestones).ToString() + "%";
                physicalGrowth.Text = returnMilestonesPerc(movementMilestones).ToString() + "%";
                LanguageDevelopment.Text = returnMilestonesPerc(commMilestones).ToString() + "%";
                ThinkingAndReasoning.Text = returnMilestonesPerc(cognitiveMilestones).ToString() + "%";

                progressBar1.Progress = CurrentChild.GetVaccinationCompletionPercentage();

                listView1.ItemsSource = warning;
                TimeSpan diff = DateTime.Today.Date - CurrentChild.Birthday.Date;
                if (diff.Days < 365 * 3 && diff.Days > 0)
                {
                    warning.Clear();
                    findWarnings();
                }

                if (warning.Count == 0)
                {
                    warning.Add(new Warning { WarningName = "No Warnings to show" });
                }
            }
        }

        void OnSettingsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage(MasterPage));
        }

        double returnMilestonesPerc(List<MilestoneWithResponse> milestoneList)
        {
            if (milestoneList.Count == 0)
            {
                return 0;
            }
            return Math.Floor(((double)milestoneList.FindAll(p => p.Answer == BinaryAnswer.YES).Count() / milestoneList.Count()) * 100);
        }

        void findWarnings()
        {
            warning.Clear();

            //Measurement Anonamlies
            DateTime maxDateofWeight = CurrentChild.Measurements.weightData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.weightData.Keys.Max();
            DateTime maxDateofHeight = CurrentChild.Measurements.heightData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.heightData.Keys.Max();
            DateTime maxDateofHead = CurrentChild.Measurements.headCircumferenceData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.headCircumferenceData.Keys.Max();

            // Update weights
            double wt = maxDateofWeight == DateTime.MinValue ? -1 : CurrentChild.GetMeasurementForDateAndType(maxDateofWeight, MeasurementType.WEIGHT).Value;
            double ht = maxDateofHeight == DateTime.MinValue ? -1 : CurrentChild.GetMeasurementForDateAndType(maxDateofHeight, MeasurementType.HEIGHT).Value;
            double hd = maxDateofHead == DateTime.MinValue ? -1 : CurrentChild.GetMeasurementForDateAndType(maxDateofHead, MeasurementType.HEAD_CIRCUMFERENCE).Value;
            WHOData data = new WHOData();

            if (wt != -1)
            {
                Tuple<double, double> acceptable = acceptableRange(data.weightPercentile);
                if (wt < acceptable.Item1)
                {
                    if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                    {
                        warning.Add(new Warning { WarningName = CurrentChild.Name + " " + "is under the 5th percentile in weight" });
                    }
                    else
                    {
                        warning.Add(new Warning { WarningName = CurrentChild.Name + " " + "está bajo el 5 por ciento en peso" });
                    }
                }

                if (wt > acceptable.Item2)
                {
                    if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                    {
                        warning.Add(new Warning { WarningName = CurrentChild.Name + " " + "is over the 95th percentile in weight" });
                    }
                    else
                    {
                        warning.Add(new Warning { WarningName = CurrentChild.Name + " " + "está sobre el 95 por ciento en peso" });
                    }
                }
            }


            if (ht != -1)
            {
                Tuple<double, double> acceptable = acceptableRange(data.heightPercentile);
                if (ht < acceptable.Item1)
                {
                    if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                    {
                        warning.Add(new Warning { WarningName = CurrentChild.Name + " " + "is under the 5th percentile in height" });
                    }
                    else
                    {
                        warning.Add(new Warning { WarningName = CurrentChild.Name + " " + "está bajo el 5 por ciento en estatura" });
                    }
                }
            }

            if (hd != -1)
            {
                Tuple<double, double> acceptable = acceptableRange(data.headPercentile);
                if (hd < acceptable.Item1)
                {

                    if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                    {
                        warning.Add(new Warning { WarningName = CurrentChild.Name + " " + "is under the 5th percentile in head circumference" });
                    }
                    else
                    {
                        warning.Add(new Warning { WarningName = CurrentChild.Name + " " + "está bajo el 5 por ciento en circunferencia de cabeza" });
                    }
                }

                if (hd > acceptable.Item2)
                {
                    if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                    {
                        warning.Add(new Warning { WarningName = CurrentChild.Name + " " + "is over the 95th percentile in head circumference" });
                    }
                    else
                    {
                        warning.Add(new Warning { WarningName = CurrentChild.Name + " " + "está sobre el 95 por ciento en circunferencia de cabeza" });
                    }
                }
            }
        }

        Tuple<double, double> acceptableRange(Dictionary<WHOData.Sex, Dictionary<WHOData.Percentile, List<double>>> data)
        {
            //Measurement Anonamlies
            DateTime maxDateofWeight = CurrentChild.Measurements.weightData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.weightData.Keys.Max();
            DateTime maxDateofHeight = CurrentChild.Measurements.heightData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.heightData.Keys.Max();
            DateTime maxDateofHead = CurrentChild.Measurements.headCircumferenceData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.headCircumferenceData.Keys.Max();

            TimeSpan diff = maxDateofWeight - CurrentChild.Birthday;
            double months = diff.TotalDays / 30.4;

            Dictionary<WHOData.Percentile, List<double>> weightData;

            if (CurrentChild.ChildGender == Child.Gender.MALE)
            {
                data.TryGetValue(WHOData.Sex.Male, out weightData);
            }
            else
            {
                data.TryGetValue(WHOData.Sex.Female, out weightData);
            }

            List<double> P5WeightList;
            List<double> P95WeightList;

            weightData.TryGetValue(WHOData.Percentile.P5, out P5WeightList);
            weightData.TryGetValue(WHOData.Percentile.P95, out P95WeightList);

            double x = Math.Round(months * 2, MidpointRounding.AwayFromZero) / 2;

            double acceptableP5Weight;
            double acceptableP95Weight;

            WHOData ageData = new WHOData();
            if (x % 1 == 0 && x > 0)
            {
                double lowX = x - 0.5;
                double highX = x + 0.5;
                int ageLow = ageData.ageList.IndexOf(lowX);
                int ageHigh = ageData.ageList.IndexOf(highX);
                acceptableP5Weight = (P5WeightList[ageLow] + P5WeightList[ageHigh]) / 2;
                acceptableP95Weight = (P95WeightList[ageLow] + P95WeightList[ageHigh]) / 2;
            }
            else
            {
                int age = ageData.ageList.IndexOf(x);
                acceptableP5Weight = P5WeightList[age];
                acceptableP95Weight = P95WeightList[age];
            }

            return new Tuple<double, double>(acceptableP5Weight, acceptableP95Weight);
        }

        public class Warning
        {
            public string WarningName { get; set; }
        }
    }
}