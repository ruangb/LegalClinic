using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace LC.WebApi.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
            { 
                Title = "Consultório Legal",
                Version = "v1",
                Description = "API da aplicação Consultório Legal",
                Contact = new OpenApiContact
                {
                    Name = "Ruan Barros",
                    Email = "ruangbarros@gmail.com",
                    Url = new Uri("https://github.com/ruangb")
                },
                License = new OpenApiLicense
                {
                    Name = "OSD",
                    Url = new Uri("https://opensource.org/osd")
                },
                TermsOfService = new Uri("https://opensource.org/osd")
            }
            ));  
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
 
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "LC V1");
            });
        }
    }
}
