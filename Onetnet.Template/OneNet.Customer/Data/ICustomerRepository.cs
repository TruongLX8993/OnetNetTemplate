using OneNet.Base.DataAccess;

namespace OneNet.Customer.Data
{
    public interface ICustomerRepository : IRepository<int, Domain.Customer>
    {
        
    }
}