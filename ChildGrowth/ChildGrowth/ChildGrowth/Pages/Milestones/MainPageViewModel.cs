using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
            items.Add(new CardStackView.Item() { Name = "Social and Emotional", Photo = new Uri("https://image.ibb.co/cheFGa/01.jpg"), Description = "Puts things in mouth", ID = 1, firstDesc = " ", firstDesc2 = " " });
            items.Add(new CardStackView.Item() { Name = "Social and Emotional", Photo = new Uri("https://image.ibb.co/mfE49v/02.jpg"), Description = "Can't say no", ID = 2, firstDesc = " ", firstDesc2 = " " });
            items.Add(new CardStackView.Item() { Name = "Social and Emotional", Photo = new Uri("https://image.ibb.co/cheFGa/01.jpg"), Description = "Says Daddy", ID = 3, firstDesc = " ", firstDesc2 = " " });
            items.Add(new CardStackView.Item() { Name = "Social and Emotional", Photo = new Uri("https://image.ibb.co/mfE49v/02.jpg"), Description = "Puts large obj in mouth", ID = 4, firstDesc = " ", firstDesc2 = " " });
        }
    }
}
