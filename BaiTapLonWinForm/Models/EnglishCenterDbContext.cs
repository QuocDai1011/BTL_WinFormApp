using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Models;

public partial class EnglishCenterDbContext : DbContext
{
    public EnglishCenterDbContext()
    {
    }

    public EnglishCenterDbContext(DbContextOptions<EnglishCenterDbContext> options)
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-3A6OS2F\\SQLEXPRESS;Database=EnglishCentre;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__admin__43AA41414ABBCB77");

            entity.HasOne(d => d.User).WithMany(p => p.Admins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__admin__user_id__5535A963");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__class__FDF47986E463AA3A");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrentStudent).HasDefaultValue(0);
            entity.Property(e => e.MaxStudent).HasDefaultValue(30);
            entity.Property(e => e.Shift).HasDefaultValue((byte)6);
            entity.Property(e => e.Status).HasDefaultValue(-1);

            entity.HasOne(d => d.Course).WithMany(p => p.Classes).HasConstraintName("FK_class_course");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__class__teacher_i__6EF57B66");

            entity.HasMany(d => d.SchoolDays).WithMany(p => p.Classes)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassDay",
                    r => r.HasOne<SchoolDay>().WithMany()
                        .HasForeignKey("SchoolDayId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__class_day__schoo__7B5B524B"),
                    l => l.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__class_day__class__7A672E12"),
                    j =>
                    {
                        j.HasKey("ClassId", "SchoolDayId").HasName("PK__class_da__4B5092A92B49DAED");
                        j.ToTable("class_day");
                        j.IndexerProperty<int>("ClassId").HasColumnName("class_id");
                        j.IndexerProperty<byte>("SchoolDayId").HasColumnName("school_day_id");
                    });
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__course__8F1EF7AE28739574");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(sysdatetime())");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__promotio__2CB9556B8428B5A3");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DiscountType).HasDefaultValue("percent");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ClassId, e.PromotionId }).HasName("PK__receipt__3FC0F857300C276E");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.NumberOfPayments).HasDefaultValue(1);
            entity.Property(e => e.PaymentDate).HasDefaultValueSql("(CONVERT([date],getdate()))");
            entity.Property(e => e.PaymentMethod).HasDefaultValue("online");
            entity.Property(e => e.Status).HasDefaultValue("paid");

            entity.HasOne(d => d.Class).WithMany(p => p.Receipts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__receipt__class_i__2180FB33");

            entity.HasOne(d => d.Promotion).WithMany(p => p.Receipts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__receipt__promoti__22751F6C");

            entity.HasOne(d => d.Student).WithMany(p => p.Receipts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__receipt__update___208CD6FA");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__role__760965CC3EC42EE3");

            entity.Property(e => e.RoleId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SchoolDay>(entity =>
        {
            entity.HasKey(e => e.SchoolDayId).HasName("PK__school_d__6A4EB2FA7F9F4D56");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__student__2A33069AD225FAE7");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student__user_id__5DCAEF64");
        });

        modelBuilder.Entity<StudentClass>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ClassId }).HasName("PK__student___55EC41022F63EF0C");

            entity.ToTable("student_class", tb => tb.HasTrigger("trg_check_insert_student_class"));

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Class).WithMany(p => p.StudentClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student_c__class__7F2BE32F");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student_c__stude__7E37BEF6");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__teacher__03AE777E66DAAD03");

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__teacher__user_id__59FA5E80");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__B9BE370F82F81A4E");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Gender).HasDefaultValue(true);
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user__role_id__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
