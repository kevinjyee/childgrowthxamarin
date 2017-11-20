using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using System.Collections.ObjectModel;
using ChildGrowth.Persistence;
using ChildGrowth.Pages.AddChild;
using System.ComponentModel;
using ChildGrowth.Constants;
using ChildGrowth.Pages.Settings;
using ChildGrowth.Models.Settings;
using System.Runtime.CompilerServices;
using ChildGrowth.Pages.Menu;

namespace ChildGrowth
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private MenuMasterDetailPage MasterPage { get; set; }
        private Child _currentChild;
        private DateTime _currentChildBirthday;
        private Language _currentLanguage;

        DateTime CurrentChildBirthday
        {
            get
            {
                return this._currentChildBirthday;
            }
            set
            {
                this._currentChildBirthday = value;
                this.EntryDate.MinimumDate = value;
            }
        }

        public Child CurrentChild
        {
            get
            {
                return _currentChild;
            }
            set
            {
                if(_currentChild?.ID != value?.ID && value != null)
                {
                    _currentChild = value;
                    CurrentChildBirthday = _currentChild.Birthday;
                    NotifyPropertyChanged(nameof(CurrentChildBirthday));
                    OnPropertyChanged("CurrentChild");
                    UpdateGraph();
                    UpdateTitle();
                    UpdateSelectedMeasurements();
                }
                else if(value == null)
                {
                    //NotifyPropertyChanged(nameof(CurrentChildBirthday));
                    _currentChild = null;
                    OnPropertyChanged("CurrentChild");
                    UpdateGraph();
                    UpdateTitle();
                    UpdateSelectedMeasurements();
                }
            }
        }

        public Language CurrentLanguage
        {
            get
            {
                return _currentLanguage;
            }
            set
            {
                if(value != _currentLanguage)
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
            }
        }

        public void SetCurrentChild(Child c)
        {
            this.CurrentChild = c;
        }

        public Context CurrentContext { get; set; }
        private MeasurementType CurrentMeasurementType { get; set; } = MeasurementType.WEIGHT;

        public MainPage()
        {
            InitializeComponent();
            UpdateDateSelectionEnabledStatus(false);
            if (CurrentContext == null)
            {
                CurrentContext = Context.LoadCurrentContext();
            }
            if (CurrentChild != null)
            {
                TryLoadingMeasurementDataForDateAndChild(this.EntryDate.Date, CurrentChild);
            }
        }

        public MainPage(MenuMasterDetailPage Page)
        {
            InitializeComponent();
            UpdateDateSelectionEnabledStatus(false);
            MasterPage = Page;
            if (CurrentContext == null)
            {
                CurrentContext = Context.LoadCurrentContext();
            }
            if (CurrentChild != null)
            {
                TryLoadingMeasurementDataForDateAndChild(this.EntryDate.Date, CurrentChild);
            }
        }

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
            if (CurrentChild != null)
            {
                TryLoadingMeasurementDataForDateAndChild(this.EntryDate.Date, CurrentChild);
            }
            UpdateTitle();
            UpdateGraph();
            UpdateSelectedMeasurements();
            UpdateButtons();
            /*
            if (CurrentChild != null)
            {
                this.Title = CurrentChild.Name;
                UpdateDateSelectionEnabledStatus(true);
            }
            else
            {
                if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                {
                    this.Title = "Please Select a Child";
                } else{
                    this.Title = "Porfavor Seleccione un Niño";
                }
                UpdateDateSelectionEnabledStatus(false);
            }
            */
        }

        protected void UpdateButtons()
        {
            if (CurrentMeasurementType == MeasurementType.WEIGHT)
            {
                if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                {
                    weightButton.Source = ImageSource.FromFile("weight_clicked.png");
                    heightButton.Source = ImageSource.FromFile("height_unclicked.png");
                    headButton.Source = ImageSource.FromFile("head_circumference_unclicked.png");
                }
                else
                {
                    weightButton.Source = ImageSource.FromFile("weight_sp_blue.png");
                    heightButton.Source = ImageSource.FromFile("height_unclicked_sp.png");
                    headButton.Source = ImageSource.FromFile("head_circumference_unclicked_sp.png");
                }
            }
            else if (CurrentMeasurementType == MeasurementType.HEIGHT)
            {
                if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                {
                    weightButton.Source = ImageSource.FromFile("weightunclicked.png");
                    heightButton.Source = ImageSource.FromFile("height_clicked.png");
                    headButton.Source = ImageSource.FromFile("head_circumference_unclicked.png");
                }
                else
                {
                    weightButton.Source = ImageSource.FromFile("weight_sp.png");
                    heightButton.Source = ImageSource.FromFile("height_sp_blue.png");
                    headButton.Source = ImageSource.FromFile("head_circumference_unclicked_sp.png");
                }
            }
            else
            {
                if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                {
                    weightButton.Source = ImageSource.FromFile("weightunclicked.png");
                    heightButton.Source = ImageSource.FromFile("height_unclicked.png");
                    headButton.Source = ImageSource.FromFile("head_circumference_clicked.png");
                }
                else
                {
                    weightButton.Source = ImageSource.FromFile("weight_sp.png");
                    heightButton.Source = ImageSource.FromFile("height_sp.png");
                    headButton.Source = ImageSource.FromFile("head_circumference_sp_blue.png");
                }
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        static object GraphLock = new object();

        void UpdateGraph()
        {
            //OnMeasurementClicked(CurrentMeasurementType);
            Device.BeginInvokeOnMainThread(() =>
            {
                if (CurrentContext == null)
                {
                    CurrentContext = Context.LoadCurrentContext();
                }
                if (CurrentChild != null)
                {
                    TryLoadingMeasurementDataForDateAndChild(this.EntryDate.Date, CurrentChild);
                }
            });

            //Task UpdateChart = Task.Run(async () => { await OnMeasurementClicked(CurrentMeasurementType); });
            //UpdateChart.Wait();
        }

        void UpdateSelectedMeasurements()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (CurrentContext == null)
                {
                    CurrentContext = Context.LoadCurrentContext();
                }
                if(CurrentChild == null)
                {
                    HeightEntry.Text = "";
                    WeightEntry.Text = "";
                    HeadEntry.Text = "";
                }
                OnMeasurementClicked(CurrentMeasurementType);
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
                    UpdateDateSelectionEnabledStatus(true);
                }
                else
                {
                    if (CurrentContext?.CurrentLanguage == Language.ENGLISH)
                    {
                        this.Title = "Please Select a Child";
                    }
                    else
                    {
                        this.Title = "Porfavor Seleccione un Niño";
                    }
                    UpdateDateSelectionEnabledStatus(false);
                }
            });
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
            catch(Exception e)
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
                _currentChild = null;
                CurrentChildBirthday = DateTime.Today;
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

        private void SetEnglish()
        {
            MeasurementTitle.Text = "Measurements";
            weightButton.Source = ImageSource.FromFile("weightunclicked.png");
            heightButton.Source = ImageSource.FromFile("height_unclicked.png");
            headButton.Source = ImageSource.FromFile("head_circumference_unclicked.png");
            TableTitle.Title = "Date";
            DateLabel.Text = "Entry Date:";
            TableTitleTwo.Title = "Measurements";
            if (CurrentContext.CurrentUnits.DistanceUnits == DistanceUnits.CM){
                HeightEntry.Label = "Height (cm): ";
                WeightEntry.Label = "Weight (oz): ";
                HeadEntry.Label = "Head Circumeference (cm): ";
            } 
            else
            {
                HeightEntry.Label = "Height (in): ";
                WeightEntry.Label = "Weight (lbs): ";
                HeadEntry.Label = "Head Circumeference (in): ";
            }
            submitButton.Text = "Submit";
            cancelButton.Text = "Cancel";
        }

        private void SetSpanish()
        {
            MeasurementTitle.Text = "Medidas";
            weightButton.Source = ImageSource.FromFile("weightunclicked_sp.png");
            heightButton.Source = ImageSource.FromFile("height_unclicked_sp.png");
            headButton.Source = ImageSource.FromFile("head_circumference_unclicked_sp.png");
            TableTitle.Title = "Fecha";
            DateLabel.Text = "Fecha:";
            TableTitleTwo.Title = "Medidas";
            if (CurrentContext.CurrentUnits.DistanceUnits == DistanceUnits.CM)
            {
                HeightEntry.Label = "Estatura (cm): ";
                WeightEntry.Label = "Peso (oz): ";
                HeadEntry.Label = "Circunferencia de Cabeza (cm): ";
            }
            else
            {
                HeightEntry.Label = "Estatura (in): ";
                WeightEntry.Label = "Peso (lbs): ";
                HeadEntry.Label = "Circunferencia de Cabeza (in): ";
            }
            submitButton.Text = "Guardar";
            cancelButton.Text = "Cancelar";
        }

        void OnSettingsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage(MasterPage));
        }

        /// <summary>
        /// Clears the values of Height, Weight, Head
        /// </summary>
        void OnCancelClicked(object sender, EventArgs args)
        {
            HeightEntry.Text = "";
            WeightEntry.Text = "";
            HeadEntry.Text = "";
        }

        /// <summary>
        /// Submit Height, Weight, and HeadC
        /// </summary>
        async void OnSubmitClicked(object sender, EventArgs args)
        {
            Double Height = DEFAULT_MEASUREMENT_VALUE;
            Double Weight = DEFAULT_MEASUREMENT_VALUE;
            Double HeadC = DEFAULT_MEASUREMENT_VALUE;

            try
            {
                Height = Double.Parse(HeightEntry.Text);
            }
            catch
            {
            }
            try
            {
                Weight = Double.Parse(WeightEntry.Text);
            }
            catch
            {
            }
            try
            {
                HeadC = Double.Parse(HeadEntry.Text);
            }
            catch
            {
            }

            Button button = (Button)sender;

            //TODO STEFAN: Replace this with an await call to SQLite
            ChildDatabaseAccess childDatabase = new ChildDatabaseAccess();
            DateTime selectedDate = GetSelectedDate();
            Units currentUnits = GetCurrentUnits();

            if (CurrentChild != null)
            {
                try
                {
                    if (DEFAULT_MEASUREMENT_VALUE != Height)
                    {
                        CurrentChild.AddMeasurementForDateAndType(selectedDate, MeasurementType.HEIGHT, currentUnits, Height);
                    }
                    if (DEFAULT_MEASUREMENT_VALUE != Weight)
                    {
                        CurrentChild.AddMeasurementForDateAndType(selectedDate, MeasurementType.WEIGHT, currentUnits, Weight);
                    }
                    if (DEFAULT_MEASUREMENT_VALUE != HeadC)
                    {
                        CurrentChild.AddMeasurementForDateAndType(selectedDate, MeasurementType.HEAD_CIRCUMFERENCE, currentUnits, HeadC);
                    }
                    UpdateSelectedMeasurements();

                }
                catch (Exception e)
                {
                    
                }

                List<Points> points = _currentChild.GetSortedMeasurementListByType(MeasurementType.WEIGHT);
                if (points == null)
                {
                    _currentChild.AddMeasurementForDateAndType(_currentChild.Birthday, MeasurementType.WEIGHT, CurrentContext.CurrentUnits, 0.0);
                    return;
                }
                foreach (Points pt in points)
                {
                    viewModel.InputData.Add(pt);
                }
            }
            
          
        }

        async Task OnMeasurementClicked(MeasurementType measurementType)
        {
            CurrentMeasurementType = measurementType;
            String measurementTitle = MeasurementEnums.MeasurementTypeAsString(measurementType, CurrentContext.CurrentLanguage);
            viewModel.ChartTitle = measurementTitle;
            GrowthChart.Text = measurementTitle;
            try
            {
                viewModel.InputData.Clear();
            }
            catch(Exception e)
            {
                // Changing children and reverting to this page causes a crash.
                viewModel = new ViewModel();
                viewModel.ChartTitle = measurementTitle;
            }
            if (CurrentChild == null)
            {
                return;
            }
            GrowthChart.Text = measurementTitle;
            viewModel.InputData.Clear();
            if(CurrentChild == null)
            {
                if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                {
                    await DisplayAlert("Error",
                                       "Please select a child",
                                       "OK");
                    return;
                }
                else
                {
                    await DisplayAlert("Error",
                                       "Porfavor seleccione un niño",
                                       "OK");
                    return;
                }
            }
            List<Points> points = CurrentChild.GetSortedMeasurementListByType(measurementType);
            if (points == null)
            {
                CurrentChild.AddMeasurementForDateAndType(CurrentChild.Birthday, MeasurementType.HEIGHT, CurrentContext.CurrentUnits, 0.0);
                CurrentChild.AddMeasurementForDateAndType(CurrentChild.Birthday, MeasurementType.WEIGHT, CurrentContext.CurrentUnits, 0.0);
                CurrentChild.AddMeasurementForDateAndType(CurrentChild.Birthday, MeasurementType.HEAD_CIRCUMFERENCE, CurrentContext.CurrentUnits, 0.0);
                return;
            }
            foreach (Points pt in points)
            {
                viewModel.InputData.Add(pt);
            }
            viewModel.LineData3.Clear();
            viewModel.LineData5.Clear();
            viewModel.LineData10.Clear();
            viewModel.LineData25.Clear();
            viewModel.LineData50.Clear();
            viewModel.LineData75.Clear();
            viewModel.LineData90.Clear();

            WHOData measurementData = new WHOData();

            Dictionary<WHOData.Percentile, List<double>> measurementsByGender;

            List<Double> measurementList3;
            List<Double> measurementList5;
            List<Double> measurementList10;
            List<Double> measurementList25;
            List<Double> measurementList50;
            List<Double> measurementList75;
            List<Double> measurementList90;
            
            // Find list of measurements for measurement type and gender. TODO: Change this based on preferred units.
            switch (measurementType)
            {
                case MeasurementType.WEIGHT:
                    measurementData.weightPercentile.TryGetValue(WHOData.AdaptChildGender(CurrentChild.ChildGender), out measurementsByGender);
                    break;
                case MeasurementType.HEIGHT:
                    measurementData.heightPercentile.TryGetValue(WHOData.AdaptChildGender(CurrentChild.ChildGender), out measurementsByGender);
                    break;
                case MeasurementType.HEAD_CIRCUMFERENCE:
                    measurementData.headPercentile.TryGetValue(WHOData.AdaptChildGender(CurrentChild.ChildGender), out measurementsByGender);
                    break;
                default:
                    measurementData.weightPercentile.TryGetValue(WHOData.AdaptChildGender(CurrentChild.ChildGender), out measurementsByGender);
                    break;
            }

            measurementsByGender.TryGetValue(WHOData.Percentile.P3, out measurementList3);
            measurementsByGender.TryGetValue(WHOData.Percentile.P5, out measurementList5);
            measurementsByGender.TryGetValue(WHOData.Percentile.P10, out measurementList10);
            measurementsByGender.TryGetValue(WHOData.Percentile.P25, out measurementList25);
            measurementsByGender.TryGetValue(WHOData.Percentile.P50, out measurementList50);
            measurementsByGender.TryGetValue(WHOData.Percentile.P75, out measurementList75);
            measurementsByGender.TryGetValue(WHOData.Percentile.P90, out measurementList90);

            for (int i = 0; i < measurementData.ageList.Count(); i++)
            {
                viewModel.LineData3.Add(new Points(measurementData.ageList[i], measurementList3[i]));
                viewModel.LineData5.Add(new Points(measurementData.ageList[i], measurementList5[i]));
                viewModel.LineData10.Add(new Points(measurementData.ageList[i], measurementList10[i]));
                viewModel.LineData25.Add(new Points(measurementData.ageList[i], measurementList25[i]));
                viewModel.LineData50.Add(new Points(measurementData.ageList[i], measurementList50[i]));
                viewModel.LineData75.Add(new Points(measurementData.ageList[i], measurementList75[i]));
                viewModel.LineData90.Add(new Points(measurementData.ageList[i], measurementList90[i]));
            }
        }


       async void OnWeightClicked(object sender, EventArgs args)
        {
            if (CurrentContext.CurrentLanguage == Language.ENGLISH)
            {
                weightButton.Source = ImageSource.FromFile("weight_clicked.png");
                heightButton.Source = ImageSource.FromFile("height_unclicked.png");
                headButton.Source = ImageSource.FromFile("head_circumference_unclicked.png");
            }
            else
            {
                weightButton.Source = ImageSource.FromFile("weight_sp_blue.png");
                heightButton.Source = ImageSource.FromFile("height_unclicked_sp.png");
                headButton.Source = ImageSource.FromFile("head_circumference_unclicked_sp.png");
            }
            await OnMeasurementClicked(MeasurementType.WEIGHT);
        }

        //TODO STEFAN: Prompt a change of graph
        async void OnHeightClicked(object sender, EventArgs args)
        {
            if (CurrentContext.CurrentLanguage == Language.ENGLISH)
            {
                weightButton.Source = ImageSource.FromFile("weightunclicked.png");
                heightButton.Source = ImageSource.FromFile("height_clicked.png");
                headButton.Source = ImageSource.FromFile("head_circumference_unclicked.png");
            }
            else
            {
                weightButton.Source = ImageSource.FromFile("weight_sp.png");
                heightButton.Source = ImageSource.FromFile("height_sp_blue.png");
                headButton.Source = ImageSource.FromFile("head_circumference_unclicked_sp.png");
            }
            await OnMeasurementClicked(MeasurementType.HEIGHT);
        }

        //TODO STEFAN: Prompt a change of graph
        async void OnHeadClicked(object sender, EventArgs args)
        {
            if (CurrentContext.CurrentLanguage == Language.ENGLISH)
            {
                weightButton.Source = ImageSource.FromFile("weightunclicked.png");
                heightButton.Source = ImageSource.FromFile("height_unclicked.png");
                headButton.Source = ImageSource.FromFile("head_circumference_clicked.png");
            }
            else
            {
                weightButton.Source = ImageSource.FromFile("weight_sp.png");
                heightButton.Source = ImageSource.FromFile("height_sp.png");
                headButton.Source = ImageSource.FromFile("head_circumference_sp_blue.png");
            }
            await OnMeasurementClicked(MeasurementType.HEAD_CIRCUMFERENCE);
        }

        // TODO: Change this to get current child from session data.

        // TODO: Set this DateTime from date selected via a calendar widget.
        private DateTime GetSelectedDate()
        {
            return this.EntryDate.Date;
        }



        // TODO: Set these Units from units selected via settings.
        private Units GetCurrentUnits()
        {
            return new Units(DistanceUnits.IN, WeightUnits.OZ);
        }

        private static int DEFAULT_MEASUREMENT_VALUE = -1;

        private void UpdateDateSelectionEnabledStatus(Boolean isEnabled)
        {
            this.EntryDate.IsEnabled = isEnabled;
            UpdateMeasurementsEnabledStatus(isEnabled);
        }

        private void UpdateMeasurementsEnabledStatus(Boolean isEnabled)
        {
            this.HeightEntry.IsEnabled = isEnabled;
            this.WeightEntry.IsEnabled = isEnabled;
            this.HeadEntry.IsEnabled = isEnabled;
        }


        private void EntryDate_DateSelected(object sender, DateChangedEventArgs e)
        {
             if (CurrentChild != null)
             {
                TryLoadingMeasurementDataForDateAndChild(this.EntryDate.Date, CurrentChild);
             }

        }

        private void TryLoadingMeasurementDataForDateAndChild(DateTime date, Child child)
        {
            if (date == null || child == null)
            {
                return;
            }
            ChildDatabaseAccess childDatabaseAccess = new ChildDatabaseAccess();
            GrowthMeasurement height = child.GetMeasurementForDateAndType(date, MeasurementType.HEIGHT);
            if (height != null)
            {
                HeightEntry.Text = height.Value.ToString();
            }
            else
            {
                HeightEntry.Text = "";
            }
            GrowthMeasurement weight = child.GetMeasurementForDateAndType(date, MeasurementType.WEIGHT);
            if (weight != null)
            {
                WeightEntry.Text = weight.Value.ToString();
            }
            else
            {
                WeightEntry.Text = "";
            }
            GrowthMeasurement headC = child.GetMeasurementForDateAndType(date, MeasurementType.HEAD_CIRCUMFERENCE);
            if (headC != null)
            {
                HeadEntry.Text = headC.Value.ToString();
            }
            else
            {
                HeadEntry.Text = "";
            }
        }

        private void EntryDate_Unfocused(object sender, FocusEventArgs e)
        {

        }
    }

    public class Points : INotifyPropertyChanged
    {
        public Points(double age, double val)
        {
            Age = age;
            Val = val;
        }

        private double age;
        private double val;

        public double Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                NotifyPropertyChanged("Age");
            }
        }

        public double Val
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
                NotifyPropertyChanged("Val");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

        public class ViewModel
        {

            public String ChartTitle { get; set; }

            private ObservableCollection<Points> lineData3;
            private ObservableCollection<Points> lineData5;
            private ObservableCollection<Points> lineData10;
            private ObservableCollection<Points> lineData25;
            private ObservableCollection<Points> lineData50;
            private ObservableCollection<Points> lineData75;
            private ObservableCollection<Points> lineData90;

            public ObservableCollection<Points> LineData3
            {
                get { return lineData3; }
                set { lineData3 = value; }
            }

            public ObservableCollection<Points> LineData5
            {
                get { return lineData5; }
                set { lineData5 = value; }
            }

            public ObservableCollection<Points> LineData10
            {
                get { return lineData10; }
                set { lineData10 = value; }
            }

            public ObservableCollection<Points> LineData25
            {
                get { return lineData25; }
                set { lineData25 = value; }
            }

            public ObservableCollection<Points> LineData50
            {
                get { return lineData50; }
                set { lineData50 = value; }
            }

            public ObservableCollection<Points> LineData75
            {
                get { return lineData75; }
                set { lineData75 = value; }
            }
            public ObservableCollection<Points> LineData90
            {
                get { return lineData90; }
                set { lineData90 = value; }
            }
            private ObservableCollection<Points> inputData;

            public ObservableCollection<Points> InputData
            {
                get { return inputData; }
                set { inputData = value; }
            }

            public ViewModel()
            {
                ChartTitle = "Weight";
                LineData3 = new ObservableCollection<Points>();
                LineData5 = new ObservableCollection<Points>();
                LineData10 = new ObservableCollection<Points>();
                LineData25 = new ObservableCollection<Points>();
                LineData50 = new ObservableCollection<Points>();
                LineData75 = new ObservableCollection<Points>();
                LineData90 = new ObservableCollection<Points>();

                WHOData weightData = new WHOData();

                Dictionary<WHOData.Percentile, List<double>> weightByGender;

                List<Double> weightList3;
                List<Double> weightList5;
                List<Double> weightList10;
                List<Double> weightList25;
                List<Double> weightList50;
                List<Double> weightList75;
                List<Double> weightList90;

                weightData.weightPercentile.TryGetValue(WHOData.Sex.Male, out weightByGender);
                weightByGender.TryGetValue(WHOData.Percentile.P3, out weightList3);
                weightByGender.TryGetValue(WHOData.Percentile.P5, out weightList5);
                weightByGender.TryGetValue(WHOData.Percentile.P10, out weightList10);
                weightByGender.TryGetValue(WHOData.Percentile.P25, out weightList25);
                weightByGender.TryGetValue(WHOData.Percentile.P50, out weightList50);
                weightByGender.TryGetValue(WHOData.Percentile.P75, out weightList75);
                weightByGender.TryGetValue(WHOData.Percentile.P90, out weightList90);

                for (int i = 0; i < weightData.ageList.Count(); i++)
                {
                    LineData3.Add(new Points(weightData.ageList[i], weightList3[i]));
                    LineData5.Add(new Points(weightData.ageList[i], weightList5[i]));
                    LineData10.Add(new Points(weightData.ageList[i], weightList10[i]));
                    LineData25.Add(new Points(weightData.ageList[i], weightList25[i]));
                    LineData50.Add(new Points(weightData.ageList[i], weightList50[i]));
                    LineData75.Add(new Points(weightData.ageList[i], weightList75[i]));
                    LineData90.Add(new Points(weightData.ageList[i], weightList90[i]));
                }

                InputData = new ObservableCollection<Points>();
                List<Double> weightList2;
                weightByGender.TryGetValue(WHOData.Percentile.P90, out weightList2);
                for (int i = 0; i < weightData.ageList.Count(); i++)
                {
                    //InputData.Add(new Points(weightData.ageList[i], weightList2[i]));
                }
                //InputData.Add(new Points(1, 1));

            }
        }
    }