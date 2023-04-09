using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SoftcrylicTech.Service.Middleware
{
    public class RequestsLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestsLoggingMiddleware> _logger;

        public RequestsLoggingMiddleware(RequestDelegate next, ILogger<RequestsLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var builder = new StringBuilder(Environment.NewLine);

            foreach (var header in context.Request.Headers)
            {
                builder.AppendLine($"{header.Key}:{header.Value}");
            }
            _logger.LogDebug(builder.ToString());

            await _next(context);
        }
    }
}
