using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using Syncfusion.SfChart.XForms;
using System.ComponentModel;
using System.Diagnostics;

namespace SimpleSample
{
	public class ViewModel
	{
		public ViewModel()
		{
			Models = new ObservableCollection<Model>();

			Models.Add(new Model("Desktop", 147, 140));
			Models.Add(new Model("Laptop", 200, 205));
			Models.Add(new Model("Keyboard", 89, 94));
			Models.Add(new Model("Mouse", 100, 124));
			Models.Add(new Model("Hard Disk",180, 185));
		}

		private ObservableCollection<Model> models;
		public ObservableCollection<Model> Models
		{
			get{return models;}
			set{ models = value;}
		}
	}

	public class Model : INotifyPropertyChanged
	{
		public Model(string pname, double value1, double value2)
		{
			ProductName = pname;
			Year2013 = value1;
			Year2014 = value2;
		}

		private string productName;

		public string ProductName
		{
			get{return productName;}
			set{ productName = value;
				NotifyPropertyChanged("ProductName");}
		}
			
		private double year2013;

		public double Year2013
		{
			get{return year2013;}
			set{ year2013 = value;
				NotifyPropertyChanged("Year2013");}
		}

		private double year2014;

		public double Year2014
		{
			get{return year2014;}
			set{ year2014 = value;
				NotifyPropertyChanged("Year2014");}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(String propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}

}


