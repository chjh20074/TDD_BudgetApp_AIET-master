using System;
using System.Linq;
using NUnit.Framework;
using TDD_BudgetApp.DTO;
using TDD_BudgetApp.Repository;

namespace TDD_BudgetApp.Service
{
    public class Accounting
    {
        private readonly IRepo<Budget> _repo;
        public Accounting(IRepo<Budget> repo)
        {
            _repo = repo;
        }

        public decimal TotalAmount(DateTime start, DateTime end)
        {
            if (_repo.GetAll().Any())
            {
                return (decimal) (end - start).TotalDays + 1;
            }

            return 0;
        }
    }
}