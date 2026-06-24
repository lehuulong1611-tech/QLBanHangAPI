using System;
using System.Collections.Generic;

namespace QLBanHangAPI.Models;

public partial class CkNhomHang
{
    public short? IdchuongTrinh { get; set; }

    public byte? Stt { get; set; }

    public string? TenNhom { get; set; }

    public string? DsMaHang { get; set; }

    public short? SoLuong { get; set; }

    public string? GhiChu { get; set; }
}
