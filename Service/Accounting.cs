using System;
using System.Linq;
using NUnit.Framework;
using TDD_BudgetApp.DTO;
using TDD_BudgetApp.Repos;

namespace TDD_BudgetApp.Service
{
    public class Accounting
    {
        private readonly IBudgetRepos<Budget> _repos;
        
        public Accounting(IBudgetRepos<Budget> repos)
        {
            _repos = repos;
        }

        public decimal TotalAmount(DateTime start, DateTime end)
        {
            if (_repos.GetAll().Any())
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
}