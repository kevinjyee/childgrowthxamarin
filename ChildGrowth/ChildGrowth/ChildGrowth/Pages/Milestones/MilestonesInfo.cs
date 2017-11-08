using ChildGrowth.Models.Milestones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Pages.Milestones
{
    public class MilestonesInfo : INotifyPropertyChanged
    {
        private int monthDue;
        private string categoryName;
        private string categoryDesc;
        private string imageURL;
        private BinaryAnswer answer;

        public BinaryAnswer Answer
        {
            get { return answer; }
            set
            {
                answer = value;
                OnPropertyChanged("Answer");
            }
        }

        public int MonthDue
        {
            get { return monthDue; }
            set
            {
                monthDue = value;
                OnPropertyChanged("MonthDue");
            }
        }

        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        public string CategoryDescription
        {
            get { return categoryDesc; }
            set
            {
                categoryDesc = value;
                OnPropertyChanged("CategoryDescription");
            }
        }

        public string ImageURL
        {
            get { return imageURL; }
            set
            {
                imageURL = value;
                OnPropertyChanged("CategoryDescription");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
