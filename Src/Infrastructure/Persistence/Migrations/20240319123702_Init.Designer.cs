﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.DataBaseContext;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240319123702_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("QTY")
                        .HasColumnType("int");

                    b.Property<int>("UOMId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UOMId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Domain.Entities.UOM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UOMs");
                });

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.HasOne("Domain.Entities.UOM", "UOM")
                        .WithMany("Items")
                        .HasForeignKey("UOMId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UOM");
                });

            modelBuilder.Entity("Domain.Entities.UOM", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
