using CNPMLyThuyet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPMLyThuyet.Controllers
{
    public class AccountController : Controller
    {
        QuanLyTrungTamThuongMaiEntities4 db = new QuanLyTrungTamThuongMaiEntities4();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(NhanVien nhanvien ) {
            
            var cust = db.NhanViens.Where(k=>k.MaNV == nhanvien.MaNV && k.MatKhau ==nhanvien.MatKhau).FirstOrDefault();
            if ( cust !=null )
            {
                Session["TaiKhoan"] = cust;
                ViewBag.ThongBao = "Đăng nhập thành công ";
                if (cust.MaNV == "AD01" && cust.MatKhau == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "Home");
            }

            else ViewBag.ThongBao = "Tên đăng nhập hoặc tài khoản không đúng ";
            return View();                   
        }

    }
}