using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Generates an <see cref="IEnumerable{T}"/> with <paramref name="count"/> elements according to <paramref name="yield"/>.
        /// </summary>
        /// <param name="count">The number of elements to generate.</param>
        /// <param name="yield">A <see cref="Func{Int32,T}"/> that generates elements for each index.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in the result.</typeparam>
        /// <returns>A new <see cref="IEnumerable{T}"/> with <paramref name="count"/> elements generated using <paramref name="yield"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="count"/> is less than 1.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="yield"/> is <see langword="null"/>.</exception>
        [Pure]
        public static IEnumerable<T> Generate<T>(int count, Func<int, T> yield)
        {
            if (count <= 0)
            {
                throw new ArgumentException($"Count must be a positive integer.", nameof(count));
            }
            if (yield is null)
            {
                throw new ArgumentNullException(nameof(yield));
            }
            return IEnumerableExtensions.GenerateIterator(count, yield);
        }

        [Pure]
        private static IEnumerable<T> GenerateIterator<T>(int count, Func<int, T> yield)
        {
            for (int index = 0; index < count; index += 1)
            {
                yield return yield.Invoke(index);
            }  
        }
    }
}