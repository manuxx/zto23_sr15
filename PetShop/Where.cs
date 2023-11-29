using System;
using System.Collections.Generic;
using System.Text;
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
        private Func<TItem, TProperty> _propertySelector;

        public CriteriaBuilder(Func<TItem, TProperty> propertySelector)
        {
            _propertySelector = propertySelector;
        }

        public Criteria<TItem> EqualTo(Species species)
        {
            return new AnonymousCriteria<TItem>(item => _propertySelector(item).Equals(species));
        }
    }

