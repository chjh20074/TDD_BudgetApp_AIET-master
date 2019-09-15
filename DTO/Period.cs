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

        public decimal OverlappingDays(Budget budget)
        {
            var lastDay = budget.LastDay;
            if (End < budget.FirstDay || Start > budget.LastDay)
            {
                return 0;
            }

            var effectiveStart = Start < budget.FirstDay ? budget.FirstDay : Start;

            var effectiveEnd = budget.LastDay < End ? budget.LastDay : End;

            return (decimal)(effectiveEnd - effectiveStart).TotalDays + 1;
        }
    }
}