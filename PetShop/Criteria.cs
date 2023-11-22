public interface Criteria<T>
{
    bool IsSatisfyBy(T item);
}