using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ChildGrowth.Models.Settings;
using ChildGrowth.Persistence;
using ChildGrowth.Pages.Menu;

namespace ChildGrowth.Pages.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        MenuMasterDetailPage MasterPage { get; set; }
        Context CurrentContext { get; set; }
        public SettingsPage()
        {
            Task contextTask = Task.Run(async () => { await getCurrentContext(); });
            contextTask.Wait();
            InitializeComponent();
            if (CurrentContext.CurrentLanguage == Language.ENGLISH)
            {
                SetEnglish();
            }
            else
            {
                SetSpanish();
            }
            SetButtons();
        }

        public SettingsPage(MenuMasterDetailPage Page)
        {
            Task contextTask = Task.Run(async () => { await getCurrentContext(); });
            contextTask.Wait();
            InitializeComponent();
            SetButtons();
            MasterPage = Page;
        }

        async private Task<Boolean> getCurrentContext()
        {
            ContextDatabaseAccess contextDB = new ContextDatabaseAccess();
            await contextDB.InitializeAsync();
            try
            {
                CurrentContext = contextDB.GetContextAsync().Result;
            }
            // Can't find definitions for SQLiteNetExtensions exceptions, so catch generic Exception e and assume there is no context.
            catch (Exception e)
            {
                CurrentContext = null;
            }
            // If context doesn't exist, create it and pass child selected with default units.
            if (CurrentContext == null)
            {
                CurrentContext = new Context();
                // Exception probably broke the synchronous connection.
                //contextDB.InitializeSync();
                ContextDatabaseAccess newContextDB = new ContextDatabaseAccess();
                await newContextDB.InitializeAsync();
                newContextDB.SaveFirstContextAsync(CurrentContext);
                //newContextDB.CloseSyncConnection();
            }
            return true;
        }

        private void SetEnglish()
        {
            SettingsTitle.Text = "Settings";
            LanguageTitle.Text = "Language";
            UnitsTitle.Text = "Unit System";
        }

        private void SetSpanish()
        {
            SettingsTitle.Text = "Configuración";
            LanguageTitle.Text = "Idioma";
            UnitsTitle.Text = "Sistema de Medidas";
        }

        void SetButtons()
        {
            if (CurrentContext.CurrentLanguage == Language.ENGLISH)
            {
                English.Source = ImageSource.FromFile("english_white.png");
                Spanish.Source = ImageSource.FromFile("spanish_outline.png");
            }
            else
            {
                English.Source = ImageSource.FromFile("english_sp_outline.png");
                Spanish.Source = ImageSource.FromFile("spanish_sp_white.png");
            }
            if (CurrentContext.CurrentUnits.DistanceUnits == DistanceUnits.IN)
            {
                Metric.Source = ImageSource.FromFile("cm_kg_outline.png");
                Imperial.Source = ImageSource.FromFile("inch_lb_white.png");
            }
            else
            {
                Metric.Source = ImageSource.FromFile("cm_kg_white.png");
                Imperial.Source = ImageSource.FromFile("inch_lb_outline.png");
            }

        }
        async Task setLanguage(Language l)
        {
            ContextDatabaseAccess database = new ContextDatabaseAccess();
            await database.InitializeAsync();
            if(CurrentContext == null)
            {
                CurrentContext = Context.LoadCurrentContext();
            }
            CurrentContext.CurrentLanguage = l;
            await database.SaveContextAsync(CurrentContext);
            try
            {
                MasterPage.UpdateLanguage(l);
            }
            catch(Exception e)
            {
                // TODO:
            }
        }

        async Task setUnits(Units u)
        {
            ContextDatabaseAccess database = new ContextDatabaseAccess();
            await database.InitializeAsync();
            CurrentContext.CurrentUnits = u;
            await database.SaveContextAsync(CurrentContext);
        }

        void EnglishClicked(object sender, System.EventArgs e)
        {
            SetEnglish();
            English.Source = ImageSource.FromFile("english_white.png");
            Spanish.Source = ImageSource.FromFile("spanish_outline.png");
            Task LanguageTask = Task.Run(async () => { await setLanguage(Language.ENGLISH); });
            LanguageTask.Wait();
        }
        void SpanishClicked(object sender, System.EventArgs e)
        {
            SetSpanish();
            English.Source = ImageSource.FromFile("english_sp_outline.png");
            Spanish.Source = ImageSource.FromFile("spanish_sp_white.png");
            Task LanguageTask = Task.Run(async () => { await setLanguage(Language.SPANISH); });
            LanguageTask.Wait();

        }
        void ImperialClicked(object sender, System.EventArgs e)
        {
            Metric.Source = ImageSource.FromFile("cm_kg_outline.png");
            Imperial.Source = ImageSource.FromFile("inch_lb_white.png");
            Task UnitsTask = Task.Run(async () => { await setUnits(new Units(DistanceUnits.IN, WeightUnits.LBS)); });
            UnitsTask.Wait();
        }
        void MetricClicked(object sender, System.EventArgs e)
        {
            Metric.Source = ImageSource.FromFile("cm_kg_white.png");
            Imperial.Source = ImageSource.FromFile("inch_lb_outline.png");
            Task UnitsTask = Task.Run(async () => { await setUnits(new Units(DistanceUnits.CM, WeightUnits.OZ)); });
            UnitsTask.Wait();
        }
    }
}