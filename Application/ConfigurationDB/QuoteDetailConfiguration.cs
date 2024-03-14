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
    public class QuoteDetailConfiguration : IEntityTypeConfiguration<QuoteDetails>
    {
        public void Configure(EntityTypeBuilder<QuoteDetails> builder)
        {
            builder.HasKey(c => new { c.QuoteId, c.MaterialId });
            builder.HasIndex(c => new { c.QuoteId, c.MaterialId }).IsUnique();
            builder.HasOne(d => d.Quote)
                .WithMany(d => d.QuoteDetails)
                .HasForeignKey(d => d.QuoteId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.Material)
               .WithMany(d => d.QuoteDetails)
               .HasForeignKey(d => d.MaterialId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
