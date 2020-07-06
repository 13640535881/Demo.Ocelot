using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Ocelot.InsideTest
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
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            ////Consul·þÎñ×¢²á
            //var consulOption = new ConsulOption
            //{
            //    ServiceName = this.Configuration.GetSection("ConsulOption:ServiceName").Value,
            //    ServiceIP = this.Configuration.GetSection("ConsulOption:ServiceIP").Value,
            //    ServicePort = int.Parse(this.Configuration.GetSection("ConsulOption:ServicePort").Value),
            //    ServiceHealthCheck = this.Configuration.GetSection("ConsulOption:ServiceHealthCheck").Value,
            //    ConsulAddress = this.Configuration.GetSection("ConsulOption:ConsulAddress").Value
            //};
            //app.RegisterConsul(lifetime, consulOption);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
