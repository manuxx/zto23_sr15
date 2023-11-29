using System;
using Training.DomainClasses;

public static class Where<TItem>
{
    public static CriteriaBuilder<TItem, TProperty> HasAn<TProperty>(Func<TItem, TProperty> propertySelector)
    {
        return new CriteriaBuilder<TItem, TProperty>(propertySelector);
    }
}

public class CriteriaBuilder<TItem, TProperty>
{
    public readonly Func<TItem, TProperty> _propertySelector;

    public CriteriaBuilder(Func<TItem, TProperty> propertySelector)
    {
        _propertySelector = propertySelector;
    }
}
