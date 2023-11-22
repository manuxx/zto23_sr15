using System;

public class AnonymousCriteria<T> : Criteria<T>
{
    private Predicate<T> _condition;
    public AnonymousCriteria(Predicate<T> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfyBy(T item)
    {
        return _condition(item);
    }
}