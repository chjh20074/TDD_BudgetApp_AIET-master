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
            if (End < budget.FirstDay || budget.LastDay < Start)
                return 0;

            var effectiveStart = Start;
            if (effectiveStart < budget.FirstDay)
            {
                effectiveStart = budget.FirstDay;
            }

            var effectiveEnd = End;
            if (budget.LastDay < effectiveEnd)
            {
                effectiveEnd = budget.LastDay;
            }

            return (effectiveEnd - effectiveStart).Days + 1;
        }
    }
}