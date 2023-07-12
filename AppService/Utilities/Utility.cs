namespace AppService.Utilities
{
    /// <summary>
    /// A static class that provides utility methods for the project.
    /// </summary>
    public static class Utility
    {

        #region Number utilities
        /// <summary>
        /// A method to check if a number is prime using a simple algorithm
        /// </summary>
        /// <param name="Number"></param>
        /// <returns>bool</returns>
        public static bool IsPrime(long number)
        {
            // Check if number is less than or equal to 1
            if (number <= 1) return false;

            // Check if number is equal to 2
            if (number == 2) return true;

            // Check if number is divisible by 2
            if (number % 2 == 0) return false;

            // Loop from 3 to the square root of number, incrementing by 2
            for (int i = 3; i * i <= number; i += 2)
            {
                // Check if number is divisible by i
                if (number % i == 0) return false;
            }

            // Return true if no divisor is found
            return true;
        }       
        #endregion



    }
}