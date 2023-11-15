using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumUntils
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}