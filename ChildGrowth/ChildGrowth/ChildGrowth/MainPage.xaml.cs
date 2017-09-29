
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

        void test(object sender, EventArgs e)
        {

        }

        void OnClicksaveEntry(object sender, EventArgs e)
        {
        }

        async void OnButtonClicked(object sender, EventArgs args)
{
    Button button = (Button)sender;
    await DisplayAlert("Clicked!",
        "The button labeled '" + button.Text + "' has been clicked",
        "OK");
}

        void onClick_cancelEntry(object sender, EventArgs e)
        {
            
            Navigation.PopModalAsync();
            
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
                LineData.Add(new Points(weightData.ageList[i],weightList[i]));
            }
        }
    }
}
