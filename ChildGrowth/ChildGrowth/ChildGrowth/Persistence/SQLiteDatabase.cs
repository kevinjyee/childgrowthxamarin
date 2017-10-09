using System;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using Xamarin.Forms;
using ChildGrowth.Factory;

namespace ChildGrowth.Persistence
{
    public class SQLiteDatabase
    {
        public static SQLiteAsyncConnection GetConnection(string fileName)
        {
            string path;
            ISQLitePlatform sqlitePlatform = null;

            // Using an interface and implementations with assembly definitions, DependencyService will get platform specific
            //  implementation when called. 
            // See https://stackoverflow.com/questions/41892254/how-to-access-the-methods-in-ios-android-projects-code-from-pcl-project
            ISQLiteConnectionInputGenerator sqliteConnectionInputGenerator = 
                DependencyService.Get<ISQLiteConnectionInputGenerator>();

            path = sqliteConnectionInputGenerator?.GetSQLiteDBPath(fileName);
            sqlitePlatform = sqliteConnectionInputGenerator?.GetSQLitePlatform();

            if (null != sqlitePlatform)
            {
                var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(sqlitePlatform, new SQLiteConnectionString(path, false)));
                return new SQLiteAsyncConnection(connectionFactory);
            }
            else
            {
                throw new SQLiteConnectionException("SQLitePlatform is null.");
            }
        }
    }
}
