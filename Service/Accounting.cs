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
            var period = new Period(start, end);

            if (budget != null)
            {
                if (end < budget.FirstDay || budget.LastDay < start)
                    return 0;

                var effectiveStart = start;
                if (start < budget.FirstDay)
                {
                    effectiveStart = budget.FirstDay;
                }

                var effectiveEnd = end;
                if (budget.LastDay < end)
                {
                    effectiveEnd = budget.LastDay;
                }

                return (effectiveEnd - effectiveStart).Days + 1;
            }


            return 0;
        }
    }
}