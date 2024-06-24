using System.Net;
using System.Text.Json;
using WebApi.HandelResponses;

namespace WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _Next;
        private readonly ILogger<ExceptionMiddleware> _Logger;
        private readonly IHostEnvironment _Environment;

        public ExceptionMiddleware(RequestDelegate next, 
                                   ILogger<ExceptionMiddleware> logger,
                                   IHostEnvironment environment)
        {
            _Next = next;
            _Logger = logger;
            _Environment = environment;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _Next(context);

            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _Environment.IsDevelopment()
                            ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                            : new ApiException((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions { PropertyNamingPolicy =  JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);

                
            }

        }

    }
}
