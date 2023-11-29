using Training.DomainClasses;

public static class CriteriaExtensions
{
    public static Conjunction<TItem> And<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> criteria2)
    {
        return new Conjunction<TItem>(criteria1, criteria2);
    }

    public static Alternative<TItem> Or<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> criteria2)
    {
        return new Alternative<TItem>(criteria1, criteria2);
    }
}