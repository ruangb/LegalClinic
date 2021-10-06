using LC.Core.Domain;
using LC.Data;
using LC.Data.Repository;
using LC.FakeData.CustomerData;
using LC.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
