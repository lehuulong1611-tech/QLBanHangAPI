using System;
using System.Collections.Generic;

namespace QLBanHangAPI.Models;

public partial class DmKhachHang
{
    public string Ma { get; set; } = null!;

    public string? Ten { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public string? DienThoai { get; set; }

    public string? Fax { get; set; }

    public string? Nhanvien { get; set; }

    public string? Mst { get; set; }

    public string? TaiKhoan { get; set; }

    public string? NganHang { get; set; }

    public string? NhomKh { get; set; }

    public string? Vung { get; set; }

    public decimal? GioiHanNo { get; set; }

    public byte? Cap { get; set; }

    public byte Loai { get; set; }

    public bool LaKhachHang { get; set; }

    public bool LaNhaCungCap { get; set; }

    public string? GiamDoc { get; set; }

    public string? NguoiGiaoDich { get; set; }

    public string? ChucVuNguoiGiaoDich { get; set; }

    public string? LoaiDoanhNghiep { get; set; }

    public string? LinhVuc { get; set; }

    public string? Nguon { get; set; }

    public string? DienThoaiGiamDoc { get; set; }

    public byte[]? Anh { get; set; }

    public string? DienThoaiNguoiGiaoDich { get; set; }

    public string? TinhTrang { get; set; }

    public string? Ghichu { get; set; }

    public string? DiaChiCoQuan { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? DienThoaiDiDong { get; set; }

    public string? ChucVu { get; set; }

    public string? XungDanh { get; set; }

    public bool IsGroup { get; set; }

    public string? TenNhomKh { get; set; }

    public string? TenGiamDoc { get; set; }

    public string? NguoiDaiDien { get; set; }

    public string? ChucVuNguoiDaiDien { get; set; }

    public string? DienThoaiNguoiDaiDien { get; set; }

    public short? User1 { get; set; }

    public DateTime? Date1 { get; set; }

    public short? User2 { get; set; }

    public DateTime? Date2 { get; set; }

    public short? IdcuaHang { get; set; }

    public string? TenGiaoDich { get; set; }

    public string? TenHoaDon { get; set; }

    public string? DiaChiHoaDon { get; set; }

    public string? Pass { get; set; }

    public string? MaLienKet { get; set; }

    public string? Website { get; set; }

    public int? IdthanhPho { get; set; }

    public int? Idquan { get; set; }

    public int? Idphuong { get; set; }

    public short? HanThanhToan { get; set; }

    public byte? LichChamSoc { get; set; }
}
