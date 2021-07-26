using OneNet.Base.Impls;
using OneNet.Base.Impls.Nhibernate;
using OneNet.Customer.Data;

namespace OneNet.Customer.Infrastructure.Data
{
    public class CustomerDataQuery : BaseDataQuery<int, Domain.Customer>,ICustomerDataQuery
    {
        public CustomerDataQuery(INhibernateSessionAdapter sessionAdapter) : base(sessionAdapter)
        {
        }
    }
}