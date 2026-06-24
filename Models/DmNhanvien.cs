using System;
using System.Collections.Generic;

namespace QLBanHangAPI.Models;

public partial class DmNhanvien
{
  
    public string Ma { get; set; } = null!;

    public string Ten { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string DienThoai { get; set; } = null!;

    public string? Chucvu { get; set; }

    public string? Email { get; set; }

    public string? GhiChu { get; set; }



   
}
