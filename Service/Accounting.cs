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
            var period = new Period(start, end);
            var totalAmount = 0m;
            foreach (var budget in _repos.GetAll())
            {
                totalAmount += budget.OverlappingAmount(period);
            }

            return totalAmount;
        }
    }
}