using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumeratorUtils
{
    public static IEnumerable<TItem> OneAtATime<TItem>(IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}