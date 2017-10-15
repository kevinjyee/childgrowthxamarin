using ChildGrowth.Persistence;
using System;
using System.Collections.Generic;

namespace ChildGrowth.Models.Milestones
{
    public class UnansweredMilestones
    {
        public UnansweredMilestones()
        {

        }

        public UnansweredMilestones GenerateNewUnansweredMilestones()
        {
            this._unansweredMilestones = new Dictionary<MilestoneDueDate, List<int>>();

            // Generate empyty lists of milestone IDs for holding unanswered milestones for a Child.
            foreach (MilestoneDueDate dueDate in Enum.GetValues(typeof(MilestoneDueDate)))
            {
                List<int> milestonesByAge = new List<int>();
                _unansweredMilestones[dueDate] = milestonesByAge;
            }

            // Populate Dictionary of unansweredMilestones questions with milestones separated by AgeRange.
            MilestoneDatabaseAccess milestoneDatabaseAccess = new MilestoneDatabaseAccess();
            List<Milestone> milestones = milestoneDatabaseAccess.GetAllMilestonesAsync().Result;
            foreach (Milestone milestone in milestones)
            {
                List<int> milestonesByAge = _unansweredMilestones[(MilestoneDueDate)milestone.MilestoneDueDate];
                milestonesByAge.Add(milestone.ID);
            }
            return this;
        }

        public Dictionary<MilestoneDueDate, List<int>> _unansweredMilestones;

    }

}
