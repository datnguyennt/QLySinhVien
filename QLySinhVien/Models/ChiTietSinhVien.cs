namespace QLySinhVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSinhVien")]
    public partial class ChiTietSinhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDSinhVien { get; set; }

        [DisplayName("Mã lớpn")]
        public int MaLSH { get; set; }

        [StringLength(15)]
        [DisplayName("Số điện thoại")]
        public string SoDienThoai { get; set; }

        [DisplayName("Giới tính")]
        public bool GioiTinh { get; set; }

        [StringLength(200)]
        [DisplayName("Thư điện tử")]
        public string Email { get; set; }

        public virtual SinhVien SinhVien { get; set; }

        public virtual LopSinhHoat LopSinhHoat { get; set; }
    }
}
