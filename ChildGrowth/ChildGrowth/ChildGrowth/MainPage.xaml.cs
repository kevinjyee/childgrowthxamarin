
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using System.Collections.ObjectModel;

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
            int Height = 0;
            int Weight = 0;
            int HeadC = 0;

            try
            {
                Height = int.Parse(HeightEntry.Text);
            }
            catch
            {
            }
            try
            {
                Weight = int.Parse(WeightEntry.Text);
            }
            catch
            {
            }
            try
            {
                HeadC = int.Parse(HeadEntry.Text);
            }
            catch
            {
            }

            Button button = (Button)sender;

            //TODO STEFAN: Replace this with an await call to SQLite
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

 


        void Handle_FabClicked(object sender, System.EventArgs e)

        {

            this.DisplayAlert("Floating Action Button", "You clicked the FAB!", "Awesome!");

        }



        private void UpdateButtonColor(Color color)

        {

            var normal = color;

            var disabled = color.MultiplyAlpha(0.25);



            fabBtn.NormalColor = normal;

            fabBtn.DisabledColor = disabled;

        }
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
