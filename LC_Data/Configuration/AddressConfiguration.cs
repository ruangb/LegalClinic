using LC.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LC.Data.Configuration
{
    class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.CustomerId);
            builder.Property(p => p.State).HasConversion(
                p => p.ToString(),
                p => (State)Enum.Parse(typeof(State), p));
        }
    }
}
