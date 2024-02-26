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
    public class ProjecttConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(c => c.ProjectID);
            builder.HasIndex(c => c.CustomerId);
            builder.HasIndex(c => c.StaffId);
            builder.Property(e => e.ProjectID)
                    .ValueGeneratedOnAdd();
            builder.Property(e => e.StartDate)
                .HasColumnType("datetime");
            builder.Property(e => e.EndDate)
                .HasColumnType("datetime");
            builder.HasOne(d => d.Customer)
                    .WithMany(d => d.Projects)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Staff)
                .WithMany(d => d.Projects)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
