using System;

namespace Training.DomainClasses;

public class AnonymousCriteria<T> : Criteria<T>
{
	private readonly Predicate<T> predicate;
	public AnonymousCriteria(Predicate<T> predicate)
	{
		this.predicate = predicate;
	}

	public bool isSatisfiedBy(T item)
	{
		return predicate(item);
	}
}