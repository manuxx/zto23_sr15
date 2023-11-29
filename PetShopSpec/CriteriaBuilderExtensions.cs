using System;

public static class CriteriaBuilderExtensions
{
    public static Criteria<TItem> EqualTo<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty property)
    {
        return new AnonymousCriteria<TItem>(p => criteriaBuilder._propertySelector(p).Equals(property));
    }

    public static Criteria<TItem> GreaterThan<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder,
        TProperty property) where TProperty : IComparable<TProperty>
    {
        return new AnonymousCriteria<TItem>(p => criteriaBuilder._propertySelector(p).CompareTo(property) > 0);
    }

}