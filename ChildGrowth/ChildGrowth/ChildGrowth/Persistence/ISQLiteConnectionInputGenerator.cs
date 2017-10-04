using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Persistence
{
    // File paths and SQLitePlatforms are platform specific, so use this interface to produce platform-specific inputs for
    //  getting an SQLConnectionAsync.
    public interface ISQLiteConnectionInputGenerator
    {
        String GetSQLiteDBPath(String fileName);
        ISQLitePlatform GetSQLitePlatform();
    }
}
