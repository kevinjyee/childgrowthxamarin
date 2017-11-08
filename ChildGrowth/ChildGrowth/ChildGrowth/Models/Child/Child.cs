using System;
using SQLiteNetExtensions.Attributes;
using ChildGrowth.Persistence;
using System.Threading.Tasks;
using ChildGrowth;
using System.Collections.Generic;
using SQLite.Net.Attributes;
using ChildGrowth.Models.Milestones;
using ChildGrowth.Models;
using ChildGrowth.Models.Vaccinations;

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
    public VaccinationResponses Vaccinations { get { return _vaccinations; } set { _vaccinations = value; } }

    [TextBlob("BirthdayBlobbed")]
    public DateTime _birthday { get; set; }
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

    [TextBlob("VaccinationsBlobbed")]
    public VaccinationResponses _vaccinations { get; set; }
    public string VaccinationsBlobbed { get; set; }

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
        this.Vaccinations = new VaccinationResponses();
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
        if (measurements == null) return null;
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
    public Boolean RemoveMeasurementForDateAndType(DateTime date, MeasurementType measurementType)
    {
        ChildDatabaseAccess childDB = new ChildDatabaseAccess();
        childDB.InitializeSync();
        Boolean data_removed = this.Measurements.RemoveMeasurementForDateAndType(date, measurementType);
        if (data_removed)
        {
            childDB.SaveUserChildSync(this);
            childDB.CloseSyncConnection();
            return true;
        }
        else
        {
            childDB.CloseSyncConnection();
            return false;
        }
    }

    /** 
     * Adds a measurement to a Child profile. This will update the Child's entry in the local database to reflect the change.
     **/
    public Boolean AddMeasurementForDateAndType(DateTime date, MeasurementType measurementType, Units currentUnits, double value)
    {
        ChildDatabaseAccess childDB = new ChildDatabaseAccess();
        childDB.InitializeSync();
        Measurements.AddMeasurementForDateAndType(date, measurementType, currentUnits, value);
        childDB.SaveUserChildSync(this);
        childDB.CloseSyncConnection();
        return true;
    }

    /**
     * Add or update milestone response history for the given milestone ID and BinaryAnswer.
     **/
    public Boolean AddOrUpdateMilestoneHistory(int milestoneID, BinaryAnswer answer)
    {
        ChildDatabaseAccess childDB = new ChildDatabaseAccess();
        childDB.InitializeSync();
        Milestones.AddOrUpdateMilestoneHistory(milestoneID, answer);
        childDB.SaveUserChildSync(this);
        childDB.CloseSyncConnection();
        return true;
    }

    /**
     * Add or update milestone response history for the given milestone ID and BinaryAnswer.
     **/
    public Boolean AddOrUpdateVaccineHistory(int vaccineID)
    {
        ChildDatabaseAccess childDB = new ChildDatabaseAccess();
        childDB.InitializeSync();
        Vaccinations.AddOrUpdateVaccinationHistory(vaccineID);
        childDB.SaveUserChildSync(this);
        childDB.CloseSyncConnection();
        return true;
    }

    /**
     * Add or update milestone response history for the given milestone ID and BinaryAnswer.
     **/
    public Boolean RemoveFromVaccineHistory(int vaccineID)
    {
        ChildDatabaseAccess childDB = new ChildDatabaseAccess();
        childDB.InitializeSync();
        Vaccinations.RemoveFromVaccinationHistory(vaccineID);
        childDB.SaveUserChildSync(this);
        childDB.CloseSyncConnection();
        return true;
    }

    /**
     * Return true if vaccine for the given ID is received, false otherwise.
     **/
     public Boolean HasVaccine(int vaccineID)
     {
        return Vaccinations.VaccineIsReceived(vaccineID);
     }

     /**
      * Return percentage of total vaccines received up to 36 months.
      **/
     public double GetVaccinationCompletionPercentage()
     {
        return Vaccinations.CalculateVaccinationCompletionPercentage();
     }

    /**
     * Get a list of milestones which are due or past due to be answered based on a Child's birthday and MilestonesResposnes.
     **/
    public List<Milestone> GetListOfDueMilestones()
    {
        return Milestones.GetListOfDueMilestones(ChildAgeInMonths());
    }

    /**
     * Get a dictionary of Milestones and their respective responses, organized by MilestoneCategory.
     **/
    public Dictionary<MilestoneCategory, List<MilestoneWithResponse>> GetMilestoneHistory()
    {
        return Milestones.GetMilestoneResponseHistoryForAllCategories();
    }

    /**
     * Get a list of vaccines which are due or past due to be answered based on a Child's birthday and VaccinationHistory.
     **/
     public List<Vaccine> GetListOfDueVaccines()
    {
        return Vaccinations.GetListOfDueVaccines(ChildAgeInMonths());
    }

    /**
     * Get a dictionary of Milestones and their respective responses, organized by MilestoneCategory.
     **/
    public List<Vaccine> GetVaccineHistory()
    {
        return Vaccinations.GetVaccineHistory();
    }

    /** 
     * Checks a ChildDatabase object to see if it is null or is unconnected. Creates new ChildDatabase and/or initialize connection
     *  as necessary.
     **/
    private ChildDatabaseAccess CheckChildDatabaseConnection(ChildDatabaseAccess childDatabase)
    {
        if (null == childDatabase)
        {
            childDatabase = new ChildDatabaseAccess();
        }
        if (!childDatabase.IsConnected)
        {
            childDatabase.InitializeSync();
        }
        return childDatabase;
    }

    private double GetMeasurementAge(GrowthMeasurement measurement)
    {
        DateTime measurementDate = measurement.DateRecorded;
        TimeSpan diff = measurementDate - this.Birthday;
        double months =  diff.TotalDays / approx_days_per_month;
        return months;
    }

    private int ChildAgeInMonths()
    {
        TimeSpan diff = DateTime.Now - this.Birthday;
        int months = (int) (diff.TotalDays / approx_days_per_month);
        return months;
    }

    private double approx_days_per_month = 30.4;
}