using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Bibliographer.Mla;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
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
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            return source is HashSet<T> set ? values.Any(set.Contains) : source.Intersect(values).Any();
        }

        /// <summary>
        /// Checks if <paramref name="source"/> contains all elements in <paramref name="values"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to check.</param>
        /// <param name="values">The <see cref="IEnumerable{T}"/> that holds the values to check.</param>
        /// <typeparam name="T">The <see cref="System.Type"/> of elements in <paramref name="source"/> and <paramref name="values"/>.</typeparam>
        /// <returns><see langword="true"/> if all elements of <paramref name="values"/> are also contained in <paramref name="source"/>, else <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if either <paramref name="source"/> or <paramref name="values"/> is <see langword="null"/>.</exception>
        [Author("Eamon", "Nerbonne")]
        [Title("Test whether two IEnumerable<T> have the same values with the same frequencies")]
        [Container("StackOverflow")]
        [Location("https://stackoverflow.com/questions/4576723/test-whether-two-ienumerablet-have-the-same-values-with-the-same-frequencies")]
        [Accessed(2022, 3, 4)]
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