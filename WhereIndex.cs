using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Filters <paramref name="source"/> based on the results of <paramref name="filter"/> applied to its elements' indices.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to filter.</param>
        /// <param name="filter">The <see cref="Predicate{T}"/> to apply on each element in <paramref name="source"/>.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements from <paramref name="source"/> that satisfy <paramref name="filter"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if either <paramref name="source"/> or <paramref name="filter"/> is <see langword="null"/>.</exception>
        [Pure]
        public static IEnumerable<T> WhereIndex<T>(this IEnumerable<T> source, Predicate<int> filter)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (filter is null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            int index = 0;
            foreach (T element in source)
            {
                if (filter.Invoke(index))
                {
                    yield return element;
                }
                index += 1;
            }
        }
    }
}