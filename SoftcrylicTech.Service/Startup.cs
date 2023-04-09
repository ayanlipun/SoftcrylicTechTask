using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoftcrylicTech.Library.Configurations;
using SoftcrylicTech.Service.Configuration;
using SoftcrylicTech.Service.Middleware;
using SoftcrylicTech.Service.ModelSettings;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SoftcrylicTech.Service
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
            services.Configure<SwaggerSettings>(Configuration.GetSection("SwaggerSettings"));
            services.AddMvcCore().AddApiExplorer();

            services.AddCors(cor => cor.AddPolicy("default",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                }));

            services.AddControllers();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSwagger();

            //services.AddSwaggerGen(swagger =>
            //{
            //    swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Sofcrylic Tech API", Version = "v1" });
            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var scApiXml = Directory.GetFiles(AppContext.BaseDirectory, xmlFile);
            //    swagger.IncludeXmlComments(scApiXml.First());
            //});

            services.ConfigureSoftcrylicDependencyInjection(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger, IOptions<SwaggerSettings> swaggerSettings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseRouting();
            app.UseWhen(user => (user.Request.Path.StartsWithSegments("/api", System.StringComparison.OrdinalIgnoreCase)), builder => { builder.UseMiddleware<RequestsLoggingMiddleware>(); });
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSwaggerMiddileware(logger, swaggerSettings);
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("swagger/v1/swagger.json", "Softcrylic Tech API");
            //});

            app.UseCors("default");
            logger.LogTrace("Completed startup configuration!");
        }
    }
}
