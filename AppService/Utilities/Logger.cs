namespace AppService.Utilities
{
    public static class Logger
    {
        /// <summary>
        /// Logs a message to the console.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Log(string message) 
        {
            Console.WriteLine(message);
        }
    }
}