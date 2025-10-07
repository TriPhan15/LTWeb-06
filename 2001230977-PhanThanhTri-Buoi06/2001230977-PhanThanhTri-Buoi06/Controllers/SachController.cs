using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001230977_PhanThanhTri_Buoi06.Models;
using _2001230977_PhanThanhTri_Buoi06.ViewsModel;
namespace _2001230977_PhanThanhTri_Buoi06.Controllers
{
    public class SachController : Controller
    {
        //
        // GET: /Sach/
        DuLieu csdl = new DuLieu();
        public ActionResult Index()
        {
            List<Loai> sp = csdl.dsl;
            return View(sp);
        }
        public ActionResult Xuat_SanPham_Loai(string ma)
        {
            SanPham_Loai_Model em = new SanPham_Loai_Model();
            if (ma==null)
            {
                em.DSL = csdl.dsl;
                em.DSSP = csdl.dssp; 
            }
            else
            {
                em.DSL = csdl.DSL(ma);
                em.DSSP = csdl.DSSP(ma);
            }
            return View(em);
        }
        [HttpGet]
        public ActionResult ChiTietSachSanPham(string maSanPham)
        {
            SanPham sanpham = csdl.ChiTietSanPham(maSanPham);
            return View(sanpham);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string phone, string password)
        {
            KhachHang khachHang = csdl.Login(phone, password);
            if (khachHang != null)
            {
                Session["KhachHang"] = khachHang;
                return RedirectToAction("Xuat_SanPham_Loai", "Sach", new { maLoai = -1 });
            }
            else
            {
                ViewBag.Message = "FAILURE";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TimKiemTheoLoai()
        {
            var em = new SanPham_Loai_Model
            {
                DSSP = csdl.dssp,
                DSL = csdl.dsl,
                SelectedMaLoai = "0"
            };
            return View(em);
        }

        [HttpPost]
        public ActionResult TimKiemTheoLoai(string ma)
        {
            var model = new SanPham_Loai_Model
            {
                DSSP = (ma == "0" || string.IsNullOrEmpty(ma)) ? csdl.dssp : csdl.TimKiemTheoLoai(ma),
                DSL = csdl.dsl,
                SelectedMaLoai = ma
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult TimKiemTheoGia()
        {
            var em = new SanPham_Loai_Model
            {
                DSSP = csdl.dssp,
                DSL = csdl.dsl
            };
            return View(em);
        }

        [HttpPost]
        public ActionResult TimKiemTheoGia(double GiaTu, double GiaDen)
        {
            var model = new SanPham_Loai_Model
            {
                DSSP = csdl.TimKiemTheoGia(GiaTu, GiaDen),
                DSL = csdl.dsl,
                GiaTu = GiaTu,
                GiaDen = GiaDen
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult LichSuGiaoDich()
        {
            KhachHang kh = Session["KhachHang"] as KhachHang;
            if (kh == null)
            {
                return RedirectToAction("Login", "Sach");
            }
            HoaDon_Full_Model model = new HoaDon_Full_Model();
             model.DSHD = csdl.DSHD();
            model.DSCT = new List<ChiTiet>();
            return View(model);
        }
        public ActionResult ChiTietHoaDon(string maHD)
        {
            KhachHang kh = Session["KhachHang"] as KhachHang;
            if (kh == null)
            {
                return RedirectToAction("Login", "Sach");
            }
            HoaDon_Full_Model model = new HoaDon_Full_Model();
            model.DSHD = csdl.DSHD();               
            model.DSCT = csdl.ChiTietHoaDon(maHD);  

            return View("LichSuGiaoDich", model); 
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Xuat_SanPham_Loai", "Sach", new { maLoai = -1 });
        }
    }
}
