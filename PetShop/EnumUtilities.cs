using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Training.DomainClasses;
using static EnumUtilities;

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

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
            {
                yield return item;
            }
        }
    }

    public interface Criteria<T>
    {
        public bool IsSatisfiedBy(T item);
    }
}

public class AnonymousCriteria<T> : Criteria<T>
{
    private Predicate<T> _condition;
    public AnonymousCriteria(Predicate<T> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}
