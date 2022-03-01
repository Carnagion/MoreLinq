using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Duplicates the items in <paramref name="source"/>, <paramref name="times"/> times.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to duplicate.</param>
        /// <param name="times">The number of times each element in <paramref name="source"/> appears in the returned <see cref="IEnumerable{T}"/>.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> containing every element <paramref name="times"/> times.</returns>
        [Pure]
        public static IEnumerable<T> Duplicate<T>(this IEnumerable<T> source, uint times = 2)
        {
            foreach (T element in source)
            {
                for (uint count = 0; count < times; count += 1)
                {
                    yield return element;
                }
            }
        }
    }
}