using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumUtils
{
    public static IEnumerable<Pet> GetOneAtATime(this IEnumerable<Pet> pets)
    {
        foreach (var pet in pets)
        {
            yield return pet;
        }
    }
}