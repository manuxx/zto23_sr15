using System.Collections.Generic;

namespace Training.DomainClasses;

public static class EnumeratorUtils
{
    public static IEnumerable<TItem> AccessPets<TItem>(IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}