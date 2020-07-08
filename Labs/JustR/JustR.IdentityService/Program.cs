using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace JustR.IdentityService
{
    public class Program
    {
        public static void Main(String[] args)
        {
            IConfigurationBuilder configurationBuilder = GetConfigurationBuilder();

            CreateHostBuilder(args, configurationBuilder)
                .Build()
                .Run();
        }

        private static IConfigurationBuilder GetConfigurationBuilder()
        {
            String directory = Directory.GetCurrentDirectory();
            String fileName = "hosting.json";

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile(fileName);

            return configurationBuilder;
        }

        public static IHostBuilder CreateHostBuilder(String[] args, IConfigurationBuilder configurationBuilder)
        {
            IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);

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