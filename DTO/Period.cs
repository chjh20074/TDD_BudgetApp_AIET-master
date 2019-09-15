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
            var lastDay = period.End;
            if (End < period.Start || Start > period.End)
            {
                return 0;
            }

            var effectiveStart = Start < period.Start ? period.Start : Start;

            var effectiveEnd = period.End < End ? period.End : End;

            return (decimal)(effectiveEnd - effectiveStart).TotalDays + 1;
        }
    }
}