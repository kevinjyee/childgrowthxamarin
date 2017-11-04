using ChildGrowth.Persistence;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChildGrowth.Models.Milestones
{
    public class MilestoneResponses
    {

        /**
         * Record the milestone BinaryAnswer for the given milestone ID and then remove it from the unanswered milestones list.
         */
        public void AddOrUpdateMilestoneHistory(int milestoneID, BinaryAnswer answer)
        {
            MilestoneDatabaseAccess milestoneDatabaseAccess = new MilestoneDatabaseAccess();
            Milestone milestone = milestoneDatabaseAccess.GetMilestoneByIdAsync(milestoneID).Result;
            MilestoneHistory.UpdateOrInsertToMilestoneHistory(milestone, answer);
            Boolean milestoneRemoved = UnansweredMilestones.RemoveMilestone(milestone);
        }

        /**
         * Return list of due milestones based on child age and questions answered.
         **/
        public List<Milestone> GetListOfDueMilestones(int childAgeInMonths)
        {
            List<int> dueMilestoneIds = UnansweredMilestones.GetDueMilestones(childAgeInMonths);
            if(dueMilestoneIds != null && dueMilestoneIds.Count > 0)
            {
                return GetMilestonesByIds(dueMilestoneIds);
            }
            else
            {
                return null;
            }
        }

        /**
         * Return dictionary of milestones with responses organized by MilestoneCategory.
         **/
        public Dictionary<MilestoneCategory, List<MilestoneWithResponse>> GetMilestoneResponseHistoryForAllCategories()
        {
            // Create result dictionary for milestones with responses organized by category.
            Dictionary<MilestoneCategory, List<MilestoneWithResponse>> result = new Dictionary<MilestoneCategory, List<MilestoneWithResponse>>();
            
            // Get Milestone history.
            Dictionary<MilestoneCategory, Dictionary<int, MilestoneAnswer>> milestoneHistory = MilestoneHistory.GetMilestoneHistory();

            // For each Milestone Category, find all milestones responses for that category and create MilestoneWithResponse pair via database retrieval.
            foreach (MilestoneCategory category in Enum.GetValues(typeof(MilestoneCategory)))
            {
                // Create new list for current Milestone Category to add to result dictionary.
                List<MilestoneWithResponse> milestoneWithResponseForCategory = new List<MilestoneWithResponse>();

                // Get MilestoneAnswers for the current category.
                Dictionary<int, MilestoneAnswer> milestonesForCategory = milestoneHistory[category];
                if(null != milestonesForCategory && milestonesForCategory.Count > 0)
                {
                    List<int> milestoneIds = new List<int>(milestonesForCategory.Keys);
                    // Retrieve milestones corresponding to list of MilestoneIds from database.
                    List<Milestone> milestones = GetMilestonesByIds(milestoneIds);
                    foreach (Milestone milestone in milestones)
                    {
                        BinaryAnswer answerForMilestone = milestonesForCategory[milestone.ID].Answer;
                        milestoneWithResponseForCategory.Add(new MilestoneWithResponse(milestone, answerForMilestone));
                    }
                }
                // Add list for current Milestone Category to result dictionary.
                result[category] = milestoneWithResponseForCategory;
            }
            return result;
        }

        /**
         * Retrieve a list of Milestone objects from storage corresponding to the input list of milestone ids.
         **/
        private List<Milestone> GetMilestonesByIds(List<int> ids)
        {
            MilestoneDatabaseAccess milestoneDatabaseAccess = new MilestoneDatabaseAccess();
            List<Task<Milestone>> readTasks = new List<Task<Milestone>>();
            List<Milestone> milestones = new List<Milestone>();
            if (ids != null && ids.Count > 0)
            {
                foreach (int milestoneID in ids)
                {
                    readTasks.Add(milestoneDatabaseAccess.GetMilestoneByIdAsync(milestoneID));
                }
            }
            if (readTasks != null && readTasks.Count > 0)
            {
                foreach (Task<Milestone> task in readTasks)
                {
                    milestones.Add(task.Result);
                }
            }
            return milestones;
        }

        public MilestoneResponses()
        {
            this._milestoneHistory = new MilestoneHistory().GenerateNewMilestoneHistory();
            this._unansweredMilestones = new UnansweredMilestones().GenerateNewUnansweredMilestones().Result;
        }

        public MilestoneHistory MilestoneHistory { get { return _milestoneHistory; } set { this._milestoneHistory = value; } }
        public UnansweredMilestones UnansweredMilestones { get { return _unansweredMilestones; } set { this._unansweredMilestones = value; } }

        public MilestoneHistory _milestoneHistory { get; set; }
        public UnansweredMilestones _unansweredMilestones { get; set; }
    }
}
