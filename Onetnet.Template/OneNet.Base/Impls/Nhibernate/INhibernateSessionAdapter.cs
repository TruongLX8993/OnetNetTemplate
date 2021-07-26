using System.Linq;
using NHibernate;

namespace OneNet.Base.Impls.Nhibernate
{

    /// <summary>
    /// Common features for 2 kind of session: stateless and stateful
    /// </summary>
    public interface INhibernateSessionAdapter
    {
        IQueryable<T> GetQuery<T>();
        TDomain GetById<TKey, TDomain>(TKey tKey);
        ISQLQuery CreateSql(string sql);
    }

    
    public class StateFullNhibernateSessionAdapter : INhibernateSessionAdapter
    {
        private readonly ISession _session;

        public StateFullNhibernateSessionAdapter(ISession session)
        {
            _session = session;
        }

        public IQueryable<T> GetQuery<T>()
        {
            return _session.Query<T>();
        }

        public TDomain GetById<TKey, TDomain>(TKey tKey)
        {
            return _session.Get<TDomain>(tKey);
        }
        

        public ISQLQuery CreateSql(string sql)
        {
            return _session.CreateSQLQuery(sql);
        }
    }


    public class StateLessNhibernateSessionAdapter : INhibernateSessionAdapter
    {
        private readonly IStatelessSession _session;

        public StateLessNhibernateSessionAdapter(IStatelessSession session)
        {
            _session = session;
        }

        public IQueryable<T> GetQuery<T>()
        {
            return _session.Query<T>();
        }

        public TDomain GetById<TKey, TDomain>(TKey tKey)
        {
            return _session.Get<TDomain>(tKey);
        }

        public ISQLQuery CreateSql(string sql)
        {
            return _session.CreateSQLQuery(sql);
        }
    }

    public static class NhibernateAdapterFactory
    {
        public static INhibernateSessionAdapter Create(ISession session)
        {
            return new StateFullNhibernateSessionAdapter(session);
        }

 
        public static INhibernateSessionAdapter Create(IStatelessSession session)
        {
            return new StateLessNhibernateSessionAdapter(session);
        }
    }
}