using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;
using System.Diagnostics;

namespace ChartSample
{
	public class SimpleSample : ContentPage
	{
		List<ChartDataPoint> Data;
		private SfChart chart;
		StackLayout layout = new StackLayout() { Padding = new Thickness(5, 15, 0, 5) };
		ScatterSeries series;
		List<Color> Colors;
		public SimpleSample()
		{
			Data = new List<ChartDataPoint>();
			Getdata();
			layout.Children.Add(GetChart());
			Content = layout;
		}

		private SfChart GetChart()
		{
			chart = new SfChart();

			chart.HorizontalOptions = LayoutOptions.FillAndExpand;
			chart.VerticalOptions = LayoutOptions.FillAndExpand;

			chart.PrimaryAxis = new NumericalAxis();
			chart.SecondaryAxis = new NumericalAxis();

			series = new ScatterSeries();
			series.ColorModel = new ChartColorModel { Palette = ChartColorPalette.Custom, CustomBrushes = Colors };

			series.ItemsSource = Data;

			chart.Series.Add(series);
			return chart;
		}

		public void Getdata()
		{
			Random random = new Random();

			for (int i = 0; i < 300; i++)
			{
				double x = random.Next (0, 100);
				double y = random.Next (0, 100); 

				Data.Add (new ChartDataPoint (x, y));

			}

			GenerateColors();
		}

		public void GenerateColors()
		{
			Colors = new List<Color>();
			foreach (ChartDataPoint dataPoint in Data)
			{
				if (dataPoint.YValue > 50 && dataPoint.YValue < 75)
					Colors.Add(Color.Green);
				else 
					Colors.Add(Color.Red);
			}
		}
	}
}