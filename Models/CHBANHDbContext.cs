using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using YourProjectName.Models;

namespace QLBanHangAPI.Models;

public partial class CHBANHDbContext : DbContext
{
    public CHBANHDbContext()
    {
    }

    public CHBANHDbContext(DbContextOptions<CHBANHDbContext> options)
        : base(options)
    {
    }
   

    public virtual DbSet<DmDvt> DmDvts { get; set; }

    public virtual DbSet<DmHangHoa> DmHangHoas { get; set; }

    public virtual DbSet<DmHangHoaBo> DmHangHoaBos { get; set; }

    public virtual DbSet<DmHangHoaDvt> DmHangHoaDvts { get; set; }

    public virtual DbSet<DmKhachHang> DmKhachHangs { get; set; }

    

    public virtual DbSet<DmNhanvien> DmNhanviens { get; set; }

    public virtual DbSet<DmNhomHang> DmNhomHangs { get; set; }

    public DbSet<PhanQuyenNhanVien> PhanQuyenNhanVien { get; set; }

    public virtual DbSet<DmNhomKh> DmNhomKhs { get; set; }
    public virtual DbSet<SoCai> SoCais { get; set; }

    public virtual DbSet<SoCaiDetail> SoCaiDetails { get; set; }

   

   

   
    

    public virtual DbSet<ViewSocai> ViewSocais { get; set; }

   
    public virtual DbSet<Tonkho> Tonkhos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=hieusachcuonghuong.cameraddns.net,48261;Database=CHBANH2026;User Id=sa;Password=vts;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<Tonkho>(entity =>
{
    entity.HasNoKey();        // Báo cho EF Core biết đây là View, không cần tìm khóa chính
    entity.ToView("Tonkho");  // Tên chính xác của View trong SQL Server
});

