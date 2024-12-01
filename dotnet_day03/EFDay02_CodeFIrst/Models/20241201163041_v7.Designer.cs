﻿// <auto-generated />
using System;
using EFDay02_CodeFIrst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFDay02_CodeFIrst.Models
{
    [DbContext(typeof(NewsContext))]
    [Migration("20241201163041_v7")]
    partial class v7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFDay02_CodeFIrst.Models.Author", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("bref")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("joinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            id = 1,
                            bref = "3",
                            joinDate = new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            name = "abood",
                            password = "hamada123",
                            username = "hamada"
                        });
                });

            modelBuilder.Entity("EFDay02_CodeFIrst.Models.Catalog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Catalogs");

                    b.HasData(
                        new
                        {
                            id = 1,
                            desc = "ok",
                            name = "kataloog"
                        });
                });

            modelBuilder.Entity("EFDay02_CodeFIrst.Models.News", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("CatalogId")
                        .HasColumnType("int");

                    b.Property<string>("bref")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CatalogId");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            id = 1,
                            AuthorId = 1,
                            CatalogId = 1,
                            bref = "m4 3aref",
                            datetime = new DateTime(2024, 12, 1, 18, 30, 41, 34, DateTimeKind.Local).AddTicks(9750),
                            desc = "eh dh",
                            title = "3enwan"
                        });
                });

            modelBuilder.Entity("EFDay02_CodeFIrst.Models.News", b =>
                {
                    b.HasOne("EFDay02_CodeFIrst.Models.Author", "author")
                        .WithMany("news")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDay02_CodeFIrst.Models.Catalog", "catalog")
                        .WithMany("news")
                        .HasForeignKey("CatalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("catalog");
                });

            modelBuilder.Entity("EFDay02_CodeFIrst.Models.Author", b =>
                {
                    b.Navigation("news");
                });

            modelBuilder.Entity("EFDay02_CodeFIrst.Models.Catalog", b =>
                {
                    b.Navigation("news");
                });
#pragma warning restore 612, 618
        }
    }
}
