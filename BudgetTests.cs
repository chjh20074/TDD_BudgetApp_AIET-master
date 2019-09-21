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
        private readonly IRepos<Budget> _repos = Substitute.For<IRepos<Budget>>();

        [SetUp]
        public void SetUp()
        {
            _account = new Accounting(_repos);
        }

        [Test]
        public void no_budgets()
        {
            GivenBudgets();
            TotalAmountShouldBe(0, new DateTime(2019, 8, 31), new DateTime(2019, 8, 31));
        }

        [Test]
        public void period_inside_budget_month()
        {
            GivenBudgets(new Budget {YearMonth = "2019/9", Amount = 30});
            TotalAmountShouldBe(1, new DateTime(2019, 9, 1), new DateTime(2019, 9, 1));
        }

        [Test]
        public void period_no_overlapping_before_budget_firstDay()
        {
            GivenBudgets(new Budget { YearMonth = "2019/9", Amount = 30 });
            TotalAmountShouldBe(0, new DateTime(2019, 8, 31), new DateTime(2019, 8, 31));
        }

        [Test]
        public void period_no_overlapping_after_budget_lastDay()
        {
            GivenBudgets(new Budget { YearMonth = "2019/9", Amount = 30 });
            TotalAmountShouldBe(0, new DateTime(2019, 10, 1), new DateTime(2019, 10, 1));
        }

        [Test]
        public void period_overlapping_budget_firstDay()
        {
            GivenBudgets(new Budget { YearMonth = "2019/9", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2019, 8, 31), new DateTime(2019, 9, 1));
        }

        private void TotalAmountShouldBe(decimal expected, DateTime start, DateTime end)
        {
            Assert.AreEqual(expected, _account.TotalAmount(start, end));
        }

        private void GivenBudgets(params Budget[] budgets)
        {
            _repos.GetAll().Returns(budgets.ToList());
        }

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