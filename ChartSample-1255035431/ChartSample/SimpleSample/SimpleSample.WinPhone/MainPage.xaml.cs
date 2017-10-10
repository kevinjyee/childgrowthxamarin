using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Syncfusion.SfChart.XForms.WinPhone;
using Xamarin.Forms;
using Syncfusion.UI.Xaml.Charts;
using System.Text;
using System.Windows.Markup;
using Syncfusion.SfChart.XForms;
using System.Windows.Media;

[assembly: ExportRenderer(typeof(SimpleSample.CustomChart), typeof(SimpleSample.WinPhone.CustomRenderer))]
namespace SimpleSample.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new SimpleSample.App());
        }
    }
		
}
