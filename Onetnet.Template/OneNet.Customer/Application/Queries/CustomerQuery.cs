using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OneNet.Base.DataAccess;
using OneNet.Customer.Data;

namespace OneNet.Customer.Application.Queries
{
    public class CustomerQuery : IRequest<Pagination<CustomerVm>>
    {
        [JsonPropertyName("name")] public string Name { get; set; }
    }

    public class CustomerQueryHandler : IRequestHandler<CustomerQuery, Pagination<CustomerVm>>
    {
        public CustomerQueryHandler(ICustomerDataQuery customerDataQuery)
        {
            _customerDataQuery = customerDataQuery;
        }

        private readonly ICustomerDataQuery _customerDataQuery;

        public async Task<Pagination<CustomerVm>> Handle(CustomerQuery request, CancellationToken cancellationToken)
        {
            return await _customerDataQuery.Search<CustomerVm>(q =>
            {
                q = q.Where(item => item.Name == request.Name);
                return q;
            }, item => new CustomerVm()
            {
                Name = item.Name
            }, new PaginationInfo());
        }
    }
}