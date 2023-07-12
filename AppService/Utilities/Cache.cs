using System.Collections.Concurrent;

namespace AppService.Utilities
{

    /// <summary>
    /// A class that provides methods for storing and retrieving the requested prime numbers and their counts.
    /// </summary>
    internal static class Cache
    {
        public static class PrimeNumbers
        {
            /// <summary>
            /// A concurrent dictionary that stores the prime numbers as keys and their counts as values.
            /// </summary>
            private static readonly ConcurrentDictionary<long, long> _cache = new ConcurrentDictionary<long, long>();

            /// <summary>
            /// Gets the top requested prime numbers and their counts.
            /// </summary>
            /// <param name="count">The maximum number of prime numbers to return.</param>
            /// <returns>An IEnumerable of KeyValuePair of Int64 and Int64, where the key is the prime number and the value is its count.</returns>
            public static IEnumerable<KeyValuePair<long, long>> GetTopRequestedPrimes(int count = 10)
            {
                // Get the top requested primes by sorting and taking from the dictionary
                return _cache.ToArray().OrderByDescending(pair => pair.Value).Take(count);
            }

            /// <summary>
            /// Gets the total count of all the requested prime numbers.
            /// </summary>
            /// <returns>The sum of all the values in the dictionary.</returns>
            public static long GetTotalCount()
            {
                // Get the total count by summing up all the values in the dictionary
                return _cache.Sum(pair => pair.Value);
            }

            /// <summary>
            /// Checks if the cache contains an entry with the specified key.
            /// </summary>
            /// <param name="key">The key to look up.</param>
            /// <returns>True if the cache contains an entry with the key, false otherwise.</returns>
            public static bool Contains(long key)
            {
                // Check if the dictionary contains the key
                return _cache.ContainsKey(key);
            }
            /// <summary>
            /// Adds a new entry to the cache with the specified key or increments its value if it already exists.
            /// </summary>
            /// <param name="key">The key of the entry to add or update.</param>      
            public static void Add(long key)
            {
                // Add or update the entry in the dictionary using a lambda expression
                _cache.AddOrUpdate(key, 1, (key, oldValue) => oldValue + 1);
            }
        }
        public static class MessagesTracker
        {
            // A counter to generate a unique number
            private static long counter = 0;

            /// <summary>
            /// Generates a unique number by incrementing a static counter.
            /// </summary>
            /// <returns>The new value of the counter.</returns>
            public static long IncrementCount()
            {
                // This ensures that no two threads can get the same value or interfere with each other
                return Interlocked.Increment(ref counter);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public static long Get()
            {
                // This ensures that no two threads can get the same value or interfere with each other
                return Interlocked.Read(ref counter);
            }
        }
    }
}
