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
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(c => c.MaterialID);
            builder.Property(e => e.MaterialID)
                    .ValueGeneratedOnAdd();
            builder.Property(e => e.CreateDate)
                    .HasColumnType("DateTime");

            
        }
    }
}
