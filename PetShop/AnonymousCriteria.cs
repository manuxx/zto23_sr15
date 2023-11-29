using System;

public class AnonymousCriteria<T> : Criteria<T>
{
    private readonly Predicate<T> _condition;

    public AnonymousCriteria(Predicate<T> condition)
    {
        _condition = condition;
    }
    
    public override bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}