using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChildGrowth.Pages.Splash;
using ChildGrowth.Pages;
using ChildGrowth.Pages.Menu;
using Xamarin.Forms;
using ChildGrowth.Localization;
using ChildGrowth.Services;
using ChildGrowth.Pages.Master;

namespace ChildGrowth
{
    public partial class App : Application
    {
        static Application app;
        public static Application CurrentApp
        {
            get { return app; }
        }
        readonly IAuthenticationService _AuthenticationService;
        public App()
        {
            InitializeComponent();

            //MainPage = new ChildGrowth.MainPage();
            app = this;

            MainPage = new MainPage();
            CurrentApp.MainPage = new MasterTab();
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static void GoToRoot()
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                //CurrentApp.MainPage = new MainPage();
                CurrentApp.MainPage = new MenuMasterDetailPage();
            }
            else
            {
                //CurrentApp.MainPage = new MainPage();
                CurrentApp.MainPage = new MenuMasterDetailPage();
            }
        }

        public static int AnimationSpeed = 250;
    }
}
