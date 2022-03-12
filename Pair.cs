using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Returns a sequence containing every possible combination of pairs from <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The source <see cref="IEnumerable{T}"/>.</param>
        /// <typeparam name="T">The <see cref="Type"/> of item in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> of every possible combination of two elements from <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static IEnumerable<(T, T)> Pair<T>(this IEnumerable<T> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            
            T[] array = source.ToArray();
            return from item1 in array
                   from item2 in array
                   select (item1, item2);
        }
    }
}