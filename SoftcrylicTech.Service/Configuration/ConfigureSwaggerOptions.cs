using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SoftcrylicTech.Service.ModelSettings;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;

namespace SoftcrylicTech.Service.Configuration
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        // private readonly IApiVersionDescriptionProvider _provider;
        private readonly SwaggerSettings _swaggerSettings;
        public ConfigureSwaggerOptions(IConfiguration configuration)
        {
            // _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            _swaggerSettings = configuration.GetSection("SwaggerSettings").Get<SwaggerSettings>();
        }

        public void Configure(SwaggerGenOptions options)
        {

            options.SwaggerDoc("v1", CreateInfoForApiVersion());

            var scopes = new Dictionary<string, string>();
            if (_swaggerSettings.Scopes != null)
            {
                foreach (var scope in _swaggerSettings.Scopes)
                {
                    scopes[scope.Name] = scope.Description;
                }
            }

            //options.AddSecurityDefinition(_swaggerSettings.SecurityDefinationName, new OpenApiSecurityScheme
            //{
            //    Type = SecuritySchemeType.OAuth2,
            //    Flows = new OpenApiOAuthFlows
            //    {
            //        Implicit = new OpenApiOAuthFlow
            //        {
            //            TokenUrl = new Uri($"https//localhost:9876/"),
            //            AuthorizationUrl = new Uri($"https//localhost:9876/oauth2/v2.0/authorize"),
            //            Scopes = scopes
            //        }
            //    }
            //});

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id =_swaggerSettings.SecurityDefinationName
                            }
                        },
                         new List<string>()
                    }
                });
        }

        private OpenApiInfo CreateInfoForApiVersion()
        {
            var information = new OpenApiInfo
            {
                Title = _swaggerSettings.Title,
                Version = "v1",
                Description = _swaggerSettings.Description
            };
            return information;
        }
    }
}
