using Gcsb.Connect.Training.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Infrastructure.Database.Map
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.BirthDate).HasMaxLength(10).IsRequired();
            builder.Property(c => c.Rg).HasMaxLength(12).IsRequired();
            builder.Property(c => c.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(c => c.Address).HasMaxLength(200).IsRequired();
            builder.Property(c => c.City).HasMaxLength(30).IsRequired();
            builder.Property(c => c.State).HasMaxLength(2).IsRequired();
            builder.Property(c => c.PostalCode).IsRequired();
        }
    }
}
