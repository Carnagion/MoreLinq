using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Picks alternating elements from <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to pick elements from.</param>
        /// <param name="beginFromOne">If <see langword="true"/>, then elements with an odd index will be picked, else elements with an even index will be picked.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> containing every alternate element from <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static IEnumerable<T> Alternate<T>(this IEnumerable<T> source, bool beginFromOne = false)
        {
            int mod = beginFromOne ? 1 : 0;
            return source.WhereIndex(index => (index % 2) == mod);
        }
    }
}