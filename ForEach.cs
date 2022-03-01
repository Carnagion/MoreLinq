using System.Collections.Generic;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Executes <paramref name="function"/> over every item in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> of items to execute <paramref name="function"/> on.</param>
        /// <param name="function">The <see cref="Action{T}"/> to invoke for each item in <paramref name="source"/>.</param>
        /// <typeparam name="T">The <see cref="Type"/> of item in <paramref name="source"/>.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown if either <paramref name="source"/> or <paramref name="function"/> is <see langword="null"/>.</exception>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> function)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (function is null)
            {
                throw new ArgumentNullException(nameof(function));
            }
            
            foreach (T item in source)
            {
                function.Invoke(item);
            }
        }
    }
}