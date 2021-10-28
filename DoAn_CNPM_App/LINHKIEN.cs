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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LINHKIEN()
        {
            CTDONHANGs = new HashSet<CTDONHANG>();
        }

        [Key]
        [StringLength(10)]
        public string MaLK { get; set; }

        [Required]
        [StringLength(50)]
        public string MaLoai { get; set; }

        [StringLength(100)]
        public string TenLK { get; set; }

        [StringLength(20)]
        public string Serial { get; set; }

        [StringLength(50)]
        public string XuatXu { get; set; }

        public double? DonGia { get; set; }

        [StringLength(50)]
        public string MaKho { get; set; }

        [StringLength(10)]
        public string MaNCC { get; set; }

        [StringLength(10)]
        public string MaHang { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }

        public virtual HANG HANG { get; set; }

        public virtual KHO KHO { get; set; }

        public virtual LOAILINHKIEN LOAILINHKIEN { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual TINHTRANGLK TINHTRANGLK { get; set; }
    }
}

