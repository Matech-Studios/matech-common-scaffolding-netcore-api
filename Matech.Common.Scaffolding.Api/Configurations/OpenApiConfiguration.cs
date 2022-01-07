using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Matech.Common.Scaffolding.Api.Configurations
{
    public static class OpenApiConfiguration
    {
        private const string Version = "v1";
        private const string Scheme = "Bearer";
        private const string SecurityDescription = "Please introduce Bearer Token";
        private const string SecurityTypeName = "Authorization";        
        private const string EndpointName = "SCAFFOLDING API";
        private static readonly string SwaggerUrl = $"/swagger/{Version}/swagger.json";

        public static void SetupSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    Version,
                    new OpenApiInfo
                    {
                        Title = "Scaffolding .NET Core 3.1 API",
                        Version = Version,
                        Description = "Base structure Matech Web API to use as a template for the .NET Core 3.1 APIs"
                    }
                );
                var dir = new DirectoryInfo(AppContext.BaseDirectory);
                foreach (var file in dir.EnumerateFiles("*.xml")) c.IncludeXmlComments(file.FullName);

                var securitySchema = new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = SecurityDescription,
                    Name = SecurityTypeName,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = Scheme,
                    BearerFormat = "JWT",
                };

                c.AddSecurityDefinition(Scheme, securitySchema);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id =  Scheme
                            }
                        },
                        new string[] {}
                    }
            });
            });
        }

        public static void UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint(SwaggerUrl, EndpointName); });
        }

        public static void UseReDocConfig(this IApplicationBuilder app) 
        {
            app.UseReDoc(c =>
            {
                c.SpecUrl($"../swagger/{Version}/swagger.json");
                c.EnableUntrustedSpec();
                c.ScrollYOffset(10);
                c.HideHostname();
                c.HideDownloadButton();
                c.ExpandResponses("200,201");
                c.RequiredPropsFirst();
                c.NoAutoAuth();
                c.PathInMiddlePanel();
                c.HideLoading();
                c.NativeScrollbars();
                c.DisableSearch();
                c.OnlyRequiredInSamples();
                c.SortPropsAlphabetically();
            });
        }
    }
}

