using Matech.Common.Middlewares.Lib.Exception;
using Matech.Common.Middlewares.Lib.Logging;
using Matech.Common.Scaffolding.Api.Configurations;
using Matech.Common.Scaffolding.Repository;
using Matech.Common.Scaffolding.Repository.Context;
using Matech.Common.Scaffolding.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Matech.Common.Scaffolding.Api
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
            services.AddHealthChecks()
                .AddDbContextCheck<TestDbContext>();

            services.SetupSwagger();

            services.AddMappers();

            services.AddRepository(Configuration);

            services.AddService();

            services.AddODataConfiguration();

            services.AddControllers(options => options.EnableEndpointRouting = false);    

            var authConfiguration = new AuthenticationConfiguration();
            Configuration.GetSection("AuthenticationConfiguration").Bind(authConfiguration);
            services.Configure<AuthenticationConfiguration>(Configuration.GetSection("AuthenticationConfiguration"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = authConfiguration.Authority;
                options.Audience = authConfiguration.Audience;
            }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health");

            app.UseMiddleware(typeof(LoggingMiddleware));
            app.UseMiddleware(typeof(CustomExceptionHandlerMiddleware));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().Filter().Expand().OrderBy().Count().MaxTop(null);
                routeBuilder.MapODataServiceRoute("odata", "odata", ODataConfiguration.GetEdmModel());
                routeBuilder.EnableDependencyInjection();
            });
                     
            app.UseSwaggerConfig();

            app.UseReDocConfig();
        }      
    }
}
