using ChildGrowth;
using System;

public class MeasurementFactory
{
	public MeasurementFactory()
	{
	}

    public GrowthMeasurement CreateMeasurement(DateTime date, MeasurementType measurementType, Units currentUnits, double value)
    {
        switch(measurementType)
        {
            case MeasurementType.HEIGHT:
                return CreateHeightMeasurement(date, currentUnits.DistanceUnits, value);
            case MeasurementType.WEIGHT:
                return CreateWeightMeasurement(date, currentUnits.WeightUnits, value);
            case MeasurementType.HEAD_CIRCUMFERENCE:
                return CreateHeadCircumferenceMeasurement(date, currentUnits.DistanceUnits, value);
        }
        return null;
    }

    private HeightMeasurement CreateHeightMeasurement(DateTime date, DistanceUnits distanceUnits, double value)
    {
        return new HeightMeasurement(date, value, distanceUnits);
    }

    private WeightMeasurement CreateWeightMeasurement(DateTime date, WeightUnits weightUnits, double value)
    {
        return new WeightMeasurement(date, value, weightUnits);
    }

    private HeadCircumferenceMeasurement CreateHeadCircumferenceMeasurement(DateTime date, DistanceUnits distanceUnits, double value)
    {
        return new HeadCircumferenceMeasurement(date, value, distanceUnits);
    }
}
