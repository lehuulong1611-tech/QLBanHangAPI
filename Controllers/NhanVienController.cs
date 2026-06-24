using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBanHangAPI.Models;

namespace QLBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly CHBANHDbContext _context;

        public NhanVienController(CHBANHDbContext context)
        {
            _context = context;
        }

        // GET: api/NhanVien?page=1&pageSize=50
        [HttpGet]
        public async Task<IActionResult> GetDanhSachNhanVien([FromQuery] int page = 1, [FromQuery] int pageSize = 50)
        {
            try
            {
                if (page < 1) page = 1;
                if (pageSize < 1) pageSize = 50;

                var totalCount = await _context.DmNhanviens.CountAsync();

                int limit = page * pageSize;
                var tatCaTamThoi = await _context.DmNhanviens
                                                 .Take(limit)
                                                 .ToListAsync();

                var danhSachPhanTrang = tatCaTamThoi
                                         .Skip((page - 1) * pageSize)
                                         .ToList();

                var ketQuaPhang = danhSachPhanTrang.Select(nv => new
                {
                    maNhanVien = nv.Ma,
                    tenNhanVien = nv.Ten ?? "Không rõ tên",
                    dienThoai = nv.DienThoai ?? "",
                    gioiTinh = nv.Chucvu ?? ""
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
                return StatusCode(500, $"Lỗi hệ thống nhân viên: {ex.Message}");
            }
        }

        // ==========================================
        // BƯỚC 1: API LẤY DANH SÁCH NHÓM HÀNG THEO MÃ NHÂN VIÊN
        // URL gọi thử: GET api/NhanVien/get-nhom-hang/MÃ_NV
        // ==========================================
        [HttpGet("get-nhom-hang/{maNhanVien}")]
        public async Task<IActionResult> GetNhomHangByNhanVien(string maNhanVien)
        {
            try
            {
                // Quét bảng phân quyền để lấy ra danh sách mã nhóm hàng (Manhom) của nhân viên này
                var dsNhomHang = await _context.PhanQuyenNhanVien
                    .Where(pq => pq.Ma == maNhanVien)
                    .Select(pq => pq.Manhom)
                    .ToListAsync();

                // Trả về chuỗi JSON Array (ví dụ: ["NHOM01", "NHOM02"])
                return Ok(dsNhomHang);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi hệ thống khi lấy quyền nhóm hàng: {ex.Message}");
            }
        }
    }
}