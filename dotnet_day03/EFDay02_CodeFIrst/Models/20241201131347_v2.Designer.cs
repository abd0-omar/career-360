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
    [Migration("20241201131347_v2")]
    partial class v2
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

                    b.Property<int>("bref")
                        .HasColumnType("int")
                        .HasColumnName("brefNumber");

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

                    b.ToTable("Catalog");
                });

            modelBuilder.Entity("EFDay02_CodeFIrst.Models.News", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("authorid")
                        .HasColumnType("int");

                    b.Property<string>("bref")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("catalogsid")
                        .HasColumnType("int");

                    b.Property<DateTime>("datetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("authorid");

                    b.HasIndex("catalogsid");

                    b.ToTable("News");
                });

            modelBuilder.Entity("EFDay02_CodeFIrst.Models.News", b =>
                {
                    b.HasOne("EFDay02_CodeFIrst.Models.Author", "author")
                        .WithMany("news")
                        .HasForeignKey("authorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDay02_CodeFIrst.Models.Catalog", "catalogs")
                        .WithMany("news")
                        .HasForeignKey("catalogsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("catalogs");
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