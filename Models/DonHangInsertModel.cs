using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QLBanHangAPI.Models
{
    /// <summary>
    /// Model hứng trọn vẹn thông tin chung của Đơn hàng từ Client gửi lên
    /// </summary>
    public class DonHangInsertModel
    {
        public string MaDonHangTam { get; set; }
        public DateTime NgayTaoDon { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoaiKH { get; set; }
        public string DiaChiKH { get; set; }
        public string GhiChuDonHang { get; set; }
        public DateTime? NgayGiaoHang { get; set; } // Để Nullable đề phòng nhân viên không nhập ngày giao
        public decimal TongTienThanhToan { get; set; }
        public string TrangThai { get; set; } // Sẽ nhận chữ "Chờ duyệt" từ JS gửi lên

        // Danh sách sản phẩm con đi kèm theo đơn
        public List<ChiTietDonHangInsertModel> DanhSachSanPham { get; set; } = new List<ChiTietDonHangInsertModel>();
    }

    /// <summary>
    /// Model chi tiết từng sản phẩm trong đơn hàng
    /// </summary>
    public class ChiTietDonHangInsertModel
    {
        public string MaHangNCC { get; set; }
        public string TenSanPham { get; set; }
        public int QuyCach { get; set; }
        public string DonViLe { get; set; }
        public string DvtSelected { get; set; } // 'thung' hoặc 'le'
        public string LoaiHang { get; set; }    // 'hang_ban' or 'khuyen_mai'
        public int SoLuong { get; set; }
        public decimal DonGiaGoc { get; set; }
        public decimal TienHangGoc { get; set; }
        public decimal ChietKhauPhanTram { get; set; }
        public decimal TienChietKhau { get; set; }
        public decimal GiaSauChietKhau { get; set; }
        public decimal ThanhTienCuoiCung { get; set; }
    }
}
