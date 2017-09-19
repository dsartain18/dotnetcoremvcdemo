using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace mvctest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Load Hosting Configuration that contains the URLs with custom ports
            IConfigurationRoot config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("hosting.json", optional:true)
                        .Build();

            // Create IWebHost using Kestrel. Use Configuration.
            IWebHost host = new WebHostBuilder()
            .UseKestrel()
            .UseConfiguration(config)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>()
            .Build();

            // Run the Host
            host.Run();

            // Commented out default code. Delete IRL
            //BuildWebHost(args).Run();
        }


        // Commented out default code. Delete IRL
        // public static IWebHost BuildWebHost(string[] args) =>

        //     WebHost.CreateDefaultBuilder(args)
        //         .UseStartup<Startup>()
        //         .UseUrls("http://localhost:8080")
        //         .Build();
    }
}
