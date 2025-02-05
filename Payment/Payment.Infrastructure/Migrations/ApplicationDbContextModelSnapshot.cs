﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Payment.Infrastructure.Context;

#nullable disable

namespace Payment.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Payment.Domain.Entities.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("AmountCharged")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("LastModifiedById")
                        .HasColumnType("uuid");

                    b.Property<string>("PaymentLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeCharge")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
