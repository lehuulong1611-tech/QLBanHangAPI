using System;
using System.Collections.Generic;

namespace QLBanHangAPI.Models;

public partial class DmHangHoaDvt
{
    public byte? Stt { get; set; }

    public string HangHoa { get; set; } = null!;

    public string Dvt { get; set; } = null!;

    public short? SlQuiDoi { get; set; }

    public decimal? GiaLe { get; set; }

    public decimal? GiaSi { get; set; }

    public decimal? GiaNhap { get; set; }
}
