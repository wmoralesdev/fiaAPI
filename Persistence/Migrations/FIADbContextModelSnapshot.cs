﻿// <auto-generated />
using System;
using Domain.BaseIdentities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(FIADbContext))]
    partial class FIADbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.BaseIdentities.BaseIdentity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("BaseIdentities");

                    b.HasDiscriminator<string>("Role");
                });

            modelBuilder.Entity("Domain.Inscriptions.Inscription", b =>
                {
                    b.Property<int>("PresentationId")
                        .HasColumnType("int");

                    b.Property<int>("AttendantId")
                        .HasColumnType("int");

                    b.HasKey("PresentationId", "AttendantId");

                    b.HasIndex("AttendantId");

                    b.ToTable("Inscription");
                });

            modelBuilder.Entity("Domain.Presentations.Presentation", b =>
                {
                    b.Property<int>("PresentationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Schedule")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SpeakerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PresentationId");

                    b.HasIndex("SpeakerId")
                        .IsUnique()
                        .HasFilter("[SpeakerId] IS NOT NULL");

                    b.ToTable("Presentations");
                });

            modelBuilder.Entity("Domain.Attendants.Attendant", b =>
                {
                    b.HasBaseType("Domain.BaseIdentities.BaseIdentity");

                    b.HasDiscriminator().HasValue("Attendant");
                });

            modelBuilder.Entity("Domain.Speakers.Speaker", b =>
                {
                    b.HasBaseType("Domain.BaseIdentities.BaseIdentity");

                    b.HasDiscriminator().HasValue("Speaker");
                });

            modelBuilder.Entity("Domain.Inscriptions.Inscription", b =>
                {
                    b.HasOne("Domain.Attendants.Attendant", "Attendant")
                        .WithMany("Inscriptions")
                        .HasForeignKey("AttendantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Presentations.Presentation", "Presentation")
                        .WithMany("Inscriptions")
                        .HasForeignKey("PresentationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Presentations.Presentation", b =>
                {
                    b.HasOne("Domain.Speakers.Speaker", "Speaker")
                        .WithOne("Presentation")
                        .HasForeignKey("Domain.Presentations.Presentation", "SpeakerId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}