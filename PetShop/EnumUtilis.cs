using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class EnumUtilis
    {
        public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}