using Microsoft.AspNetCore.Hosting;
using System.Configuration;
using static DocJur.Api.App.Utilities.ConfigurationConstants;

namespace DocJur.Api.App.Utilities
{
    public static class WebHostServiceExtensions
    {
        /// <summary>
        /// Reads the port numbers from App.Config and set them into the webHostBuilder
        /// </summary>
        /// <param name="webHostBuilder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseAppPorts(this IWebHostBuilder webHostBuilder)
        {
            int httpPort = int.Parse(ConfigurationManager.AppSettings[APP_PORT_HTTP_KEY]);
            int httpsPort = int.Parse(ConfigurationManager.AppSettings[APP_PORT_HTTPS_KEY]);

            return webHostBuilder.UseUrls($"http://*:{httpPort}", $"https://*:{httpsPort}");
        }
    }
}
