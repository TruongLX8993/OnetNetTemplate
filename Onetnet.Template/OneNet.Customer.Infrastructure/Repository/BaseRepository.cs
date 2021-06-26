using System.Collections.Generic;
using System.Threading.Tasks;
using OneNet.Core.Domain;
using OneNet.Core.Repository;

namespace OneNet.Customer.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private IList<TEntity> _storage = new List<TEntity>();

        public async Task<TEntity> Add(TEntity entity)
        {
            _storage.Add(entity);
            return entity;
        }

        public async Task Remove(TEntity entity)
        {
            _storage.Remove(entity);
        }
    }
}