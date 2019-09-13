using System;

namespace TDD_BudgetApp.DTO
{
    public class Budget
    {
        public string YearMonth { get; set; }

        public decimal Amount { get; set; }

        public DateTime FirstDay => DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);

        public DateTime LastDay => new DateTime(FirstDay.Year, FirstDay.Month, DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month));

        public Period CreatePeriod()
        {
            return new Period(FirstDay, LastDay);
        }
    }
}