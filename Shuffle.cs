using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Bibliographer.Mla;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
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
        /// Randomises the order of elements in <paramref name="source"/> using <paramref name="randomiser"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to shuffle.</param>
        /// <param name="randomiser">The <see cref="System.Random"/> to use when shuffling elements.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> containing all elements of <paramref name="source"/> in a random order.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Author("Anton", "Gogolev")]
        [Title("An extension method on IEnumerable needed for shuffling [duplicate]")]
        [Container("StackOverflow")]
        [Location("https://stackoverflow.com/questions/5807128/an-extension-method-on-ienumerable-needed-for-shuffling")]
        [Accessed(2022, 3, 12)]
        [Pure]
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random randomiser)
        {
            return source is null
                ? throw new ArgumentNullException(nameof(source))
                : from element in from element in source
                                  select (randomiser.Next(), element)
                  orderby element.Item1
                  select element.Item2;
        }
    }
}