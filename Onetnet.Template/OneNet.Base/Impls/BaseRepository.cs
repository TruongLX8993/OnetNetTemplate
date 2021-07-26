using System.Threading.Tasks;
using NHibernate;
using OneNet.Base.DataAccess;
using OneNet.Base.Domain;
using OneNet.Base.Impls.Nhibernate;

namespace OneNet.Base.Impls
{
    public abstract class BaseRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : BaseEntity<TKey>
    {
        protected readonly ISession _session;

        protected BaseRepository(ISession session)
        {
            _session = session;
        }


        public Task<TKey> Add(TEntity entity)
        {
            return (Task<TKey>) _session.SaveOrUpdateAsync(entity);
        }

        public Task Remove(TEntity entity)
        {
            return _session.DeleteAsync(entity);
        }
    }
}