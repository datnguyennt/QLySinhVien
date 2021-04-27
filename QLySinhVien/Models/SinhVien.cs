namespace QLySinhVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [Key]
        public int IDSinhVien { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Mã sinh viên")]
        public string MaSinhVien { get; set; }

        [StringLength(100)]
        [DisplayName("Bí danh")]
        public string HoTen { get; set; }

        [StringLength(20)]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        public virtual ChiTietSinhVien ChiTietSinhVien { get; set; }
    }
}
