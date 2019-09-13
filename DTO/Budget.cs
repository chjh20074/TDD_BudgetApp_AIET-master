using System;

namespace TDD_BudgetApp.DTO
{
    public class Budget
    {
        public string YearMonth { get; set; }

        public decimal Amount { get; set; }

        public DateTime FirstDay
        {
            get
            {
                var dateTime = DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);
                return dateTime;
            }
        }
    }
}