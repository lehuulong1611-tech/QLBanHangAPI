using System;
using System.Collections.Generic;

namespace QLBanHangAPI.Models;

public partial class DmLoaiHang
{
    public string Ma { get; set; } = null!;

    public string Ten { get; set; } = null!;

    public decimal? MucThuongNhanVien { get; set; }

    public decimal? MucThuongLanhDao { get; set; }

    public short? User1 { get; set; }

    public DateTime? Date1 { get; set; }

    public short? User2 { get; set; }

    public DateTime? Date2 { get; set; }
}
