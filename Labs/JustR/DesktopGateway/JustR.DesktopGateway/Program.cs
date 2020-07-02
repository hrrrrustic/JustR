using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace JustR.DesktopGateway
{
    public class Program
    {
        public static void Main(String[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(String[] args)
        {
            IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);

            String directory = Directory.GetCurrentDirectory();
            String fileName = "hosting.json";

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile(fileName);

            hostBuilder = hostBuilder
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseConfiguration(configurationBuilder.Build())
                        .UseStartup<Startup>();
                });

            return hostBuilder;
        }
    }
}