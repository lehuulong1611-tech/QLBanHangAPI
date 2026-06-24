using System;
using System.Collections.Generic;

namespace QLBanHangAPI.Models;

public partial class DmHangHoa
{
    public string Ma { get; set; } = null!;

    public string? Ma1 { get; set; }

    public string? Ten { get; set; }

    public string? NhomHang { get; set; }

    public string? QuiCach { get; set; }

    public string? Dvt { get; set; }
    public decimal? Giasi { get; set; }

    public decimal? GiaLe { get; set; }

    public decimal? GiaNhap { get; set; }
    public decimal? MucThue { get; set; }

    public decimal? KhuyenMaiNhap { get; set; }

    public decimal? KhuyenMaiBanLe { get; set; }

    public decimal? KhuyenMaiBanBuon { get; set; }

    public decimal? Cap1 { get; set; }

    public decimal? Cap2 { get; set; }

    public decimal? Cap3 { get; set; }

    public decimal? Cap4 { get; set; }

    public string MaLienKet { get; set; } = null!;

    public string? NhaCc { get; set; }

     public string? Kho { get; set; }
    public bool QuanLyLo { get; set; }
    public string? MaCu { get; set; }

    public decimal? InBaoGia { get; set; }
    public bool KhongTinhThue { get; set; }

    public decimal? Slg1Lo { get; set; }
    public bool TinhTrang { get; set; }

    public int Id { get; set; }

    public string? TenNhaCc { get; set; }

   
}
