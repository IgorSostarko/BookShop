﻿// <auto-generated />
using BookShop.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookShop.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230911084321_AddTableConnections")]
    partial class AddTableConnections
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookShop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Classics"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Crime"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 8,
                            Name = "Manual"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 4,
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = 6,
                            DisplayOrder = 5,
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("BookShop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublishingYear")
                        .HasColumnType("int");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "John Johne",
                            CategoryId = 1,
                            Name = "Scary book",
                            Price = 49.6m,
                            Publisher = "Bookfirm",
                            PublishingYear = 2001,
                            QuantityInStock = 2023
                        },
                        new
                        {
                            Id = 2,
                            Author = "Anna Banana",
                            CategoryId = 2,
                            Name = "Smart book",
                            Price = 490.6m,
                            Publisher = "Bookfirm",
                            PublishingYear = 2003,
                            QuantityInStock = 203
                        },
                        new
                        {
                            Id = 3,
                            Author = "Wayne Waffles",
                            CategoryId = 2,
                            Name = "Manual book",
                            Price = 56m,
                            Publisher = "Getrobook",
                            PublishingYear = 2012,
                            QuantityInStock = 5000
                        },
                        new
                        {
                            Id = 4,
                            Author = "Anna Banana",
                            CategoryId = 4,
                            Name = "Red book",
                            Price = 15.6m,
                            Publisher = "Bookfirm",
                            PublishingYear = 2020,
                            QuantityInStock = 13
                        },
                        new
                        {
                            Id = 5,
                            Author = "John Johne",
                            CategoryId = 2,
                            Name = "Yesbook",
                            Price = 15m,
                            Publisher = "Getrobook",
                            PublishingYear = 2019,
                            QuantityInStock = 17000
                        });
                });

            modelBuilder.Entity("BookShop.Models.Product", b =>
                {
                    b.HasOne("BookShop.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}