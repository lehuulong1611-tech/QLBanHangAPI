using System;
using System.Collections.Generic;

namespace QLBanHangAPI.Models;

public partial class DmHangHoaBo
{
    public string MaBo { get; set; } = null!;

    public string MaHang { get; set; } = null!;

    public short? Soluong { get; set; }

    public short? PhanBo { get; set; }

    public short? Stt { get; set; }

    public decimal? DonGia { get; set; }

    public decimal? GiaLe { get; set; }

    public decimal? GiaSi { get; set; }

    public decimal? GiaNhap { get; set; }

    public decimal? KhuyenMaiBanLe { get; set; }

    public decimal? KhuyenMaiBanBuon { get; set; }

    public decimal? KhuyenMaiNhap { get; set; }

    public decimal? Cap1 { get; set; }

    public decimal? Cap2 { get; set; }

    public decimal? Cap3 { get; set; }

    public decimal? Cap4 { get; set; }
}
