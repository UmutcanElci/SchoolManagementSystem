using System;
using System.Collections.Generic;
using Backend.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Canteen> Canteens { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassesAndTeacher> ClassesAndTeachers { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<ParentsAndStudent> ParentsAndStudents { get; set; }

    public virtual DbSet<Password> Passwords { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentInformation> StudentInformations { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=UMUTCAN\\SQLEXPRESS;Database=SSMS;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Canteen>(entity =>
        {
            entity.HasOne(d => d.Student).WithMany().HasConstraintName("FK_Canteen_Students");

            entity.HasOne(d => d.Wallet).WithMany().HasConstraintName("FK_Canteen_Wallet");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.Property(e => e.ClassLetter).IsFixedLength();
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasOne(d => d.City).WithMany(p => p.Districts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_District_City");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasOne(d => d.Password).WithMany(p => p.Parents).HasConstraintName("FK_Parents_Password");
        });

        modelBuilder.Entity<ParentsAndStudent>(entity =>
        {
            entity.HasOne(d => d.Parent).WithMany(p => p.ParentsAndStudents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ParentsAndStudents_Parents");

            entity.HasOne(d => d.Student).WithMany(p => p.ParentsAndStudents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ParentsAndStudents_Students");
        });

        modelBuilder.Entity<Password>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SystemPassword");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasOne(d => d.Class).WithMany(p => p.Students).HasConstraintName("FK_Students_Class");

            entity.HasOne(d => d.District).WithMany(p => p.Students).HasConstraintName("FK_Students_District");

            entity.HasOne(d => d.Parent).WithMany(p => p.Students).HasConstraintName("FK_Students_Parents");

            entity.HasOne(d => d.Password).WithMany(p => p.Students).HasConstraintName("FK_Students_Password");
        });

        modelBuilder.Entity<StudentInformation>(entity =>
        {
            entity.HasOne(d => d.Student).WithMany(p => p.StudentInformations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentInformation_Students");
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasOne(d => d.Parent).WithMany(p => p.Wallets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wallet_Parents");

            entity.HasOne(d => d.Student).WithMany(p => p.Wallets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wallet_Students");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
