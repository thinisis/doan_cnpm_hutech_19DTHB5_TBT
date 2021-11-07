using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoAn_CNPM_App
{
    public partial class EntityFramework : DbContext
    {
        public EntityFramework()
            : base("name=EntityFramework")
        {
        }
        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<ACCOUNTLV> ACCOUNTLVs { get; set; }
        public virtual DbSet<CALAMVIEC> CALAMVIECs { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<HANG> HANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<KHO> KHOes { get; set; }
        public virtual DbSet<LINHKIEN> LINHKIENs { get; set; }
        public virtual DbSet<LOAILINHKIEN> LOAILINHKIENs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<THEKHACHHANG> THEKHACHHANGs { get; set; }
        public virtual DbSet<TINHTRANGLK_GIATRI> TINHTRANGLK_GIATRI { get; set; }
        public virtual DbSet<CTDONHANG> CTDONHANGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.lv)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNTLV>()
                .Property(e => e.lv)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNTLV>()
                .HasMany(e => e.ACCOUNTs)
                .WithRequired(e => e.ACCOUNTLV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CALAMVIEC>()
                .Property(e => e.MaCa)
                .IsUnicode(false);

            modelBuilder.Entity<CALAMVIEC>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<CALAMVIEC>()
                .Property(e => e.ThoiGianBatDau)
                .IsUnicode(false);

            modelBuilder.Entity<CALAMVIEC>()
                .Property(e => e.ThoiGianKetThuc)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MaDH)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .HasMany(e => e.CTDONHANGs)
                .WithRequired(e => e.DONHANG)
                .HasForeignKey(e => e.MaDH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HANG>()
                .Property(e => e.MaHang)
                .IsUnicode(false);

            modelBuilder.Entity<HANG>()
                .HasMany(e => e.LINHKIENs)
                .WithRequired(e => e.HANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.DONHANGs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.THEKHACHHANGs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHO>()
                .Property(e => e.MaKho)
                .IsUnicode(false);

            modelBuilder.Entity<KHO>()
                .HasMany(e => e.LINHKIENs)
                .WithRequired(e => e.KHO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LINHKIEN>()
                .Property(e => e.MaLK)
                .IsUnicode(false);

            modelBuilder.Entity<LINHKIEN>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<LINHKIEN>()
                .Property(e => e.Serial)
                .IsUnicode(false);

            modelBuilder.Entity<LINHKIEN>()
                .Property(e => e.MaKho)
                .IsUnicode(false);

            modelBuilder.Entity<LINHKIEN>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<LINHKIEN>()
                .Property(e => e.MaHang)
                .IsUnicode(false);

            modelBuilder.Entity<LINHKIEN>()
                .HasMany(e => e.CTDONHANGs)
                .WithRequired(e => e.LINHKIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAILINHKIEN>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<LOAILINHKIEN>()
                .HasMany(e => e.LINHKIENs)
                .WithRequired(e => e.LOAILINHKIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.LINHKIENs)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.ACCOUNTs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.DONHANGs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THEKHACHHANG>()
                .Property(e => e.MaThe)
                .IsUnicode(false);

            modelBuilder.Entity<THEKHACHHANG>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<TINHTRANGLK_GIATRI>()
                .HasMany(e => e.LINHKIENs)
                .WithRequired(e => e.TINHTRANGLK_GIATRI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CTDONHANG>()
                .Property(e => e.MaDH)
                .IsUnicode(false);

            modelBuilder.Entity<CTDONHANG>()
                .Property(e => e.MaLK)
                .IsUnicode(false);
        }
    }
}