using Basket.Core.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Basket.Core.Extensions
{
    public static class RegisterCoreExtensions
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
