using IdentityServer_4;
using IdentityServer4;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddIdentityServer()
             .AddDeveloperSigningCredential()
             .AddOperationalStore(options =>
             {
                 options.EnableTokenCleanup = true;
                 options.TokenCleanupInterval = 30; // interval in seconds
             })
             .AddInMemoryApiResources(Config.GetApiResources())
             .AddInMemoryClients(Config.GetClients())
             .AddTestUsers(Config.GetUsers())
             .AddProfileService<ProfileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello Identity Server Is Active");
                });
            });
        }
    }
}
