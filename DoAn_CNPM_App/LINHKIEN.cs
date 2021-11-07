namespace DoAn_CNPM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LINHKIEN")]
    public partial class LINHKIEN
    {
        [Key]
        [StringLength(50)]
        public string MaLK { get; set; }

        [Required]
        [StringLength(50)]
        public string MaLoai { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLK { get; set; }

        [Required]
        [StringLength(50)]
        public string Serial { get; set; }

        [Required]
        [StringLength(50)]
        public string XuatXu { get; set; }

        public double DonGia { get; set; }

        [Required]
        [StringLength(50)]
        public string MaKho { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNCC { get; set; }

        [Required]
        [StringLength(10)]
        public string MaHang { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgayNhap { get; set; }

        public bool TinhTrang { get; set; }

        public int? SoLuong { get; set; }

[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }

        public virtual HANG HANG { get; set; }

        public virtual KHO KHO { get; set; }

        public virtual LOAILINHKIEN LOAILINHKIEN { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual TINHTRANGLK_GIATRI TINHTRANGLK_GIATRI { get; set; }
    }
}

