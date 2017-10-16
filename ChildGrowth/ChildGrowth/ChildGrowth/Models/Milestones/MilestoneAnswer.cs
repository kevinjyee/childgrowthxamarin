using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Models.Milestones
{
    public class MilestoneAnswer
    {

        public MilestoneAnswer()
        {

        }

        public MilestoneAnswer(int ID, BinaryAnswer answer)
        {
            _milestoneID = ID;
            _answer = answer;
        }
        
        public int MilestoneID { get { return _milestoneID; } set { this._milestoneID = value; } }
        public BinaryAnswer Answer { get { return _answer; } set { this._answer = value; } }

        public int _milestoneID { get; set; }
        public BinaryAnswer _answer { get; set; }

    }
}
