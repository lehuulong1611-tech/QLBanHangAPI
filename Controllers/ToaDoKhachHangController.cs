using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLBanHangAPI.Models; // Giữ nguyên theo namespace của bạn
using System;
using System.Data;
using System.Threading.Tasks;
using static QLBanHangAPI.Controllers.ToaDoKhachHangController;


namespace QLBanHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToaDoKhachHangController : ControllerBase
    {
        private readonly CHBANHDbContext _context;

        public ToaDoKhachHangController(CHBANHDbContext context)
        {
            _context = context;
        }

        // =========================================================================
        // 🌟 1. API LẤY TỌA ĐỘ THEO MÃ KHÁCH HÀNG (Dùng SQL Thuần ADO.NET Reader)
        // =========================================================================
        [HttpGet("{maKH}")]
        public async Task<IActionResult> GetToaDoKhachHang(string maKH)
        {
            if (string.IsNullOrEmpty(maKH))
            {
                return BadRequest("Thiếu thông tin mã khách hàng.");
            }

            try
            {
                string sqlQuery = "SELECT MaKhachHang, ViDo, KinhDo, NgayCapNhat, NguoiCapNhat FROM ToaDoKhachHang WHERE MaKhachHang = @MaKhachHang";
                var connection = _context.Database.GetDbConnection();
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                object toaDoResult = null;

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sqlQuery;
                    var param = command.CreateParameter();
                    param.ParameterName = "@MaKhachHang";
                    param.Value = maKH;
                    command.Parameters.Add(param);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            toaDoResult = new
                            {
                                maKhachHang = reader["MaKhachHang"]?.ToString(),
                                viDo = reader["ViDo"] != DBNull.Value ? Convert.ToDecimal(reader["ViDo"]) : 0,
                                kinhDo = reader["KinhDo"] != DBNull.Value ? Convert.ToDecimal(reader["KinhDo"]) : 0,
                                ngayCapNhat = reader["NgayCapNhat"] != DBNull.Value ? Convert.ToDateTime(reader["NgayCapNhat"]).ToString("yyyy-MM-ddTHH:mm:ss") : null,
                                nguoiCapNhat = reader["NguoiCapNhat"]?.ToString()
                            };
                        }
                    }
                }

                if (toaDoResult == null)
                {
                    return NotFound("Chưa có dữ liệu vị trí cho khách hàng này.");
                }

                return Ok(toaDoResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi hệ thống khi lấy tọa độ khách hàng: {ex.Message}");
            }
        }

        // =========================================================================
        // 🌟 1.5 API LẤY TOÀN BỘ DANH SÁCH TỌA ĐỘ KHÁCH HÀNG (Dùng SQL Thuần Reader)
        // =========================================================================
        [HttpGet]
        public async Task<IActionResult> GetAllToaDo()
        {
            try
            {
                string sqlQuery = "SELECT MaKhachHang, ViDo, KinhDo, NgayCapNhat, NguoiCapNhat FROM ToaDoKhachHang";
                var connection = _context.Database.GetDbConnection();
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                var listToaDo = new System.Collections.Generic.List<object>();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sqlQuery;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            listToaDo.Add(new
                            {
                                maKhachHang = reader["MaKhachHang"]?.ToString(),
                                viDo = reader["ViDo"] != DBNull.Value ? Convert.ToDecimal(reader["ViDo"]) : 0,
                                kinhDo = reader["KinhDo"] != DBNull.Value ? Convert.ToDecimal(reader["KinhDo"]) : 0,
                                ngayCapNhat = reader["NgayCapNhat"] != DBNull.Value ? Convert.ToDateTime(reader["NgayCapNhat"]).ToString("yyyy-MM-ddTHH:mm:ss") : null,
                                nguoiCapNhat = reader["NguoiCapNhat"]?.ToString()
                            });
                        }
                    }
                }

                return Ok(listToaDo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi hệ thống khi tải toàn bộ tọa độ: {ex.Message}");
            }
        }
        // =========================================================================
        // 🌟 2. API LƯU HOẶC CẬP NHẬT TỌA ĐỘ (Dùng UPSERT bằng ExecuteSqlRawAsync)
        // =========================================================================
        [HttpPost]
        public async Task<IActionResult> SaveToaDoKhachHang([FromBody] ToaDoKhachHangDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.MaKhachHang))
            {
                return BadRequest("Dữ liệu tọa độ không hợp lệ.");
            }

            var connection = _context.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();

            // 1. Kiểm tra khách hàng đã tồn tại bản ghi tọa độ nào chưa
            bool exists = false;
            using (var checkCmd = connection.CreateCommand())
            {
                checkCmd.CommandText = "SELECT COUNT(1) FROM ToaDoKhachHang WHERE MaKhachHang = @MaKhachHang";
                var p = checkCmd.CreateParameter();
                p.ParameterName = "@MaKhachHang";
                p.Value = dto.MaKhachHang;
                checkCmd.Parameters.Add(p);

                var countObj = await checkCmd.ExecuteScalarAsync();
                exists = Convert.ToInt32(countObj) > 0;
            }

            // 2. Thực hiện Transaction để đảm bảo an toàn dữ liệu
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    string sqlExecute = "";

                    if (exists)
                    {
                        // Nếu đã có bản ghi -> UPDATE
                        sqlExecute = @"
                            UPDATE ToaDoKhachHang 
                            SET ViDo = @ViDo, 
                                KinhDo = @KinhDo, 
                                NgayCapNhat = @NgayCapNhat, 
                                NguoiCapNhat = @NguoiCapNhat 
                            WHERE MaKhachHang = @MaKhachHang";
                    }
                    else
                    {
                        // Nếu chưa có bản ghi -> INSERT
                        sqlExecute = @"
                            INSERT INTO ToaDoKhachHang (MaKhachHang, ViDo, KinhDo, NgayCapNhat, NguoiCapNhat) 
                            VALUES (@MaKhachHang, @ViDo, @KinhDo, @NgayCapNhat, @NguoiCapNhat)";
                    }

                    await _context.Database.ExecuteSqlRawAsync(sqlExecute,
                        new SqlParameter("@MaKhachHang", dto.MaKhachHang),
                        new SqlParameter("@ViDo", dto.ViDo),
                        new SqlParameter("@KinhDo", dto.KinhDo),
                        new SqlParameter("@NgayCapNhat", DateTime.Now),
                        new SqlParameter("@NguoiCapNhat", dto.NguoiCapNhat ?? (object)DBNull.Value)
                    );

                    await transaction.CommitAsync();
                    return Ok(new { success = true, message = "Cập nhật tọa độ khách hàng thành công!" });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, $"Lỗi hệ thống khi lưu tọa độ: {ex.Message}");
                }
            }
        }

        // Cấu trúc DTO đồng bộ dữ liệu với JavaScript Client gửi lên
        public class ToaDoKhachHangDto
        {
            public string MaKhachHang { get; set; }
            public decimal ViDo { get; set; }
            public decimal KinhDo { get; set; }
            public string NguoiCapNhat { get; set; }
        }
    }
}