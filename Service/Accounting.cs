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
                return Days(new Period(start, end));
            }
            
            return 0;
        }

        private static decimal Days(Period period)
        {
            return (decimal) (period.End - period.Start).TotalDays + 1;
        }
    }

    public class Period
    {
        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
    }
}