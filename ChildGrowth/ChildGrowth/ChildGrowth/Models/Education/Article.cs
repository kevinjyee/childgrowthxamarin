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
    [Table("Article")]
    public class Article
    {
        [PrimaryKey]
        public int ID { get; set; }

        [Indexed]
        // This Category should actually be an EducationCategory object, but in order to index on this value it probably needs to be a string.
        public string Category { get; set; }

        public string Title { get; set; }

        public string URL { get; set; }

        [Ignore]
        public Language Language { get; set; }

        [TextBlob("LanguageBlobbed")]
        public Language _language { get; set; }
        public string LangaugeBlobbed { get; set; }

    }
}
