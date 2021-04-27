using QLySinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLySinhVien.Controllers
{
    public class SinhVienController : Controller
    {
        DBSinhVienContext context = new DBSinhVienContext();
        // GET: SinhVien
        //Hiển thị danh sách sinh viên truy vấn linq nhiều bảng sau đó add vào model tự tạo gồm các trường liên quan
        public ActionResult Index(string searchName, string searchClass)
        {
            //Khởi tạo DBcontext của sinh viên
            var lstSinhVien = new DBSinhVienContext();

            //Tạo list result chứa thông tin dựa trên SinhVienViewModel
            //Câu lệnh linq kết hợp 3 bảng để lấy thông tin cần in ra
            var result = from ctsv in lstSinhVien.ChiTietSinhVien
                         join sv in lstSinhVien.SinhVien on ctsv.IDSinhVien equals sv.IDSinhVien
                         join lsh in lstSinhVien.LopSinhHoat on ctsv.MaLSH equals lsh.MaLSH
                         select new SinhVienViewModel
                         {
                             IDSinhVien = sv.IDSinhVien,
                             HoTen = sv.HoTen,
                             TenLSH = lsh.TenLSH,
                             SoDienThoai = ctsv.SoDienThoai,
                             Email = ctsv.Email
                         };

            //Code tìm kiếm tên sinh viên
            if (!string.IsNullOrEmpty(searchName))
            {
                result = result.Where(x => x.HoTen.Contains(searchName)).OrderByDescending(x => x.HoTen); //Tìm kiếm thông tin và trả về list result
                if (result.Count() <= 0) //Đếm nếu <= 0 nghĩa là không tồn tại sinh viên đó
                {
                    //Gửi viewbag thông báo tới trang index
                    ViewBag.result = "Không tìm thấy sinh viên cần tìm";

                }
            }

            //Code tìm kiếm thông tin về lớp học
            if (!string.IsNullOrEmpty(searchClass))
            {
                result = result.Where(x => x.TenLSH.Contains(searchClass)).OrderByDescending(x => x.HoTen);
                if (result.Count() <= 0)
                {
                    ViewBag.result = "Không tìm thấy sinh viên thuộc lớp cần tìm";

                }
            }
            return View(result.ToList());
        }

        // GET: SinhVien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SinhVien/Create
        public ActionResult Create()
        {
            var context = new DBSinhVienContext();
            List<LopSinhHoat> list = context.LopSinhHoat.ToList();
            ViewBag.LopSHList = new SelectList(list, "MaLSH", "TenLSH");

            return View();
        }

        // POST: SinhVien/Create
        //Thêm sinh viên, xử lý thêm ở phần POST
        [HttpPost]
        public ActionResult Create(SinhVienViewModel model)
        {
            try
            {
                //Insert dữ liệu vào nhiều bảng khác nhau 
                // TODO: Add insert logic here
                var context = new DBSinhVienContext();
                List<LopSinhHoat> list = context.LopSinhHoat.ToList();
                ViewBag.LopSHList = new SelectList(list, "MaLSH", "TenLSH");

                //Khởi tạo lớp sinh viên để thêm trước
                SinhVien sv = new SinhVien();
                sv.MaSinhVien = model.MaSinhVien;
                sv.MatKhau = model.MatKhau;
                sv.HoTen = model.HoTen;
                context.SinhVien.Add(sv);
                context.SaveChanges();//Lưu lại

                //Lấy id của sinh viên (đã tự động tạo) từ table sinh viên sau đó truyền vào cho table chitietsinhvien 
                int id = sv.IDSinhVien;

                ChiTietSinhVien ctsv = new ChiTietSinhVien();
                ctsv.IDSinhVien = sv.IDSinhVien; //Thêm ID ở chỗ này nè
                ctsv.GioiTinh = model.GioiTinh;
                ctsv.Email = model.Email;
                ctsv.SoDienThoai = model.SoDienThoai;
                ctsv.MaLSH = model.MaLSH;
                context.ChiTietSinhVien.Add(ctsv);
                context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SinhVien/Edit/5
        public ActionResult Edit(int id)
        {
            var context = new DBSinhVienContext();
            var sinhvien = context.ChiTietSinhVien.Find(id);
            List<LopSinhHoat> list = context.LopSinhHoat.ToList();
            ViewBag.LopSHList = new SelectList(list, "MaLSH", "TenLSH");

            return View(sinhvien);

        }

        // POST: SinhVien/Edit/5
        [HttpPost]
        public ActionResult Edit(ChiTietSinhVien model)
        {
            try
            {
                // TODO: Add update logic here
                var context = new DBSinhVienContext();
                var old = context.ChiTietSinhVien.Find(model.IDSinhVien);

                old.IDSinhVien = model.IDSinhVien;
                old.MaLSH = model.MaLSH;
                old.SoDienThoai = model.SoDienThoai;
                //old.SinhVien.HoTen = model.SinhVien.HoTen;
                old.Email = model.Email;

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SinhVien/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new DBSinhVienContext();
            var delete = context.ChiTietSinhVien.Find(id);

            return View(delete);
        }

        // POST: SinhVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var context = new DBSinhVienContext();
                var delete1 = context.SinhVien.Find(id);
                var delete2 = context.ChiTietSinhVien.Find(id);
                context.SinhVien.Remove(delete1);
                context.ChiTietSinhVien.Remove(delete2);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
