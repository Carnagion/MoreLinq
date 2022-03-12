using System.Collections.Generic;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Executes <paramref name="function"/> over every item in <paramref name="source"/>, yielding the elements back.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> of items to execute <paramref name="function"/> on.</param>
        /// <param name="function">The <see cref="Action{T}"/> to invoke for each item in <paramref name="source"/>.</param>
        /// <typeparam name="T">The <see cref="Type"/> of item in <paramref name="source"/>.</typeparam>
        /// <returns>The same <see cref="IEnumerable{T}"/>, after executing <paramref name="function"/> over its elements.</returns>
        /// <exception cref="ArgumentNullException">Thrown if either <paramref name="source"/> or <paramref name="function"/> is <see langword="null"/>.</exception>
        public static IEnumerable<T> Execute<T>(this IEnumerable<T> source, Action<T> function)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (function is null)
            {
                throw new ArgumentNullException(nameof(function));
            }
            return IEnumerableExtensions.ExecuteIterator(source, function);
        }

        
        /// <summary>
        /// Executes <paramref name="function"/> over every item in <paramref name="source"/>, yielding the elements back.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> of items to execute <paramref name="function"/> on.</param>
        /// <param name="function">The function to invoke for each item in <paramref name="source"/>.</param>
        /// <typeparam name="T">The <see cref="Type"/> of item in <paramref name="source"/>.</typeparam>
        /// <returns>The same <see cref="IEnumerable{T}"/>, after executing <paramref name="function"/> over its elements.</returns>
        /// <exception cref="ArgumentNullException">Thrown if either <paramref name="source"/> or <paramref name="function"/> is <see langword="null"/>.</exception>
        public static IEnumerable<T> Execute<T>(this IEnumerable<T> source, Action<T, int> function)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (function is null)
            {
                throw new ArgumentNullException(nameof(function));
            }
            return IEnumerableExtensions.ExecuteIterator(source, function);
        }

        private static IEnumerable<T> ExecuteIterator<T>(IEnumerable<T> source, Action<T> function)
        {
            foreach (T element in source)
            {
                function.Invoke(element);
                yield return element;
            }
        }

        private static IEnumerable<T> ExecuteIterator<T>(IEnumerable<T> source, Action<T, int> function)
        {
            int index = 0;
            foreach (T element in source)
            {
                function.Invoke(element, index);
                yield return element;
                index += 1;
            }
        }
    }
}