using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace System.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Joins each element in <paramref name="source"/> into a single <see cref="string"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> of elements to join.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in <paramref name="source"/>.</typeparam>
        /// <returns>A <see cref="string"/> consisting of the string representations of each element in <paramref name="source"/> with no separator between them.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static string Join<T>(this IEnumerable<T> source)
        {
            return source.Aggregate(new StringBuilder(), (builder, element) => builder.Append(element)).ToString();
        }
        
        /// <summary>
        /// Joins each element in <paramref name="source"/> into a single <see cref="string"/> using <paramref name="separator"/> as a separator.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> of elements to join.</param>
        /// <param name="separator">The separator to use.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in <paramref name="source"/>.</typeparam>
        /// <returns>A <see cref="string"/> consisting of the string representations of each element in <paramref name="source"/> separated by <paramref name="separator"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        [Pure]
        public static string Join<T>(this IEnumerable<T> source, char separator)
        {
            return String.Join(separator, source);
        }
        
        /// <summary>
        /// Joins each element in <paramref name="source"/> into a single <see cref="string"/> using <paramref name="separator"/> as a separator.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> of elements to join.</param>
        /// <param name="separator">The separator to use.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in <paramref name="source"/>.</typeparam>
        /// <returns>A <see cref="string"/> consisting of the string representations of each element in <paramref name="source"/> separated by <paramref name="separator"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if either <paramref name="source"/> or <paramref name="separator"/> is <see langword="null"/>.</exception>
        [Pure]
        public static string Join<T>(this IEnumerable<T> source, string separator)
        {
            return separator is null
                ? throw new ArgumentNullException(nameof(separator))
                : String.Join(separator, source);
        }
    }
}