using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class EnumUtilities
    {
        public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
        {
            foreach (var item in items)
            {
                if (condition(item))
                {
                    yield return item;
                }
            }
        }
    }
}