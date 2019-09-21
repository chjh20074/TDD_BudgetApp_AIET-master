using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NSubstitute.Callbacks;
using NUnit.Framework;
using TDD_BudgetApp.DTO;
using TDD_BudgetApp.Repos;
using TDD_BudgetApp.Service;

namespace TDD_BudgetApp
{
    public class BudgetTests
    {
        private Accounting _account;
        private IRepos<Budget> _repos = Substitute.For<IRepos<Budget>>();

        [SetUp]
        public void SetUp()
        {
            _account = new Accounting(_repos);
        }

        [Test]
        public void no_budgets()
        {
            _repos.GetAll().Returns(new List<Budget>());
            var start = new DateTime(2019, 8, 31);
            var end = new DateTime(2019, 8, 31);
            Assert.AreEqual(0, _account.TotalAmount(start, end)); 
        }

        [Test]
        public void period_inside_budget_month()
        {
            _repos.GetAll().Returns(new List<Budget>
            {
                new Budget {YearMonth = "2019/9", Amount = 30}
            });
            var start = new DateTime(2019, 9, 1);
            var end = new DateTime(2019, 9, 1);
            Assert.AreEqual(1, _account.TotalAmount(start, end));
        }

        //[Test]
        //public void period_no_overlapping_after_budget_lastDay()
        //{

        //}

        //[Test]
        //public void period_no_overlapping_before_budget_firstDay()
        //{

        //}

        //[Test]
        //public void period_overlapping_budget_firstDay()
        //{

        //}

        //[Test]
        //public void period_overlapping_budget_lastDay()
        //{

        //}

        //[Test]
        //public void Daily_Amount_is_10()
        //{

        //}

        //[Test]
        //public void invalid_period()
        //{

        //}

        //[Test]
        //public void multiple_budgets()
        //{

        //}
    }
}