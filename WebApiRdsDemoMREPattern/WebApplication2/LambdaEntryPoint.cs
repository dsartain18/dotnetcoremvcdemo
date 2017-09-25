using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication2
{
    public class LambdaEntryPoint : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<DependencyResolution.Startup>()
                .UseSetting(WebHostDefaults.ApplicationKey, typeof(LambdaEntryPoint).GetTypeInfo().Assembly.FullName) // Ignore the startup class assembly as the "entry point" and instead point it to this app
               .UseApiGateway(); 
        }
    }
}
