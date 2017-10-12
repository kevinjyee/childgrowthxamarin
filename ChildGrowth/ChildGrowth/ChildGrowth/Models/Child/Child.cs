using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
using ChildGrowth.Persistence;
using System.Threading.Tasks;
using ChildGrowth;
using System.Collections.Generic;
using SQLite.Net.Attributes;

[Table("Child")]
public class Child
{
    // See https://developer.xamarin.com/recipes/android/data/databases/sqlite/
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }

    [Indexed]
    public string Name { get; set; }

    [Ignore]
    public DateTime Birthday { get { return _birthday; } set { _birthday = value; } }
    [Ignore]
    public Gender ChildGender { get { return _childGender; } set { _childGender = value; } }
    [Ignore]
    public MilestoneResponses Milestones { get { return _milestones; } set { _milestones = value; } }
    [Ignore]
    public GrowthData Measurements { get { return _measurements; } set { _measurements = value; } }
    [Ignore]
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
        FEMALE,
        UNSPECIFIED // This is used on the "add child" page. No added child can have this value, as the app will block addition of a child with unspecified gender.
    }

    public Child(string name, DateTime birthday, Gender gender)
    {
        this.Name = name;
        this.Birthday = birthday;
        this.ChildGender = gender;
        this.Measurements = new GrowthData();
        this.Milestones = new MilestoneResponses();
        this.VaccineHistory = new VaccinationHistory();
    }

    public Child()
    {

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
    public GrowthMeasurement GetMeasurementForDateAndType(DateTime date, MeasurementType measurementType)
    {
        return Measurements.GetMeasurementForDateAndType(date, measurementType);
    }

    /**
     * Read out any saved measurements for the given MeasurementType.
     * Return null if no measurements found.
     **/
    public List<Points> GetSortedMeasurementListByType(MeasurementType measurementType)
    {
        /*
        Task<List<GrowthMeasurement>> thread = new Task<List<GrowthMeasurement>>(() =>
        {
            return Measurements.GetSortedMeasurementList(measurementType);
        });
        thread.Start();
        return await thread;
        */
        List<GrowthMeasurement> measurements = Measurements.GetSortedMeasurementList(measurementType);
        List<Points> series = new List<Points>();
        foreach (GrowthMeasurement measurement in measurements)
        {
            series.Add(new Points(GetMeasurementAge(measurement), measurement.Value));
        }
        return series;

    }

    /** 
     * Removes a measurement from a Child profile. This will update the Child's entry in the database to reflect the change.
     **/
    public async Task<Boolean> RemoveMeasurementForDateAndType(DateTime date, MeasurementType measurementType, ChildDatabaseAccess childDatabase)
    {
        ChildDatabaseAccess childDB = CheckChildDatabaseConnection(childDatabase).Result;
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
    public async Task<Boolean> AddMeasurementForDateAndType(DateTime date, MeasurementType measurementType, Units currentUnits, double value, ChildDatabaseAccess childDatabase)
    {
        ChildDatabaseAccess childDB = CheckChildDatabaseConnection(childDatabase).Result;
        Measurements.AddMeasurementForDateAndType(date, measurementType, currentUnits, value);
        await childDB.SaveUserChildAsync(this);
        return true;
    }

    /** 
     * Checks a ChildDatabase object to see if it is null or is unconnected. Creates new ChildDatabase and/or initialize connection
     *  as necessary.
     **/
    private async Task<ChildDatabaseAccess> CheckChildDatabaseConnection(ChildDatabaseAccess childDatabase)
    {
        if (null == childDatabase)
        {
            childDatabase = new ChildDatabaseAccess();
        }
        if (!childDatabase.IsConnected)
        {
            await childDatabase.InitializeAsync();
        }
        return childDatabase;
    }

    private double GetMeasurementAge(GrowthMeasurement measurement)
    {
        DateTime measurementDate = measurement.DateRecorded;
        //TimeSpan diff = measurementDate - this.Birthday;
        TimeSpan diff = measurementDate - new DateTime(2014,10,1);
        double days =  diff.TotalDays / approx_days_per_month;
        return days;
    }

    private double approx_days_per_month = 30.4;
}