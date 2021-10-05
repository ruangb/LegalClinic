using FluentAssertions;
using LC.Core.Shared.ModelViews.Customer;
using LC.FakeData.CustomerData;
using LC.Manager.Interfaces.Managers;
using LC.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
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
        private readonly List<CustomerView> listCustomerView;
        private readonly NewCustomer newCustomer;

        public CustomersControllerTest()
        {
            manager    = Substitute.For<ICustomerManager>();
            logger     = Substitute.For<ILogger<CustomersController>>();
            controller = new CustomersController(manager, logger);

            customerView     = new CustomerViewFaker().Generate();
            listCustomerView = new CustomerViewFaker().Generate(10);
            newCustomer      = new NewCustomerFaker().Generate();
        }

        [Fact]
        public async Task Get_Ok()
        {
            var control = new List<CustomerView>();
            listCustomerView.ForEach(p => control.Add(p.TypedClone()));
            manager.GetCustomersAsync().Returns(listCustomerView);

            var result = (ObjectResult) await controller.Get();

            await manager.Received().GetCustomersAsync();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(control);
        }

        [Fact]
        public async Task Get_NotFound()
        {
            manager.GetCustomersAsync().Returns(new List<CustomerView>());

            var result = (StatusCodeResult)await controller.Get();

            await manager.Received().GetCustomersAsync();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task GetById_Ok()
        {
            manager.GetCustomerAsync(Arg.Any<int>()).Returns(customerView.TypedClone());

            var result = (ObjectResult)await controller.Get(customerView.Id);

            await manager.Received().GetCustomerAsync(Arg.Any<int>());
            result.Value.Should().BeEquivalentTo(customerView);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetById_NotFound()
        {
            manager.GetCustomerAsync(Arg.Any<int>()).Returns(new CustomerView());

            var result = (StatusCodeResult)await controller.Get(1);

            await manager.Received().GetCustomerAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Post_Created()
        {
            manager.InsertCustomerAsync(Arg.Any<NewCustomer>()).Returns(customerView.TypedClone());

            var result = (ObjectResult)await controller.Post(newCustomer);

            await manager.Received().InsertCustomerAsync(Arg.Any<NewCustomer>());
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
            result.Value.Should().BeEquivalentTo(customerView);
        }

        [Fact]
        public async Task Put_Ok()
        {
            manager.UpdateCustomerAsync(Arg.Any<UpdateCustomer>()).Returns(customerView.TypedClone());

            var resultado = (ObjectResult)await controller.Put(new UpdateCustomer());

            await manager.Received().UpdateCustomerAsync(Arg.Any<UpdateCustomer>());
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
            resultado.Value.Should().BeEquivalentTo(customerView);
        }

        [Fact]
        public async Task Put_NotFound()
        {
            manager.UpdateCustomerAsync(Arg.Any<UpdateCustomer>()).ReturnsNull();

            var resultado = (StatusCodeResult)await controller.Put(new UpdateCustomer());

            await manager.Received().UpdateCustomerAsync(Arg.Any<UpdateCustomer>());
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Delete_NoContent()
        {
            manager.DeleteCustomerAsync(Arg.Any<int>()).Returns(customerView);

            var resultado = (StatusCodeResult)await controller.Delete(1);

            await manager.Received().DeleteCustomerAsync(Arg.Any<int>());
            resultado.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task NotFound_NotFound()
        {
            manager.DeleteCustomerAsync(Arg.Any<int>()).ReturnsNull();

            var resultado = (StatusCodeResult)await controller.Delete(1);

            await manager.Received().DeleteCustomerAsync(Arg.Any<int>());
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}
