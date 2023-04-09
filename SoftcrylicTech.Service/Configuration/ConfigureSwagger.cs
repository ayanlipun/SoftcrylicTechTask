using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoftcrylicTech.Service.ModelSettings;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;

namespace SoftcrylicTech.Service.Configuration
{
    public static class ConfigureSwagger
    {
        // private static string groupName = "v1";
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(swagg =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swagg.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerMiddileware(this IApplicationBuilder app, ILogger logger, IOptions<SwaggerSettings> swaggerOptions)
        {
            logger.LogTrace("configuring swagger middileware...");

            app.UseSwagger();
            app.UseSwaggerUI(swagg =>
            {

                swagg.SwaggerEndpoint($"/swagger/v1/swagger.json", "V1");
                swagg.RoutePrefix = "doc";
                swagg.OAuthClientId(swaggerOptions?.Value?.HubClientId);
                swagg.OAuthAppName(swaggerOptions?.Value?.Title);
            });
            logger.LogTrace("Completed configuring swagger middileware.");
        }
    }
}
