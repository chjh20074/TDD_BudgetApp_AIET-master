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
                var period = new Period(start, end);

                var dailyAmount = budget.Amount / budget.DaysInMonth;

                return dailyAmount * period.OverlappingDays(budget.CreatePeriod());
            }
            return 0;
        }
    }
}