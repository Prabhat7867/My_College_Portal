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

    public virtual DbSet<AdminCredential> AdminCredentials { get; set; }

    public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }

    public virtual DbSet<StudentCredential> StudentCredentials { get; set; }

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
        modelBuilder.Entity<AdminCredential>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin_Cr__719FE4E8B0483A3C");

            entity.ToTable("Admin_Credentials");

            entity.Property(e => e.AdminId)
                .ValueGeneratedNever()
                .HasColumnName("AdminID");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StudentAttendance>(entity =>
        {
            entity.HasKey(e => e.RollNo).HasName("PK__StudentA__7886D5A05AF72B7F");

            entity.ToTable("StudentAttendance");

            entity.Property(e => e.RollNo).ValueGeneratedNever();
            entity.Property(e => e.Date)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsPresent)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StudentCredential>(entity =>
        {
            entity.HasKey(e => e.RollNo).HasName("PK__Student___7886D5A0CE9245B7");

            entity.ToTable("Student_Credentials");

            entity.Property(e => e.RollNo).ValueGeneratedNever();
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StudentDetail>(entity =>
        {
            entity.HasKey(e => e.RollNo).HasName("PK__Student___28B6682D21FF6E2F");

            entity.ToTable("Student_Details");

            entity.Property(e => e.RollNo)
                .ValueGeneratedNever()
                .HasColumnName("Roll_No");
            entity.Property(e => e.Dob)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DOB");
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
            entity.HasKey(e => e.RollNo).HasName("PK__Y2020__28B6682DAE7D1F2D");

            entity.ToTable("Y2020");

            entity.Property(e => e.RollNo)
                .ValueGeneratedNever()
                .HasColumnName("Roll_No");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PassedYear).HasColumnName("Passed_Year");
        });

        modelBuilder.Entity<Y2021>(entity =>
        {
            entity.HasKey(e => e.RollNo).HasName("PK__Y2021__28B6682D487420E4");

            entity.ToTable("Y2021");

            entity.Property(e => e.RollNo)
                .ValueGeneratedNever()
                .HasColumnName("Roll_No");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PassedYear).HasColumnName("Passed_Year");
        });

        modelBuilder.Entity<Y2022>(entity =>
        {
            entity.HasKey(e => e.RollNo).HasName("PK__Y2022__28B6682D10928874");

            entity.ToTable("Y2022");

            entity.Property(e => e.RollNo)
                .ValueGeneratedNever()
                .HasColumnName("Roll_No");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PassedYear).HasColumnName("Passed_Year");
        });

        modelBuilder.Entity<Y2023>(entity =>
        {
            entity.HasKey(e => e.RollNo).HasName("PK__Y2023__28B6682DF593617B");

            entity.ToTable("Y2023");

            entity.Property(e => e.RollNo)
                .ValueGeneratedNever()
                .HasColumnName("Roll_No");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PassedYear).HasColumnName("Passed_Year");
        });

        modelBuilder.Entity<Y2024>(entity =>
        {
            entity.HasKey(e => e.RollNo).HasName("PK__Y2024__28B6682D629C27FC");

            entity.ToTable("Y2024");

            entity.Property(e => e.RollNo)
                .ValueGeneratedNever()
                .HasColumnName("Roll_No");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PassedYear).HasColumnName("Passed_Year");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
