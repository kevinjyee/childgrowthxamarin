using System;

namespace ChildGrowth.Models.Milestones
{
    /**
     * Throw this exception when a Milestone category string does not match with any MilestoneCategory.
     */
    class InvalidMilestoneCategoryException : Exception
    {
        public InvalidMilestoneCategoryException() : base() { }
        public InvalidMilestoneCategoryException(string message) : base(message) { }
    }
}
