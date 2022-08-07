using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns all elements in <paramref name="source"/> that come before <paramref name="element"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to search in.</param>
        /// <param name="element">The element to search for.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> of all elements in <paramref name="source"/> that appear before <paramref name="element"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static IEnumerable<T> Before<T>(this IEnumerable<T> source, T element)
        {
            return source.TakeWhile(other => !EqualityComparer<T>.Default.Equals(element, other));
        }
        
        /// <summary>
        /// Returns all elements in <paramref name="source"/> that come before <paramref name="element"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to search in.</param>
        /// <param name="element">The element to search for.</param>
        /// <param name="equals">The function to use to compare the elements of <paramref name="source"/> with <paramref name="element"/>.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> of all elements in <paramref name="source"/> that appear before <paramref name="element"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if either <paramref name="source"/> or <paramref name="equals"/> is <see langword="null"/>.</exception>
        [Pure]
        public static IEnumerable<T> Before<T>(this IEnumerable<T> source, T element, Func<T, T, bool> equals)
        {
            return equals is null
                ? throw new ArgumentNullException(nameof(equals))
                : source.TakeWhile(other => !equals.Invoke(other, element));
        }
    }
}