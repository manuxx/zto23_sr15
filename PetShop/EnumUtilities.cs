using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class EnumUtilities
    {
        public static IEnumerable<TItem> OneAtATime<TItem>(IEnumerable<TItem> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}