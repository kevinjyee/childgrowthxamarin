using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }

        public Category Category { get; set; }
    }
}
