namespace DoAn_CNPM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TINHTRANGLK_GIATRI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TINHTRANGLK_GIATRI()
        {
            LINHKIENs = new HashSet<LINHKIEN>();
        }

        [Key]
        public bool TinhTrang { get; set; }

        [Required]
        [StringLength(20)]
        public string GiaTri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LINHKIEN> LINHKIENs { get; set; }
    }
}
