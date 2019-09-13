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
            if (allBudgets.Any())
            {
                var period = new Period(start, end);
                var budget = allBudgets.First();

                return budget.OverlappingDaysAmount(period);
            }
            
            return 0;
        }
    }
}