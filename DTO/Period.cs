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

            DateTime effectiveStart;
            if (Start < budget.FirstDay)
            {
                effectiveStart = budget.FirstDay;
            }
            else
            {
                effectiveStart = Start;
            }

            return (decimal)(End - effectiveStart).TotalDays + 1;
        }
    }
}