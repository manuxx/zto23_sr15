using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DomainClasses;

namespace PetShop
{
    public class Where<T>
    {
        public static WhereSupport<T,E> HasAn<E>(Func<T,E> func)
        {
            return new WhereSupport<T,E>(func);
        }
    }
    public class WhereSupport<T,E>
    {
        public Func<T, E> func;

        public WhereSupport(Func<T, E> func)
        {
            this.func = func;
        }

        public Criteria<T> EqualTo(E equal)
        {
            return new AnonymousCriteria<T>(item => func(item).Equals(equal));
        }
    }
}
