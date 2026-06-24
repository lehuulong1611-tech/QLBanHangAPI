using System;
using System.Collections.Generic;

namespace QLBanHangAPI.Models;

public partial class DmNganhHang
{
    public string Ma { get; set; } = null!;

    public string? Ten { get; set; }

    public short? User1 { get; set; }

    public DateTime? Date1 { get; set; }

    public short? User2 { get; set; }

    public DateTime? Date2 { get; set; }

    public short? ViTri { get; set; }

    public bool TinhTrang { get; set; }
}
