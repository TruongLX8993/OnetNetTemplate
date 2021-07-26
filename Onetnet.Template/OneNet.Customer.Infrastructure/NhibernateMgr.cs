using System;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace OneNet.Customer.Infrastructure
{
    public class NhibernateMgr : IDisposable
    {
        private readonly ISessionFactory _factory;

        public NhibernateMgr(Assembly assembly, IPersistenceConfigurer persistenceConfigurer)
        {
            _factory = CreateSessionFactory(assembly, persistenceConfigurer);
        }

        public ISession Open()
        {
            return _factory.OpenSession();
        }

        public IStatelessSession OpenStateLessSession()
        {
            return _factory.OpenStatelessSession();
        }


        private ISessionFactory CreateSessionFactory(
            Assembly assembly,
            IPersistenceConfigurer persistenceConfigurer)
        {
            return Fluently.Configure()
                .Database(
                    persistenceConfigurer
                )
                .Mappings(m => m.FluentMappings
                    .AddFromAssembly(assembly))
                .BuildSessionFactory();
        }

        public void Close()
        {
            _factory.CloseAsync();
        }

        public void Dispose()
        {
            _factory?.Close();
        }
    }
}