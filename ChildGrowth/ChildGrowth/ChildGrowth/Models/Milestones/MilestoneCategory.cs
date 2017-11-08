using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Models
{
    public enum MilestoneCategory
    {
        SOCIAL_AND_EMOTIONAL,
        COMMUNICATION,
        COGNITIVE,
        MOVEMENT
    }

    public class MilestoneCategoryStringConverter
    {
        private static readonly Dictionary<MilestoneCategory, String> _stringRepresentations =
            new Dictionary<MilestoneCategory, String>
            {
                { MilestoneCategory.SOCIAL_AND_EMOTIONAL, "Social and Emotional" },
                { MilestoneCategory.COMMUNICATION, "Language/Communication" },
                { MilestoneCategory.COGNITIVE, "Cognitive" },
                { MilestoneCategory.MOVEMENT, "Movement/Physical Development" },

            };

        private static readonly Dictionary<String, MilestoneCategory> _enumRepresentations =
            new Dictionary<String, MilestoneCategory>
            {
                { "Social and Emotional", MilestoneCategory.SOCIAL_AND_EMOTIONAL },
                { "Language/Communication", MilestoneCategory.COMMUNICATION },
                { "Cognitive", MilestoneCategory.COGNITIVE },
                { "Movement/Physical Development", MilestoneCategory.MOVEMENT },

            };

        public String GetStringForCategory(MilestoneCategory category)
        {
            return _stringRepresentations[category];
        }

        public MilestoneCategory GetCategoryFromString(String categoryAsString)
        {
            return _enumRepresentations[categoryAsString];
        }
    }
}
