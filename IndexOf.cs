using System.Collections.Generic;

namespace System.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns the index of <paramref name="element"/> in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to search in.</param>
        /// <param name="element">The element to search for.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in <paramref name="source"/>.</typeparam>
        /// <returns>The zero-based index of <paramref name="element"/> in <paramref name="source"/>, or -1 if it does not exist.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        /// <remarks>This method results in boxing for <see cref="ValueType"/>s. To prevent this, use <see cref="IndexOf{T}(System.Collections.Generic.IEnumerable{T},T,Func{T,T,bool})"/> instead.</remarks>
        public static int IndexOf<T>(this IEnumerable<T> source, T element)
        {
            return source.IndexOf(element, EqualityComparer<T>.Default.Equals);
        }
        
        /// <summary>
        /// Returns the index of <paramref name="element"/> in <paramref name="source"/>, using <paramref name="equals"/> to compare each element.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to search in.</param>
        /// <param name="element">The element to search for.</param>
        /// <param name="equals">The function to use to compare values in <paramref name="source"/> with <paramref name="element"/>.</param>
        /// <typeparam name="T">The <see cref="Type"/> of element in <paramref name="source"/>.</typeparam>
        /// <returns>The zero-based index of <paramref name="element"/> in <paramref name="source"/>, or -1 if it does not exist.</returns>
        /// <exception cref="ArgumentNullException">Thrown if either <paramref name="source"/> or <paramref name="equals"/> is <see langword="null"/>.</exception>
        public static int IndexOf<T>(this IEnumerable<T> source, T element, Func<T, T, bool> equals)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (equals is null)
            {
                throw new ArgumentNullException(nameof(equals));
            }
            
            int index = 0;
            foreach (T other in source)
            {
                if (equals.Invoke(other, element))
                {
                    return index;
                }
                index += 1;
            }
            return -1;
        }
    }
}