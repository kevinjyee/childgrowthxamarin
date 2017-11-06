using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ChildGrowth.Models.Settings;
using ChildGrowth.Persistence;

namespace ChildGrowth.Pages.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {

        Context currentContext { get; set; }
        public SettingsPage()
        {
            getCurrentContext();
            InitializeComponent();
        }

        async void getCurrentContext()
        {
            ContextDatabaseAccess database = new ContextDatabaseAccess();
            await database.InitializeAsync();
            Context context = database.GetContextAsync().Result;
            currentContext = context;
            if (currentContext == null)
            {
                currentContext = new Context(-1, Language.ENGLISH, new Units(DistanceUnits.IN, WeightUnits.OZ));
            }
            await database.SaveContextAsync(currentContext);
            SetButtons();
        }
        void SetButtons()
        {
            if(currentContext.CurrentLanguage == Language.ENGLISH){
                English.Image = "english_outline.png";
                Spanish.Image = "spanish_white.png";
            }
            else{
                English.Image = "english_white.png";
                Spanish.Image = "spanish_outline.png";
            }
            if(currentContext.CurrentUnits.DistanceUnits == DistanceUnits.IN){
                Metric.Image = "cm_kg_white.png";
                Imperial.Image = "inch_lb_outline.png";
            }
            else{
                Metric.Image = "cm_kg_outline.png";
                Imperial.Image = "inch_lb_white.png";
            }
            
        }
        async void setLanguage(Language l)
        {
            ContextDatabaseAccess database = new ContextDatabaseAccess();
            await database.InitializeAsync();
            currentContext.CurrentLanguage = l;
            await database.SaveContextAsync(currentContext);
        }

        async void setUnits(Units u)
        {
            ContextDatabaseAccess database = new ContextDatabaseAccess();
            await database.InitializeAsync();
            currentContext.CurrentUnits = u;
            await database.SaveContextAsync(currentContext);
        }

        void EnglishClicked(object sender, System.EventArgs e)
        {
            English.Image = "english_outline.png";
            Spanish.Image = "spanish_white.png";
            setLanguage(Language.ENGLISH);
        }
        void SpanishClicked(object sender, System.EventArgs e)
        {
            English.Image = "english_white.png";
            Spanish.Image = "spanish_outline.png";
            setLanguage(Language.SPANISH);
        }
        void ImperialClicked(object sender, System.EventArgs e)
        {
            Metric.Image = "cm_kg_white.png";
            Imperial.Image = "inch_lb_outline.png";
            setUnits(new Units(DistanceUnits.IN, WeightUnits.LBS));
        }
        void MetricClicked(object sender, System.EventArgs e)
        {
            Metric.Image = "cm_kg_outline.png";
            Imperial.Image = "inch_lb_white.png";
            setUnits(new Units(DistanceUnits.CM, WeightUnits.OZ));
        }
    }
}