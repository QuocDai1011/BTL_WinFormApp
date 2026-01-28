using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWebApi.Models;

public partial class EnglistCenterContext : DbContext
{
    public EnglistCenterContext()
    {
    }

    public EnglistCenterContext(DbContextOptions<EnglistCenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<ReceiptPayment> ReceiptPayments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__promotio__2CB9556B2453E388");

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
            entity.HasKey(e => new { e.StudentId, e.ClassId, e.PromotionId }).HasName("PK__receipt__3FC0F8573E226F29");

            entity.ToTable("receipt");

            entity.HasIndex(e => e.ClassId, "IX_receipt_class");

            entity.HasIndex(e => e.StudentId, "IX_receipt_student");

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

            entity.HasOne(d => d.Promotion).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.PromotionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__receipt__promoti__540C7B00");
        });

        modelBuilder.Entity<ReceiptPayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__receipt___ED1FC9EA6A9C041D");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
