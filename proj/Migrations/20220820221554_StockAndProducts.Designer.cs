﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using proj.Data;

#nullable disable

namespace proj.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220820221554_StockAndProducts")]
    partial class StockAndProducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("proj.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProductsNomId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Stock")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("StockId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductsNomId");

                    b.HasIndex("StockId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("proj.Models.ProductsNOM", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UnitOfMeasurement")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductsNOMs");
                });

            modelBuilder.Entity("proj.Models.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FiscalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("proj.Models.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("proj.Models.Product", b =>
                {
                    b.HasOne("proj.Models.ProductsNOM", "ProductsNom")
                        .WithMany()
                        .HasForeignKey("ProductsNomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("proj.Models.Stock", null)
                        .WithMany()
                        .HasForeignKey("StockId");

                    b.Navigation("ProductsNom");
                });
#pragma warning restore 612, 618
        }
    }
}
