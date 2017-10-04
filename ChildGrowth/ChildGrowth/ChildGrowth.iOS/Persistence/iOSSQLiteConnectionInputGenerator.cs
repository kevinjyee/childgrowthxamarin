using System;
using SQLite.Net.Interop;
using System.IO;
using SQLite.Net.Platform.XamarinIOS;
using ChildGrowth.iOS.Persistence;

[assembly: Xamarin.Forms.Dependency(typeof(iOSSQLiteConnectionInputGenerator))]
namespace ChildGrowth.iOS.Persistence
{
    class iOSSQLiteConnectionInputGenerator : ChildGrowth.Persistence.ISQLiteConnectionInputGenerator
    {
        public string GetSQLiteDBPath(string fileName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, "..", "Library", fileName);
        }

        public ISQLitePlatform GetSQLitePlatform()
        {
            return new SQLitePlatformIOS();
        }
    }
}