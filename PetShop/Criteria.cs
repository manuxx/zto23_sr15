using System;
using Training.DomainClasses;

public abstract class Criteria<T>
{
    public abstract bool IsSatisfiedBy(T item);

    public Criteria<T> Or(Criteria<T> other)
    {
        return new AnonymousCriteria<T>(pet => IsSatisfiedBy(pet) || other.IsSatisfiedBy(pet));
    }
}