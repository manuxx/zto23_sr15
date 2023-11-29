using System;

namespace PetShop;

public class CriteriaBuilder<TItem, TProperty>
{
    private readonly Func<TItem, TProperty> _propertySelector;

    public CriteriaBuilder(Func<TItem, TProperty> propertySelector)
    {
        _propertySelector = propertySelector;
    }

    public Criteria<TItem> EqualTo(TProperty property)
    {
        return new AnonymousCriteria<TItem>(p => _propertySelector(p).Equals(property));
    }

    public Criteria<TItem> GreaterThan(IComparable<TProperty> i)
    {
        return new AnonymousCriteria<TItem>(p => i.CompareTo(_propertySelector(p)) < 0);
    }
}
