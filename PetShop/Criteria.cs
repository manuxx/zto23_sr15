public interface Criteria<T>
{
    bool IsSatisfiedBy(T item);
}