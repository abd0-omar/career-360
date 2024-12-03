using System;
using System.Collections.Generic;
using CoursesCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursesCRUD.Context;

public partial class CoursesContext : DbContext
{
    public CoursesContext()
    {
    }

    public CoursesContext(DbContextOptions<CoursesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=bodbod\\SQLEXPRESS;database=courses;user id=abdo;password=password;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__courses__3213E83F76FFF9AB");

            entity.ToTable("courses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CrsDesc)
                .HasMaxLength(150)
                .HasColumnName("crs_desc");
            entity.Property(e => e.CrsName)
                .HasMaxLength(50)
                .HasColumnName("crs_name");
            entity.Property(e => e.Duration).HasColumnName("duration");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
