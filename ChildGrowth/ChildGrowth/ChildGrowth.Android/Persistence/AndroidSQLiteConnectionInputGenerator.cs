using System.IO;
using SQLite.Net.Platform.XamarinAndroid;
using ChildGrowth.Droid.Persistence;
using ChildGrowth.Persistence;
using SQLite.Net.Interop;

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

        ISQLitePlatform ISQLiteConnectionInputGenerator.GetSQLitePlatform()
        {
            return new SQLitePlatformAndroid();
        }
    }
}