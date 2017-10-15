using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace ChildGrowth.Models.Milestones
{
    public class MilestoneResponses
    {
        public MilestoneHistory MilestoneHistory { get { return _milestoneHistory; }  set { this._milestoneHistory = value; } }
        public UnansweredMilestones UnansweredMilestones { get { return _unansweredMilestones; } set { this._unansweredMilestones = value; } }

        public MilestoneHistory _milestoneHistory { get; set; }

        public UnansweredMilestones _unansweredMilestones { get; set; }

        public MilestoneResponses()
        {
            this._milestoneHistory = new MilestoneHistory().GenerateNewMilestoneHistory();
            this._unansweredMilestones = new UnansweredMilestones().GenerateNewUnansweredMilestones();
        }
    }
}
