using System.Collections.Concurrent;

namespace AppClient.Utilities
{
    internal static class Cache
    {
        /// <summary>
        /// A dictionary to cache the results of requested numbers.
        /// </summary>
        private static ConcurrentDictionary<Int64, CalculationResponse> cache = new ConcurrentDictionary<Int64, CalculationResponse>();

        /// <summary>
        /// Gets the cached value associated with the specified key.
        /// </summary>
        /// <param name="key">The key to look up.</param>
        /// <returns>The cached value if the key is found, null otherwise.</returns>
        public static CalculationResponse Get(Int64 key)
        {
            // Get the result from the cache
           return cache[key];
        }    

        /// <summary>
        /// Checks if the cache contains an entry with the specified key.
        /// </summary>
        /// <param name="key">The key to look up.</param>
        /// <returns>True if the cache contains an entry with the key, false otherwise.</returns>

        public static bool Contains(Int64 key)
        {
            return cache.ContainsKey(key);
        }

        /// <summary>
        /// Adds a new entry to the cache with the specified key and value.
        /// </summary>
        /// <param name="key">The key of the entry to add.</param>
        /// <param name="obj">The value of the entry to add.</param>
        /// <returns>True if the entry was added successfully, false if the key already exists.</returns>
        public static bool Add(Int64 key, CalculationResponse obj )
        {
            return cache.TryAdd(key, obj);
        }
        
       
    }
}
