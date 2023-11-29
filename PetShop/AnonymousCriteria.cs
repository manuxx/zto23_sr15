using System;
using System.Collections.Generic;

public class AnonymousCriteria<T> : Criteria<T>
{
    private readonly Predicate<T> _condition;

    public AnonymousCriteria(Predicate<T> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}

public class Negation<T> : Criteria<T>
{
    private readonly Criteria<T> _condition;

    public Negation(Criteria<T> condition)
    {
        _condition= condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return !_condition.IsSatisfiedBy(item);
    }
}

//public class Conjunction<T> : Criteria<T>
//{
//    private readonly IEnumerable<Predicate<T>> _conditions;

//    public Conjunction(IEnumerable<Predicate<T>> conditions)
//    {
//        _conditions = conditions;
//    }

//    public bool IsSatisfiedBy(T item)
//    {
//        bool result = true;
//        foreach (var condition in _conditions)
//        {
//            result &= condition(item);
//        }
//        return result;
//    }
//}
public class Conjunction<T> : Criteria<T>
{
    private readonly Criteria<T> _condition1;
    private readonly Criteria<T> _condition2;

    public Conjunction(Criteria<T> condition1, Criteria<T>  condition2)
    {
        _condition1 = condition1;
        _condition2 = condition2;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition1.IsSatisfiedBy(item) && _condition2.IsSatisfiedBy(item);
    }
}

public class Alternative<T> : Criteria<T>
{
    private readonly Criteria<T> _condition1;
    private readonly Criteria<T> _condition2;

    public Alternative(Criteria<T> condition1, Criteria<T> condition2)
    {
        _condition1 = condition1;
        _condition2 = condition2;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition1.IsSatisfiedBy(item) || _condition2.IsSatisfiedBy(item);
    }
}