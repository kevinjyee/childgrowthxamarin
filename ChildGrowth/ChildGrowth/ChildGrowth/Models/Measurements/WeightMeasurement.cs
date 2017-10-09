using ChildGrowth;
using System;

public class WeightMeasurement : GrowthMeasurement
{
    private WeightUnits weightUnits;

    public WeightMeasurement(DateTime date, double value, WeightUnits units)
        : base(date, value)
    {
        this.weightUnits = units;
    }
}
