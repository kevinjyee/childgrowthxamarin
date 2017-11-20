﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChildGrowth.Pages.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChildGrowth.Models.Settings;
using ChildGrowth.Persistence;
using ChildGrowth.Models.Milestones;
using ChildGrowth.Models.Vaccinations;

namespace ChildGrowth.Pages.Insights
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insights : ContentPage
    {
        private Child _currentChild;

        public Child CurrentChild
        {
            get
            {
                return _currentChild;
            }
            set
            {
                if (_currentChild?.ID != value?.ID)
                {
                    _currentChild = value;
                    OnPropertyChanged("CurrentChild");
                    UpdateTitle();
                    UpdateInsights();
                }
            }
        }

        public Context CurrentContext { get; set; }

        override
        protected void OnAppearing()
        {
            Task Load = Task.Run(async () => { await LoadContext(); });
            Load.Wait();
            UpdateTitle();
            UpdateInsights();
        }

        // Load context and set value for current child if it exists.
        private async Task<Boolean> LoadContext()
        {
            ContextDatabaseAccess contextDB = new ContextDatabaseAccess();
            await contextDB.InitializeAsync();
            try
            {
                CurrentContext = contextDB.GetContextAsync().Result;
            }
            // Can't find definitions for SQLiteNetExtensions exceptions, so catch generic Exception e and assume there is no context.
            catch (Exception e)
            {
                CurrentContext = null;
                //contextDB.CloseSyncConnection();
            }
            // If context doesn't exist, create it, save it, and populate vaccine/milestones databases.
            if (CurrentContext == null)
            {
                CurrentContext = new Context();
                // Exception probably broke the synchronous connection.
                //contextDB.InitializeSync();
                ContextDatabaseAccess newContextDB = new ContextDatabaseAccess();
                await newContextDB.InitializeAsync();
                newContextDB.SaveFirstContextAsync(CurrentContext);
                //newContextDB.CloseSyncConnection();
                CurrentChild = null;
                Task tVaccine = VaccineTableConstructor.ConstructVaccineTable();
                Task tMilestone = MilestonesTableConstructor.ConstructMilestonesTable();
                await tVaccine;
                await tMilestone;
                return true;
            }
            else
            {
                CurrentChild = CurrentContext.GetSelectedChild();
                return true;
            }

        }
        public Insights()
        {
            InitializeComponent();
        }

        private void UpdateInsights()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                updateFields();
            });
        }

        void UpdateTitle()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (CurrentChild != null)
                {
                    this.Title = CurrentChild.Name;
                }
                else
                {
                    this.Title = "Please Select a Child";
                }
            });
        }

        private void updateFields()
        {
            if(CurrentChild == null)
            {
                childBirthday.Text = "NaN";
                heightMeasurement.Text = "NaN";
                weightMeasurement.Text = "NaN";
                headCircumferenceMeasurement.Text = "NaN";
            }
            else
            {
                // Get last input dates
                
                DateTime maxDateofWeight = CurrentChild.Measurements.weightData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.weightData.Keys.Max();
                DateTime maxDateofHeight = CurrentChild.Measurements.heightData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.heightData.Keys.Max();
                DateTime maxDateofHead = CurrentChild.Measurements.headCircumferenceData.Keys.Count == 0 ? DateTime.MinValue : CurrentChild.Measurements.headCircumferenceData.Keys.Max();

                // Check if these dates matches today
                if(maxDateofHead.Date == DateTime.Today.Date
                    && maxDateofHeight.Date == DateTime.Today.Date
                    && maxDateofWeight.Date == DateTime.Today.Date)
                {
                    measurementsImage.Source = "check_1";
                    measurementsAlert.Text = "All Measurements Completed For Today";
                }

                // Check if Milestones Completed
                List<Milestone> milestoneList = CurrentChild.GetListOfDueMilestones();
                if(milestoneList == null || milestoneList.Count == 1)
                {
                    milestonesImage.Source = "check_1";
                    milestonesAlert.Text = "All Milestones Completed For Today";
                }
                else
                {
                    int count = milestoneList.Count - 1;
                    milestonesAlert.Text = count.ToString() + " unanswered";
                }

                //Check if Vaccination Completed
                List<Vaccine> vaccineList = CurrentChild.GetListOfDueVaccines();
                if (vaccineList == null || vaccineList.Count == 0)
                {
                    vaccinationsImage.Source = "check_1";
                    vaccinationsAlert.Text = "All Vaccinations Completed For Today";
                }
                else
                {
                    vaccinationsAlert.Text = vaccineList.Count.ToString() + " vaccinations pending";
                }
                childBirthday.Text = CurrentChild.Birthday.ToString();
                

                weightMeasurement.Text = maxDateofWeight == DateTime.MinValue ? "NaN" :CurrentChild.GetMeasurementForDateAndType(maxDateofWeight, MeasurementType.WEIGHT).Value.ToString() + " oz";
                heightMeasurement.Text = maxDateofHeight == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofHeight, MeasurementType.HEIGHT).Value.ToString() + " cm";
                headCircumferenceMeasurement.Text = maxDateofHead == DateTime.MinValue ? "NaN" : CurrentChild.GetMeasurementForDateAndType(maxDateofHead, MeasurementType.HEAD_CIRCUMFERENCE).Value.ToString()+ " cm";

            }
            
        }

        void OnSettingsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }
    }
}