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
            if (budget.LastDay < Start || End < budget.FirstDay)
            {
                return 0;
            }

            var effectiveStart = budget.FirstDay > Start
                ? budget.FirstDay
                : Start;

            var effectiveEnd = budget.LastDay < End
                ? budget.LastDay
                : End;
            return (decimal)(effectiveEnd - effectiveStart).TotalDays + 1;
        }
    }
}