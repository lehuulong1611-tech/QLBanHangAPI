using System;
using System.Collections.Generic;

namespace QLBanHangAPI.Models;

public partial class SoCaiDetail
{
    public short? Stt { get; set; }

    public string ChungTu { get; set; } = null!;

    public string HangHoa { get; set; } = null!;

    public decimal SoLuong { get; set; }

    public string? Dvt { get; set; }

    public decimal? Dongia { get; set; }

    public decimal? ChietKhau { get; set; }

    public decimal? KhuyenMai { get; set; }

    public decimal? ThanhTien { get; set; }

    public string? LyDo { get; set; }

    public decimal? GiaVon { get; set; }

    public string? PhieuDatHang { get; set; }

    public string? SoHoaDon { get; set; }

    public DateTime? NgayHoaDon { get; set; }

    public decimal? SlGiaVon { get; set; }

    public decimal? MucThue { get; set; }

    public string? SoThe { get; set; }

    public string? Nhanvien { get; set; }

    public string? Kho { get; set; }

    public string? QuiCach { get; set; }

    public decimal SlQuiDoi { get; set; }

    public string? SoLo { get; set; }

    public string? ViSa { get; set; }

    public DateTime? HanSuDung { get; set; }

    public string TenHang { get; set; } = null!;

    public short? User1 { get; set; }

    public DateTime? Date1 { get; set; }

    public short? User2 { get; set; }

    public DateTime? Date2 { get; set; }

    public int Id { get; set; }
}
