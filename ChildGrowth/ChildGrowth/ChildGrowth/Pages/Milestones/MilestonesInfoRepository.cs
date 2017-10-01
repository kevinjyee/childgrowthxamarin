using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Pages.Milestones
{
    public class MilestonesInfoRepository
    {
        private ObservableCollection<MilestonesInfo> milestonesInfo;

        public ObservableCollection<MilestonesInfo> MilestonesInfo
        {
            get { return milestonesInfo; }
            set { this.milestonesInfo = value; }
        }

        public MilestonesInfoRepository()
        {
            GenerateBookInfo();
        }

        internal void GenerateBookInfo()
        {
            milestonesInfo = new ObservableCollection<MilestonesInfo>();
            milestonesInfo.Add(new MilestonesInfo { CategoryName = "Social and Emotional", CategoryDescription = "Begins to smile at people " });
            milestonesInfo.Add(new MilestonesInfo { CategoryName = "Social and Emotional", CategoryDescription = "Can briefly calm herself (may bring hands to mouth and suck on hand)" });
            milestonesInfo.Add(new MilestonesInfo { CategoryName = "Social and Emotional", CategoryDescription = "Tries to look at parent" });
            milestonesInfo.Add(new MilestonesInfo { CategoryName = "Language/Communication", CategoryDescription = "Coos, makes gurgling sounds " });
            milestonesInfo.Add(new MilestonesInfo { CategoryName = "Language/Communication", CategoryDescription = "Turns head toward sounds" });
            milestonesInfo.Add(new MilestonesInfo { CategoryName = "Cognitive", CategoryDescription = "Pays attention to faces " });
        }
    }
}
