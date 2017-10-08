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

        public DateTime DateRecorded { get { return _dateRecorded; } set { _dateRecorded = value; } }

        public double Value { get { return _value; } set { _value = value; } }

    }
}
