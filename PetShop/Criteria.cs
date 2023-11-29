using Training.DomainClasses;

public interface Criteria<T>
{
    bool IsSatisfiedBy(T item);
    Criteria<Pet> And(Criteria<Pet> isBornAfter);
}