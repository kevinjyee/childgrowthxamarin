﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChildGrowth.Pages.Education
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EducationInfoDisplay : ContentPage
    {
        public EducationInfoDisplay()
        {
            InitializeComponent();
        }

        public EducationInfoDisplay(String topic)
        {
            InitializeComponent();

            var eduEntryPage = new EducationInfoRepository(topic);
        }
    }
}