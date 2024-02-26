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
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(c => c.StaffId);
            builder.HasIndex(e => e.AccountId).IsUnique();
            //builder.HasAlternateKey(c => c.AccountId);

            builder.Property(e => e.StaffId)
                    .ValueGeneratedOnAdd();
            builder.Property(e => e.CreateDate)
                    .HasColumnType("datetime");
        }
    }
}
