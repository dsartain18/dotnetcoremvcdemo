using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using WebApplication2.Entities.Entities;
using WebApplication2.Managers.Interfaces;
using WebApplication2.Managers.Managers;
using WebApplication2.Repositories.Interfaces;
using WebApplication2.Repositories.Repositories;

namespace WebApplication2.DependencyResolution
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("EFCoreTest");
            
            services.AddDbContext<TESTContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IRDSManager, RDSManager>();
            services.AddTransient<IRDSRepo, RDSRepo>();

            services.AddMvc()
                .AddApplicationPart(Assembly.Load(new AssemblyName("WebApplication2.Controllers")));            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
        {
            if (applicationBuilder == null)
            {
                throw new ArgumentNullException("applicationBuilder");
            }

            if (hostingEnvironment == null)
            {
                throw new ArgumentNullException("hostingEnvironment");
            }

            if (loggerFactory == null)
            {
                throw new ArgumentNullException("loggerFactory");
            }

            loggerFactory.AddLambdaLogger(Configuration.GetLambdaLoggerOptions());

            if (hostingEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
                applicationBuilder.UseBrowserLink();
            }
            else
            {
                applicationBuilder.UseExceptionHandler("/Home/Error");
            }

            applicationBuilder.UseStaticFiles();

            applicationBuilder.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
