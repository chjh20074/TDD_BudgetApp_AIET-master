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

        public decimal Days()
        {
            return (decimal) (End - Start).TotalDays + 1;
        }

        public decimal OverlappingDays(Budget budget)
        {
            if (budget.LastDay < Start || End < budget.FirstDay)
            {
                return 0;
            }

            return Days();
        }
    }
}