namespace WebApi.Middleware.Exceptions
{
    public static class ExceptionsMiddlewareUse
    {
        public static IApplicationBuilder UseExceptionHandlerMiddlerware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionsHandler>();
            return builder;
        }
    }
}
