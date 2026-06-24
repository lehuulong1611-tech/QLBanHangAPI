using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourProjectName.Models // Bạn đổi lại "YourProjectName" cho đúng với Namespace dự án của bạn nhé
{
    [Table("PhanQuyenNhanVien")]
    public class PhanQuyenNhanVien
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)] // Khai báo độ dài tùy theo kiểu dữ liệu NVARCHAR dưới DB của bạn
        public string Ma { get; set; }

        [Required]
        [StringLength(50)]
        public string Manhom { get; set; }

        public string GhiChu { get; set; }

        public DateTime? NgayCapNhat { get; set; }
    }
}