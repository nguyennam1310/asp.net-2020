using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;

namespace TAMS.Areas.Admin.Controllers
{
    public class NewsController : SessionController
    {
        // GET: Admin/News
        private readonly string KeyElement = "Tin tức";
        public ActionResult Index()
        {
            ViewBag.Feature = "Bảng điều khiển";
            ViewBag.Element = KeyElement;
            ViewBag.BaseURL = "/Admin/News/Index";
            NewsContext newsContext = new NewsContext();
            List<Entity.News> obj = newsContext.GetNews();
            return View(obj);
        }

        public ActionResult Create()
        {
            ViewBag.Feature = "Thêm mới";
            ViewBag.Element = KeyElement;
            ViewBag.BaseURL = "/Admin/News/Create";

            ViewBag.isEdit = false;
            return View();
        }
        [HttpPost]
        public JsonResult CreateNews(Entity.News obj)
        {
           
            NewsContext newsContext = new NewsContext();
            newsContext.Create(obj);
            return Json(new { status = true, mess = "Thêm thành công " });

        }
        public JsonResult CreateNews1(Entity.News obj)
        {
            NewsContext newsContext = new NewsContext();
            newsContext.Create1(obj);
            return Json(new { status = true , mess = "Thêm thành công " });

        }

        [HttpPost]
        public JsonResult Update(Entity.News obj)
        {
            NewsContext newsContext = new NewsContext();
            newsContext.Update(obj);
            return Json(new { status = true, mess = "Cập nhật thành công " });
        }
        public JsonResult Update1(Entity.News obj)
        {
            NewsContext newsContext = new NewsContext();
            newsContext.Update1(obj);
            return Json(new { status = true, mess = "Cập nhật thành công " });
        }
        [HttpPost]
        public JsonResult Delete(int Id)
        {

            NewsContext newsContext = new NewsContext();
             newsContext.Delete(Id);
            return Json(new { status = true, mess = "Xóa thành công "  });

        }
        public ActionResult GetById(int Id)
        {
            ViewBag.isEdit = true;
            ViewBag.Feature = "Cập nhật";
            ViewBag.Element = KeyElement;



            NewsContext newsContext = new NewsContext();
            Entity.News obj = newsContext.GetById(Id);

            if (obj != null)
            {
                return View("Create", obj);
            }
            else
            {
                return RedirectToAction("Create", "Index");
            }

        }

    }
}