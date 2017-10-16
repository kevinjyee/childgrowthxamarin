using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Models.Milestones
{
    public class MilestoneWithResponse
    {
        public MilestoneWithResponse()
        {

        }

        public MilestoneWithResponse(Milestone milestone, BinaryAnswer answer)
        {
            _milestone = milestone;
            _answer = answer;
        }

        public Milestone Milestone { get { return _milestone; } set { this._milestone = value; } }
        public BinaryAnswer Answer { get { return _answer; } set { this._answer = value; } }

        public Milestone _milestone { get; set; }
        public BinaryAnswer _answer { get; set; }
    }
}
