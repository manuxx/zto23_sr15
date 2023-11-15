using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class EnumUtilities
    {
        public static IEnumerable<TItem> OneAtATime<TItem>(IEnumerable<TItem> pets)
        {
            foreach (var pet in pets)
            {
                yield return pet;
            }
        }
    }
}