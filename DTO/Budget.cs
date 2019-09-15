using System;

namespace TDD_BudgetApp.DTO
{
    public class Budget
    {
        public string YearMonth { get; set; }

        public decimal Amount { get; set; }

        public DateTime FirstDay => DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);

        public int DaysInMonth => DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);

        public DateTime LastDay => new DateTime(FirstDay.Year, FirstDay.Month, DaysInMonth);

        public Period CreatePeriod()
        {
            return new Period(FirstDay, LastDay);
        }

        public decimal DailyAmount()
        {
            return Amount / DaysInMonth;
        }
    }
}