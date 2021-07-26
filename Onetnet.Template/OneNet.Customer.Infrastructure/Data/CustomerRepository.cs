using System.Threading.Tasks;
using NHibernate;
using OneNet.Base.Impls;
using OneNet.Customer.Data;

namespace OneNet.Customer.Infrastructure.Data
{
    public class CustomerRepository : BaseRepository<int, Domain.Customer>, ICustomerRepository
    {
        public CustomerRepository(ISession session) : base(session)
        {
        }
    }
}