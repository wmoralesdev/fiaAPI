using Domain.Attendants;
using Domain.BaseIdentities;
using Domain.Speakers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class BaseIdentityConfiguration : IEntityTypeConfiguration<BaseIdentity>
    {
        public void Configure(EntityTypeBuilder<BaseIdentity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Email).IsRequired();
            builder.HasIndex(e => e.Email).IsUnique();

            builder.Property(e => e.FullName).IsRequired();

            builder.Property(e => e.Role)
                .HasConversion(new EnumToStringConverter<IdentityRole>());

            builder.HasDiscriminator(i => i.Role)
                    .HasValue<Attendant>(IdentityRole.Attendant)
                    .HasValue<Speaker>(IdentityRole.Speaker);
        }
    }
}
