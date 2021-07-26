using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OneNet.Base.Application;
using OneNet.Customer.Data;

namespace OneNet.Customer.Application.Create
{
    public class CreateCustomerHandler : IRequestHandler<Request<CreateCustomerDto, CreateCustomerResponse>,
        CreateCustomerResponse>
    {
        private readonly CreateCustomerService _createCustomerService;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _createCustomerService = new CreateCustomerService(customerRepository);
        }

        public Task<CreateCustomerResponse> Handle(Request<CreateCustomerDto, CreateCustomerResponse> request,
            CancellationToken cancellationToken)
        {
            return
                _createCustomerService.Create(request.RequestContent);
        }
    }
}