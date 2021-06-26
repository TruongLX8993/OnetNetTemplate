using OneNet.Customer.Repository;

namespace OneNet.Customer.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Domain.Customer>, ICustomerRepository
    {
    }
}