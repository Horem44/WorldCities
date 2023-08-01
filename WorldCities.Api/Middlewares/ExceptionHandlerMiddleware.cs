using Newtonsoft.Json;
using System.Net;
using WorldCities.Domain.Exceptions;

namespace WorldCities.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string errorMessage = "An error occurred while processing your request.";

            if (exception is BaseError baseError)
            {
                statusCode = baseError.Status;
                errorMessage = baseError.Message;
            }

            var error = new BaseError(statusCode, errorMessage);

            var result = JsonConvert.SerializeObject(error, Formatting.None);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(result);
        }
    }
}
