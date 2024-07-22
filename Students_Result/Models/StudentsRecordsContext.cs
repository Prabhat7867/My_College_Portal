using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Students_Result.Models;

public partial class StudentsRecordsContext : DbContext
{
    public StudentsRecordsContext()
    {
    }

    public StudentsRecordsContext(DbContextOptions<StudentsRecordsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentDetail> StudentDetails { get; set; }

    public virtual DbSet<Y2020> Y2020s { get; set; }

    public virtual DbSet<Y2021> Y2021s { get; set; }

    public virtual DbSet<Y2022> Y2022s { get; set; }

    public virtual DbSet<Y2023> Y2023s { get; set; }

    public virtual DbSet<Y2024> Y2024s { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=PRABHAT-RAJPUT\\SQLEXPRESS; database=Students_Records; trusted_connection=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentDetail>(entity =>
        {
            entity.HasKey(e => e.RollNo).HasName("PK__Student___28B6682D67374E73");

            entity.ToTable("Student_Details");

            entity.Property(e => e.RollNo).HasColumnName("Roll_No");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.FathersName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Fathers_Name");
            entity.Property(e => e.MothersName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Mothers_Name");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PassedYear).HasColumnName("Passed_Year");
        });

        modelBuilder.Entity<Y2020>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Y2020");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PassedYear).HasColumnName("Passed_Year");
            entity.Property(e => e.RollNo).HasColumnName("Roll_No");
        });

        modelBuilder.Entity<Y2021>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Y2021");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PassedYear).HasColumnName("Passed_Year");
            entity.Property(e => e.RollNo).HasColumnName("Roll_No");
        });

        modelBuilder.Entity<Y2022>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Y2022");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PassedYear).HasColumnName("Passed_Year");
            entity.Property(e => e.RollNo).HasColumnName("Roll_No");
        });

        modelBuilder.Entity<Y2023>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Y2023");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PassedYear).HasColumnName("Passed_Year");
            entity.Property(e => e.RollNo).HasColumnName("Roll_No");
        });

        modelBuilder.Entity<Y2024>(entity =>
        {
            entity
                .HasKey(e => e.RollNo).HasName("PK__Student___28B6682D67374E73");
            entity.ToTable("Y2024");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PassedYear).HasColumnName("Passed_Year");
            entity.Property(e => e.RollNo).HasColumnName("Roll_No");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
