using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Picks a random element from <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to pick an element from.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in <paramref name="source"/>.</typeparam>
        /// <returns>A randomly chosen element from <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> is empty.</exception>
        [Pure]
        public static T Random<T>(this IEnumerable<T> source)
        {
            return source.Random(new());
        }
        
        /// <summary>
        /// Picks a random element from <paramref name="source"/> using <paramref name="randomiser"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to pick an element from.</param>
        /// <param name="randomiser">The <see cref="System.Random"/> to use when choosing a random element.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in <paramref name="source"/>.</typeparam>
        /// <returns>A randomly chosen element from <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if either <paramref name="source"/> or <paramref name="randomiser"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> is empty.</exception>
        [Pure]
        public static T Random<T>(this IEnumerable<T> source, Random randomiser)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (randomiser is null)
            {
                throw new ArgumentNullException(nameof(randomiser));
            }
            
            T? current = default;
            int count = 0;
            foreach (T element in source)
            {
                count += 1;
                if (randomiser.Next(count) is 0)
                {
                    current = element;
                }
            }
            return count is 0 ? throw new InvalidOperationException("Sequence was empty") : current!;
        }
        
        /// <summary>
        /// Picks a random element from <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to pick an element from.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in <paramref name="source"/>.</typeparam>
        /// <returns>A randomly chosen element from <paramref name="source"/>, or a default value if <paramref name="source"/> is empty.</returns>
        [Pure]
        public static T? RandomOrDefault<T>(this IEnumerable<T> source)
        {
            return source.RandomOrDefault(new());
        }
        
        /// <summary>
        /// Picks a random element from <paramref name="source"/> using <paramref name="randomiser"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to pick an element from.</param>
        /// <param name="randomiser">The <see cref="System.Random"/> to use when choosing a random element.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in <paramref name="source"/>.</typeparam>
        /// <returns>A randomly chosen element from <paramref name="source"/>, or a default value if <paramref name="source"/> is empty.</returns>
        [Pure]
        public static T? RandomOrDefault<T>(this IEnumerable<T> source, Random randomiser)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (randomiser is null)
            {
                throw new ArgumentNullException(nameof(randomiser));
            }
            
            T? current = default;
            int count = 0;
            foreach (T element in source)
            {
                count += 1;
                if (randomiser.Next(count) is 0)
                {
                    current = element;
                }
            }
            return current;
        }
    }
}