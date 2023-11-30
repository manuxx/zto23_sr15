

public static class CriteriaHelpers
{

    public static Criteria<T> And<T>(this Criteria<T> first, Criteria<T> other)
    {
        return new AnonymousCriteria<T>(pet => first.IsSatisfiedBy(pet) && other.IsSatisfiedBy(pet));
    }
}
