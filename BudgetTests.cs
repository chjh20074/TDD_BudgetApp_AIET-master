using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace TDD_BudgetApp
{
    public class BudgetTests
    {
        [Test]
        public void no_budgets()
        {
            Accounting account = new Accounting();
            Assert.AreEqual(0, account.TotalAmount()); 
        }

        //[Test]
        //public void period_inside_budget_month()
        //{
            
        //}

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

    public class Accounting
    {
        public decimal TotalAmount()
        {
            return 0;
        }
    }
}