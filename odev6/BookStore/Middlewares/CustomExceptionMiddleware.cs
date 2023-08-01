using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using BookStore.Services;

namespace BookStore.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            Console.WriteLine("CustomExceptionMiddleware");
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                _loggerService.Write(message);

                await _next(context);
                watch.Stop();

                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " Responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms";
                _loggerService.Write(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("HandleException");

                _loggerService.Write(ex.ToString());
                watch.Stop();
                //await HandleException(context, ex, watch);

            }

        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            Console.WriteLine("HandleException");
            string message = "[Error] HTTP " + context.Request.Method +" - " +  context.Response.StatusCode + " Error Message " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds +" ms" ;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            _loggerService.Write(message);
            var result = JsonConvert.SerializeObject(new { error = ex.Message },Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder) 
        {
            Console.WriteLine("UseCustomExceptionMiddle");
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
