using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Returns all elements in <paramref name="source"/> that come after <paramref name="element"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to search in.</param>
        /// <param name="element">The element to search for.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> of all elements in <paramref name="source"/> that appear after <paramref name="element"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        /// <remarks>This method results in boxing for <see cref="ValueType"/>s. To prevent this, use <see cref="After{T}(System.Collections.Generic.IEnumerable{T},T,Func{T,T,bool})"/> instead.</remarks>
        [Pure]
        public static IEnumerable<T> After<T>(this IEnumerable<T> source, T element)
        {
            return source is null ? throw new ArgumentNullException(nameof(source)) : IEnumerableExtensions.AfterIterator(source, element, (left, right) => Object.Equals(left, right));
        }

        /// <summary>
        /// Returns all elements in <paramref name="source"/> that come after <paramref name="element"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to search in.</param>
        /// <param name="element">The element to search for.</param>
        /// <param name="equals">The function to use to compare the elements of <paramref name="source"/> with <paramref name="element"/>.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> of all elements in <paramref name="source"/> that appear after <paramref name="element"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if either <paramref name="source"/> or <paramref name="equals"/> is <see langword="null"/>.</exception>
        [Pure]
        public static IEnumerable<T> After<T>(this IEnumerable<T> source, T element, Func<T, T, bool> equals)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (equals is null)
            {
                throw new ArgumentNullException(nameof(equals));
            }
            return IEnumerableExtensions.AfterIterator(source, element, equals);
        }

        [Pure]
        private static IEnumerable<T> AfterIterator<T>(IEnumerable<T> source, T element, Func<T, T, bool> equals)
        {
            bool yield = false;
            foreach (T other in source)
            {
                if (yield)
                {
                    yield return other;
                }
                else if (equals.Invoke(other, element))
                {
                    yield = true;
                }
            }
        }
    }
}