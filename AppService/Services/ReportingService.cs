using AppService.Utilities;

namespace AppService.Services
{
    /// <summary>
    /// A class that provides a method for displaying the statistics of the requested prime numbers
    /// </summary>
    public class ReportingService
    {
        // A timer for displaying the statistics every second
        private Timer _statsTimer;

        public ReportingService()
        {

            // Create a timer that runs every second and uses a lambda expression to display the statistics
            _statsTimer ??= new Timer(_ =>
            {
                // Get the total number of messages received from the Cache
                long total = Cache.MessagesTracker.Get();

                // Get the top 10 highest requested primes from the Cache 
                var top10 = Cache.PrimeNumbers.GetTopRequestedPrimes(10);

                // Display the results using string interpolation and the Logger class
                Logger.Log($"Total messages received: {total}");
                Logger.Log("Top 10 requested primes:");
                foreach (var pair in top10)
                {
                    Logger.Log($"{pair.Key}: {pair.Value}");
                }
                Console.WriteLine();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(1)); // Set the timer to run every second

        }

    }
}


