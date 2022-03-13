using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Inserts <paramref name="values"/> into <paramref name="source"/> at the index specified by <paramref name="index"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> into which values are to be inserted.</param>
        /// <param name="values">The <see cref="IEnumerable{T}"/> whose values are to be inserted into <paramref name="source"/>.</param>
        /// <param name="index">The index at which the insertion is to occur. All elements in <paramref name="source"/> with this index or higher will be pushed down.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in <paramref name="source"/> and <paramref name="values"/>.</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if either <paramref name="source"/> or <paramref name="values"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="index"/> is less than 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is greater than or equal to the number of elements in <paramref name="source"/>.</exception>
        [Pure]
        public static IEnumerable<T> Insert<T>(this IEnumerable<T> source, IEnumerable<T> values, int index)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            if (index < 0)
            {
                throw new ArgumentException("Index must be a non-negative integer", nameof(index));
            }
            return IEnumerableExtensions.InsertIterator(source, values, index);
        }

        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        [Pure]
        private static IEnumerable<T> InsertIterator<T>(IEnumerable<T> source, IEnumerable<T> values, int index)
        {
            int currentIndex = 0;
            foreach (T element in source)
            {
                if (currentIndex == index)
                {
                    foreach (T value in values)
                    {
                        yield return value;
                    }
                }
                yield return element;
                currentIndex += 1;
            }
            
            if (currentIndex <= index)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
    }
}