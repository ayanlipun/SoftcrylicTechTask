using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SoftcrylicTech.Service.ModelSettings;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoftcrylicTech.Service.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                ErrorResponse errorResponse = new ErrorResponse(ex);

                _logger.LogError(new Exception(errorResponse.Error), errorResponse.ErrorId);

                var json = JsonSerializer.Serialize(errorResponse);
                httpContext.Response.ContentType = "application /json";
                httpContext.Response.StatusCode = errorResponse.StatusCode;
                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}
