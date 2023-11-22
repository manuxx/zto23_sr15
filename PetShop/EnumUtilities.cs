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

    public static IEnumerable<TItem> ThatsSatisfy<TItem>(this IList<TItem> petsInTheStore, Predicate<TItem> condition)
    {
        foreach (var pet in petsInTheStore)
        {
            if (condition(pet))
            {
                yield return pet;
            }
        }
    }
}