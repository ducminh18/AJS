using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AJS.Models;
namespace AJS.Areas.Admin.Controllers
{
    public class HomeAdController : Controller
    {
        // GET: Admin/HomeAd
        LoaiSPModel dblsp = new LoaiSPModel();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }
        public JsonResult GetAllLSP()
        {
            List<LoaiSP> li = dblsp.getAllLoaiSP();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOneLSP(string id)
        {
            LoaiSP li = dblsp.getOneLSP(id);
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateLSP(LoaiSP x)
        {
            dblsp.CreateLSP(x);
            return Json(new { message="Thêm mới thành công"}, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateLSP(LoaiSP x)
        {
            dblsp.UpdateLSP(x);
            return Json(new { message = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteLSP(string id)
        {
            dblsp.DeleteLSP(id);
            return Json(new { message = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
        }
    }
}