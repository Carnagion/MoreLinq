# MoreLinq

A C# library that provides useful LINQ extension methods.

With MoreLinq, you can:
- Get all elements in an `IEnumerable<T>` after/before a specific element
- Get alternating elements in an `IEnumerable<T>`, starting from either the first or the second element
- Check whether an `IEnumerable<T>` contains any or all elements from another `IEnumerable<T>`
- Get an exact copy of an `IEnumerable<T>`
- Generate an `IEnumerable<T>` with a specified amount of duplicates of each element from a different `IEnumerable<T>`
- Flatten an `IEnumerable<T>` of `IEnumerable<T>`s into one single sequence
- Execute a function over each element of an `IEnumerable<T>` using lambda expressions rather than a `foreach` loop
- Generate a new `IEnumerable<T>` of a specified count using a yielding function
- Get all non-null elements of an `IEnumerable<T>`
- Get all possible pairings of each element in an `IEnumerable<T>`
- Get the product of any `IEnumerable<T>` where `T` is a numeric type like `int`, `double`, etc
- Get a random element from an `IEnumerable<T>`
- Randomise the order of elements in an `IEnumerable<T>`
- Create a new `IEnumerable<T>` from a single element

Each of these methods are located in the new `IEnumerableExtensions` static class in the `System.Linq` namespace.  
So if you're already using extension methods, you won't need to add any additional `using` directives. 