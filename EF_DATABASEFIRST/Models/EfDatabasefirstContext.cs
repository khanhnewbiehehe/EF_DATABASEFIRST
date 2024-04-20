using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_DATABASEFIRST.Models;

public partial class EfDatabasefirstContext : DbContext
{
    public EfDatabasefirstContext()
    {
    }

    public EfDatabasefirstContext(DbContextOptions<EfDatabasefirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-8E8BNI1;Initial Catalog=EF_DATABASEFIRST;User ID=sa;Password=123456789;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.MaKhoa).HasName("PK__KHOA__653904053C2B460E");

            entity.ToTable("KHOA");

            entity.Property(e => e.MaKhoa)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.TenKhoa).HasMaxLength(20);
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.MaLop).HasName("PK__LOP__3B98D27386840162");

            entity.ToTable("LOP");

            entity.Property(e => e.MaLop)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(4)
                .IsUnicode(false);

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.Lops)
                .HasForeignKey(d => d.MaKhoa)
                .HasConstraintName("FK_LOP_KHOA");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.MaSv).HasName("PK__SINHVIEN__2725081AAFF60519");

            entity.ToTable("SINHVIEN");

            entity.Property(e => e.MaSv)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MaSV");
            entity.Property(e => e.MaLop)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.TenSv)
                .HasMaxLength(30)
                .HasColumnName("TenSV");

            entity.HasOne(d => d.MaLopNavigation).WithMany(p => p.Sinhviens)
                .HasForeignKey(d => d.MaLop)
                .HasConstraintName("FK_SINHVIEN_LOP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
