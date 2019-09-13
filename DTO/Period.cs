﻿using System;

namespace TDD_BudgetApp.DTO
{
    public class Period
    {
        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public decimal OverlappingDays(Period another)
        {
            if (HasNoOverlapping(another))
            {
                return 0;
            }

            var effectiveStart = another.Start > Start
                ? another.Start
                : Start;

            var effectiveEnd = another.End < End
                ? another.End
                : End;
            return (decimal)(effectiveEnd - effectiveStart).TotalDays + 1;
        }

        private bool HasNoOverlapping(Period another)
        {
            return another.End < Start || End < another.Start;
        }
    }
}