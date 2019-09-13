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

                var dailyAmount = budget.DailyAmount();

                return OverlappingDaysAmount(dailyAmount, period, budget);
            }
            
            return 0;
        }

        private static decimal OverlappingDaysAmount(decimal dailyAmount, Period period, Budget budget)
        {
            return dailyAmount * period.OverlappingDays(budget.CreatePeriod());
        }
    }
}