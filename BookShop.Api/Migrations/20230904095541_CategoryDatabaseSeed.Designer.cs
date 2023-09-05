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
    [Migration("20230904095541_CategoryDatabaseSeed")]
    partial class CategoryDatabaseSeed
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
                            DisplayOrder = 1,
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
                            DisplayOrder = 1,
                            Name = "Horror"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}