using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace WebApplication2
{
    public class LambdaEntryPoint : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

            builder
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(config)
                .UseStartup<DependencyResolution.Startup>()
                .UseSetting(WebHostDefaults.ApplicationKey, typeof(LambdaEntryPoint).GetTypeInfo().Assembly.FullName) // Ignore the startup class assembly as the "entry point" and instead point it to this app
               .UseApiGateway(); 
        }
    }
}
