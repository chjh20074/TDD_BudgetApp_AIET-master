﻿using System;
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
            var period = new Period(start, end);

            return _budgetRepo.GetAll().Sum(s => s.OverlappingDaysAmount(period));
        }
    }
}