namespace LasmartTestContext.API.Middlewares.ExceptionMiddleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LasmartTestContext.API.Middlewares.ExceptionMiddleware.ExceptionMiddleware>();
        }
    }
}
