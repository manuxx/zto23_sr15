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

    public static IEnumerable<TItem> Filter<TItem>(this IList<TItem> items, Predicate<TItem> condition)
    {
	    return items.FilterBy(new AnonymousCriteria<TItem>(condition));
    }

    public static IEnumerable<TItem> FilterBy<TItem>(this IList<TItem> items, Criteria<TItem> criteria)
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