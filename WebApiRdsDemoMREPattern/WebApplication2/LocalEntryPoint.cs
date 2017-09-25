using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace WebApplication2
{
    public class LocalEntryPoint
    {
        public static void Main(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("hosting.json", optional: false)
            .Build();
            
            IWebHost host = new WebHostBuilder()
            .UseKestrel()            
            .UseConfiguration(config)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<DependencyResolution.Startup>()
            .UseSetting(WebHostDefaults.ApplicationKey, typeof(LocalEntryPoint).GetTypeInfo().Assembly.FullName) // Ignore the startup class assembly as the "entry point" and instead point it to this app
            .Build();

            host.Run();
        }        
    }
}
