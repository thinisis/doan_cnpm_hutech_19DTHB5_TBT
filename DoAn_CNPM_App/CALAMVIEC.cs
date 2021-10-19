namespace DoAn_CNPM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CALAMVIEC")]
    public partial class CALAMVIEC
    {
        [Key]
        [StringLength(10)]
        public string MaCa { get; set; }

        [StringLength(10)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string ThoiGianBatDau { get; set; }

        [StringLength(50)]
        public string ThoiGianKetThuc { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Ngay { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
