using AppService.Utilities;
using Grpc.Core;
namespace AppService.Services
{
    public class CalculationService : Calculation.CalculationBase
    {
        public override Task<CalculationResponse> CheckNumber(PrimeNumber request, ServerCallContext context)
        {
            // Update the message tracker
            Cache.MessagesTracker.IncrementCount();

            // Get the number from the request or use zero if null
            var number = request?.Number ?? 0;

            // Check if it is prime
            bool isPrime = Utility.IsPrime(number);

            // If it is prime, update the cache
            if (isPrime)
            {
                Cache.PrimeNumbers.Add(number);

            }

            // Create response 
            var res = new CalculationResponse
            {
                Number = number,
                Isprime = isPrime,
                Timestamp = request?.Timestamp ?? -1
            };

            // Return the response
            return Task.FromResult(res);
        }

    }
}