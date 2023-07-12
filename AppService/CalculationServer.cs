using AppService.Services;
namespace AppService
{
    public static class CalculationServer
    {

        /// <summary>
        /// A method to run the web application and the gRPC service
        /// </summary>
        /// <param name="args"></param>
        public static void Run(string[] args)
        {
           
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddGrpc();

            var app = builder.Build();

            // Map gRPC service to the endpoint
            app.MapGrpcService<CalculationService>();


            // Display the stats in a background task
            Task.Run(() => new AppService.Services.ReportingService());


            app.Run();

        }    
    }
}
