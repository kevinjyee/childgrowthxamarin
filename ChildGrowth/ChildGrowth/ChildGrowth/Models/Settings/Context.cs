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
        public int ID { get { return ID; } set { this.ID = value; } }

        // TODO: [Stefan 10/30/2017] Reset ChildId when user child deleted.
        private int _childId { get; set; } = NO_CHILD_SELECTED;
        public int ChildId { get { return this._childId; } set { this._childId = value; } }

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

        public async Task<Child> GetSelectedChild()
        {
            if(this == null)
            {
                return null;
            }
            // Retrieve child object if child selected. This can break and return null if child has been deleted and Context hasn't been reset.
            if (_childId != NO_CHILD_SELECTED)
            {
                ChildDatabaseAccess childDBAccess = new ChildDatabaseAccess();
                await childDBAccess.InitializeAsync();
                return await childDBAccess.GetUserChildAsync(_childId);
            }
            else
            {
                return null;
            }

        }

        private readonly static int NO_CHILD_SELECTED = -1;

    }
}
