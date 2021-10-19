namespace DoAn_CNPM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THEKHACHHANG")]
    public partial class THEKHACHHANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaThe { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaKH { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayLap { get; set; }

        public int? DiemTichLuy { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
