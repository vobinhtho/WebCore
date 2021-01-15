using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebCore.DBContextofSQLserver
{
    public partial class QuanLyQuanAnContext : DbContext
    {
        public QuanLyQuanAnContext()
        {
        }

        public QuanLyQuanAnContext(DbContextOptions<QuanLyQuanAnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dondat> Dondats { get; set; }
        public virtual DbSet<Dondatct> Dondatcts { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Loaimonan> Loaimonans { get; set; }
        public virtual DbSet<Monan> Monans { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Nhommonan> Nhommonans { get; set; }
        public virtual DbSet<Taikhoan> Taikhoans { get; set; }
        public virtual DbSet<Toado> Toados { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-T2HE9QU\\SQLEXPRESS;Database=QuanLyQuanAn;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Dondat>(entity =>
            {
                entity.HasKey(e => e.Madondat)
                    .HasName("PK__DONDAT__565EA94532DF4F32");

                entity.ToTable("DONDAT");

                entity.Property(e => e.Madondat)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MADONDAT");

                entity.Property(e => e.Makh)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MAKH");

                entity.Property(e => e.Manv)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MANV");

                entity.Property(e => e.Thoigiandat)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("THOIGIANDAT");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(255)
                    .HasColumnName("TRANGTHAI");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Dondats)
                    .HasForeignKey(d => d.Makh)
                    .HasConstraintName("FK__AT");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Dondats)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK_PHU_TRACH");
            });

            modelBuilder.Entity<Dondatct>(entity =>
            {
                entity.HasKey(e => new { e.Madondat, e.Mamonan })
                    .HasName("PK__DONDATCT__48F81DB4AE4A0F74");

                entity.ToTable("DONDATCT");

                entity.Property(e => e.Madondat)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MADONDAT");

                entity.Property(e => e.Mamonan)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MAMONAN");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.MadondatNavigation)
                    .WithMany(p => p.Dondatcts)
                    .HasForeignKey(d => d.Madondat)
                    .HasConstraintName("FK_DONDATCT");

                entity.HasOne(d => d.MamonanNavigation)
                    .WithMany(p => p.Dondatcts)
                    .HasForeignKey(d => d.Mamonan)
                    .HasConstraintName("FK_DONDATCT2");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahd)
                    .HasName("PK__HOADON__603F20CE03058253");

                entity.ToTable("HOADON");

                entity.Property(e => e.Mahd)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MAHD");

                entity.Property(e => e.IdVoucher).HasColumnName("ID_VOUCHER");

                entity.Property(e => e.Madondat)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MADONDAT");

                entity.Property(e => e.Mamonan)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MAMONAN");

                entity.Property(e => e.Tonghd).HasColumnName("TONGHD");

                entity.HasOne(d => d.IdVoucherNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.IdVoucher)
                    .HasConstraintName("FK_APDUNG2");

                entity.HasOne(d => d.MadondatNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Madondat)
                    .HasConstraintName("FK_CHUA2");

                entity.HasOne(d => d.MamonanNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Mamonan)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_RELATIONSHIP_8");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makh)
                    .HasName("PK__KHACHHAN__603F592CEE0E25E8");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Makh)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MAKH");

                entity.Property(e => e.Diachikh)
                    .HasMaxLength(50)
                    .HasColumnName("DIACHIKH");

                entity.Property(e => e.Matk)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MATK");

                entity.Property(e => e.Sdtkh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDTKH");

                entity.Property(e => e.Tenkh)
                    .HasMaxLength(30)
                    .HasColumnName("TENKH");

                entity.HasOne(d => d.MatkNavigation)
                    .WithMany(p => p.Khachhangs)
                    .HasForeignKey(d => d.Matk)
                    .HasConstraintName("FK_CO_KH2");
            });

            modelBuilder.Entity<Loaimonan>(entity =>
            {
                entity.HasKey(e => e.Maloai)
                    .HasName("PK__LOAIMONA__2F633F232BC88325");

                entity.ToTable("LOAIMONAN");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MALOAI");

                entity.Property(e => e.Tenloai)
                    .HasMaxLength(50)
                    .HasColumnName("TENLOAI");
            });

            modelBuilder.Entity<Monan>(entity =>
            {
                entity.HasKey(e => e.Mamonan)
                    .HasName("PK__MONAN__EA6B4F105BA8CAA6");

                entity.ToTable("MONAN");

                entity.Property(e => e.Mamonan)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MAMONAN");

                entity.Property(e => e.Giaban).HasColumnName("GIABAN");

                entity.Property(e => e.Giagiam).HasColumnName("GIAGIAM");
                entity.Property(e => e.Hinh).HasColumnName("HINHANH");

                entity.Property(e => e.Maloai)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MALOAI");

                entity.Property(e => e.Manhom)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MANHOM");

                entity.Property(e => e.Mieuta)
                    .HasMaxLength(255)
                    .HasColumnName("MIEUTA");

                entity.Property(e => e.Tenmonan)
                    .HasMaxLength(255)
                    .HasColumnName("TENMONAN");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Monans)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("FK_THUOC");

                entity.HasOne(d => d.ManhomNavigation)
                    .WithMany(p => p.Monans)
                    .HasForeignKey(d => d.Manhom)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_THUOC_NHOM");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv)
                    .HasName("PK__NHANVIEN__603F5114001B98A2");

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Manv)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MANV");

                entity.Property(e => e.Diachinv)
                    .HasMaxLength(100)
                    .HasColumnName("DIACHINV");

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GIOITINH");

                entity.Property(e => e.Matk)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MATK");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.Sdtnv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDTNV");

                entity.Property(e => e.Tennv)
                    .HasMaxLength(30)
                    .HasColumnName("TENNV");

                entity.HasOne(d => d.MatkNavigation)
                    .WithMany(p => p.Nhanviens)
                    .HasForeignKey(d => d.Matk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NHANVIEN_TAIKHOAN");
            });

            modelBuilder.Entity<Nhommonan>(entity =>
            {
                entity.HasKey(e => e.Manhom)
                    .HasName("PK__NHOMMONA__2587AA306B8F48A8");

                entity.ToTable("NHOMMONAN");

                entity.Property(e => e.Manhom)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MANHOM");

                entity.Property(e => e.Tennhom)
                    .HasMaxLength(255)
                    .HasColumnName("TENNHOM");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.Matk)
                    .HasName("PK__TAIKHOAN__602372169C2150AF");

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.Matk)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MATK");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Quyensd)
                    .HasMaxLength(30)
                    .HasColumnName("QUYENSD");

                entity.Property(e => e.Status).HasColumnName("STATUS");
            });

            modelBuilder.Entity<Toado>(entity =>
            {
                entity.HasKey(e => e.IdTd)
                    .HasName("PK__TOADO__8B63B1B2017FD31A");

                entity.ToTable("TOADO");

                entity.Property(e => e.IdTd)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_TD");

                entity.Property(e => e.TenCuahang)
                    .HasMaxLength(255)
                    .HasColumnName("TEN_CUAHANG");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(e => e.IdVoucher)
                    .HasName("PK__VOUCHER__B432F8F265AE209F");

                entity.ToTable("VOUCHER");

                entity.Property(e => e.IdVoucher)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_VOUCHER");

                entity.Property(e => e.Mavoucher)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MAVOUCHER");

                entity.Property(e => e.Tenvoucher)
                    .HasMaxLength(255)
                    .HasColumnName("TENVOUCHER");

                entity.Property(e => e.Tylegiamgia).HasColumnName("TYLEGIAMGIA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
