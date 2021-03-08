using DocJur.Api.App.Database;
using DocJur.Api.App.Utilities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Threading;


namespace DocJur.Api.App
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationConstants.APP_CULTURE);
            IWebHostBuilder builder = CreateWebHostBuilder(args);
            IWebHost host = builder.Build();

            using IServiceScope scope = host.Services.CreateScope();
            System.IServiceProvider services = scope.ServiceProvider;
            DatabaseContext context = services.GetRequiredService<DatabaseContext>();
            DatabaseInit.Execute(context);

            host.Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.SetMinimumLevel(LogLevel.Trace);
            })
            .UseAppPorts()
            .UseStartup<Startup>();

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
