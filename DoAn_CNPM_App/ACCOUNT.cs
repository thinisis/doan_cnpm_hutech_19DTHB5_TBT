namespace DoAn_CNPM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCOUNT")]
    public partial class ACCOUNT
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [StringLength(20)]
        public string username { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string lv { get; set; }

        [StringLength(10)]
        public string MaNV { get; set; }

        public virtual ACCOUNTLV ACCOUNTLV { get; set; }
    }
}
