using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBanHangAPI.Models;

namespace QLBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly CHBANHDbContext _context;

        public SanPhamController(CHBANHDbContext context)
        {
            _context = context;
        }

        // GET: api/SanPham?page=1&pageSize=50&nhomHangs=0001
        [HttpGet]
        public async Task<IActionResult> GetDanhSachSanPham(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 50,
            [FromQuery] string nhomHangs = "")
        {
            try
            {
                if (page < 1) page = 1;
                if (pageSize < 1) pageSize = 50;

                List<Tonkho> tatCaTrongView = new List<Tonkho>();

                // 1. DÙNG RAW SQL: Ép SQL Server chạy lệnh Select thuần túy để CHẮC CHẮN NÉ LỖI 'WITH'
                if (!string.IsNullOrEmpty(nhomHangs))
                {
                    // Băm chuỗi "0001" từ Front-end gửi qua
                    var danhSachNhom = nhomHangs.Split(',')
                                               .Select(x => x.Trim().Replace("'", "''")) // Chống SQL Injection nhẹ nhàng
                                               .ToList();

                    // Biến mảng thành chuỗi định dạng: '0001','0002' để ném thẳng vào mệnh đề IN của SQL
                    string chuoiInSql = string.Join(",", danhSachNhom.Select(x => $"'{x}'"));

                    // Câu lệnh SQL thuần túy, không thông qua trình dịch của EF Core
                    string rawSqlString = $"SELECT * FROM Tonkho WHERE SoLuongConLai>0 and NhomHang IN ({chuoiInSql})";

                    tatCaTrongView = await _context.Tonkhos.FromSqlRaw(rawSqlString).ToListAsync();
                }
                else
                {
                    // Nếu không có nhóm hàng nào truyền lên, lấy hết toàn bộ View ra RAM
                    tatCaTrongView = await _context.Tonkhos.FromSqlRaw("SELECT * FROM Tonkho where NhomHang = '' and SoLuongConLai>0").ToListAsync();
                }

                // 2. Tính toán tổng số lượng trực tiếp trên danh sách RAM đã bốc về
                var totalCount = tatCaTrongView.Count;

                // 3. Phân trang thủ công trên RAM bằng LINQ (An toàn tuyệt đối)
                var danhSachPhanTrang = tatCaTrongView
                                         .Skip((page - 1) * pageSize)
                                         .Take(pageSize)
                                         .ToList();

                // 4. Khớp dữ liệu sang dạng phẳng trả về cho Front-end render
                var ketQuaPhang = danhSachPhanTrang.Select(tk => new
                {
                    ma = tk.Ma,
                    ten = tk.Ten,
                    dvt = tk.Dvt,
                    slg1Lo = tk.Slg1Lo != null ? Convert.ToDouble(tk.Slg1Lo) : 1.0,
                    giasi = tk.Giasi ?? 0,
                    soLuongConLai = tk.SoLuongConLai != null ? Convert.ToDouble(tk.SoLuongConLai) : 0.0,
                    nhomHang = tk.NhomHang != null ? tk.NhomHang.ToString() : ""
                }).ToList();

                return Ok(new
                {
                    TotalRecords = totalCount,
                    CurrentPage = page,
                    PageSize = pageSize,
                    Data = ketQuaPhang
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi hệ thống lấy dữ liệu từ View Tồn Kho: {ex.Message}");
            }
        }
    }
}