using AppClient.Utilities;
using Grpc.Core;
using Grpc.Net.Client;
using System.Configuration;
using System.Text;

namespace AppClient
{
    /// <summary>
    /// A class that represents a gRPC client for the calculation service.
    /// </summary>
    public class CalculationClient
    {
        private static readonly string ServiceUrl;
        private static readonly bool IsCacheEnabled ;
        private static int RequestPerSecond;

        static CalculationClient() {
            ServiceUrl = ConfigurationManager.AppSettings["CalculationServiceUrl"]?? string.Empty;
            IsCacheEnabled = bool.Parse( ConfigurationManager.AppSettings["IsCacheEnabled"]??"false");
            RequestPerSecond = int.Parse( ConfigurationManager.AppSettings["RequestPerSecond"]?? "1");
        }
      
        #region private methods

        /// <summary>
        /// Gets or creates a request object with a random number and the current timestamp.
        /// </summary>
        /// <returns>A request object.</returns>
        private static PrimeNumber GetOrCreateRequest()
        {
            // Generate a random number
            int number = Utility.GetRandomNumber();

            // Check if the number is already in the cache
            if (IsCacheEnabled && Cache.Contains(number))
            {
                // Return a dummy request with an  negative id
                return new PrimeNumber { Id = -1 };
            }

            // Create and return a new request object with a unique id and the current timestamp
            var unixTimestamp = Utility.GetUnixTimeMs(DateTime.Now);
            var uniqueId = Utility.GetUniqueNumber();
            return new PrimeNumber
            {
                Id = uniqueId,
                Timestamp = unixTimestamp,
                Number = number
            };
        }
        /// <summary>
        /// Sends a request to the server with a random number and gets a response indicating if it is prime or not.
        /// </summary>
        /// <param name="client">The gRPC client stub.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private static async Task SendRequestAsync(Calculation.CalculationClient client)
        {
            try
            {
                // Get or create a request object
                var request = GetOrCreateRequest();

                // Check if the request has an negative id
                if (request.Id<0)
                {
                    // Get the result from the cache
                    var res = Cache.Get(request.Number);

                    // Create and log a message from the result
                    var message = CreateMessage(res);
                    Logger.Log(message);
                    return;
                }

                // Call the service
                CalculationResponse result = await client.CheckNumberAsync(request);

                // Validate result for null or empty response
                if (result == null)
                {
                    // Display custom error message
                    Logger.Log("No response received");
                    return;
                }

                // Add the result to the cache
                Cache.Add(result.Number, result);

                // Create and log a message from the result
                var responseMessage = CreateMessage(result);
                Logger.Log(responseMessage);
            }
            catch (RpcException ex)
            {
                // Handle any gRPC errors
                Logger.Log($"gRPC error: {ex.Message}");
            }
        }
      
        /// <summary>
        /// Creates a message to display the result from the response object.
        /// </summary>
        /// <param name="response">The response object.</param>
        /// <returns>A message string.</returns>
        private static string CreateMessage(CalculationResponse response)
        {
            // Calculate the round trip time (RTT) in milliseconds
            var rtt = Utility.SubTractUnixTime(response.Timestamp, Utility.GetUnixTimeMs(DateTime.Now));

            // Rent a string builder from the pool
            var builder = new StringBuilder();

            // Append the message using string interpolation
            builder.Append($"Number {response.Number} is ");
            if (!response.Isprime)
            {
                builder.Append("not ");
            }
            builder.Append($"prime. RTT: {rtt} ms"); 

            // Return the message
            return builder.ToString();
}

        #endregion 

        #region Public methods

        /// <summary>
        /// Runs the client and sends Given requests per second to the server.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task RunAsync(string[] args)
        {
            // The port number must match the port of the gRPC server.           

            if(ServiceUrl == null || ServiceUrl == string.Empty)
            {
                Console.WriteLine("Config setting missing for 'CalculationServiceUrl'"); 
                return;
            }

            using (var channel = GrpcChannel.ForAddress(ServiceUrl))
            {
                var client = new Calculation.CalculationClient(channel);
                // Send requests per second in parallel
                await Task.WhenAll(Enumerable.Range(0, RequestPerSecond).Select(i => SendRequestAsync(client)));
            }
        }
        #endregion

    }
}


