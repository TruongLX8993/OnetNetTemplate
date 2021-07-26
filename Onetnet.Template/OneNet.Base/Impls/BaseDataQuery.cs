using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NHibernate.Linq;
using OneNet.Base.DataAccess;
using OneNet.Base.Domain;
using OneNet.Base.Impls.Nhibernate;

namespace OneNet.Base.Impls
{
    public class BaseDataQuery<TKey, TEntity> : IDataQuery<TKey, TEntity> where TEntity : BaseEntity<TKey>
    {
        private readonly INhibernateSessionAdapter _sessionAdapter;

        public BaseDataQuery(INhibernateSessionAdapter sessionAdapter)
        {
            _sessionAdapter = sessionAdapter;
        }


        public async Task<Pagination<TOut>> Search<TOut>(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate,
            Expression<Func<TEntity, TOut>> selection,
            PaginationInfo paginationInfo)
        {
            var query = _sessionAdapter.GetQuery<TEntity>();
            query = predicate(query);
            var count = await query.CountAsync();
            query = query.Skip(paginationInfo.Index * paginationInfo.Size);
            var pageData = await query.Select(selection)
                .Take(paginationInfo.Size)
                .ToListAsync();
            return new Pagination<TOut>()
            {
                Data = pageData,
                PaginationInfo = paginationInfo,
            };
        }
    }
}