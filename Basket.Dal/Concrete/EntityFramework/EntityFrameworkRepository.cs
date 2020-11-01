using Basket.Dal.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Dal.Concrete.EntityFramework
{
    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        public int Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
