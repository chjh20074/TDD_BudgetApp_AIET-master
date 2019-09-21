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
            var budget = _repos.GetAll().FirstOrDefault();

            if (budget != null)
            {
                if (end < budget.FirstDay || budget.LastDay < start)
                    return 0;

                return new Period(start, end).Days();
            }


            return 0;
        }
    }
}