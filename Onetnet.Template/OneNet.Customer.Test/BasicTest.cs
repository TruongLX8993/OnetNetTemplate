using System;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OneNet.Customer.Application.Queries;
using OneNet.Customer.Infrastructure;

namespace OneNet.Customer.Test
{
    public class Tests
    {
        private ServiceProvider _serviceProvider;

        [OneTimeSetUp]
        public void Setup()
        {
            _serviceProvider = new ServiceCollection()
                .RegisFra()
                .AddMediatR(Assembly.Load("OneNet.Customer"))
                .BuildServiceProvider();
        }

        [Test]
        public async Task Test()
        {
            var request = new CustomerQuery()
            {
                Name = "truonglx",
            };
            var mediator = _serviceProvider.GetService<IMediator>();
            var res = await mediator.Send(request);
        }
    }
}