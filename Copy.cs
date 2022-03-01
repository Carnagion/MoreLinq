using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Returns a copy of <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to copy.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in <paramref name="source"/>.</typeparam>
        /// <returns>A new <see cref="IEnumerable{T}"/> containing all the elements of <paramref name="source"/> in the same order.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static IEnumerable<T> Copy<T>(this IEnumerable<T> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return from item in source
                   select item;
        }
    }
}