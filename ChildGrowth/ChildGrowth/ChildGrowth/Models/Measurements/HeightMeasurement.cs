using ChildGrowth;
using System;

public class HeightMeasurement : GrowthMeasurement
{
    private DistanceUnits heightUnits;

	public HeightMeasurement(DateTime date, double value, DistanceUnits units)
        : base(date, value)
    { 
        this.heightUnits = units;
	}
}
