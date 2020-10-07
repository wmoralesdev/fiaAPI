using Domain.Inscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class InscriptionConfiguration : IEntityTypeConfiguration<Inscription>
    {
        public void Configure(EntityTypeBuilder<Inscription> builder)
        {
            builder.HasKey(i => new { i.PresentationId, i.AttendantId });

            builder.HasOne(e => e.Attendant)
                .WithMany(att => att.Inscriptions);

            builder.HasOne(e => e.Presentation)
                .WithMany(p => p.Inscriptions);
        }
    }
}
