using System;

namespace TDD_BudgetApp.DTO
{
    public class Budget
    {
        public string YearMonth { get; set; }

        public decimal Amount { get; set; }

        private DateTime FirstDay => DateTime.Parse(YearMonth + "/1");

        private int DaysInMonth => DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);

        private DateTime LastDay => new DateTime(FirstDay.Year, FirstDay.Month, DaysInMonth);

        private Period CreatePeriod()
        {
            return new Period(FirstDay, LastDay);
        }

        private decimal AmountInDay()
        {
            return Amount / DaysInMonth;
        }

        public decimal OverlappingAmount(Period period)
        {
            return AmountInDay() * period.OverlappingDays(CreatePeriod());
        }
    }
}