using System;

public class Units
{
	public Units(DistanceUnits distanceUnits, WeightUnits weightUnits)
    {
        this._distanceUnits = distanceUnits;
        this._weightUnits = weightUnits;
    }

    private DistanceUnits _distanceUnits { get; set; }

    private WeightUnits _weightUnits { get; set; }

    public DistanceUnits DistanceUnits { get { return _distanceUnits; } set { ; } }

    public WeightUnits WeightUnits { get { return _weightUnits; } set {; } }

}
