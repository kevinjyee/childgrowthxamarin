using ChildGrowth.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            milestoneDatabaseAccess.InitializeSync();
            List<Milestone> milestones = milestoneDatabaseAccess.GetAllMilestonesSync();
            foreach (Milestone milestone in milestones)
            {
                List<int> milestonesByAge = _unansweredMilestones[(MilestoneDueDate)milestone.MilestoneDueDate];
                milestonesByAge.Add(milestone.ID);
            }
            milestoneDatabaseAccess.CloseSyncConnection();
            return this;
        }

        // Removal takes O(n) time, where n is the length of the unanswered milestones list from which the id of the input milestone is being removed.
        public Boolean RemoveMilestone(Milestone milestone)
        {
            if(milestone == null)
            {
                return false;
            }
            int dueDate = milestone.MilestoneDueDate;
            if(this._unansweredMilestones != null && this._unansweredMilestones[(MilestoneDueDate) dueDate] != null)
            {
                return this._unansweredMilestones[(MilestoneDueDate) dueDate].Remove(milestone.ID);
            }
            return false;
        }

        /**
         *  Based off child's age in months, find any milestones questions that need to be answered and return list of IDs.
         **/
        public List<int> GetDueMilestones(int childAgeInMonths)
        {
            List<int> dueMilestones = new List<int>();
            foreach (MilestoneDueDate dueDate in Enum.GetValues(typeof(MilestoneDueDate)))
            {
                if(childAgeInMonths >= (int) dueDate)
                {
                    List<int> milestonesForDueDate = _unansweredMilestones[dueDate];
                    if(milestonesForDueDate != null && milestonesForDueDate.Count > 0)
                    {
                        foreach(int milestoneID in milestonesForDueDate)
                        {
                            dueMilestones.Add(milestoneID);
                        }
                    }
                }
            }
            return dueMilestones;
        }

        public Dictionary<MilestoneDueDate, List<int>> _unansweredMilestones;

    }

}
