using FluentAssertions;
using LC.Core.Domain;
using LC.Data;
using LC.Data.Repository;
using LC.FakeData.CustomerData;
using LC.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LC.Repository.Tests.Repository
{
    public class CustomerRepositoryTest : IDisposable
    {
        private readonly ICustomerRepository repository;
        private readonly LCContext context;
        private readonly Customer customer;
        private CustomerFaker customerFaker;

        public CustomerRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LCContext>();

            optionsBuilder.UseInMemoryDatabase("DB_Test");

            context = new LCContext(optionsBuilder.Options);
            repository = new CustomerRepository(context);
            customer = new Customer();
            customerFaker = new CustomerFaker();
        }

        public async Task<List<Customer>> InsertRecords()
        {
            var customers = customerFaker.Generate(100);

            foreach (var item in customers)
            {
                item.Id = 0;
                await context.AddAsync(item);
            }

            await context.SaveChangesAsync();

            return customers;
        }

        [Fact]
        public async Task GetCustomerAsync_WithReturn()
        {
            var registers = await InsertRecords();
            var _return = await repository.GetCustomersAsync();

            _return.Should().HaveCount(registers.Count);
            _return.First().Address.Should().NotBeNull();
            _return.First().Phones.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCustomerAsync_Empty()
        {
            var _return = await repository.GetCustomersAsync();

            _return.Should().HaveCount(0);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
