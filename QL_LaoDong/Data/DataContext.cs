using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QL_LaoDong.Models;

namespace QL_LaoDong.Data
{
    public partial class DataContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Calendar> Calendar { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Muster> Muster { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Tool> Tool { get; set; }
        public virtual DbSet<Toolticker> Toolticker { get; set; }
        public virtual DbSet<Workticker> Workticker { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Fullname).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Picture).HasColumnType("ntext");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Sex).HasMaxLength(5);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TAIKHOAN_QUYEN");
            });

            modelBuilder.Entity<Calendar>(entity =>
            {
                entity.ToTable("CALENDAR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Day).HasColumnType("date");

                entity.Property(e => e.SessionOfDay).HasMaxLength(10);

                entity.Property(e => e.Weekdays).HasMaxLength(20);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("CLASS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .HasColumnName("CLassName");

                entity.Property(e => e.FacultyId).HasColumnName("FacultyID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Training).HasMaxLength(20);

                entity.Property(e => e.TypeOfEducation).HasMaxLength(20);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLASS_FACULTY");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("FACULTY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FacultyName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("JOB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Job1)
                    .HasMaxLength(100)
                    .HasColumnName("Job");

                entity.Property(e => e.Locate).HasMaxLength(50);
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.HasKey(e => e.IdMn)
                    .HasName("PK_DANHMUC");

                entity.ToTable("MENUS");

                entity.Property(e => e.IdMn).HasColumnName("ID_MN");

                entity.Property(e => e.Label).HasMaxLength(100);

                entity.Property(e => e.UrlLink)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserAddNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.UserAdd)
                    .HasConstraintName("FK_DANHMUC_TAIKHOAN");
            });

            modelBuilder.Entity<Muster>(entity =>
            {
                entity.ToTable("MUSTER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.WorkTickerId).HasColumnName("WorkTickerID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Muster)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MUSTER_ACCOUNT");

                entity.HasOne(d => d.WorkTicker)
                    .WithMany(p => p.Muster)
                    .HasForeignKey(d => d.WorkTickerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MUSTER_WORKTICKER");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NameRole)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Mssv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MSSV");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SINHVIEN_TAIKHOAN");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SINHVIEN_LOP");
            });

            modelBuilder.Entity<Tool>(entity =>
            {
                entity.ToTable("TOOL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tool1)
                    .HasMaxLength(50)
                    .HasColumnName("Tool");

                entity.Property(e => e.Unit).HasMaxLength(50);
            });

            modelBuilder.Entity<Toolticker>(entity =>
            {
                entity.ToTable("TOOLTICKER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.ToolId).HasColumnName("ToolID");

                entity.Property(e => e.WorkTickerId).HasColumnName("WorkTickerID");

                entity.HasOne(d => d.Tool)
                    .WithMany(p => p.Toolticker)
                    .HasForeignKey(d => d.ToolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHIEUDUNGCU_DUNGCULAODONG");

                entity.HasOne(d => d.WorkTicker)
                    .WithMany(p => p.Toolticker)
                    .HasForeignKey(d => d.WorkTickerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHIEUDUNGCU_PHIEULAODONG");
            });

            modelBuilder.Entity<Workticker>(entity =>
            {
                entity.ToTable("WORKTICKER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalendarId).HasColumnName("CalendarID");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Calendar)
                    .WithMany(p => p.Workticker)
                    .HasForeignKey(d => d.CalendarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHIEULAODONG_LICHLAODONG");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Workticker)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHIEULAODONG_CONGVIEC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
