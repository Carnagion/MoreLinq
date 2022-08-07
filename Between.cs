using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Gets all elements between <paramref name="from"/> and <paramref name="to"/> in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to search in.</param>
        /// <param name="from">The index to start from, inclusive.</param>
        /// <param name="to">The index to end at, inclusive.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> containing all elements of <paramref name="source"/> between <paramref name="from"/> and <paramref name="to"/>, inclusive.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if either <paramref name="from"/> or <paramref name="to"/> is less than 0, or if <paramref name="from"/> is greater than <paramref name="to"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if either <paramref name="from"/> or <paramref name="to"/> is greater than the number of elements in <paramref name="source"/>.</exception>
        [Pure]
        public static IEnumerable<T> Between<T>(this IEnumerable<T> source, int from, int to)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (from < 0)
            {
                throw new ArgumentException("Index must be a non-negative integer", nameof(from));
            }
            if (to < 0)
            {
                throw new ArgumentException("Index must be a non-negative integer", nameof(to));
            }
            if (from > to)
            {
                throw new ArgumentException("End index must be equal to or less than start index", nameof(to));
            }
            return from == to
                ? source.ElementAt(from).Yield()
                : EnumerableExtensions.BetweenIterator(source, from, to);
        }
        
        private static IEnumerable<T> BetweenIterator<T>(IEnumerable<T> source, int from, int to)
        {
            int index = 0;
            foreach (T element in source)
            {
                if ((index >= from) && (index <= to))
                {
                    yield return element;
                }
                index += 1;
            }
            
            if (from > index)
            {
                throw new ArgumentOutOfRangeException(nameof(from));
            }
            if (to > index)
            {
                throw new ArgumentOutOfRangeException(nameof(to));
            }
        }
    }
}