using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Yields every element from an <see cref="IEnumerable{T}"/> of <see cref="IEnumerable{T}"/>s.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> of sequences.</param>
        /// <typeparam name="T">The <see cref="Type"/> of item in each <see cref="IEnumerable{T}"/> in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> containing every element from every <see cref="IEnumerable{T}"/> in <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return from sequence in source
                   from element in sequence
                   select element;
        }
    }
}