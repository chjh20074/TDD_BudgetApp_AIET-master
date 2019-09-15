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

            var period = new Period(start, end);
            var totalAmount = 0m;
            foreach (var budget in getAllBudgets)
            {
                totalAmount += budget.OverlappingAmount(period);
            }
            return totalAmount;
        }
    }
}