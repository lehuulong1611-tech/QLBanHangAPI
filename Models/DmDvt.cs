using System;
using System.Collections.Generic;

namespace QLBanHangAPI.Models;

public partial class DmDvt
{
    public string Dvt { get; set; } = null!;

    public short? User1 { get; set; }

    public DateTime? Date1 { get; set; }

    public short? User2 { get; set; }

    public DateTime? Date2 { get; set; }
}
