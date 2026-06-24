using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBanHangAPI.Models;

namespace QLBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly CHBANHDbContext _context;

        public KhachHangController(CHBANHDbContext context)
        {
            _context = context;
        }

        
        // GET: api/KhachHang
        [HttpGet]
        public async Task<IActionResult> GetDanhSachKhachHang()
        {
            try
            {
                // 1. Lấy toàn bộ khách hàng thỏa mãn điều kiện
                var tatCaKhachHang = await _context.DmKhachHangs
                                                   .Where(kh => kh.LaKhachHang == true)
                                                   .ToListAsync();

                // 2. Chuyển thành dữ liệu phẳng để giảm dung lượng tối đa khi truyền qua mạng
                var ketQuaPhang = tatCaKhachHang.Select(kh => new
                {
                    maKhachHang = kh.Ma,
                    tenKhachHang = kh.Ten,
                    dienThoai = kh.DienThoai,
                    diaChi = kh.DiaChi
                }).ToList();

                // 3. Trả về mảng trần luôn, không cần đóng gói TotalRecords hay Page nữa
                return Ok(ketQuaPhang);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi hệ thống: {ex.Message}");
            }
        }
    }
}