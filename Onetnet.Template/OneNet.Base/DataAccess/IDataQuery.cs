using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OneNet.Base.Domain;

namespace OneNet.Base.DataAccess
{
    public class Pagination<TData>
    {
        public IList<TData> Data { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }

    public class PaginationInfo
    {
        public int Index { get; set; } = 0;
        public int Size { get; set; } = 10;
    }


    public interface IDataQuery<Tkey, TEntity> where TEntity : BaseEntity<Tkey>
    {
        Task<Pagination<TOut>> Search<TOut>(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate,
            Expression<Func<TEntity, TOut>> selection,
            PaginationInfo paginationInfo);
    }
}