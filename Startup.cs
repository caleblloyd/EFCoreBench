using System;
using System.Buffers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using EFCoreBench.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Design;
using System.Threading;

namespace EFCoreBench
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Configuration = AppConfig.Config;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(options =>
            {
                options.OutputFormatters.Clear();
                options.OutputFormatters.Add(new JsonOutputFormatter(new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                }, ArrayPool<char>.Shared));
            });
            ConfigureEntityFramework(services);
        }

        private static int _identified = 0; 

        public static void ConfigureEntityFramework(IServiceCollection services)
        {            
#if MYSQL
                if (Interlocked.Increment(ref _identified) == 1)
                    Console.WriteLine("using MySQL");
                services.AddDbContextPool<AppDb>(
                    options => options.UseMySql(AppConfig.Config["Data:MYSQL"],
                        providerOptions => providerOptions.MaxBatchSize(AppConfig.EfBatchSize)));
#elif NPGSQL
                if (Interlocked.Increment(ref _identified) == 1)
                    Console.WriteLine("using PostgreSQL");
                services.AddDbContextPool<AppDb>(
                    options => options.UseNpgsql(AppConfig.Config["Data:NPGSQL"],
                        providerOptions => providerOptions.MaxBatchSize(AppConfig.EfBatchSize)));
#elif SQLSERVER
                if (Interlocked.Increment(ref _identified) == 1)
                    Console.WriteLine("using SQL Server");
                services.AddDbContextPool<AppDb>(
                    options => options.UseSqlServer(AppConfig.Config["Data:SQLSERVER"],
                        providerOptions => providerOptions.MaxBatchSize(AppConfig.EfBatchSize)));
#else
                throw new InvalidOperationException("no configuration specified, use MYSQL, NPGSQL, or SQLSERVER");
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            app.UseMvc();
        }

    }
}
