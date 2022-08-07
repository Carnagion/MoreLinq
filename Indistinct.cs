using System.Collections.Generic;

namespace System.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Finds elements that are contained more than once in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to search in.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> of all elements that appear more than once in <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        public static IEnumerable<T> Indistinct<T>(this IEnumerable<T> source)
        {
            return source is null
                ? throw new ArgumentNullException(nameof(source))
                : EnumerableExtensions.IndistinctIterator(source).Distinct();
        }
        
        private static IEnumerable<T> IndistinctIterator<T>(IEnumerable<T> source)
        {
            HashSet<T> visited = new();
            foreach (T element in source)
            {
                if (!visited.Add(element))
                {
                    yield return element;
                }
            }
        }
    }
}