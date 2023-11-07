using System.Collections.Generic;


namespace Training.Specificaton
{
    public static class CollectionExtensions
    {
        public static void AddManyItems<T>(this ICollection<T> collection, params T[] itemsToAdd)
        {
            foreach (var item in itemsToAdd) collection.Add(item);
        }

        public static int CountItems<T>(this IEnumerable<T> collection)
        {
            int cnt = 0;
            var enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext()) cnt++;
            return cnt;
        }

    }
}
