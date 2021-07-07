﻿using LC.Core;
using LC.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LC.Data
{
    public class LCContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}

        public LCContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }
    }
}
