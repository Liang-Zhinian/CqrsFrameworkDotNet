using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Reservation.ClientWebApi
{
    public class Program
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// Builds the web host.
        /// </summary>
        /// <returns>The web host.</returns>
        /// <param name="args">Arguments.</param>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseUrls("http://localhost:60001")
                .UseStartup<Startup>()
                .Build();
    }
}
