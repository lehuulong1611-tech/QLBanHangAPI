using System;
using System.Collections.Generic;

namespace QLBanHangAPI.Models;

public partial class DmNhomHang
{
    public string Ma { get; set; } = null!;

    public string? Ten { get; set; }

    public string? LoaiNhom { get; set; }

    public short? User1 { get; set; }

    public DateTime? Date1 { get; set; }

    public short? User2 { get; set; }

    public DateTime? Date2 { get; set; }

    public string? NganhHang { get; set; }

    public decimal? Cap1 { get; set; }

    public decimal? GiaSi { get; set; }

    public decimal? GiaLe { get; set; }

    public bool TinhTrang { get; set; }

    public decimal? GiaBuon { get; set; }

    public bool Imei { get; set; }

    public decimal? Cap2 { get; set; }

    public short? ViTri { get; set; }

    public string? QuyenThemMoi { get; set; }

    public string? QuyenSua { get; set; }

    public string? QuyenXoa { get; set; }
}
