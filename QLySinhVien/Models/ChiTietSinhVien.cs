namespace QLySinhVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSinhVien")]
    public partial class ChiTietSinhVien
    {
        [Key]
        [StringLength(15)]
        public string MaSinhVien { get; set; }

        public int MaLSH { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        public bool GioiTinh { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public virtual LopSinhHoat LopSinhHoat { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
