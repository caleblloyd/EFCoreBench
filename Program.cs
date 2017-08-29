using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using EFCoreBench.Commands;
using Microsoft.AspNetCore;

namespace EFCoreBench
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
	            BuildWebHost(args).Run();
            }
            else
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection
                    .AddLogging()
                    .AddSingleton<ICommandRunner, CommandRunner>()
                    .AddSingleton<ITestPerformanceCommand, TestPerformanceCommand>();
                Startup.ConfigureEntityFramework(serviceCollection);
                var serviceProvider = serviceCollection.BuildServiceProvider();

                serviceProvider
                    .GetService<ILoggerFactory>()
                    .AddConsole(AppConfig.Config.GetSection("Logging"));

                var commandRunner = serviceProvider.GetService<ICommandRunner>();

                Environment.Exit(commandRunner.Run(args));
            }
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:5000")
                .UseStartup<Startup>()
                .Build();
        }

    }
}
