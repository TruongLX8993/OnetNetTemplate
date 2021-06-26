using System;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OneNet.Core.Application;
using OneNet.Customer.Application.Create;
using OneNet.Customer.Infrastructure.Repository;
using OneNet.Customer.Repository;

namespace OneNet.Customer.Test
{
    public class Tests
    {
        private ServiceProvider _serviceProvider;

        [OneTimeSetUp]
        public void Setup()
        {
            _serviceProvider = new ServiceCollection()
                .AddTransient<ICustomerRepository, CustomerRepository>()
                .AddMediatR(Assembly.Load("OneNet.Customer"))
                .BuildServiceProvider();
        }

        [Test]
        public async Task CreateCustomerCommandTest()
        {
            var cusService = new CreateCustomerService(_serviceProvider.GetService<ICustomerRepository>());
            var res = await cusService.Create(new CreateCustomerDto()
            {
                Name = "truonglx"
            });

            Assert.IsTrue(res.Status);
        }

        [Test]
        public async Task CreateCustomerCommandTest2()
        {
            var req = new Request<CreateCustomerDto, CreateCustomerResponse>
            {
                RequestContent = new CreateCustomerDto() {Name = "truonglx"}
            };
            var mediator = _serviceProvider.GetService<IMediator>();
            if (mediator != null)
            {
                var res = await mediator.Send(req);
                Assert.IsTrue(res.Status);
            }
        }
    }
}