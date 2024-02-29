using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ConfigurationDB
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerID);
            builder.HasIndex(e => e.AccountId).IsUnique();
            builder.HasIndex(e => e.Email).IsUnique();
            builder.HasIndex(e => e.Phone).IsUnique();

            //builder.HasAlternateKey(c => c.AccountId);
            builder.Property(e => e.CustomerID)
                    .ValueGeneratedOnAdd();
            builder.Property(e => e.CreateDate)
                    .HasColumnType("DateTime");
        }
    }
}
