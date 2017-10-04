using System;

namespace ChildGrowth
{
    public abstract class GrowthMeasurement
    {
        public GrowthMeasurement(DateTime date, double value)
        {
            this._dateRecorded = date;
            this._value = value;
        }

        protected DateTime _dateRecorded;
        protected double _value;

        protected DateTime DateRecorded { get { return _dateRecorded; } set { ; } }

        public double Value { get { return _value; } set { ; } }

    }
}