        modelBuilder.Entity<DmDvt>(entity =>
        {
            entity.HasKey(e => e.Dvt);

            entity.ToTable("DM_DVT");

            entity.Property(e => e.Dvt)
                .HasMaxLength(10)
                .HasColumnName("DVT");
            entity.Property(e => e.Date1).HasColumnType("smalldatetime");
            entity.Property(e => e.Date2).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<DmHangHoa>(entity =>
        {
            entity.HasKey(e => e.Ma);

            entity.ToTable("DM_HangHoa");

            entity.Property(e => e.Ma).HasMaxLength(25);
            entity.Property(e => e.Cap1).HasColumnType("money");
            entity.Property(e => e.Cap2).HasColumnType("money");
            entity.Property(e => e.Cap3).HasColumnType("money");
            entity.Property(e => e.Cap4).HasColumnType("money");
            
           
            entity.Property(e => e.Dvt)
                .HasMaxLength(10)
                .HasColumnName("DVT");
           
            entity.Property(e => e.GiaLe).HasColumnType("money");
            entity.Property(e => e.GiaNhap).HasColumnType("money");
            entity.Property(e => e.Giasi).HasColumnType("money");
            entity.Property(e => e.Kho).HasMaxLength(10);
            entity.Property(e => e.KhuyenMaiBanBuon).HasColumnType("money");
            entity.Property(e => e.KhuyenMaiBanLe).HasColumnType("money");
            entity.Property(e => e.KhuyenMaiNhap).HasColumnType("money");
            entity.Property(e => e.Ma1).HasMaxLength(25);
            entity.Property(e => e.MaCu).HasMaxLength(15);
            entity.Property(e => e.MaLienKet)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.NhaCc)
                .HasMaxLength(20)
                .HasColumnName("NhaCC");
            entity.Property(e => e.NhomHang).HasMaxLength(10);
            entity.Property(e => e.QuiCach).HasMaxLength(200);
            entity.Property(e => e.Slg1Lo)
                .HasColumnType("numeric(9, 2)")
                .HasColumnName("SLg1Lo");
            entity.Property(e => e.Ten).HasMaxLength(100);
            entity.Property(e => e.TenNhaCc)
                .HasMaxLength(100)
                .HasColumnName("TenNhaCC");
            entity.Property(e => e.TinhTrang).HasDefaultValue(true);
           
        });

        modelBuilder.Entity<DmHangHoaBo>(entity =>
        {
            entity.HasKey(e => new { e.MaBo, e.MaHang });

            entity.ToTable("DM_HangHoa_Bo");

            entity.Property(e => e.MaBo).HasMaxLength(25);
            entity.Property(e => e.MaHang).HasMaxLength(25);
            entity.Property(e => e.Cap1).HasColumnType("money");
            entity.Property(e => e.Cap2).HasColumnType("money");
            entity.Property(e => e.Cap3).HasColumnType("money");
            entity.Property(e => e.Cap4).HasColumnType("money");
            entity.Property(e => e.DonGia).HasColumnType("money");
            entity.Property(e => e.GiaLe).HasColumnType("money");
            entity.Property(e => e.GiaNhap).HasColumnType("money");
            entity.Property(e => e.GiaSi).HasColumnType("money");
            entity.Property(e => e.KhuyenMaiBanBuon).HasColumnType("numeric(4, 2)");
            entity.Property(e => e.KhuyenMaiBanLe).HasColumnType("numeric(4, 2)");
            entity.Property(e => e.KhuyenMaiNhap).HasColumnType("numeric(4, 2)");
            entity.Property(e => e.Soluong).HasColumnName("soluong");
            entity.Property(e => e.Stt).HasColumnName("STT");
        });

        modelBuilder.Entity<DmHangHoaDvt>(entity =>
        {
            entity.HasKey(e => new { e.HangHoa, e.Dvt });

            entity.ToTable("DM_HangHoa_DVT");

            entity.Property(e => e.HangHoa).HasMaxLength(25);
            entity.Property(e => e.Dvt)
                .HasMaxLength(10)
                .HasColumnName("DVT");
            entity.Property(e => e.GiaLe).HasColumnType("money");
            entity.Property(e => e.GiaNhap).HasColumnType("money");
            entity.Property(e => e.GiaSi).HasColumnType("money");
            entity.Property(e => e.SlQuiDoi).HasColumnName("SL_QuiDoi");
            entity.Property(e => e.Stt).HasColumnName("STT");
        });

      
       

        modelBuilder.Entity<DmKhachHang>(entity =>
        {
            entity.HasKey(e => e.Ma);

            entity.ToTable("DM_KhachHang");

            entity.Property(e => e.Ma).HasMaxLength(15);
            entity.Property(e => e.Anh).HasColumnType("image");
            entity.Property(e => e.ChucVu).HasMaxLength(30);
            entity.Property(e => e.ChucVuNguoiDaiDien).HasMaxLength(30);
            entity.Property(e => e.ChucVuNguoiGiaoDich)
                .HasMaxLength(50)
                .HasColumnName("ChucVu_NguoiGiaoDich");
            entity.Property(e => e.Date1).HasColumnType("smalldatetime");
            entity.Property(e => e.Date2).HasColumnType("smalldatetime");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.DiaChiCoQuan).HasMaxLength(200);
            entity.Property(e => e.DiaChiHoaDon)
                .HasMaxLength(100)
                .HasColumnName("DiaChi_HoaDon");
            entity.Property(e => e.DienThoai).HasMaxLength(50);
            entity.Property(e => e.DienThoaiDiDong).HasMaxLength(15);
            entity.Property(e => e.DienThoaiGiamDoc).HasMaxLength(50);
            entity.Property(e => e.DienThoaiNguoiDaiDien).HasMaxLength(30);
            entity.Property(e => e.DienThoaiNguoiGiaoDich)
                .HasMaxLength(50)
                .HasColumnName("DienThoai_NguoiGiaoDich");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.Ghichu).HasColumnType("ntext");
            entity.Property(e => e.GiamDoc).HasMaxLength(50);
            entity.Property(e => e.GioiHanNo).HasColumnType("money");
            entity.Property(e => e.IdcuaHang).HasColumnName("IDCuaHang");
            entity.Property(e => e.Idphuong).HasColumnName("IDPhuong");
            entity.Property(e => e.Idquan).HasColumnName("IDQuan");
            entity.Property(e => e.IdthanhPho).HasColumnName("IDThanhPho");
            entity.Property(e => e.LaKhachHang).HasDefaultValue(true);
            entity.Property(e => e.LinhVuc).HasMaxLength(20);
            entity.Property(e => e.LoaiDoanhNghiep).HasMaxLength(20);
            entity.Property(e => e.MaLienKet).HasMaxLength(20);
            entity.Property(e => e.Mst)
                .HasMaxLength(50)
                .HasColumnName("MST");
            entity.Property(e => e.NganHang).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("smalldatetime");
            entity.Property(e => e.NguoiDaiDien).HasMaxLength(30);
            entity.Property(e => e.NguoiGiaoDich).HasMaxLength(50);
            entity.Property(e => e.Nguon).HasMaxLength(20);
            entity.Property(e => e.Nhanvien).HasMaxLength(10);
            entity.Property(e => e.NhomKh)
                .HasMaxLength(10)
                .HasColumnName("NhomKH");
            entity.Property(e => e.Pass).HasMaxLength(200);
            entity.Property(e => e.TaiKhoan).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(100);
            entity.Property(e => e.TenGiamDoc).HasMaxLength(30);
            entity.Property(e => e.TenGiaoDich).HasMaxLength(50);
            entity.Property(e => e.TenHoaDon)
                .HasMaxLength(100)
                .HasColumnName("Ten_HoaDon");
            entity.Property(e => e.TenNhomKh)
                .HasColumnType("ntext")
                .HasColumnName("TenNhomKH");
            entity.Property(e => e.TinhTrang).HasMaxLength(10);
            entity.Property(e => e.Vung).HasMaxLength(10);
            entity.Property(e => e.Website).HasMaxLength(50);
            entity.Property(e => e.XungDanh).HasMaxLength(30);
        });


        
        modelBuilder.Entity<DmKho>(entity =>
        {
            entity.HasKey(e => e.Ma);

            entity.ToTable("DM_Kho");

            entity.Property(e => e.Ma).HasMaxLength(10);
            entity.Property(e => e.Date1).HasColumnType("smalldatetime");
            entity.Property(e => e.Date2).HasColumnType("smalldatetime");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.IdcuaHang).HasColumnName("IDCuaHang");
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.Ten).HasMaxLength(200);
            entity.Property(e => e.TenThuKho).HasMaxLength(50);
        });

        modelBuilder.Entity<DmKhoHang>(entity =>
        {
            entity.HasKey(e => new { e.Kho, e.HangHoa });

            entity.ToTable("DM_Kho_Hang");

            entity.Property(e => e.Kho).HasMaxLength(10);
            entity.Property(e => e.HangHoa).HasMaxLength(20);
        });


        modelBuilder.Entity<DmLoaiHang>(entity =>
        {
            entity.HasKey(e => e.Ma);

            entity.ToTable("DM_LoaiHang");

            entity.Property(e => e.Ma).HasMaxLength(10);
            entity.Property(e => e.Date1).HasColumnType("smalldatetime");
            entity.Property(e => e.Date2).HasColumnType("smalldatetime");
            entity.Property(e => e.MucThuongLanhDao).HasColumnType("numeric(9, 2)");
            entity.Property(e => e.MucThuongNhanVien).HasColumnType("numeric(9, 2)");
            entity.Property(e => e.Ten).HasMaxLength(50);
        });

       
       

        

        modelBuilder.Entity<DmNganhHang>(entity =>
        {
            entity.HasKey(e => e.Ma).HasName("PK_DM_ChungLoai");

            entity.ToTable("DM_NganhHang");

            entity.Property(e => e.Ma).HasMaxLength(10);
            entity.Property(e => e.Date1).HasColumnType("smalldatetime");
            entity.Property(e => e.Date2).HasColumnType("smalldatetime");
            entity.Property(e => e.Ten).HasMaxLength(100);
            entity.Property(e => e.TinhTrang).HasDefaultValue(true);
        });

       

      

        modelBuilder.Entity<DmNhanvien>(entity =>
        {
            entity.HasKey(e => e.Ma);

            entity.ToTable("DM_Nhanvien");

            entity.Property(e => e.Ma).HasMaxLength(10);
            
            entity.Property(e => e.Chucvu).HasMaxLength(50);
            
            
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.DienThoai).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.Ten).HasMaxLength(100);
        });

        modelBuilder.Entity<DmNhomHang>(entity =>
        {
            entity.HasKey(e => e.Ma);

            entity.ToTable("DM_NhomHang");

            entity.Property(e => e.Ma).HasMaxLength(10);
            entity.Property(e => e.Cap1).HasColumnType("money");
            entity.Property(e => e.Cap2).HasColumnType("money");
            entity.Property(e => e.Date1).HasColumnType("smalldatetime");
            entity.Property(e => e.Date2).HasColumnType("smalldatetime");
            entity.Property(e => e.GiaBuon).HasColumnType("money");
            entity.Property(e => e.GiaLe).HasColumnType("money");
            entity.Property(e => e.GiaSi).HasColumnType("money");
            entity.Property(e => e.LoaiNhom).HasMaxLength(20);
            entity.Property(e => e.NganhHang).HasMaxLength(10);
            entity.Property(e => e.Ten).HasMaxLength(100);
            entity.Property(e => e.TinhTrang).HasDefaultValue(true);
        });


        modelBuilder.Entity<DmNhomKh>(entity =>
        {
            entity.HasKey(e => e.Ma);

            entity.ToTable("DM_NhomKH");

            entity.Property(e => e.Ma).HasMaxLength(10);
            entity.Property(e => e.DatQuyen).HasMaxLength(200);
            entity.Property(e => e.Date1).HasColumnType("smalldatetime");
            entity.Property(e => e.Date2).HasColumnType("smalldatetime");
            entity.Property(e => e.QuyenXem).HasColumnType("ntext");
            entity.Property(e => e.Stt)
                .HasMaxLength(10)
                .HasColumnName("STT");
            entity.Property(e => e.Ten).HasMaxLength(100);
        });

 

        modelBuilder.Entity<SoCaiDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SoCai_Detail");

            entity.Property(e => e.ChietKhau)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.ChungTu)
                .HasMaxLength(30)
                .HasColumnName("Chung_tu");
            entity.Property(e => e.Date1).HasColumnType("smalldatetime");
            entity.Property(e => e.Date2).HasColumnType("smalldatetime");
            entity.Property(e => e.Dongia).HasColumnType("money");
            entity.Property(e => e.Dvt)
                .HasMaxLength(50)
                .HasColumnName("DVT");
            entity.Property(e => e.GiaVon)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.HanSuDung).HasColumnType("smalldatetime");
            entity.Property(e => e.HangHoa).HasMaxLength(25);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Kho).HasMaxLength(20);
            entity.Property(e => e.KhuyenMai)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.LyDo)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.MucThue).HasColumnType("money");
            entity.Property(e => e.NgayHoaDon).HasColumnType("smalldatetime");
            entity.Property(e => e.Nhanvien).HasMaxLength(20);
            entity.Property(e => e.PhieuDatHang).HasMaxLength(50);
            entity.Property(e => e.QuiCach).HasMaxLength(10);
            entity.Property(e => e.SlGiaVon)
                .HasColumnType("numeric(9, 2)")
                .HasColumnName("SL_GiaVon");
            entity.Property(e => e.SlQuiDoi)
                .HasDefaultValue(1m)
                .HasColumnType("numeric(9, 2)")
                .HasColumnName("SL_QuiDoi");
            entity.Property(e => e.SoHoaDon).HasMaxLength(50);
            entity.Property(e => e.SoLo).HasMaxLength(20);
            entity.Property(e => e.SoLuong)
                .HasColumnType("numeric(9, 2)")
                .HasColumnName("So_Luong");
            entity.Property(e => e.SoThe).HasMaxLength(50);
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.TenHang)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.ThanhTien)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.ViSa).HasMaxLength(20);
        });


        modelBuilder.Entity<ViewSocai>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_socai");

            entity.Property(e => e.ChiPhiNgoai).HasColumnType("money");
            entity.Property(e => e.ChiPhiNoi).HasColumnType("money");
            entity.Property(e => e.ChietKhau).HasColumnType("money");
            entity.Property(e => e.ChungTu)
                .HasMaxLength(30)
                .HasColumnName("Chung_tu");
            entity.Property(e => e.ConLai).HasColumnType("money");
            entity.Property(e => e.Date1)
                .HasColumnType("smalldatetime")
                .HasColumnName("date1");
            entity.Property(e => e.Date2)
                .HasColumnType("smalldatetime")
                .HasColumnName("date2");
            entity.Property(e => e.DiaDiemBanGiao).HasMaxLength(50);
            entity.Property(e => e.Diachi).HasMaxLength(150);
            entity.Property(e => e.DoiTuong).HasMaxLength(20);
            entity.Property(e => e.GhiChuDonVi).HasMaxLength(100);
            entity.Property(e => e.Ghichu).HasMaxLength(250);
            entity.Property(e => e.HinhThucThanhToan).HasMaxLength(10);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.IdcuaHang).HasColumnName("IDCuaHang");
            entity.Property(e => e.KhachHang).HasMaxLength(15);
            entity.Property(e => e.Kho).HasMaxLength(15);
            entity.Property(e => e.KhoanMuc).HasMaxLength(10);
            entity.Property(e => e.KhuyenMai).HasColumnType("money");
            entity.Property(e => e.KhuyenMaiHoaDon)
                .HasColumnType("money")
                .HasColumnName("KhuyenMai_HoaDon");
            entity.Property(e => e.LePhi).HasColumnType("money");
            entity.Property(e => e.LoaiCt)
                .HasMaxLength(15)
                .HasColumnName("LoaiCT");
            entity.Property(e => e.LoaiTien).HasMaxLength(5);
            entity.Property(e => e.Mst)
                .HasMaxLength(30)
                .HasColumnName("MST");
            entity.Property(e => e.MucThue).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.NganHang).HasMaxLength(10);
            entity.Property(e => e.Ngay).HasColumnType("datetime");
            entity.Property(e => e.NgayHenTra).HasColumnType("smalldatetime");
            entity.Property(e => e.NgayHoaDon).HasColumnType("smalldatetime");
            entity.Property(e => e.NgayNhanHang).HasColumnType("smalldatetime");
            entity.Property(e => e.NgayNhanHoaDon).HasColumnType("smalldatetime");
            entity.Property(e => e.NgayNopThue).HasColumnType("smalldatetime");
            entity.Property(e => e.NguoiMua).HasMaxLength(50);
            entity.Property(e => e.NhanVien1).HasMaxLength(15);
            entity.Property(e => e.Nhanvien).HasMaxLength(15);
            entity.Property(e => e.PhaiTra).HasColumnType("money");
            entity.Property(e => e.PhieuDatHang).HasMaxLength(30);
            entity.Property(e => e.PhieuGiaoHang).HasMaxLength(50);
            entity.Property(e => e.PsCo).HasColumnType("money");
            entity.Property(e => e.PsNo).HasColumnType("money");
            entity.Property(e => e.SoHoaDon).HasMaxLength(100);
            entity.Property(e => e.SoHopDong).HasMaxLength(50);
            entity.Property(e => e.SqlDetail).HasColumnName("SQL_Detail");
            entity.Property(e => e.Ten).HasMaxLength(100);
            entity.Property(e => e.ThanhTien).HasColumnType("money");
            entity.Property(e => e.ThanhToan).HasColumnType("money");
            entity.Property(e => e.The).HasMaxLength(20);
            entity.Property(e => e.TienHang).HasColumnType("money");
            entity.Property(e => e.TienTe).HasMaxLength(5);
            entity.Property(e => e.TienThue).HasColumnType("money");
            entity.Property(e => e.TinhTrang).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.TyGia).HasColumnType("money");
            entity.Property(e => e.User1).HasColumnName("user1");
            entity.Property(e => e.User2).HasColumnName("user2");
        });
     
   

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
