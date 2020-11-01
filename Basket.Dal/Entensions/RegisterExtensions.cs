using Basket.Dal.Concrete.Dapper;
using Basket.Dal.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Dal.Entensions
{
    public static class RegisterExtensions
    {
        public static void RegisterBasketDal(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(DapperRepository<>));
        }
    }
}
