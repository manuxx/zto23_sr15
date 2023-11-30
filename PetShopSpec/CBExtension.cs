using System;
using Training.Specificaton;

public static class CBExtension
{
    public static Criteria<TItem> GreaterThan<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty n)
    where TProperty : IComparable
    {
        return new AnonymousCriteria<TItem>(p => criteriaBuilder._propertySelector(p).CompareTo(n)> 0);
    }

    public static Criteria<TItem> EqualTo<TItem, TProperty>(CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty mouse)
    {
        return new AnonymousCriteria<TItem>(p => criteriaBuilder._propertySelector(p).Equals(mouse));
    }
}