using System;
using System.IO;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using SQLite.Net.Platform.XamarinAndroid;
using XamarinSQLite.PCL;
using ChildGrowth.Droid.Persistence;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLiteConnectionInputGenerator))]
namespace ChildGrowth.Droid.Persistence
{
    class AndroidSQLiteConnectionInputGenerator : ChildGrowth.Persistence.ISQLiteConnectionInputGenerator
    {
        public string GetSQLiteDBPath(string fileName)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, fileName);
        }

        public ISQLitePlatform GetSQLitePlatform()
        {
            return new SQLitePlatformAndroid();
        }
    }
}