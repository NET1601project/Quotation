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
    public class QuoteConfiguration : IEntityTypeConfiguration<QuoteDetail>
    {
        public void Configure(EntityTypeBuilder<QuoteDetail> builder)
        {
            builder.HasKey(c => c.QuoteID);
            builder.Property(e => e.QuoteID)
                    .ValueGeneratedOnAdd();
            builder.Property(e => e.QuoteDate)
                .HasColumnType("datetime");
            builder.HasOne(d => d.Project)
                    .WithMany(d => d.QuoteDetail)
                    .HasForeignKey(d => d.ProjectID)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Material)
                .WithMany(d => d.QuoteDetails)
                .HasForeignKey(d => d.MaterialID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.Staff)
                .WithMany(d => d.QuoteDetails)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
