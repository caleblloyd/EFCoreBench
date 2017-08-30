using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace EFCoreBench
{
    public static class AppConfig
    {
	    public static readonly bool AppVeyor = !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("APPVEYOR"));

	    public static readonly int EfBatchSize = !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("EF_BATCH_SIZE"))
		    ? Convert.ToInt32(Environment.GetEnvironmentVariable("EF_BATCH_SIZE")) : 1;

        public static readonly string EfSchema = !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("EF_SCHEMA"))
            ? Environment.GetEnvironmentVariable("EF_SCHEMA") : null;

        public static readonly IConfigurationRoot Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile("config.json")
            .Build();
        
    }
}
