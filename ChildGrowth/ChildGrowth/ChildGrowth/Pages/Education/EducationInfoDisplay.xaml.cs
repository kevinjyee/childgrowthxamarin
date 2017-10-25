using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Diagnostics;
using System.Windows.Navigation;


namespace ChildGrowth.Pages.Education
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EducationInfoDisplay : ContentPage
    {
        public EducationInfoDisplay()
        {
            InitializeComponent();
        }

        public EducationInfoDisplay(String topic)
        {
            InitializeComponent();

            var eduEntryPage = new EducationInfoRepository(topic);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}