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

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassSession> ClassSessions { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<ReceiptPayment> ReceiptPayments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SchoolDay> SchoolDays { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentClass> StudentClasses { get; set; }

    public virtual DbSet<StudentFaceImage> StudentFaceImages { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherAttendance> TeacherAttendances { get; set; }

    public virtual DbSet<TeacherFaceImage> TeacherFaceImages { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=localhost,1444;Database=tre_xanh_english_center_dev;User Id=sa;Password=Qdai1011@;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__admin__43AA4141ADE0A888");

            entity.ToTable("admin");

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(12, 3)")
                .HasColumnName("salary");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Admins)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__admin__user_id__534D60F1");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__attendan__20D6A9683E886721");

            entity.ToTable("attendance");

            entity.HasIndex(e => new { e.StudentId, e.SessionId }, "uq_student_session").IsUnique();

            entity.Property(e => e.AttendanceId).HasColumnName("attendance_id");
            entity.Property(e => e.CheckInTime)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("check_in_time");
            entity.Property(e => e.IsPresent)
                .HasDefaultValue(true)
                .HasColumnName("is_present");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__class__FDF47986909786CA");

            entity.ToTable("class");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.ClassName).HasColumnName("class_name");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
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

            entity.HasOne(d => d.Course).WithMany(p => p.Classes)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_class_course");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__class__teacher_i__6D0D32F4");

            entity.HasMany(d => d.SchoolDays).WithMany(p => p.Classes)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassDay",
                    r => r.HasOne<SchoolDay>().WithMany()
                        .HasForeignKey("SchoolDayId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__class_day__schoo__797309D9"),
                    l => l.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__class_day__class__787EE5A0"),
                    j =>
                    {
                        j.HasKey("ClassId", "SchoolDayId").HasName("PK__class_da__4B5092A924FFBCF0");
                        j.ToTable("class_day");
                        j.IndexerProperty<int>("ClassId").HasColumnName("class_id");
                        j.IndexerProperty<byte>("SchoolDayId").HasColumnName("school_day_id");
                    });
        });

        modelBuilder.Entity<ClassSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__class_se__69B13FDCD322F049");

            entity.ToTable("class_session");

            entity.HasIndex(e => new { e.ClassId, e.SessionNumber }, "uq_class_session").IsUnique();

            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.SessionDate).HasColumnName("session_date");
            entity.Property(e => e.SessionNumber).HasColumnName("session_number");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassSessions)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__class_ses__class__6D9742D9");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__course__8F1EF7AE126C74A4");

            entity.ToTable("course");

            entity.HasIndex(e => e.CourseCode, "UQ__course__AB6B45F18EAD114A").IsUnique();

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
            entity.HasKey(e => e.PromotionId).HasName("PK__promotio__2CB9556BB729CAA0");

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
            entity.HasKey(e => new { e.StudentId, e.ClassId, e.PromotionId }).HasName("PK__receipt__3FC0F857F9057C0B");

            entity.ToTable("receipt");

            entity.HasIndex(e => e.TxnRef, "idx_txn_ref").IsUnique();

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.PromotionId).HasColumnName("promotion_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.PaidAmount)
                .HasColumnType("decimal(12, 3)")
                .HasColumnName("paid_amount");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(12, 3)")
                .HasColumnName("total_amount");
            entity.Property(e => e.TxnRef)
                .HasMaxLength(50)
                .HasColumnName("txn_ref");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");

            entity.HasOne(d => d.Class).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__receipt__class_i__39237A9A");

            entity.HasOne(d => d.Promotion).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.PromotionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__receipt__promoti__3A179ED3");

            entity.HasOne(d => d.Student).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__receipt__update___382F5661");
        });

        modelBuilder.Entity<ReceiptPayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__receipt___ED1FC9EA60C99D49");

            entity.ToTable("receipt_payment");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.PayAmount)
                .HasColumnType("decimal(12, 3)")
                .HasColumnName("pay_amount");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("online")
                .HasColumnName("payment_method");
            entity.Property(e => e.PromotionId).HasColumnName("promotion_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Receipt).WithMany(p => p.ReceiptPayments)
                .HasForeignKey(d => new { d.StudentId, d.ClassId, d.PromotionId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_receipt_payment_receipt");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__role__760965CC4151F088");

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
            entity.HasKey(e => e.SchoolDayId).HasName("PK__school_d__6A4EB2FAB68BB5B7");

            entity.ToTable("school_day");

            entity.Property(e => e.SchoolDayId).HasColumnName("school_day_id");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(100)
                .HasColumnName("day_of_week");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__student__2A33069A1CE8CF89");

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
                .HasConstraintName("FK__student__user_id__5BE2A6F2");
        });

        modelBuilder.Entity<StudentClass>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ClassId }).HasName("PK__student___55EC4102460B7725");

            entity.ToTable("student_class", tb => tb.HasTrigger("trg_check_insert_student_class"));

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
                .HasConstraintName("FK__student_c__class__7D439ABD");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentClasses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student_c__stude__7C4F7684");
        });

        modelBuilder.Entity<StudentFaceImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__student___DC9AC9557FD32ECB");

            entity.ToTable("student_face_image");

            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image_path");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.UploadedDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("uploaded_date");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__teacher__03AE777E026203DD");

            entity.ToTable("teacher");

            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.ExperienceYear).HasColumnName("experience_year");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__teacher__user_id__5812160E");
        });

        modelBuilder.Entity<TeacherAttendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__teacher___20D6A968893E59E3");

            entity.ToTable("teacher_attendance");

            entity.HasIndex(e => new { e.TeacherId, e.SessionId }, "uq_teacher_session").IsUnique();

            entity.Property(e => e.AttendanceId).HasColumnName("attendance_id");
            entity.Property(e => e.CheckInTime)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("check_in_time");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Session).WithMany(p => p.TeacherAttendances)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__teacher_a__sessi__73501C2F");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherAttendances)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__teacher_a__teach__74444068");
        });

        modelBuilder.Entity<TeacherFaceImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__teacher___DC9AC955F9BCAAB2");

            entity.ToTable("teacher_face_image");

            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image_path");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.UploadedDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("uploaded_date");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherFaceImages)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__teacher_f__teach__68D28DBC");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__B9BE370F7C5CD9FD");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "UQ__user__AB6E61644DEA00C9").IsUnique();

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
                .HasConstraintName("FK__user__role_id__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
