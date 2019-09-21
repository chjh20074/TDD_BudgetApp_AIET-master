using System;

namespace TDD_BudgetApp.DTO
{
    public class Period
    {
        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public decimal OverlappingDays(Period period)
        {
            if (Invalid() || HasNoOverlapping(period))
                return 0;

            var effectiveStart = Start;
            if (effectiveStart < period.Start)
            {
                effectiveStart = period.Start;
            }

            var effectiveEnd = End;
            if (period.End < effectiveEnd)
            {
                effectiveEnd = period.End;
            }
            

            return (effectiveEnd - effectiveStart).Days + 1;
        }

        private bool Invalid()
        {
            return Start > End;
        }

        private bool HasNoOverlapping(Period period)
        {
            return End < period.Start || period.End < Start;
        }
    }
}