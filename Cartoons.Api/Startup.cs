using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.IO;

using Cartoons.Models;
using Cartoons.Services;

namespace Cartoons.Api
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
            // The configuration instance to which the appsettings.json file's CartoonStoreDBSettings section binds is registered in 
            // the Dependency Injection (DI) container. 
            // For example, a CartoonStoreDBSettings object's ConnectionString property is populated with the 
            // CartoonStoreDBSettings:ConnectionString property in appsettings.json.
            services.Configure<CartoonStoreDBSettings>(Configuration.GetSection(nameof(CartoonStoreDBSettings)));
            
            // The ICartoonStoreDBSettings interface is registered in DI with a singleton service lifetime.
            //  When injected, the interface instance resolves to a ICartoonStoreDBSettings object.
            services.AddSingleton<ICartoonStoreDBSettings>(sp => sp.GetRequiredService<IOptions<CartoonStoreDBSettings>>().Value);
            services.AddSingleton<ICartoonStoreDBService, CartoonStoreDBService>();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cartoons Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cartoons Api V1");            
            });

            app.UseMvc();

            // app.UseRouting();
            // app.UseAuthorization();
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });
        }
    }
}
