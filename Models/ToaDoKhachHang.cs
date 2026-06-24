using System;
using System.ComponentModel.DataAnnotations;

namespace QLBanHang.Models
{
    public class ToaDoKhachHang
    {
        [Key] // Khóa chính
        public string MaKhachHang { get; set; } = null!;
        public decimal ViDo { get; set; }
        public decimal KinhDo { get; set; }
        public DateTime? NgayCapNhat { get; set; } = DateTime.Now;
        public string? NguoiCapNhat { get; set; }
    }
}