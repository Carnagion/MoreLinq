using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Checks if <paramref name="source"/> contains all elements in <paramref name="values"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to check.</param>
        /// <param name="values">The <see cref="IEnumerable{T}"/> that holds the values to check.</param>
        /// <typeparam name="T">The <see cref="System.Type"/> of elements in <paramref name="source"/> and <paramref name="values"/>.</typeparam>
        /// <returns><see langword="true"/> if all elements of <paramref name="values"/> are also contained in <paramref name="source"/>, else <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if either <paramref name="source"/> or <paramref name="values"/> is <see langword="null"/>.</exception>
        [Pure]
        public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<T> values)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            
            if (source is HashSet<T> set)
            {
                return values.All(set.Contains);
            }
            
            ILookup<T, T> sourceGroups = source.ToLookup(element => element);
            ILookup<T, T> valuesGroups = values.ToLookup(element => element);
            return (sourceGroups.Count == valuesGroups.Count) && sourceGroups.All(group => group.Count() == valuesGroups[group.Key].Count());
        }
    }
}