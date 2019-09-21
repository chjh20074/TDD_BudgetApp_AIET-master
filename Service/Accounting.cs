using System;
using System.Linq;
using TDD_BudgetApp.DTO;
using TDD_BudgetApp.Repos;

namespace TDD_BudgetApp.Service
{
    public class Accounting
    {
        private readonly IRepos<Budget> _repos;

        public Accounting(IRepos<Budget> repos)
        {
            _repos = repos;
        }

        public decimal TotalAmount(DateTime start, DateTime end)
        {
            var budget = _repos.GetAll().FirstOrDefault();
            if (budget != null)
            {
                var firstDay = DateTime.Parse(budget.YearMonth + "/1");
                var daysInMonth = DateTime.DaysInMonth(firstDay.Year, firstDay.Month);
                var lastDay = new DateTime(firstDay.Year, firstDay.Month, daysInMonth);

                if (end < firstDay)
                    return 0;
                if (lastDay < start)
                    return 0;

                return (end - start).Days + 1;
            }


            return 0;
        }
    }
}