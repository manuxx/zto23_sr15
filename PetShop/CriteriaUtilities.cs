using System;
using System.Collections.Generic;
using System.Text;
using Training.DomainClasses;

    public static class CriteriaUtilities
    {
        public static Criteria<TItem> And<TItem>(this Criteria<TItem> items, Criteria<TItem> next)
        {
            return new Conjunction<TItem>(items, next);
        }
        public static Criteria<TItem> Or<TItem>(this Criteria<TItem> items, Criteria<TItem> next)
        {
            return new Alternative<TItem>(items, next);
        }
    }
