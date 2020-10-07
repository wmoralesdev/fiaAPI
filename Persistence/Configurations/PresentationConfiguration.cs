using Domain.Presentations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class PresentationConfiguration : IEntityTypeConfiguration<Presentation>
    {
        public void Configure(EntityTypeBuilder<Presentation> builder)
        {
            builder.HasKey(e => e.PresentationId);
            builder.Property(e => e.PresentationId)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Schedule)
                .IsRequired();

            builder.HasOne(e => e.Speaker)
                .WithOne(e => e.Presentation)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
