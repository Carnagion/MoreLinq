using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Checks if <paramref name="source"/> contains any of the elements in <paramref name="values"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to check.</param>
        /// <param name="values">The <see cref="IEnumerable{T}"/> that holds the values to check.</param>
        /// <typeparam name="T">The <see cref="System.Type"/> of elements in <paramref name="source"/> and <paramref name="values"/>.</typeparam>
        /// <returns><see langword="true"/> if at least one element of <paramref name="values"/> is also contained in <paramref name="source"/>, else <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if either <paramref name="source"/> or <paramref name="values"/> is <see langword="null"/>.</exception>
        [Pure]
        public static bool ContainsAny<T>(this IEnumerable<T> source, IEnumerable<T> values)
        {
            return source is HashSet<T> set
                ? values.Any(set.Contains)
                : source.Intersect(values).Any();
        }
    }
}