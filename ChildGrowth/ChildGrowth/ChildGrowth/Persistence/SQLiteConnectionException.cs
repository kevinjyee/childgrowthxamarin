using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Persistence
{
    public class SQLiteConnectionException : Exception
    {
        public SQLiteConnectionException(String message) : base() { }
    }
}
