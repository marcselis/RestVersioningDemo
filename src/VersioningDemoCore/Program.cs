using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace VersioningDemoCore
{
    /// <summary>
    /// Represents the program
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            new V2.Models.Concern().Name = null;
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
