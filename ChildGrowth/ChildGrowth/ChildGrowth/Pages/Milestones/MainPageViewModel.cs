using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ChildGrowth.Persistence;
using ChildGrowth.Models.Milestones;
using ChildGrowth.Models.Settings;

namespace ChildGrowth.Pages.Milestones
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        List<CardStackView.Item> items = new List<CardStackView.Item>();
        public List<CardStackView.Item> ItemsList
        {
            get
            {
                return items;
            }
            set
            {
                if (items == value)
                {
                    return;
                }
                items = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainPageViewModel()
        {
            ContextDatabaseAccess currentContext = new ContextDatabaseAccess();
            currentContext.InitializeSync();
            
            
            Context currSettings = currentContext.GetContextSync();



            Child currChild = currSettings.GetSelectedChild();
            currentContext.CloseSyncConnection();

            if(currChild == null) { return; }

            List<Milestone> milestonesDue = currChild.GetListOfDueMilestones();
            items.Clear();
            items.Add(new CardStackView.Item() { Name = "Swipe to see Milestones", Photo = new Uri("https://preview.ibb.co/eDzv0w/ben_white_124388.jpg"), Description = "Click Yes or No", ID = -1, firstDesc = " ", firstDesc2 = " " });
            items.Add(new CardStackView.Item() { Name = "Click Yes or No to Track Progress", Photo = new Uri("https://preview.ibb.co/eDzv0w/ben_white_124388.jpg"), Description = "Click Yes or No", ID = -2, firstDesc = " ", firstDesc2 = " " });
            if (milestonesDue == null) { return; }

            foreach (Milestone m in milestonesDue)
            {
                try
                {
                    items.Add(new CardStackView.Item() { Name = m.Category, Photo = new Uri(m.Media), Description = m.QuestionText, ID = m.ID, firstDesc = " ", firstDesc2 = " " });
                }
                catch(Exception e)
                {
                    string current = m.Media;
                }
            }
          
        }
    }
}
