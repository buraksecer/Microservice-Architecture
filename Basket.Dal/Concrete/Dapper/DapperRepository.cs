using Basket.Core.Exceptions;
using Basket.Dal.Infrastructure;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using DapperExtensions;
namespace Basket.Dal.Concrete.Dapper
{
    public class DapperRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private string connectionString;
        public DapperRepository(IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration.GetConnectionString("DefaultConnection")))
                throw new NotFoundException("Connection string is null or empty");

            connectionString = configuration.GetConnectionString("DefaultConnection");
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.MySqlDialect();
        }

        public int Insert(TEntity entity)
        {
            using (var sqlConnection = new MySqlConnection(connectionString))
            {
                return sqlConnection.Insert(entity);
            }
        }
    }
}
