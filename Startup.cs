using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedOTPService.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AdvancedOTPService
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.Json")
                .AddJsonFile("appsettings.Development.Json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContextPool<AppDbContext>(opts => opts.UseSqlServer(Configuration["Connection:ConnectionString"]));
            services.AddScoped<iuser, sqluser>();
            services.AddScoped<iotpmessage, sqlotpmessage>();
            services.AddScoped<iapikeycontrol, sqlapicontrol>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
