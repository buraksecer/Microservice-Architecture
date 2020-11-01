using Basket.Business.Abstract;
using Basket.Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Business.Extensions
{
    public static class RegisterExtensions
    {
        public static void RegisterBasketServices(this IServiceCollection services)
        {
            services.AddScoped<IBasketItemService, BasketItemService>();
        }
    }
}
