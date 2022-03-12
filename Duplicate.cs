using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Duplicates the items in <paramref name="source"/> <paramref name="amount"/> times.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to duplicate.</param>
        /// <param name="amount">The number of duplicates of each element in the returned <see cref="IEnumerable{T}"/>.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> containing every element (<paramref name="amount"/> + 1) times.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="amount"/> is less than 0.</exception>
        [Pure]
        public static IEnumerable<T> Duplicate<T>(this IEnumerable<T> source, int amount = 1)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (amount < 0)
            {
                throw new ArgumentException("Amount of duplicates must be a non-negative integer.", nameof(amount));
            }
            return amount switch
            {
                0 => source,
                _ => IEnumerableExtensions.DuplicateIterator(source, amount),
            };
        }

        [Pure]
        private static IEnumerable<T> DuplicateIterator<T>(IEnumerable<T> source, int amount)
        {
            foreach (T element in source)
            {
                for (int count = 0; count <= amount; count += 1)
                {
                    yield return element;
                }
            }
        }
    }
}