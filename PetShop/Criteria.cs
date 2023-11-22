public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}