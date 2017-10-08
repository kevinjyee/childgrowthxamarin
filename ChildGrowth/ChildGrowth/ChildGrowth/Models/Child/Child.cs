using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
using ChildGrowth.Persistence;
using System.Threading.Tasks;
using ChildGrowth;
using System.Collections.Generic;

[Table("Child")]
public class Child
{
    // See https://developer.xamarin.com/recipes/android/data/databases/sqlite/
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }

    [Indexed]
    public string Name { get; set; }

    public DateTime Birthday { get { return _birthday; } set { _birthday = value; } }
    public Gender ChildGender { get { return _childGender; } set { _childGender = value; } }
    public MilestoneResponses Milestones { get { return _milestones; } set { _milestones = value; } }
    public GrowthData Measurements { get { return _measurements; } set { _measurements = value; } }
    public VaccinationHistory VaccineHistory { get { return _vaccineHistory; } set { _vaccineHistory = value; } }

    [TextBlob("BirthdayBlobbed")]
    private DateTime _birthday { get; set; }
    public string BirthdayBlobbed { get; set; }

    [TextBlob("GenderBlobbed")]
    public Gender _childGender { get; set; }
    public string GenderBlobbed { get; set; }

    [TextBlob("MilestonesBlobbed")]
    public MilestoneResponses _milestones { get; set; }
    public string MilestonesBlobbed { get; set; }

    [TextBlob("MeasurementsBlobbed")]
    public GrowthData _measurements { get; set; }
    public string MeasurementsBlobbed { get; set; }

    [TextBlob("VaccineHistoryBlobbed")]
    public VaccinationHistory _vaccineHistory { get; set; }
    public string VaccineHistoryBlobbed { get; set; }

    public enum Gender
    {
        MALE,
        FEMALE
    }

	public Child(string name)
	{
        this.Name = name;
	}

    public int GetID()
    {
        return this.ID;
    }

    public void SetID(int id)
    {
        this.ID = id;
    }

    /**
     * Reads a measurement for the given date and MeasurementType.
     * Returns null if no measurement found.
     **/
    public async Task<GrowthMeasurement> GetMeasurementForDateAndType(DateTime date, MeasurementType measurementType)
    {
        Task<GrowthMeasurement> thread = new Task<GrowthMeasurement>(() =>
        {
            return Measurements.GetMeasurementForDateAndType(date, measurementType);
        });
        thread.Start();
        return await thread;
    }

    /**
     * Read out any saved measurements for the given MeasurementType.
     * Return null if no measurements found.
     **/
    public async Task<List<GrowthMeasurement>> GetSortedMeasurementListByType(MeasurementType measurementType)
    {
        Task<List<GrowthMeasurement>> thread = new Task<List<GrowthMeasurement>>(() =>
        {
            return Measurements.GetSortedMeasurementList(measurementType);
        });
        thread.Start();
        return await thread;
    }

    /** 
     * Removes a measurement from a Child profile. This will update the Child's entry in the database to reflect the change.
     **/
    public async Task<Boolean> RemoveMeasurementForDateAndType(DateTime date, MeasurementType measurementType, ChildDatabase childDatabase)
    {
        ChildDatabase childDB = CheckChildDatabaseConnection(childDatabase).Result;
        Boolean data_removed = this.Measurements.RemoveMeasurementForDateAndType(date, measurementType);
        if (data_removed)
        {
            await childDB.SaveUserChildAsync(this);
            return true;
        }
        else return false;
    }

    /** 
     * Adds a measurement to a Child profile. This will update the Child's entry in the local database to reflect the change.
     **/
    public async Task<Boolean> AddMeasurementForDateAndType(DateTime date, MeasurementType measurementType, Units currentUnits, double value, ChildDatabase childDatabase)
    {
        ChildDatabase childDB = CheckChildDatabaseConnection(childDatabase).Result;
        Measurements.AddMeasurementForDateAndType(date, measurementType, currentUnits, value);
        await childDB.SaveUserChildAsync(this);
        return true;
    }

    /** 
     * Checks a ChildDatabase object to see if it is null or is unconnected. Creates new ChildDatabase and/or initialize connection
     *  as necessary.
     **/
    private async Task<ChildDatabase> CheckChildDatabaseConnection(ChildDatabase childDatabase)
    {
        if (null == childDatabase)
        {
            childDatabase = new ChildDatabase();
        }
        if (!childDatabase.IsConnected)
        {
            await childDatabase.InitializeAsync();
        }
        return childDatabase;
    }
}
