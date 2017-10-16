using ChildGrowth.Models.Settings;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Models.Education
{

    public class Article
    {
        public int ID { get { return _id; } set { this._id = value; } }
        private int _id { get; set; }

        public EducationCategory Category { get { return _category; } set { this._category = value; } }
        private EducationCategory _category { get; set; }

        public string Title { get { return _title;  } set { this._title = value; } }
        private string _title { get; set; }


        public string URL { get { return _url; } set { this._url = value; } }
        private string _url { get; set; }

        public Language Language { get { return _language; } set { this._language = value; } }
        private Language _language { get; set; }

    }
}
