using ChildGrowth;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

public class GrowthData
{

    public GrowthData()
    {
        heightData = new Dictionary<DateTime, HeightMeasurement>();
        weightData = new Dictionary<DateTime, WeightMeasurement>();
        headCircumferenceData = new Dictionary<DateTime, HeadCircumferenceMeasurement>();
        /*
        measurementData = new List<KeyValuePair<MeasurementType, Dictionary<DateTime, GrowthMeasurement>>>()
        {
            new KeyValuePair<MeasurementType, Dictionary<DateTime, GrowthMeasurement>>(MeasurementType.HEIGHT, heightData),
            new KeyValuePair<MeasurementType, Dictionary<DateTime, GrowthMeasurement>>(MeasurementType.WEIGHT, weightData),
            new KeyValuePair<MeasurementType, Dictionary<DateTime, GrowthMeasurement>>(MeasurementType.HEAD_CIRCUMFERENCE,
                headCircumferenceData)
        };
        measurementTypeMap = ImmutableDictionary<MeasurementType, Dictionary<DateTime, GrowthMeasurement>>.Empty
            .AddRange(measurementData);
        */

    }

    /**
        * Add measurement corresponding to the input DateTime and MeasurementType.
        */
    public void AddMeasurementForDateAndType(DateTime date, MeasurementType measurementType, Units currentUnits, double value)
    {
        //Dictionary<DateTime, GrowthMeasurement> measurementDictionary = measurementTypeMap[measurementType];
        MeasurementFactory measurementFactory = new MeasurementFactory();
        GrowthMeasurement measurement = measurementFactory.CreateMeasurement(date, measurementType, currentUnits, value);
        //measurementDictionary.Add(date, measurement);
        switch (measurementType)
        {
            case MeasurementType.HEIGHT:
                heightData[date] = (HeightMeasurement) measurement;
                break;
            case MeasurementType.WEIGHT:
                weightData[date] = (WeightMeasurement) measurement;
                break;
            case MeasurementType.HEAD_CIRCUMFERENCE:
                headCircumferenceData[date] = (HeadCircumferenceMeasurement) measurement;
                break;
        }
    }

    /**
        * Get measurement corresponding to the input DateTime and MeasurementType.
        *  If no key/value pair exists for this DateTime, return null.
        */
    public GrowthMeasurement GetMeasurementForDateAndType(DateTime date, MeasurementType measurementType)
    {
        // TODO: [Stefan 09/25/2017] Make measurement retrieval convert values to given units.
        // Check if measurement exists for date/type and update value of "measurement".
        /*
        Boolean measurement_exists_for_date = measurementTypeMap[measurementType].TryGetValue(date, out GrowthMeasurement measurement);
        if (measurement_exists_for_date)
        {
            return measurement;
        }
        else
        {
            return null;
        }
        */

        switch (measurementType)
        {
            case MeasurementType.HEIGHT:
                heightData.TryGetValue(date, out HeightMeasurement heightMeasurement);
                return heightMeasurement;
            case MeasurementType.WEIGHT:
                weightData.TryGetValue(date, out WeightMeasurement weightMeasurement);
                return weightMeasurement;
            case MeasurementType.HEAD_CIRCUMFERENCE:
                headCircumferenceData.TryGetValue(date, out HeadCircumferenceMeasurement headCircumferenceMeasurement);
                return headCircumferenceMeasurement;
        }
        return null;
    }

    /**
        * Remove measurement corresponding to the input DateTime and MeasurementType.
        *  Return true if value successfully removed, return false otherwise.
        */
    public Boolean RemoveMeasurementForDateAndType(DateTime date, MeasurementType measurementType)
    {
        /*
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
        */
        switch (measurementType)
        {
            case MeasurementType.HEIGHT:
                if (null != heightData && heightData.ContainsKey(date))
                {
                    heightData.Remove(date);
                    return true;
                }
                break;
            case MeasurementType.WEIGHT:
                if (null != weightData && weightData.ContainsKey(date))
                {
                    weightData.Remove(date);
                    return true;
                }
                break;
            case MeasurementType.HEAD_CIRCUMFERENCE:
                if (null != headCircumferenceData && headCircumferenceData.ContainsKey(date))
                {
                    headCircumferenceData.Remove(date);
                    return true;
                }
                break;
        }
        return false;
    }

    /**
        * Retrieve sorted list of data corresponding to a given measurementType.
        *  Return null if no data.
        *  TODO: [Stefan 10/03/2017] Return measurements converted to proper units.
        */
    public List<GrowthMeasurement> GetSortedMeasurementList(MeasurementType measurementType)
    {
        //Dictionary<DateTime, GrowthMeasurement> measurementDictionary = measurementTypeMap[measurementType];
        List<GrowthMeasurement> measurements = new List<GrowthMeasurement>();

        switch(measurementType)
        {
            case MeasurementType.HEIGHT:
                measurements.AddRange(heightData?.Values);
                break;
            case MeasurementType.WEIGHT:
                measurements.AddRange(weightData?.Values);
                break;
            case MeasurementType.HEAD_CIRCUMFERENCE:
                measurements.AddRange(headCircumferenceData?.Values);
                break;
        }
        if (EMPTY == measurements.Count)
        {
            return null;
        }
        measurements?.Sort();
        return measurements;
    }

    public Dictionary<DateTime, HeightMeasurement> heightData;

    public Dictionary<DateTime, WeightMeasurement> weightData;

    public Dictionary<DateTime, HeadCircumferenceMeasurement> headCircumferenceData;

    /*
    // Key value pairs for all measurement lists.
    public IEnumerable<KeyValuePair<MeasurementType, Dictionary<DateTime, GrowthMeasurement>>> measurementData;

    // Build an immutable dictionary from measurement type to the three types of measurement dictionaries.
    public ImmutableDictionary<MeasurementType, Dictionary<DateTime, GrowthMeasurement>> measurementTypeMap;
    */

    public int EMPTY = 0;
}
