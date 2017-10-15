using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Models.Milestones
{
    /*
     * Each AgeRange enum corresponds to an equivalent value of months.
     */
    public enum MilestoneDueDate : int
    {
        TWO_MONTHS = 2,
        FOUR_MONTHS = 4,
        SIX_MONTHS = 6,
        NINE_MONTHS = 9,
        ONE_YEAR = 12,
        EIGHTEEN_MONTHS = 18,
        TWO_YEARS = 24,
        THREE_YEARS = 36
    }
}
