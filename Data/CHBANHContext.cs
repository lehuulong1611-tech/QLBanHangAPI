using Microsoft.EntityFrameworkCore;
using QLBanHangAPI.Models; // Đảm bảo dòng này đúng với thư mục chứa file Tonkho.cs của bạn

namespace QLBanHangAPI.Data
{
    public class CHBANHContext : DbContext
    {
        public CHBANHContext(DbContextOptions<CHBANHContext> options)
            : base(options)
        {
        }

        // 1. Khai báo View Tonkho vào hệ thống C#
        public virtual DbSet<Tonkho> Tonkhos { get; set; }

        // 2. Khai báo bảng Khách hàng (để dùng cho KhachHangController hôm nọ nếu bạn dùng chung Context này)
        // public virtual DbSet<DmKhachHang> DmKhachHangs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình riêng cho View Tonkho vì View không có Khóa chính (PrimaryKey)
            modelBuilder.Entity<Tonkho>(entity =>
            {
                entity.HasNoKey();        // Báo cho EF Core biết đây là View, không cần tìm ID/Khóa chính
                entity.ToView("Tonkho");  // Tên chính xác của View trong SQL Server của bạn
            });
        }
    }
}