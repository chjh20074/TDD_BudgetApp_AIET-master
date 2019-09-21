using System;
using System.Collections.Generic;
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
            var budgets = _repos.GetAll();
            if (budgets.Count > 0)
            {
                return (end - start).Days + 1;
            }


            return 0;
        }
    }
}