using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBookStore.Models;
using PagedList.Mvc;
using PagedList;

namespace MVCBookStore.Controllers
{
    public class TimkiemController : Controller
    {
        // GET: Timkiem
        dbQLBansachDataContext db = new dbQLBansachDataContext();
        [HttpPost]
        public ActionResult Ketquatimkiem(FormCollection collection, int ? page)
        {
            string tukhoa = collection["txttimkiem"].ToString();
            ViewBag.Tukhoa = tukhoa;
            List<SACH> lstkqtk = db.SACHes.Where(n => n.Tensach.Contains(tukhoa)).ToList();
            int pageSize = 6;
            int pageNum = (page ?? 1);
            if (lstkqtk.Count == 0)
            {
                ViewBag.Thongbao = "Không tìm thấy sản phẩm nào";
                return View(db.SACHes.OrderBy(n => n.Tensach).ToPagedList(pageNum, pageSize));
            }
            ViewBag.Thongbao = "Đã tìm thấy" + lstkqtk.Count + "Kết quả";
            return View(lstkqtk.OrderBy(n=>n.Tensach).ToPagedList(pageNum, pageSize));
        }
        [HttpGet]
        public ActionResult Ketquatimkiem(string tukhoa, int? page)
        {
            ViewBag.Tukhoa = tukhoa;
            List<SACH> lstkqtk = db.SACHes.Where(n => n.Tensach.Contains(tukhoa)).ToList();
            int pageSize = 6;
            int pageNum = (page ?? 1);
            if (lstkqtk.Count == 0)
            {
                ViewBag.Thongbao = "Không tìm thấy sản phẩm nào";
                return View(db.SACHes.OrderBy(n => n.Tensach).ToPagedList(pageNum, pageSize));
            }
            ViewBag.Thongbao = "Đã tìm thấy" + lstkqtk.Count + "Kết quả";
            return View(lstkqtk.OrderBy(n => n.Tensach).ToPagedList(pageNum, pageSize));
        }
    }
}