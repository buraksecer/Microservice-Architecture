namespace Basket.Dal.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        int Insert(TEntity entity);
    }
}
