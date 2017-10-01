﻿using ChildGrowth.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildGrowth.Factory
{
    public static class DataFactory
    {
        public static IList<Item> DataItems { get; private set; }

        private static readonly Category Category1 = new Category { CategoryId = 1, CategoryTitle = "Category 1" };
        private static readonly Category Category2 = new Category { CategoryId = 2, CategoryTitle = "Category 2" };

        static DataFactory()
        {
            DataItems = new ObservableCollection<Item>()
            {
                new Item
                {
                    ItemId = 1,
                    ItemTitle = "Item 1",
                    Category = Category1
                },
                new Item
                {
                    ItemId = 2,
                    ItemTitle = "Item 2",
                    Category = Category1
                },
                new Item
                {
                    ItemId = 3,
                    ItemTitle = "Item 3",
                    Category = Category2
                },
                new Item
                {
                    ItemId = 4,
                    ItemTitle = "Item 4",
                    Category = Category2
                }
            };
        }
    }
}
