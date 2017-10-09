
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using System.Collections.ObjectModel;
using ChildGrowth.Persistence;

namespace ChildGrowth
{
    public partial class MainPage : ContentPage
    {

        public ObservableCollection<ChartDataPoint> BarData { get; set; }
        public ObservableCollection<ChartDataPoint> Data { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes WHO Data
        /// </summary>
        void InitializeData()
        {
            Data = new ObservableCollection<ChartDataPoint>();

            WHOData weightData = new WHOData();

            Dictionary<WHOData.Percentile, List<double>> weightByGender;
            List<Double> weightList;

            weightData.weightPercentile.TryGetValue(WHOData.Sex.Male, out weightByGender);
            weightByGender.TryGetValue(WHOData.Percentile.P3, out weightList);

            for (int i = 0; i < weightData.ageList.Count(); i++)
            {
                Data.Add(new ChartDataPoint(weightData.ageList[i], weightList[i]));
            }
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
            Child currentChild = GetCurrentChild();
            DateTime selectedDate = GetSelectedDate();
            Units currentUnits = GetCurrentUnits();
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
                    await currentChild.AddMeasurementForDateAndType(selectedDate, MeasurementType.HEIGHT, currentUnits, HeadC, childDatabase);
                }
                await childDatabase.SaveUserChildAsync(currentChild);
                              
            }
            catch(Exception e)
            {

            }
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
        }

        //TODO STEFAN: Prompt a change of graph
        async void OnWeightClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
        }

        //TODO STEFAN: Prompt a change of graph
        async void OnHeightClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
        }

        //TODO STEFAN: Prompt a change of graph
        async void OnHeadClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
        }

        // TODO: Change this to get current child from session data.
        private Child GetCurrentChild()
        {
            // Replace this with load method
            return new Child("Test_Child", DateTime.MinValue, Child.Gender.MALE);
        }

        // TODO: Set this DateTime from date selected via a calendar widget.
        private DateTime GetSelectedDate()
        {
            return DateTime.Now;
        }

        // TODO: Set these Units from units selected via settings.
        private Units GetCurrentUnits()
        {
            return new Units(DistanceUnits.IN, WeightUnits.OZ);
        }

        private static int DEFAULT_MEASUREMENT_VALUE = -1;
    }

    public class Points
    {
        public double Age { get; set; }

        public double Value { get; set; }

        public Points(double age, double val)
        {
            this.Age = age;
            this.Value = val;
        }
    }

    public class ViewModel
    {
        public List<Points> LineData { get; set; }

        public ViewModel()
        {
            LineData = new List<Points>();
            WHOData weightData = new WHOData();

            Dictionary<WHOData.Percentile, List<double>> weightByGender;
            List<Double> weightList;

            weightData.weightPercentile.TryGetValue(WHOData.Sex.Male, out weightByGender);
            weightByGender.TryGetValue(WHOData.Percentile.P3, out weightList);

            for (int i = 0; i < weightData.ageList.Count(); i++)
            {
                LineData.Add(new Points(weightData.ageList[i], weightList[i]));
            }
        }
    }
}
