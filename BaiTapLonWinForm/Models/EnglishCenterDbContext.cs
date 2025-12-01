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

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=DESKTOP-3A6OS2F\\SQLEXPRESS;Database=EnglishCentre;Trusted_Connection=True;TrustServerCertificate=True");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__admin__43AA41414ABBCB77");

            entity.ToTable("admin");

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(12, 3)")
                .HasColumnName("salary");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Admins)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__admin__user_id__5535A963");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__class__FDF47986E463AA3A");

            entity.ToTable("class");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.ClassName).HasColumnName("class_name");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CurrentStudent)
                .HasDefaultValue(0)
                .HasColumnName("current_student");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.MaxStudent)
                .HasDefaultValue(30)
                .HasColumnName("max_student");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.OnlineMeetingLink)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("online_meeting_link");
            entity.Property(e => e.Shift)
                .HasDefaultValue((byte)6)
                .HasColumnName("shift");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasDefaultValue(-1)
                .HasColumnName("status");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__class__teacher_i__6EF57B66");

            entity.HasMany(d => d.Courses).WithMany(p => p.Classes)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassCourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__class_cou__cours__74AE54BC"),
                    l => l.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__class_cou__class__73BA3083"),
                    j =>
                    {
                        j.HasKey("ClassId", "CourseId").HasName("PK__class_co__050596FC1242CAB2");
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

            entity.ToTable("course");

            entity.HasIndex(e => e.CourseCode, "UQ__course__AB6B45F1D56FCDC2").IsUnique();

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CourseCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("course_name");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Level)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("level");
            entity.Property(e => e.NumberSessions).HasColumnName("number_sessions");
            entity.Property(e => e.Tuition)
                .HasColumnType("decimal(12, 3)")
                .HasColumnName("tuition");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__promotio__2CB9556B8428B5A3");

            entity.ToTable("promotion");

            entity.Property(e => e.PromotionId).HasColumnName("promotion_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.DiscountType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("percent")
                .HasColumnName("discount_type");
            entity.Property(e => e.DiscountValue)
                .HasColumnType("decimal(12, 3)")
                .HasColumnName("discount_value");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PromotionName).HasColumnName("promotion_name");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ClassId, e.PromotionId }).HasName("PK__receipt__3FC0F8574BBB0138");

            entity.ToTable("receipt");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.PromotionId).HasColumnName("promotion_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(12, 3)")
                .HasColumnName("amount");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.NumberOfPayments)
                .HasDefaultValue(1)
                .HasColumnName("number_of_payments");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(CONVERT([date],getdate()))")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("online")
                .HasColumnName("payment_method");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("paid")
                .HasColumnName("status");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__role__760965CC3EC42EE3");

            entity.ToTable("role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedOnAdd()
                .HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<SchoolDay>(entity =>
        {
            entity.HasKey(e => e.SchoolDayId).HasName("PK__school_d__6A4EB2FA7F9F4D56");

            entity.ToTable("school_day");

            entity.Property(e => e.SchoolDayId).HasColumnName("school_day_id");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(100)
                .HasColumnName("day_of_week");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__student__2A33069AD225FAE7");

            entity.ToTable("student");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.PhoneNumberOfParents)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone_number_of_parents");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student__user_id__5DCAEF64");
        });

        modelBuilder.Entity<StudentClass>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ClassId }).HasName("PK__student___55EC41022F63EF0C");

            entity.ToTable("student_class");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");

            entity.HasOne(d => d.Class).WithMany(p => p.StudentClasses)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student_c__class__7F2BE32F");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentClasses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student_c__stude__7E37BEF6");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__teacher__03AE777E66DAAD03");

            entity.ToTable("teacher");

            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.ExperienceYear).HasColumnName("experience_year");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__teacher__user_id__59FA5E80");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__B9BE370F82F81A4E");
            entity.ToTable("user", "dbo");
            //entity.ToTable("user");

            entity.HasIndex(e => e.Email, "UQ__user__AB6E616479DCCD3F").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasDefaultValue(true)
                .HasColumnName("gender");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.PasswordHashing)
                .IsUnicode(false)
                .HasColumnName("password_hashing");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user__role_id__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
