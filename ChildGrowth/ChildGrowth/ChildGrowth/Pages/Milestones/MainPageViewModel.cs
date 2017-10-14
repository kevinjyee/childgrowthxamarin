﻿using System;
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
            items.Add(new CardStackView.Item() { Name = "Pizza to go", Photo = "one.jpg", Location = "30 meters away", Description = "Pizza" });
            //items.Add(new CardStackView.Item() { Name = "Dragon & Peacock", Photo = "two.jpg", Location = "800 meters away", Description = "Sweet & Sour" });
            //items.Add(new CardStackView.Item() { Name = "Murrays Food Palace", Photo = "three.jpg", Location = "9 miles away", Description = "Salmon Plate" });
            //items.Add(new CardStackView.Item() { Name = "Food to go", Photo = "four.jpg", Location = "4 miles away", Description = "Salad Wrap" });
            //items.Add(new CardStackView.Item() { Name = "Mexican Joint", Photo = "five.jpg", Location = "2 miles away", Description = "Chilli Bites" });
            //items.Add(new CardStackView.Item() { Name = "Mr Bens", Photo = "six.jpg", Location = "1 mile away", Description = "Beef" });
            //items.Add(new CardStackView.Item() { Name = "Corner Shop", Photo = "seven.jpg", Location = "100 meters away", Description = "Burger & Chips" });
            //items.Add(new CardStackView.Item() { Name = "Sarah's Cafe", Photo = "eight.jpg", Location = "6 miles away", Description = "House Breakfast" });
            //items.Add(new CardStackView.Item() { Name = "Pata Place", Photo = "nine.jpg", Location = "2 miles away", Description = "Chicken Curry" });
            //items.Add(new CardStackView.Item() { Name = "Jerrys", Photo = "ten.jpg", Location = "8 miles away", Description = "Pasta Salad" });
        }
    }
}
