using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;

namespace EmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .ConfigureLogging((hc, l) =>
             {
                 //  l.ClearProviders();
                 l.AddConfiguration(hc.Configuration.GetSection("Logging"));
                 l.AddConsole();
                 l.AddDebug();
                 l.AddEventSourceLogger();
                 //  l.SetMinimumLevel(LogLevel.Trace);
                 l.AddNLog();
             })
                .UseStartup<Startup>();
    }
}
