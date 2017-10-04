using ChildGrowth;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

public class GrowthData
{

    public GrowthData()
    {
    }

    /**
        * Add measurement corresponding to the input DateTime and MeasurementType.
        */
    public void AddMeasurementForDateAndType(DateTime date, MeasurementType measurementType, Units currentUnits, double value)
    {
        Dictionary<DateTime, GrowthMeasurement> measurementDictionary = measurementTypeMap[measurementType];
        MeasurementFactory measurementFactory = new MeasurementFactory();
        GrowthMeasurement measurement = measurementFactory.CreateMeasurement(date, measurementType, currentUnits, value);
        measurementDictionary.Add(date, measurement);
    }

    /**
        * Get measurement corresponding to the input DateTime and MeasurementType.
        *  If no key/value pair exists for this DateTime, return null.
        */
    public GrowthMeasurement GetMeasurementForDateAndType(DateTime date, MeasurementType measurementType)
    {
        // TODO: [Stefan 09/25/2017] Make measurement retrieval convert values to given units.
        // Check if measurement exists for date/type and update value of "measurement".
        Boolean measurement_exists_for_date = measurementTypeMap[measurementType].TryGetValue(date, out GrowthMeasurement measurement);
        if (measurement_exists_for_date)
        {
            return measurement;
        }
        else
        {
            return null;
        }
    }

    /**
        * Remove measurement corresponding to the input DateTime and MeasurementType.
        *  Return true if value successfully removed, return false otherwise.
        */
    public Boolean RemoveMeasurementForDateAndType(DateTime date, MeasurementType measurementType)
    {
        Dictionary<DateTime, GrowthMeasurement> measurementDictionary = measurementTypeMap[measurementType];
        if (null != measurementDictionary && measurementDictionary.ContainsKey(date))
        {
            measurementDictionary.Remove(date);
            return true;
        }
        else
        {
            return false;
        }
    }

    /**
        * Retrieve sorted list of data corresponding to a given measurementType.
        *  Return null if no data.
        *  TODO: [Stefan 10/03/2017] Return measurements converted to proper units.
        */
    public List<GrowthMeasurement> GetSortedMeasurementList(MeasurementType measurementType)
    {
        Dictionary<DateTime, GrowthMeasurement> measurementDictionary = measurementTypeMap[measurementType];
        List<GrowthMeasurement> measurements = new List<GrowthMeasurement>();

        if (null != measurementDictionary)
        {
            measurements.AddRange(measurementDictionary?.Values);
            if (EMPTY == measurements.Count)
            {
                return null;
            }
            measurements?.Sort();
            return measurements;
        }
        else
        {
            return null;
        }
    }

    private static Dictionary<DateTime, GrowthMeasurement> heightData = new Dictionary<DateTime, GrowthMeasurement>();

    private static Dictionary<DateTime, GrowthMeasurement> weightData = new Dictionary<DateTime, GrowthMeasurement>();

    private static Dictionary<DateTime, GrowthMeasurement> headCircumferenceData = new Dictionary<DateTime, GrowthMeasurement>();

    // Key value pairs for all measurement lists.
    private static IEnumerable<KeyValuePair<MeasurementType, Dictionary<DateTime, GrowthMeasurement>>> measurementData =
        new List<KeyValuePair<MeasurementType, Dictionary<DateTime, GrowthMeasurement>>>()
        {
            new KeyValuePair<MeasurementType, Dictionary<DateTime, GrowthMeasurement>>(MeasurementType.HEIGHT, heightData),
            new KeyValuePair<MeasurementType, Dictionary<DateTime, GrowthMeasurement>>(MeasurementType.WEIGHT, weightData),
            new KeyValuePair<MeasurementType, Dictionary<DateTime, GrowthMeasurement>>(MeasurementType.HEAD_CIRCUMFERENCE, 
                headCircumferenceData)
        };

    // Build an immutable dictionary from measurement type to the three types of measurement dictionaries.
    private static ImmutableDictionary<MeasurementType, Dictionary<DateTime, GrowthMeasurement>> measurementTypeMap =
        ImmutableDictionary<MeasurementType, Dictionary<DateTime, GrowthMeasurement>>.Empty
            .AddRange(measurementData);

    private int EMPTY = 0;
}
