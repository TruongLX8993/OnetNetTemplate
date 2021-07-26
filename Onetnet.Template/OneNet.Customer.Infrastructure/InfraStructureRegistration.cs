using System.Reflection;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;
using OneNet.Base.Impls.Nhibernate;
using OneNet.Customer.Data;
using OneNet.Customer.Infrastructure.Data;

namespace OneNet.Customer.Infrastructure
{
    public static class InfraStructureRegistration
    {
        public static IServiceCollection RegisFra(this IServiceCollection serviceCollection)
        {
            var cfg = MsSqlConfiguration.MsSql2012
                .ConnectionString(c =>
                    c.Is(
                        "data source=103.74.123.8;initial catalog=rwtfgrxz_motor;user id=rwtfgrxz_sa;password=Motor@123;MultipleActiveResultSets=True;"));

            var nhibernateMgr = new NhibernateMgr(Assembly.GetExecutingAssembly(), cfg);
            serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddTransient<ICustomerDataQuery, CustomerDataQuery>();
            serviceCollection.AddSingleton<INhibernateSessionAdapter>(
                new StateLessNhibernateSessionAdapter(nhibernateMgr.OpenStateLessSession()));
            return serviceCollection;
        }
    }
}