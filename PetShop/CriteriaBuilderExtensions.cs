using System;
using System.Collections.Generic;
using System.Text;


public static class CriteriaBuilderExtensions
{
    public static Criteria<TItem> EqualTo<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty property)
    {
        return new AnonymousCriteria<TItem>(item => criteriaBuilder._propertySelector(item).Equals(property));
    }

    public static Criteria<TItem> GreaterThan<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty v)
        where TProperty : IComparable<TProperty>
    {
        return new AnonymousCriteria<TItem>(item => criteriaBuilder._propertySelector(item).CompareTo(v) < 0);
    }
}

