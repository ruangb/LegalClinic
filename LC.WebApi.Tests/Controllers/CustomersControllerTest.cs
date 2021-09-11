using FluentAssertions;
using LC.Core.Shared.ModelViews.Customer;
using LC.FakeData.CustomerData;
using LC.Manager.Interfaces.Managers;
using LC.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LC.WebApi.Tests.Controllers
{
    public class CustomersControllerTest
    {
        private readonly ICustomerManager manager;
        private readonly ILogger<CustomersController> logger;
        private readonly CustomersController controller;
        private readonly CustomerView customerView;
        private readonly IList<CustomerView> listCustomerView;

        public CustomersControllerTest()
        {
            manager    = Substitute.For<ICustomerManager>();
            logger     = Substitute.For<ILogger<CustomersController>>();
            controller = new CustomersController(manager, logger);

            customerView = new CustomerViewFaker().Generate();
            listCustomerView = new CustomerViewFaker().Generate(10);
        }

        [Fact]
        public async Task Get_Ok()
        {
            manager.GetCustomersAsync().Returns(new List<CustomerView> { new CustomerView { Name = "Bla" } });
            var result = (ObjectResult) await controller.Get();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(listCustomerView);
        }
    }
}
