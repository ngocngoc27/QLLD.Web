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
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<MenusRole> MenusRole { get; set; }
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

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Picture).HasColumnType("ntext");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Sex).HasMaxLength(5);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.RoleId)
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
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .HasColumnName("CLassName");

                entity.Property(e => e.FacultyId).HasColumnName("FacultyID");

                entity.Property(e => e.Training).HasMaxLength(20);

                entity.Property(e => e.TypeOfEducation).HasMaxLength(20);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("FK_CLASS_FACULTY");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("FACULTY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FacultyName).HasMaxLength(100);
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.ToTable("GROUPS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GroupsName).HasMaxLength(50);

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.Leader).HasMaxLength(50);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_GROUPS_JOB");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("JOB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.JobName).HasMaxLength(100);

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
            });

            modelBuilder.Entity<MenusRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MENUS_ROLE");

                entity.Property(e => e.IdMn).HasColumnName("ID_MN");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.IdMnNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdMn)
                    .HasConstraintName("FK_MENUS_ROLE_MENUS");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_MENUS_ROLE_ROLE");
            });

            modelBuilder.Entity<Muster>(entity =>
            {
                entity.ToTable("MUSTER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GroupsId).HasColumnName("GroupsID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Groups)
                    .WithMany(p => p.Muster)
                    .HasForeignKey(d => d.GroupsId)
                    .HasConstraintName("FK_MUSTER_GROUPS");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Muster)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_MUSTER_STUDENT");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NameRole).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Mssv)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MSSV");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_SINHVIEN_TAIKHOAN");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.ClassId)
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

                entity.Property(e => e.GroupsId).HasColumnName("GroupsID");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.ToolId).HasColumnName("ToolID");

                entity.HasOne(d => d.Groups)
                    .WithMany(p => p.Toolticker)
                    .HasForeignKey(d => d.GroupsId)
                    .HasConstraintName("FK_TOOLTICKER_GROUPS");

                entity.HasOne(d => d.Tool)
                    .WithMany(p => p.Toolticker)
                    .HasForeignKey(d => d.ToolId)
                    .HasConstraintName("FK_PHIEUDUNGCU_DUNGCULAODONG");
            });

            modelBuilder.Entity<Workticker>(entity =>
            {
                entity.ToTable("WORKTICKER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CalendarId).HasColumnName("CalendarID");

                entity.Property(e => e.GroupsId).HasColumnName("GroupsID");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.RegistrationForm).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Workticker)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_WORKTICKER_ACCOUNT");

                entity.HasOne(d => d.Calendar)
                    .WithMany(p => p.Workticker)
                    .HasForeignKey(d => d.CalendarId)
                    .HasConstraintName("FK_PHIEULAODONG_LICHLAODONG");

                entity.HasOne(d => d.Groups)
                    .WithMany(p => p.Workticker)
                    .HasForeignKey(d => d.GroupsId)
                    .HasConstraintName("FK_WORKTICKER_GROUPS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
