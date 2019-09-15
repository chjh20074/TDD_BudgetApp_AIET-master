using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

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
                return (decimal) (end - start).TotalDays + 1;
            }
            return 0;
        }
    }

    public interface IBudgetRepos<T>
    {
        List<T> GetAll();
    }

    public class Budget
    {
        public string YearMonth { get; set; }

        public decimal Amount { get; set; }
    }
}