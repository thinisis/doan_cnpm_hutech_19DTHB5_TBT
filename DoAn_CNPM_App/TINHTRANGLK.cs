namespace DoAn_CNPM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TINHTRANGLK")]
    public partial class TINHTRANGLK
    {
        [Key]
        [StringLength(10)]
        public string MaLK { get; set; }

        public bool TinhTrang { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayBan { get; set; }

        public virtual LINHKIEN LINHKIEN { get; set; }
    }
}
