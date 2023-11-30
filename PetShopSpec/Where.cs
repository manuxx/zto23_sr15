using System;
using Training.DomainClasses;

namespace Training.Specificaton
{
    public static class Where<TClass>
    {
        public static CriteriaBuilder<TClass, TProperty> HasAn<TProperty>(Func<TClass, TProperty> propertySelector) 
        {
            return new CriteriaBuilder<TClass, TProperty>(propertySelector);
        }
    }

    public class CriteriaBuilder<TClass, TProperty> 
    {
        public readonly Func<TClass, TProperty> _propertySelector;
        public bool negation { get; set; }  = false;
        public CriteriaBuilder(Func<TClass, TProperty> propertySelector) {
            _propertySelector = propertySelector;
        }

    }

    public static class CriteriaBuilderUtil
    {
        public static CriteriaBuilder<TClass, TProperty> Not<TClass, TProperty>(this CriteriaBuilder<TClass, TProperty> critBuilder)
        {
            critBuilder.negation = true;
            return critBuilder;
        }
        public static Criteria<TClass> EqualTo<TClass, TProperty>(this CriteriaBuilder<TClass, TProperty> critBuilder, TProperty species)
        {
            if(critBuilder.negation)
            {
                return new Negation<TClass>(new AnonymousCriteria<TClass>(p => critBuilder._propertySelector(p).Equals(species)));
            }
            return new AnonymousCriteria<TClass>(p => critBuilder._propertySelector(p).Equals(species));
        }
        public static Criteria<TClass> GreaterThen<TClass, TProperty>( this CriteriaBuilder<TClass, TProperty> critBuilder, TProperty v)
        where TProperty : IComparable<TProperty>
        {
            if(critBuilder.negation)
            {
                return new Negation<TClass>(new AnonymousCriteria<TClass>(p => critBuilder._propertySelector(p).CompareTo(v) > 0));
            }
            return new AnonymousCriteria<TClass>(p => critBuilder._propertySelector(p).CompareTo(v) > 0);
        }
    }
}