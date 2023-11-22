namespace Training.DomainClasses;

public interface Criteria<TItem>
{
	bool isSatisfiedBy(TItem item);
}