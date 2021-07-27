using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BlogAPI.Middeleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ApiKeyName = "ApiKey";
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if(!context.Request.Headers.TryGetValue(ApiKeyName, out var extractedapiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not Provided. (Using ApiKey Middleware)");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(ApiKeyName);
            if(!extractedapiKey.Equals(apiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized Client. (Using ApiKey Middleware)");
                return;
            }

            await _next(context);
        }
    }
}