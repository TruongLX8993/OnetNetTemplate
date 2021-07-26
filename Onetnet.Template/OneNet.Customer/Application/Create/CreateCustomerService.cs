using System.Threading.Tasks;
using OneNet.Customer.Data;

namespace OneNet.Customer.Application.Create
{
    public class CreateCustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CreateCustomerResponse> Create(CreateCustomerDto command)
        {
            var cus = new Domain.Customer()
            {
                Phone = command.Phone,
                Name = command.Phone,
            };
            var res = await _customerRepository.Add(cus);
            return new CreateCustomerResponse() {Status = true};
        }
    }
}