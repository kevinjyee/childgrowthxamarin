using ChildGrowth;
using System;

public class HeadCircumferenceMeasurement : GrowthMeasurement
{
    private DistanceUnits circumferenceUnits;

    public HeadCircumferenceMeasurement(DateTime date, double value, DistanceUnits units)
        : base(date, value)
    {
        this.circumferenceUnits = units;
    }
}
