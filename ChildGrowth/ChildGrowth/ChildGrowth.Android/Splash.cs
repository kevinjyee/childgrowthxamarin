using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ChildGrowth.Droid
{
    [Activity(Theme = "@style/splashTheme", MainLauncher = true, NoHistory = true)]
    public class Splash : Activity
    {   
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            

            // This will push the application to the main activity
            StartActivity(typeof(MainActivity));

           

        }
    }
}