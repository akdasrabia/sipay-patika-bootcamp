namespace odev2.API.Middlewares
{
    public class CustomMiddleware 
    {
        private readonly RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string message = "[Request] HTTP" + context.Request.Method + " - " + context.Request.Path;
            Console.WriteLine(message);
            await _next(context);
        }
    }
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder) 
        { 
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
