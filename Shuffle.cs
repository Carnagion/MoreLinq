using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Randomises the order of elements in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to shuffle.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> containing all elements of <paramref name="source"/> in a random order.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.Shuffle(new());
        }
        
        /// <summary>
        /// Randomises the order of elements in <paramref name="source"/> using <paramref name="randomizer"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to shuffle.</param>
        /// <param name="randomizer">The <see cref="System.Random"/> to use when shuffling elements.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> containing all elements of <paramref name="source"/> in a random order.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random randomizer)
        {
            return source
                .Select(element => (randomizer.Next(), element))
                .OrderBy(element => element.Item1)
                .Select(element => element.Item2);
        }
    }
}