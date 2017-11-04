using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Models.Milestones
{
    public class MilestoneHistory
    {
        public MilestoneHistory()
        {
           
        }

        // Create new milestone history dictionary of dictionaries.
        public MilestoneHistory GenerateNewMilestoneHistory()
        {
            this._milestoneHistory = new Dictionary<MilestoneCategory, Dictionary<int, MilestoneAnswer>>();

            // Generate empty dictionary for each MilestoneCategory.
            foreach (MilestoneCategory category in Enum.GetValues(typeof(MilestoneCategory)))
            {
                Dictionary<int, MilestoneAnswer> milestoneResponsesByCategory = new Dictionary<int, MilestoneAnswer>();
                _milestoneHistory[category] = milestoneResponsesByCategory;
            }
            return this;
        }

        public void UpdateOrInsertToMilestoneHistory(Milestone milestone, BinaryAnswer answer)
        {
            MilestoneCategory category;
            Boolean CategoryIsValid = Enum.TryParse<MilestoneCategory>(milestone.Category, out category);
            if (CategoryIsValid)
            {
                if (_milestoneHistory != null && _milestoneHistory[category] != null)
                {
                    _milestoneHistory[category][milestone.ID] = new MilestoneAnswer(milestone.ID, answer);
                }
            }
            else
            {
                throw new InvalidMilestoneCategoryException(milestone.Category + " does not match any MilestoneCategory.");
            }
        }

        public Dictionary<MilestoneCategory, Dictionary<int, MilestoneAnswer>> GetMilestoneHistory()
        {
            return _milestoneHistory;
        }

        public Dictionary<MilestoneCategory, Dictionary<int, MilestoneAnswer>> _milestoneHistory;
    }
}
