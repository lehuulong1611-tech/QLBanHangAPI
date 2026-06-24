using System;
using System.Collections.Generic;

namespace QLBanHangAPI.Models;

public partial class DmKho
{
    public string Ma { get; set; } = null!;

    public string? Ten { get; set; }

    public string? TenThuKho { get; set; }

    public short? User1 { get; set; }

    public DateTime? Date1 { get; set; }

    public short? User2 { get; set; }

    public DateTime? Date2 { get; set; }

    public short? IdcuaHang { get; set; }

    public string? QuyenNhap { get; set; }

    public string? QuyenXem { get; set; }

    public short Stt { get; set; }

    public string? Email { get; set; }
}
