using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.Extensions.Hosting.Internal;

namespace BuildCostEstimator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    // Recreate the settings hierarchy manually
                    //config.Sources.Clear();
                    //config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    //config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    //if (context.HostingEnvironment.IsDevelopment())
                    //{
                    //    config.AddUserSecrets<Program>();
                    //    
                    //}
                    //
                    //config.AddEnvironmentVariables();
                    //config.AddCommandLine(args);   
                    
                    
                    if (context.HostingEnvironment.IsDevelopment())
                    {
                       return;
                    }

                    var builtConfig = config.Build();
                    var keyVaultEndpoint = new Uri($"https://{builtConfig["KeyVaultName"]}.vault.azure.net/");
                    config.AddAzureKeyVault(keyVaultEndpoint.ToString());

                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
