using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Filters all elements from <paramref name="source"/> that are not <see langword="null"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to search in.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> of all non-<see langword="null"/> elements from <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return (from element in source
                    where element is not null
                    select element)!;
        }
    }
}