using System;
using System.Collections.Generic;
using Training.DomainClasses;

namespace Training.DomainClasses;

public static class EnumUtilities
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
	    foreach (var item in items)
	    {
		    yield return item;
	    }
    }

    public static IEnumerable<TItem> Filter(this IList<TItem> items, Predicate<TItem> condition)
    {
	    Criteria<TItem> criteria = new AnonymousCriteria<TItem>(condition);
		return items.FilterBy(criteria);
    }

    public static IEnumerable<TItem> FilterBy(this IList<TItem> items, Criteria<TItem> criteria)
    {
	    foreach (var item in items)
	    {
		    if (criteria.isSatisfiedBy(item))
		    {
			    yield return item;
		    }
	    }
    }
}

public class AnonymousCriteria<T> : Criteria<T>
{
	private readonly Predicate<T> predicate;
	public AnonymousCriteria(Predicate<T> predicate)
	{
		this.predicate = predicate;
	}

	public bool isSatisfiedBy(T item)
	{
		return predicate(item);
	}
}

public interface Criteria<TItem>
{
	bool isSatisfiedBy(TItem item);
}