using Training.DomainClasses;

public static class CriteriaExtensions
{
    public static Conjunction<TItem> And<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> criteria2)
    {
        return new Conjunction<TItem>(criteria1,criteria2);
    }
}