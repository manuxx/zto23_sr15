using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public abstract class ListBaseCritetria<T> : Criteria<T>
    {
        protected IList<Criteria<T>> Criteria;

        public ListBaseCritetria(Criteria<T> critera1, Criteria<T> criteria2)
        {
            Criteria = new List<Criteria<T>>() { critera1, criteria2 };
        }

        public ListBaseCritetria(IList<Criteria<T>> criteria)
        {
            Criteria = criteria;
        }
    }

    public class AndCriteria<T> : ListBaseCritetria<T>

    {
        public AndCriteria(Criteria<T> critera1, Criteria<T> criteria2) : base(critera1, criteria2)
        {
        }

        public AndCriteria(IList<Criteria<T>> criteria) : base(criteria)
        {
        }

        public override bool IsSatisfiedBy(T item)
        {
            foreach (var criterion in Criteria)
            {
                if (!criterion.IsSatisfiedBy(item))
                    return false;
            }

            return true;
        }
        public ListBaseCritetria<T> And(Criteria<T> cr)
        {
            Criteria.Add(cr);
            return this;
        }
    }

    public class OrCriteria<T> : ListBaseCritetria<T>

    {
        public OrCriteria(Criteria<T> criteria1, Criteria<T> criteria2) : base(criteria1, criteria2)
        {
        }

        public OrCriteria(IList<Criteria<T>> criteria) : base(criteria)
        {
        }

        public override bool IsSatisfiedBy(T item)
        {
            foreach (var criterion in Criteria)
            {
                if (criterion.IsSatisfiedBy(item))
                    return true;
            }

            return false;
        }
        public ListBaseCritetria<T> Or(Criteria<T> cr)
        {
            Criteria.Add(cr);
            return this;
        }
    }
}