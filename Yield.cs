using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Creates a new sequence from a single element.
        /// </summary>
        /// <param name="element">The only element of the sequence.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in the the sequence.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> containing only <paramref name="element"/>.</returns>
        [Pure]
        public static IEnumerable<T> Yield<T>(this T element)
        {
            yield return element;
        }
    }
}