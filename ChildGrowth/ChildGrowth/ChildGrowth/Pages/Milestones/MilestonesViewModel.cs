using System;

using Xamarin.Forms;

namespace ChildGrowth.Pages.Milestones
{
    public class MilestonesViewModel : ViewModels.Base.BaseViewModel
    {
        public Milestone Milestone { get; set; }

        public MilestonesViewModel(Milestone milestone = null)
        {
            Title = milestone?.CategoryDescription;
            Milestone = milestone;
        }
    }
}

