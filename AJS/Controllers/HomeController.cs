using AJS.Interface.Models;
using AJS.Models;
using AJS.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJS.Controllers
{
    public class HomeController : Controller
    {
        private ProductService _product = new ProductService();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("GetAll")]
        public JsonResult GetAll()
        {
            return Json(_product.GetList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("Detail")]
        public JsonResult Detail(string id)
        {
            return Json(_product.GetById(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("Delete")]
        public JsonResult Delete(string id)
        {
            return Json(new { message = _product.Delete(id) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("AddOrEdit")]
        public JsonResult AddOrEdit(Product prod)
        {
            return Json(new { message = _product.AddOrUpdate(prod) }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        [ActionName("GetByID")]
        public JsonResult GetByID(string id)
        {
            return Json(_product.GetById(id), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DetailPage(string id)
        {
            return View(_product.GetById(id));
        }
    }
}