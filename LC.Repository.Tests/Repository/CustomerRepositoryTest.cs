using FluentAssertions;
using LC.Core.Domain;
using LC.Data;
using LC.Data.Repository;
using LC.FakeData.CustomerData;
using LC.FakeData.PhoneData;
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

        [Fact]
        public async Task GetCustomerAsync_Found()
        {
            var records = await InsertRecords();
            var retorno = await repository.GetCustomerAsync(records.First().Id);
            retorno.Should().BeEquivalentTo(records.First());
        }

        [Fact]
        public async Task GetCustomerAsync_NotFound()
        {
            var retorno = await repository.GetCustomerAsync(1);
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task InsertCustomerAsync_Success()
        {
            var retorno = await repository.InsertCustomerAsync(customer);
            retorno.Should().BeEquivalentTo(customer);
        }

        [Fact]
        public async Task UpdateCustomerAsync_Success()
        {
            var records = await InsertRecords();
            var updatedCustomer = customerFaker.Generate();
            updatedCustomer.Id = records.First().Id;
            var retorno = await repository.UpdateCustomerAsync(updatedCustomer);
            retorno.Should().BeEquivalentTo(updatedCustomer);
        }

        [Fact]
        public async Task UpdateCustomerAsync_AddPhone()
        {
            var records = await InsertRecords();
            var updatedCustomer = records.First();
            updatedCustomer.Phones.Add(new PhoneFaker(updatedCustomer.Id).Generate());
            var retorno = await repository.UpdateCustomerAsync(updatedCustomer);
            retorno.Should().BeEquivalentTo(updatedCustomer);
        }

        [Fact]
        public async Task UpdateCustomerAsync_RemovePhone()
        {
            var records = await InsertRecords();
            var updatedCustomer = records.First();
            updatedCustomer.Phones.Remove(updatedCustomer.Phones.First());
            var retorno = await repository.UpdateCustomerAsync(updatedCustomer);
            retorno.Should().BeEquivalentTo(updatedCustomer);
        }

        [Fact]
        public async Task UpdateCustomerAsync_RemoveAllPhones()
        {
            var records = await InsertRecords();
            var updatedCustomer = records.First();
            updatedCustomer.Phones.Clear();
            var retorno = await repository.UpdateCustomerAsync(updatedCustomer);
            retorno.Should().BeEquivalentTo(updatedCustomer);
        }

        [Fact]
        public async Task UpdateCustomerAsync_NotFound()
        {
            var retorno = await repository.UpdateCustomerAsync(customer);
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task DeleteCustomerAsync_Success()
        {
            var records = await InsertRecords();
            var retorno = await repository.DeleteCustomerAsync(records.First().Id);
            retorno.Should().BeEquivalentTo(records.First());
        }

        [Fact]
        public async Task DeleteCustomerAsync_NotFound()
        {
            var retorno = await repository.DeleteCustomerAsync(1);
            retorno.Should().BeNull();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
