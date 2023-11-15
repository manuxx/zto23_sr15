using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumUtilities
{
    public static IEnumerable<TElement> AccessItem<TElement>(this IEnumerable<TElement> elements)
    {
        foreach (var element in elements)
        {
            yield return element;
        }
    }
}
