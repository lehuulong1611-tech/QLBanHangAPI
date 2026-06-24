using System;
using System.Collections.Generic;

namespace QLBanHangAPI.Models;

public partial class DmNhomKh
{
    public string Ma { get; set; } = null!;

    public string? Ten { get; set; }

    public string? Stt { get; set; }

    public string? DatQuyen { get; set; }

    public short? User1 { get; set; }

    public DateTime? Date1 { get; set; }

    public short? User2 { get; set; }

    public DateTime? Date2 { get; set; }

    public string? QuyenXem { get; set; }
}
