using System.Threading.Tasks;
using OneNet.Core.Domain;

namespace OneNet.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity> Add(TEntity entity);
        public Task Remove(TEntity entity);
    }
}