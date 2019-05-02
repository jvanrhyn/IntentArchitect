using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ModuleTesting.IdentityServer4Host.Api.IdentityData;
using ModuleTesting.IdentityServer4Host.Api.IdentityModels;
using ModuleTesting.IdentityServer4Host.Application;
using ModuleTesting.IdentityServer4Host.Application.ServiceImplementation;
using Swashbuckle.AspNetCore.Swagger;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.AspNetCore.Startup", Version = "1.0")]

namespace ModuleTesting.IdentityServer4Host.Api
{
    [IntentManaged(Mode.Merge)]
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IHostingEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        // [IntentManaged(Mode.Ignore)] // Uncomment this line to take over management of configuring services
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            IntentConfiguredServices(services);

            ConfigureSwagger(services);
            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(IdentityConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityConfig.GetApis())
                .AddInMemoryClients(IdentityConfig.GetClients())
                //.AddTestUsers(IdentityConfig.GetUsers())
                .AddAspNetIdentity<ApplicationUser>()
                ;

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                throw new Exception("need to configure key material");
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            InitializeSwagger(app);
        }

        public void IntentConfiguredServices(IServiceCollection services)
        {

            services.AddTransient<ISimpleTest, SimpleTest>();
        }



        //[IntentManaged(Mode.Ignore)] // Uncomment to take control of this method.
        private void InitializeSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdentityServer4Host API V1");
            });
        }

        //[IntentManaged(Mode.Ignore)] // Uncomment to take control of this method.
        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "IdentityServer4Host API", Version = "v1" });
            });
        }
    }
}