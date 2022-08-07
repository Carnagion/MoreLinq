using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Intersperses <paramref name="element"/> between each element in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to use.</param>
        /// <param name="element">The value to intersperse.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> with <paramref name="element"/> between each element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static IEnumerable<T> Intersperse<T>(this IEnumerable<T> source, T element)
        {
            return source
                .SelectMany(element.Yield().Append)
                .Skip(1);
        }
    }
}