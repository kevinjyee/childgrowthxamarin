using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ChildGrowth
{
    public partial class MainPage : ContentPage
    {
        public PlotModel LineModel { get; set; }

        public MainPage()
        {
            InitializeComponent();
            LineModel = InitializeLineChart("Weight");
            plotView.Model = LineModel;
        }

        PlotModel InitializeLineChart(string title)
        {
            var model = new PlotModel
            {
                Title = title
            };
            addWeights(model);
            return model;
        }

        void addWeights(PlotModel weightChart)
        {
            var lineSeries = new LineSeries();
            WHOData weightData = new WHOData();

            Dictionary<WHOData.Percentile, List<double>> weightByGender;
            List<Double> weightList;

            weightData.weightPercentile.TryGetValue(WHOData.Sex.Male, out weightByGender);
            weightByGender.TryGetValue(WHOData.Percentile.P3, out weightList);


            for (int i = 0; i < weightData.ageList.Count(); i++)
            {
                lineSeries.Points.Add(new DataPoint(weightData.ageList[i], weightList[i]));
            }

            weightChart.Series.Add(lineSeries);
        }

        void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            //MainLable.Text = e.NewDate.ToString();
        }
    }
}
