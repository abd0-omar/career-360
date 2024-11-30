using System;
using System.Collections.Generic;
using EF_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_CRUD.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Dependent> Dependents { get; set; }

    public virtual DbSet<DeptLocation> DeptLocations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }

    public virtual DbSet<Hamadum> Hamada { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BODBOD\\SQLEXPRESS;Database=my_employees;User Id=abdo;Password=password;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__Departme__014881AE944EB78B");

            entity.ToTable("Department");

            entity.Property(e => e.DeptId).ValueGeneratedNever();
            entity.Property(e => e.DeptName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MgrSsn).HasColumnName("MgrSSN");

            entity.HasOne(d => d.MgrSsnNavigation).WithMany(p => p.Departments)
                .HasForeignKey(d => d.MgrSsn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Departmen__MgrSS__3A81B327");
        });

        modelBuilder.Entity<Dependent>(entity =>
        {
            entity.HasKey(e => new { e.Essn, e.Name }).HasName("PK__Dependen__6D268D0FCA7A6C57");

            entity.ToTable("Dependent");

            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Bdate).HasColumnName("BDate");
            entity.Property(e => e.Relationship)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("sex");

            entity.HasOne(d => d.EssnNavigation).WithMany(p => p.Dependents)
                .HasForeignKey(d => d.Essn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Dependent__Essn__47DBAE45");
        });

        modelBuilder.Entity<DeptLocation>(entity =>
        {
            entity.HasKey(e => new { e.DeptId, e.Location }).HasName("PK__Dept_Loc__B078F507E7BDE48E");

            entity.ToTable("Dept_Locations");

            entity.Property(e => e.DeptId).HasColumnName("deptId");
            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.DeptLocations)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("LocDeptIDFK");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Ssn).HasName("PK__Employee__CA1E8E3DBC1178A5");

            entity.ToTable("Employee");

            entity.Property(e => e.Ssn)
                .ValueGeneratedNever()
                .HasColumnName("SSN");
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FName");
            entity.Property(e => e.Lname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LName");
            entity.Property(e => e.Salary)
                .HasColumnType("money")
                .HasColumnName("salary");
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("sex");
            entity.Property(e => e.SuperSsn).HasColumnName("superSSN");

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__Employee__DeptId__3B75D760");

            entity.HasOne(d => d.SuperSsnNavigation).WithMany(p => p.InverseSuperSsnNavigation)
                .HasForeignKey(d => d.SuperSsn)
                .HasConstraintName("SuperviorFK");
        });

        modelBuilder.Entity<EmployeeProject>(entity =>
        {
            entity.HasKey(e => new { e.Essn, e.ProjNo }).HasName("PK__Employee__F26C8BBB0E07DE86");

            entity.ToTable("Employee_Projects");

            entity.Property(e => e.Essn).HasColumnName("ESSN");
            entity.Property(e => e.Hours).HasColumnName("hours");

            entity.HasOne(d => d.EssnNavigation).WithMany(p => p.EmployeeProjects)
                .HasForeignKey(d => d.Essn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ESSNFK");

            entity.HasOne(d => d.ProjNoNavigation).WithMany(p => p.EmployeeProjects)
                .HasForeignKey(d => d.ProjNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProjNoFK");
        });

        modelBuilder.Entity<Hamadum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("hamada");

            entity.Property(e => e.Bod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("bod");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Salary)
                .HasColumnType("money")
                .HasColumnName("salary");
            entity.Property(e => e.Sex)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sex");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjId).HasName("PK__Project__3E1AD14262C0894C");

            entity.ToTable("Project");

            entity.Property(e => e.ProjId)
                .ValueGeneratedNever()
                .HasColumnName("projId");
            entity.Property(e => e.Plocation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PLocation");
            entity.Property(e => e.ProjName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.Projects)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DeptIDFK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
