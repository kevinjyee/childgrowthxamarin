using ChildGrowth.Models.Settings;
using System;

public static class MeasurementEnums
{

    public static String MeasurementTypeAsString(MeasurementType measurementType, Language language)
    {
        if(language == null || language == Language.ENGLISH)
        {
            switch (measurementType)
            {
                case MeasurementType.HEIGHT:
                    return HEIGHT_STRING_ENG;
                case MeasurementType.WEIGHT:
                    return WEIGHT_STRING_ENG;
                case MeasurementType.HEAD_CIRCUMFERENCE:
                    return HEAD_CIRCUMFERENCE_STRING_ENG;
                default:
                    return "";
            }
        }
        // Spanish language settings.
        switch(measurementType)
        {
            case MeasurementType.HEIGHT:
                return HEIGHT_STRING_SPANISH;
            case MeasurementType.WEIGHT:
                return WEIGHT_STRING_SPANISH;
            case MeasurementType.HEAD_CIRCUMFERENCE:
                return HEAD_CIRCUMFERENCE_STRING_SPANISH;
            default:
                return "";
        }
    }

    public static readonly String HEIGHT_STRING_ENG = "Height";
    public static readonly String HEIGHT_STRING_SPANISH = "Estatura";
    public static readonly String WEIGHT_STRING_ENG = "Weight";
    public static readonly String WEIGHT_STRING_SPANISH = "Peso";
    public static readonly String HEAD_CIRCUMFERENCE_STRING_ENG = "Head Circumference";
    public static readonly String HEAD_CIRCUMFERENCE_STRING_SPANISH = "Circunferencia de la Cabeza";

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
