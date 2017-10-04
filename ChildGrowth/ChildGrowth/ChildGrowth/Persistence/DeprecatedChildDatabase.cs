using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLiteNetExtensionsAsync.Extensions;
using Xamarin.Forms;
using SQLite.Net.Async;
using System.IO;
using SQLite.Net;

namespace ChildGrowth.Persistence
{
    public class DeprecatedChildDatabase
    {
        private SQLiteAsyncConnection Database { get; }

        public DeprecatedChildDatabase(String dbPath)
        {
            // Referencing https://github.com/xamarin/xamarin-forms-samples/blob/master/Todo/
            //   also see https://blog.infeeny.com/2016/05/30/xamarin-using-sqlite-net-async-in-pcl/ for 
            if (Device.OS == TargetPlatform.Android)
            {
                // Just use whatever directory SpecialFolder.Personal returns
                string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                // we need to put in /Library/ on iOS5.1+ to meet Apple's iCloud terms
                // (they don't want non-user-generated data in Documents)
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder instead
            }
            else if (Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Other)
            {
                throw new PlatformNotSupportedException();
            }
            string path = DependencyService.Get<Services.IFileHelper>().GetLocalFilePath(CHILD_DB_FILE_NAME);
            var platform = new SQLitePlatformAndroid();
            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), new SQLiteConnectionString(path, storeDateTimeAsTicks: false)));

            Database = new SQLiteAsyncConnection();
            var path = Path.Combine(libraryPath, sqliteFilename);
            var dbPath = System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, CHILD_DB_FILE_NAME);
            var conn = new SQLiteAsyncConnection(dbPath);
            Database = Utils.CreateConnection();
            Database.CreateTableAsync<Child>().Wait();
        }

        public Task<List<Child>> GetChildrenAsync()
        {
            return ReadOperations.GetAllWithChildrenAsync<Child>(Database);
        }

        public Task<Child> GetChildAsync(int id)
        {
            return ReadOperations.GetWithChildrenAsync<Child>(Database, id);
        }

        public Task SaveChildAsync(Child child)
        {
            return WriteOperations.InsertOrReplaceWithChildrenAsync(Database, child);
        }

        public Task DeleteChildAsync(Child child)
        {
            return WriteOperations.DeleteAsync(Database, child, true);
        }

    }
}
