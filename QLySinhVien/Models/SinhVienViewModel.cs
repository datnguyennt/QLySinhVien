using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLySinhVien.Models
{
    public partial class SinhVienViewModel
    {
        [DisplayName("Mã sinh viên")]
        public string MaSinhVien { get; set; }

        [DisplayName("Bí danh")]
        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(20)]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        [Display(Name ="Mã lớp")]
        public int MaLSH { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Lớp")]
        public string TenLSH { get; set; }

        [DisplayName("Số điện thoại")]
        public string SoDienThoai { get; set; }

        [DisplayName("Giới tính")]
        public bool GioiTinh { get; set; }

        [StringLength(200)]
        [DisplayName("Thư điện tử")]
        public string Email { get; set; }

        public virtual ChiTietSinhVien ChiTietSinhVien { get; set; }
        public virtual SinhVien SinhVien { get; set; }
        public virtual LopSinhHoat LopSinhHoat { get; set; }



    }
}