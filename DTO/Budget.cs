using System;

namespace TDD_BudgetApp.DTO
{
    public class Budget
    {
        public string YearMonth { get; set; }

        public decimal Amount { get; set; }

        public DateTime FirstDay => DateTime.Parse(YearMonth + "/1");

        public int DaysInMonth => DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);

        public DateTime LastDay => new DateTime(FirstDay.Year, FirstDay.Month, DaysInMonth);

        public Period CreateBudget()
        {
            return new Period(FirstDay, LastDay);
        }

        public decimal AmountInDay()
        {
            return Amount / DaysInMonth;
        }
    }
}