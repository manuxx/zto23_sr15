using System;

public class AnonyymousCriteria<T> : Criteria<T>
{
    private Predicate<T> _condition;

    public AnonyymousCriteria(Predicate<T> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}