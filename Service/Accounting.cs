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
            if (_budgetRepo.GetAll().Any())
            {
                return Days(start, end);
            }
            
            return 0;
        }

        private static decimal Days(DateTime start, DateTime end)
        {
            return (decimal) (end - start).TotalDays + 1;
        }
    }
}