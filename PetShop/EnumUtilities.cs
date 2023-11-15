using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumUtilities
{
    public static IEnumerable<TItem> OneAtTheTime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}