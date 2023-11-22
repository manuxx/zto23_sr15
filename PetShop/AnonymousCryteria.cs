using System;

public class AnonymousCryteria<TItem> : Criteria<TItem>
{
    private Predicate<TItem> _condition;

    public AnonymousCryteria(Predicate<TItem> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(TItem pet)
    {
        return _condition(pet);
    }
}