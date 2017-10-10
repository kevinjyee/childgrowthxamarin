using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using Syncfusion.RangeNavigator.XForms;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace ChartSample
{
	public partial class MyPage : ContentPage
	{
		ViewModel model;

		public MyPage ()
		{
			InitializeComponent ();

			model = new ViewModel();
			this.BindingContext = model;
		}

		void Year_Clicked (object sender, EventArgs e)
		{
			Chart.Title.Text = "year";
			LineSeries.ItemsSource = model.YearData;
		}

		void Quarter_Clicked (object sender, EventArgs e)
		{
			Chart.Title.Text = "q";
			LineSeries.ItemsSource = model.QuarterData;
		}

		void Month_Clicked (object sender, EventArgs e)
		{
			Chart.Title.Text = "mon";
			LineSeries.ItemsSource = model.MonthData;
		}

		void Weak_Clicked (object sender, EventArgs e)
		{
			Chart.Title.Text = "week";
			LineSeries.ItemsSource = model.WeekData;
		}
	}
}

