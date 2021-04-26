namespace QLySinhVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LopSinhHoat")]
    public partial class LopSinhHoat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LopSinhHoat()
        {
            ChiTietSinhVien = new HashSet<ChiTietSinhVien>();
        }

        [Key]
        public int MaLSH { get; set; }

        public int MaKhoa { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLSH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSinhVien> ChiTietSinhVien { get; set; }
    }
}
