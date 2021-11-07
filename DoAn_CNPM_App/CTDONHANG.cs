namespace DoAn_CNPM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDONHANG")]
    public partial class CTDONHANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaDH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MaLK { get; set; }

        [Key]
        [Column(Order = 2)]
        public double DonGia { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SoLuong { get; set; }

        [Key]
        [Column(Order = 4)]
        public double GiamGia { get; set; }

        public virtual DONHANG DONHANG { get; set; }

        public virtual LINHKIEN LINHKIEN { get; set; }
    }
}
