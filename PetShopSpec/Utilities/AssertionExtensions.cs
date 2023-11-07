using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.Utility.Internal;

namespace Training.Specificaton
{
    public static class AssertionExtensions
    {
        public static void ShouldContainOnlyInOrder<TItem>(this IEnumerable<TItem> items, params TItem[] ordered_items)
        {
            AssertionExtensions.ShouldContainOnlyInOrder<TItem>(items, (IEnumerable<TItem>)ordered_items);
        }

        public static void ShouldContainOnlyInOrder<TItem>(this IEnumerable<TItem> items, IEnumerable<TItem> ordered_items)
        {
            List<TItem> source = new List<TItem>(items);
            if (!Enumerable.Any<TItem>(Enumerable.Where<TItem>(ordered_items, (Func<TItem, int, bool>)((ordered_element, index) => !source[index].Equals((object)ordered_element)))))
                return;
            throw new SpecificationException(string.Format("The set of items should only contain the items in the order {0}\r\nbut it actually contains the items:{1}", ordered_items.EachToUsefulString(), items.EachToUsefulString()));
        }
    }
}
