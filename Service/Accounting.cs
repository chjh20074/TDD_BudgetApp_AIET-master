using System;
using System.Linq;
using NUnit.Framework;
using TDD_BudgetApp.DTO;
using TDD_BudgetApp.Repos;

namespace TDD_BudgetApp.Service
{
    public class Accounting
    {
        private readonly IBudgetRepos<Budget> _budgetRepos;
        
        public Accounting(IBudgetRepos<Budget> repos)
        {
            _budgetRepos = repos;
        }

        public decimal TotalAmount(DateTime start, DateTime end)
        {
            var getAllBudgets = _budgetRepos.GetAll();
            if (getAllBudgets.Any())
            {
                var budget = getAllBudgets.First();
                var firstDay = DateTime.ParseExact(budget.YearMonth + "01", "yyyyMMdd", null);
                if (end < firstDay)
                {
                    return 0;
                }

                return new Period(start, end).Days();
            }
            return 0;
        }
    }
}