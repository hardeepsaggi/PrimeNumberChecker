namespace AppClient.Utilities
{
    /// <summary>
    /// A static class that provides utility methods for the project.
    /// </summary>
    public static class Utility
    {

        #region Number utilities
        // random number generator
        private static Random random = new Random();

        /// <summary>
        /// Generates a random number between 1 and a specified maximum value.
        /// </summary>
        /// <param name="Max">The exclusive upper bound of the random number. The default value is 1001.</param>
        /// <returns>A random number between 1 and Max.</returns>
        public static int GetRandomNumber(int Max =1001)
        {
            return random.Next(1, Max);
        }


        // A counter to generate a unique number
        private static Int64 counter = 0;

        /// <summary>
        /// Generates a unique number by incrementing a static counter.
        /// </summary>
        /// <returns>The new value of the counter.</returns>
        public static Int64 GetUniqueNumber()
        {
            // This ensures that no two threads can get the same value or interfere with each other
          return  Interlocked.Increment(ref counter);
        }
        #endregion


        #region Datetime utilities
        /// <summary>
        /// Converts a DateTime value to a Unix time in milliseconds.
        /// </summary>
        /// <param name="date">The DateTime value to convert.</param>
        /// <returns>The number of milliseconds that have elapsed since 1970-01-01T00:00:00Z.</returns>
        public static Int64 GetUnixTimeMs(DateTime date)
        {
            // Use the DateTimeOffset.ToUnixTimeMilliseconds() method to get the Unix time
            long unixTimestamp = new DateTimeOffset(date).ToUnixTimeMilliseconds();
            return unixTimestamp;
        }

        /// <summary>
        /// Subtracts two Unix time values in milliseconds.
        /// </summary>
        /// <param name="a">The first Unix time value.</param>
        /// <param name="b">The second Unix time value.</param>
        /// <returns>The difference between a and b in milliseconds.</returns>
        public static Int64 SubTractUnixTime(Int64 a,Int64 b)
        {
            return a - b;            
        }
        #endregion
    }
}