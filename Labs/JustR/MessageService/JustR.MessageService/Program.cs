using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace JustR.MessageService
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

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hosting.json");


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
