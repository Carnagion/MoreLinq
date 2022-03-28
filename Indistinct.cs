using System.Collections.Generic;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Finds elements that are contained more than once in <paramref name="source"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to search in.</param>
        /// <typeparam name="T">The <see cref="Type"/> of elements in <paramref name="source"/>.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> of all elements that appear more than once in <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <see langword="null"/>.</exception>
        public static IEnumerable<T> Indistinct<T>(this IEnumerable<T> source)
        {
            return source is null ? throw new ArgumentNullException(nameof(source)) : IEnumerableExtensions.IndistinctIterator(source);
        }

        private static IEnumerable<T> IndistinctIterator<T>(IEnumerable<T> source)
        {
            // Disable nullability warning as null is handled inside the loop
#pragma warning disable 8714
            Dictionary<T, bool> visited = new();
#pragma warning restore 8714
            bool? nullYielded = null;
            
            foreach (T element in source)
            {
                // Handle null separately since Dictionary<TKey, TValue> cannot have null as a key
                if (element is null)
                {
                    if (nullYielded is null)
                    {
                        nullYielded = false;
                    }
                    else if (!nullYielded.Value)
                    {
                        yield return element;
                        nullYielded = true;
                    }
                    continue;
                }
                
                if (!visited.TryGetValue(element, out bool yielded))
                {
                    visited[element] = false;
                    continue;
                }
                if (yielded)
                {
                    continue;
                }
                visited[element] = true;
                yield return element;
            }
        }
    }
}