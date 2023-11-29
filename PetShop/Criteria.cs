using System.Collections.Generic;
using PetShop;

public abstract class Criteria<T>
{
    public abstract bool IsSatisfiedBy(T item);

    public ListBaseCritetria<T> And(Criteria<T> cr)
    {
        return new AndCriteria<T>(this,cr);
    }

    public ListBaseCritetria<T> Or(Criteria<T> cr)
    {
        return new OrCriteria<T>(this,cr);
    }
}