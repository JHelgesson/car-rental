using System;

namespace CarRental.Domain
{
    public class Period
    {
        public Period(DateTime start)
        {
            Start = start;
        }

        public Period(DateTime start, DateTime end)
        {
            Start = start;
            _end = end;
        }

        public Period With(DateTime end)
        {
            _end = end;
            return this;
        }

        public readonly DateTime Start;
        private DateTime _end;

        public int NumberOfDays => _end.Subtract(Start).Days;
    }
}
