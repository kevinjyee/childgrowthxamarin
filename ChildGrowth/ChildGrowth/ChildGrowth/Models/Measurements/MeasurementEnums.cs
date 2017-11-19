using System;

public static class MeasurementEnums
{

    public static String MeasurementTypeAsString(MeasurementType measurementType)
    {
        switch(measurementType)
        {
            case MeasurementType.HEIGHT:
                return HEIGHT_STRING;
            case MeasurementType.WEIGHT:
                return WEIGHT_STRING;
            case MeasurementType.HEAD_CIRCUMFERENCE:
                return HEAD_CIRCUMFERENCE_STRING;
            default:
                return "";
        }
        if (measurementType == MeasurementType.HEIGHT)
        {
            return HEIGHT_STRING;
        }
        if (measurementType == MeasurementType.WEIGHT)
        {
            return WEIGHT_STRING;
        }
        if (measurementType == MeasurementType.HEAD_CIRCUMFERENCE)
        {
            return HEAD_CIRCUMFERENCE_STRING;
        }
        else return "";
    }

    public static readonly String HEIGHT_STRING = "Height";
    public static readonly String WEIGHT_STRING = "Weight";
    public static readonly String HEAD_CIRCUMFERENCE_STRING = "Head Circumference";

}

public enum DistanceUnits
{
    CM,    // Centimeters
    IN     // Inches
}

public enum WeightUnits
{
    OZ,     // Ounces   
    LBS,    // Pounds
    KG,     // Kilograms
    G       // Grams
}

public enum MeasurementType
{
    HEIGHT,
    WEIGHT,
    HEAD_CIRCUMFERENCE
}
