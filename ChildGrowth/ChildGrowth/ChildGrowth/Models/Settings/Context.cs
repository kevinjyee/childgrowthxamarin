using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
using ChildGrowth.Persistence;
using System.Threading.Tasks;
using ChildGrowth;
using System.Collections.Generic;
using SQLite.Net.Attributes;


namespace ChildGrowth.Models.Settings
{
    [Table("Context")]
    public class Context
    {
        [PrimaryKey]
        public int ID { get; set; }

        // TODO: [Stefan 10/30/2017] Reset ChildId when user child deleted.
        public int ChildId { get { return this._childId; } set { this._childId = value; } }

        [Ignore]
        public int _childId { get; set; } = ContextBuilder.NO_CHILD_SELECTED;

        [Ignore]
        public Language CurrentLanguage { get { return this._currentLanguage; } set { this._currentLanguage = value; } }
        [Ignore]
        public Units CurrentUnits { get { return this._currentUnits; } set { this._currentUnits = value; } }
        [Ignore]
        public DateTime DateSaved { get { return this._dateSaved; } set { this._dateSaved = value; } }

        [TextBlob("CurrentLanguageBlobbed")]
        public Language _currentLanguage { get; set; }
        public string CurrentLanguageBlobbed { get; set; }
        [TextBlob("CurrentUnitsBlobbed")]
        public Units _currentUnits { get; set; }
        public string CurrentUnitsBlobbed { get; set; }
        [TextBlob("DateSavedBlobbed")]
        public DateTime _dateSaved { get; set; }
        public string DateSavedBlobbed { get; set; }

        /**
         * Retrieve Child from database corresponding to the current value of ChildID. Return null if Context null or if no child selected for context.
         **/
        public Child GetSelectedChild()
        {
            if (this == null)
            {
                return null;
            }
            // Retrieve child object if child selected. This can break and return null if child has been deleted and Context hasn't been reset.
            if (_childId != ContextBuilder.NO_CHILD_SELECTED)
            {
                ChildDatabaseAccess childDBAccess = new ChildDatabaseAccess();
                childDBAccess.InitializeSync();
                return childDBAccess.GetUserChildSync(_childId);
            }
            else
            {
                return null;
            }

        }

        public static Context LoadCurrentContext()
        {
            ContextDatabaseAccess contextDB = new ContextDatabaseAccess();
            contextDB.InitializeSync();
            Context CurrentContext;
            try
            {
                CurrentContext = contextDB.GetContextSync();
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
                newContextDB.InitializeSync();
                newContextDB.SaveFirstContextSync(CurrentContext);
                newContextDB.CloseSyncConnection();
                Task tVaccine = Task.Run(async () =>
                {
                    await VaccineTableConstructor.ConstructVaccineTable();
                });
                tVaccine.Wait();
                Task tMilestone = Task.Run(async () =>
                {
                    MilestonesTableConstructor.ConstructMilestonesTable();
                });
                tMilestone.Wait();
                return CurrentContext;
            }
            else
            {
                return CurrentContext;
            }
        }

        public Context()
        {
            ChildId = -1;
            CurrentLanguage = Language.ENGLISH;
            CurrentUnits = new Units(DistanceUnits.IN, WeightUnits.OZ);
        }

        public Context(int childSelected, Language language, Units units)
        {
            ChildId = childSelected;
            CurrentLanguage = language;
            CurrentUnits = units;
        }

    }

    public class ContextBuilder
    {
        public Context Build()
        {
            return new Context(_childSelected, _language, _units);
        }

        public ContextBuilder WithChildSelected(int childSelected)
        {
            this._childSelected = childSelected;
            return this;
        }

        public ContextBuilder WithLanguage(Language language)
        {
            this._language = language;
            return this;
        }

        public ContextBuilder WithUnits(Units units)
        {
            this._units = units;
            return this;
        }

        private int _childSelected = NO_CHILD_SELECTED;
        private Language _language = Language.ENGLISH;
        private Units _units = new Units(DistanceUnits.IN, WeightUnits.OZ);

        public readonly static int NO_CHILD_SELECTED = -1;
    }
}