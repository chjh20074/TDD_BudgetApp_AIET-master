using System;
using System.Linq;
using NUnit.Framework;
using TDD_BudgetApp.DTO;
using TDD_BudgetApp.Repository;

namespace TDD_BudgetApp.Service
{
    public class Accounting
    {
        private readonly IRepo<Budget> _budgetRepo;
        public Accounting(IRepo<Budget> budgetRepo)
        {
            _budgetRepo = budgetRepo;
        }

        public decimal TotalAmount(DateTime start, DateTime end)
        {
            var allBudgets = _budgetRepo.GetAll();
            var period = new Period(start, end);
            var totalAmount = 0m;
            foreach (var budget in allBudgets)
            {
                totalAmount += budget.OverlappingDaysAmount(period);

            }

            return totalAmount;
        }
    }
}