﻿using System;
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
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)            
            .Build();
            
            var host = new WebHostBuilder()
            .UseKestrel()            
            .UseConfiguration(config)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<WebApplication2.DependencyResolution.Startup>()
            .UseSetting(WebHostDefaults.ApplicationKey, typeof(Program).GetTypeInfo().Assembly.FullName) // Ignore the startup class assembly as the "entry point" and instead point it to this app
            .Build();

            host.Run();
        }        
    }
}