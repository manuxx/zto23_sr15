using System;
using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumUtilities
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
    {

        Criteria<TItem> adapter = new AnonymousCriteria<TItem>(condition);
        return items.ThatSatisfy(adapter);
    }   

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Criteria<TItem> condition)
    {
        foreach (var item in items)
        {
            if (condition.IsSatisfiedBy(item))
            {
                yield return item;
            }
        }
    }

}