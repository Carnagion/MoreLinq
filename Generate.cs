using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Generates an <see cref="IEnumerable{T}"/> with <paramref name="count"/> elements according to <paramref name="yield"/>.
        /// </summary>
        /// <param name="count">The number of elements to generate.</param>
        /// <param name="yield">A <see cref="Func{Int32,T}"/> that generates elements for each index.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in the result.</typeparam>
        /// <returns>A new <see cref="IEnumerable{T}"/> with <paramref name="count"/> elements generated using <paramref name="yield"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="count"/> is less than 0 or greater than <see cref="Int32.MaxValue"/>.</exception>
        [Pure]
        public static IEnumerable<T> Generate<T>(int count, Func<int, T> yield)
        {
            return Enumerable.Range(0, count).Select(yield);
        }
    }
}