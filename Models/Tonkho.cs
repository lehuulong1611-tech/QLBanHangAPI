using System;

namespace QLBanHangAPI.Models
{
    public class Tonkho
    {
        public string Ma { get; set; } = null!;
        public string? Ten { get; set; }
        public string? Dvt { get; set; }
        public string? Ma1 { get; set; }
        public decimal? Giasi { get; set; }
        public decimal? GiaLe { get; set; }

        // ĐỔI TẤT CẢ THÀNH DECIMAL? ĐỂ KHỚP VỚI KIỂU SỐ CỦA SQL SERVER
        public decimal? Slg1Lo { get; set; }
        public decimal? SoLuongConLai { get; set; }
        public string? NhomHang { get; set; }
    }
}