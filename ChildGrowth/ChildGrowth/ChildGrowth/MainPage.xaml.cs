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

namespace ChildGrowth
{
    public partial class MainPage : ContentPage
    {
        public Child CurrentChild{ get; set;}

        public MainPage(Child child)
        {
            CurrentChild = child;
            this.Title = CurrentChild.Name;
            InitializeComponent();
            UpdateDateSelectionEnabledStatus(false);
        }

        public MainPage()
        {
            InitializeComponent();
            UpdateDateSelectionEnabledStatus(false);
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
                    await childDatabase.InitializeAsync();
                    if (DEFAULT_MEASUREMENT_VALUE != Height)
                    {
                        await currentChild.AddMeasurementForDateAndType(selectedDate, MeasurementType.HEIGHT, currentUnits, Height, childDatabase);
                    }
                    if (DEFAULT_MEASUREMENT_VALUE != Weight)
                    {
                        await currentChild.AddMeasurementForDateAndType(selectedDate, MeasurementType.WEIGHT, currentUnits, Weight, childDatabase);
                    }
                    if (DEFAULT_MEASUREMENT_VALUE != HeadC)
                    {
                        await currentChild.AddMeasurementForDateAndType(selectedDate, MeasurementType.HEAD_CIRCUMFERENCE, currentUnits, HeadC, childDatabase);
                    }
                    await childDatabase.SaveUserChildAsync(currentChild);

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
            foreach (Points pt in currentChild.GetSortedMeasurementListByType(MeasurementType.WEIGHT))
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
            foreach (Points pt in currentChild.GetSortedMeasurementListByType(MeasurementType.HEIGHT))
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
            foreach (Points pt in currentChild.GetSortedMeasurementListByType(MeasurementType.HEAD_CIRCUMFERENCE))
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

        override
        protected void OnAppearing()
        {
            if (CurrentChild != null){
                this.Title = CurrentChild.Name;
            }
            UpdateGraph();
        }

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

        private ObservableCollection<Points> lineData;

        public ObservableCollection<Points> LineData
        {
            get { return lineData; }
            set { lineData = value; }
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
            LineData = new ObservableCollection<Points>();
            WHOData weightData = new WHOData();

            Dictionary<WHOData.Percentile, List<double>> weightByGender;
            List<Double> weightList;

            weightData.weightPercentile.TryGetValue(WHOData.Sex.Male, out weightByGender);
            weightByGender.TryGetValue(WHOData.Percentile.P3, out weightList);

            for (int i = 0; i < weightData.ageList.Count(); i++)
            {
                LineData.Add(new Points(weightData.ageList[i], weightList[i]));
            }

            InputData = new ObservableCollection<Points>();
            List<Double> weightList2;
            weightByGender.TryGetValue(WHOData.Percentile.P90, out weightList2);
            for (int i = 0; i < weightData.ageList.Count(); i++)
            {
                //InputData.Add(new Points(weightData.ageList[i], weightList2[i]));
            }
            InputData.Add(new Points(1, 1));
        }
    }
}