using System.Threading.Tasks;
using OneNet.Base.Domain;

namespace OneNet.Base.DataAccess
{
    public interface IRepository<TKey,TEntity> where TEntity : BaseEntity<TKey>
    {
        public Task<TKey> Add(TEntity entity);
        public Task Remove(TEntity entity);
    }
}