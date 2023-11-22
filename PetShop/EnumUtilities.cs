using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class EnumUtilities
    {
        public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
        {
            Criteria<TItem> adapter = new AnonymousCriteria<TItem>(condition);
            return items.ThatSatisfy(adapter);
        }

        public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
        {
            foreach (var item in items)
            {
                if (criteria.IsSatisifedBy<TItem>(item))
                {
                    yield return item;
                }
            }
        }
    }

    public class AnonymousCriteria<T> : Criteria<T>
    {
        Predicate<T> _condition;
        public AnonymousCriteria(Predicate<T> condition)
        {
            _condition = condition;
        }

        public bool IsSatisifedBy<TItem>(T item)
        {
            return _condition(item);
        }
    }

    public interface Criteria<T>
    {
        public bool IsSatisifedBy<TItem>(T item);
    }

    public class IsBornAfterCriteria : Criteria<Pet>
    {
        int _year;

        public IsBornAfterCriteria(int year)
        {
            _year = year;
        }

        public bool IsSatisifedBy<TItem>(Pet item)
        {
            return item.yearOfBirth > _year;
        }
    }
}