using SysacadWebAPI.Middlewares;

namespace SysacadWebAPI.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlerMiddleware(IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
