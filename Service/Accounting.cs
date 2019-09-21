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
                return OverlapingDays(period, budget);
            }


            return 0;
        }

        private static decimal OverlapingDays(Period period, Budget budget)
        {
            if (period.End < budget.FirstDay || budget.LastDay < period.Start)
                return 0;

            var effectiveStart = period.Start;
            if (effectiveStart < budget.FirstDay)
            {
                effectiveStart = budget.FirstDay;
            }

            var effectiveEnd = period.End;
            if (budget.LastDay < effectiveEnd)
            {
                effectiveEnd = budget.LastDay;
            }

            return (effectiveEnd - effectiveStart).Days + 1;
        }
    }
}