using System;
using System.Collections.Generic;
using BaiTapLonWinForm.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SchoolDay> SchoolDays { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentClass> StudentClasses { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1431;Database=english_center_management_dev;User Id=sa;Password=Abc@12345XyZ;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__admin__43AA4141593C90B4");

            entity.HasOne(d => d.User).WithMany(p => p.Admins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__admin__user_id__4316F928");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__class__FDF4798638113F7F");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrentStudent).HasDefaultValue(0);
            entity.Property(e => e.MaxStudent).HasDefaultValue(30);
            entity.Property(e => e.Shift).HasDefaultValue((byte)6);
            entity.Property(e => e.Status).HasDefaultValue(-1);

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__class__teacher_i__5DCAEF64");

            entity.HasMany(d => d.Courses).WithMany(p => p.Classes)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassCourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__class_cou__cours__6383C8BA"),
                    l => l.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__class_cou__class__628FA481"),
                    j =>
                    {
                        j.HasKey("ClassId", "CourseId").HasName("PK__class_co__050596FCE34723CC");
                        j.ToTable("class_course");
                        j.IndexerProperty<int>("ClassId").HasColumnName("class_id");
                        j.IndexerProperty<int>("CourseId").HasColumnName("course_id");
                    });

            entity.HasMany(d => d.SchoolDays).WithMany(p => p.Classes)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassDay",
                    r => r.HasOne<SchoolDay>().WithMany()
                        .HasForeignKey("SchoolDayId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__class_day__schoo__6A30C649"),
                    l => l.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__class_day__class__693CA210"),
                    j =>
                    {
                        j.HasKey("ClassId", "SchoolDayId").HasName("PK__class_da__4B5092A9F952764E");
                        j.ToTable("class_day");
                        j.IndexerProperty<int>("ClassId").HasColumnName("class_id");
                        j.IndexerProperty<byte>("SchoolDayId").HasColumnName("school_day_id");
                    });
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__course__8F1EF7AE6FA18845");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(sysdatetime())");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__promotio__2CB9556B72F35C43");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DiscountType).HasDefaultValue("percent");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ClassId, e.PromotionId }).HasName("PK__receipt__3FC0F8575CC0DD8D");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.NumberOfPayments).HasDefaultValue(1);
            entity.Property(e => e.PaymentDate).HasDefaultValueSql("(CONVERT([date],getdate()))");
            entity.Property(e => e.PaymentMethod).HasDefaultValue("online");
            entity.Property(e => e.Status).HasDefaultValue("paid");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__role__760965CC0569F847");

            entity.Property(e => e.RoleId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SchoolDay>(entity =>
        {
            entity.HasKey(e => e.SchoolDayId).HasName("PK__school_d__6A4EB2FADF42BF53");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__student__2A33069A9416D23D");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student__user_id__4CA06362");
        });

        modelBuilder.Entity<StudentClass>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ClassId }).HasName("PK__student___55EC4102AD52496F");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Class).WithMany(p => p.StudentClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student_c__class__6E01572D");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student_c__stude__6D0D32F4");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__teacher__03AE777EEE8C9FF3");

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__teacher__user_id__48CFD27E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__B9BE370FA890A853");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Gender).HasDefaultValue(true);
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user__role_id__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
