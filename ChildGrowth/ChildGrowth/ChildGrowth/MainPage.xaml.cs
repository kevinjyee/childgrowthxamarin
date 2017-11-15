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

namespace ChildGrowth
{
    public partial class MainPage : ContentPage
    {
        public Child CurrentChild{ get; set; }
        public Context CurrentContext { get; set; }

        public MainPage()
        {
            InitializeComponent();
            UpdateDateSelectionEnabledStatus(false);
           
            
        }

        override
        protected void OnAppearing()
        {
            Task Load = Task.Run(async () => { await LoadContext(); });
            Load.Wait();
            if (CurrentChild != null)
            {
                this.Title = CurrentChild.Name;
                UpdateDateSelectionEnabledStatus(true);
            }
            else{
                this.Title = "Please Select a Child";
                UpdateDateSelectionEnabledStatus(false);

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

        void OnSettingsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
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
            Child currentChild = CurrentChild;
            DateTime selectedDate = GetSelectedDate();
            Units currentUnits = GetCurrentUnits();

            if (currentChild != null)
            {
                try
                {
                    if (DEFAULT_MEASUREMENT_VALUE != Height)
                    {
                        currentChild.AddMeasurementForDateAndType(selectedDate, MeasurementType.HEIGHT, currentUnits, Height);
                    }
                    if (DEFAULT_MEASUREMENT_VALUE != Weight)
                    {
                        currentChild.AddMeasurementForDateAndType(selectedDate, MeasurementType.WEIGHT, currentUnits, Weight);
                    }
                    if (DEFAULT_MEASUREMENT_VALUE != HeadC)
                    {
                        currentChild.AddMeasurementForDateAndType(selectedDate, MeasurementType.HEAD_CIRCUMFERENCE, currentUnits, HeadC);
                    }

                }
                catch (Exception e)
                {

                }
            }
            
          
        }


       async void OnWeightClicked(object sender, EventArgs args)
        {
            viewModel.ChartTitle = "Weight";
            GrowthChart.Text = "Weight";
            ChildDatabaseAccess childDatabaseAccess = new ChildDatabaseAccess();
            Child currentChild = CurrentChild;
            viewModel.InputData.Clear();
            if(currentChild == null)
            {
                await DisplayAlert("Error",
                "Please select a child",
                "OK");
                return;
            }
            List<Points> points = currentChild.GetSortedMeasurementListByType(MeasurementType.WEIGHT);
            if (points == null)
            {
                currentChild.AddMeasurementForDateAndType(currentChild.Birthday,MeasurementType.WEIGHT, CurrentContext.CurrentUnits, 0.0);
                return;
            }
            foreach (Points pt in points)
            {
                viewModel.InputData.Add(pt);
            }
        }

        //TODO STEFAN: Prompt a change of graph
        async void OnHeightClicked(object sender, EventArgs args)
        {
            viewModel.ChartTitle = "Height";
            GrowthChart.Text = "Height";
            ChildDatabaseAccess childDatabaseAccess = new ChildDatabaseAccess();
            Child currentChild = CurrentChild;
            if (currentChild == null)
            {
                await DisplayAlert("Error",
                "Please select a child",
                "OK");
                return;
            }
            viewModel.InputData?.Clear();
            List<Points> points = currentChild.GetSortedMeasurementListByType(MeasurementType.HEIGHT);
            if (points == null)
            {
                currentChild.AddMeasurementForDateAndType(currentChild.Birthday, MeasurementType.HEIGHT, CurrentContext.CurrentUnits, 0.0);
                return;
            }
            foreach (Points pt in points)
            {
                viewModel.InputData.Add(pt);
            }
        }

        //TODO STEFAN: Prompt a change of graph
        async void OnHeadClicked(object sender, EventArgs args)
        {
            viewModel.ChartTitle = "Head Circumference";
            GrowthChart.Text = "Head Circumference";
            ChildDatabaseAccess childDatabaseAccess = new ChildDatabaseAccess();
            Child currentChild = CurrentChild;
            if (currentChild == null)
            {
                await DisplayAlert("Error",
                "Please select a child",
                "OK");
                return;
            }
            viewModel.InputData.Clear();
            List<Points> points = currentChild.GetSortedMeasurementListByType(MeasurementType.HEAD_CIRCUMFERENCE);
            if (points == null)
            {
                currentChild.AddMeasurementForDateAndType(currentChild.Birthday, MeasurementType.HEAD_CIRCUMFERENCE, CurrentContext.CurrentUnits, 0.0);
                return;
            }
            foreach (Points pt in points)
            {
                viewModel.InputData.Add(pt);
            }
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


        private async void UpdateGraph()
        {
            //TODO: Determine current child on session state before i can update graph
        }

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
             Child currentChild = CurrentChild;
             if (currentChild != null)
                {
                    TryLoadingMeasurementDataForDateAndChild(this.EntryDate.Date, currentChild);
                }

        }

        private void TryLoadingMeasurementDataForDateAndChild(DateTime date, Child currentChild)
        {
            if (date == null || currentChild == null)
            {
                return;
            }
            ChildDatabaseAccess childDatabaseAccess = new ChildDatabaseAccess();
            GrowthMeasurement height = currentChild.GetMeasurementForDateAndType(date, MeasurementType.HEIGHT);
            if (height != null)
            {
                HeightEntry.Text = height.Value.ToString();
            }
            else
            {
                HeightEntry.Text = "";
            }
            GrowthMeasurement weight = currentChild.GetMeasurementForDateAndType(date, MeasurementType.WEIGHT);
            if (weight != null)
            {
                WeightEntry.Text = weight.Value.ToString();
            }
            else
            {
                WeightEntry.Text = "";
            }
            GrowthMeasurement headC = currentChild.GetMeasurementForDateAndType(date, MeasurementType.HEAD_CIRCUMFERENCE);
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