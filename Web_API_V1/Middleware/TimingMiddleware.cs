using Microsoft.AspNetCore.Server.HttpSys;
using static System.Net.Mime.MediaTypeNames;

namespace Web_API_V1.Middleware
{
    public class TimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TimingMiddleware> _logger;

        public TimingMiddleware(ILogger<TimingMiddleware> logger, 
            RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            var start = DateTime.UtcNow;
            //Pass the context
            await _next.Invoke(ctx);
            _logger.LogInformation($"Timing {ctx.Request.Path}: {(DateTime.UtcNow - start).TotalMilliseconds} ms");

        }
    }

    public static class TimingMiddlewareExtensions
    {
        public static IApplicationBuilder UseTimingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimingMiddleware>();
        }

        /*
        public static void AddTiming(this IServiceCollection svcs)
        {

           svcs.AddTransient<ITiming, SomeTiming>();
        }
        */
    }
}
