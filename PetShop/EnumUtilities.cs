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

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IList<TItem> items, Predicate<TItem> condition)
    {
        Criteria<TItem> adapter = new AnonymousCryteria<TItem>(condition);
        return items.ThatSatisfy(adapter);
    }

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IList<TItem> petsInTheStore, Criteria<TItem> criteria)
    {
        foreach (var pet in petsInTheStore)
        {
            if (criteria.IsSatisfiedBy(pet))
            {
                yield return pet;
            }
        }
    }
}