using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;
namespace TAMS.Areas.Admin.Controllers
{
    public class PatientController : Controller
    {
        // GET: Admin/Patient
        private readonly string KeyElement = "Bệnh nhân";
        public ActionResult Index()
        {
            ViewBag.Feature = "Bảng điều khiển";
            ViewBag.Element = KeyElement;
            ViewBag.BaseURL = "/Admin/Patient/Index";
            PatientContext PatientContext = new PatientContext();
            List<Entity.Patient> obj = PatientContext.GetPatient();
            return View(obj);
        }
        
        public ActionResult Create()
        {
            ViewBag.Feature = "Thêm mới";
            ViewBag.Element = KeyElement;
            ViewBag.BaseURL = "/Admin/Patient";

            ViewBag.isEdit = false;
            return View();
        }
        [HttpPost]
        public JsonResult CreatePatient(Entity.Patient obj)
        {

            PatientContext PatientContext = new PatientContext();
       
            int check = PatientContext.Create(obj);
            if (check == 1)
            {
                return Json(new { status = true, mess = "Thêm thành công " , data = new { obj.Id } });
            }
            else
            {  
                    return Json(new { status = false, mess = "Số chứng minh thư đã tồn tại " });
            
            }

        }
        public JsonResult CreatePatient1(Entity.Patient obj)
        {
            PatientContext PatientContext = new PatientContext();
            int check = PatientContext.Create1(obj);
            if (check == 1)
            {
                return Json(new { status = true, mess = "Thêm thành công ", data = new { obj.Id } });
            }
            else
            {
                return Json(new { status = false, mess = "Số chứng minh thư đã tồn tại " });
            }

        }

        [HttpPost]
        public JsonResult Update(Entity.Patient obj)
        {
            PatientContext PatientContext = new PatientContext();
            int check = PatientContext.Update(obj);
            if (check == 1)
            {
                return Json(new { status = true, mess = "Cập nhật thành công ", data = new { obj.Id } });
            }
            else
            {
                return Json(new { status = false, mess = "Số chứng minh thư đã tồn tại " });

            }
        }
        public JsonResult Update1(Entity.Patient obj)
        {
            PatientContext PatientContext = new PatientContext();
            int check = PatientContext.Update1(obj);
            if (check == 1)
            {
                return Json(new { status = true, mess = "Cập nhật thành công ", data = new { obj.Id } });
            }
            else
            {
                return Json(new { status = false, mess = "Số chứng minh thư đã tồn tại " });

            }
        }
        [HttpPost]
        public JsonResult Delete(int Id)
        {

            PatientContext PatientContext = new PatientContext();
            PatientContext.Delete(Id);
            return Json(new { status = true, mess = "Xóa thành công " });

        }
        public ActionResult GetById(int Id)
        {
            ViewBag.isEdit = true;
            ViewBag.Feature = "Cập nhật";
            ViewBag.Element = KeyElement;
            ViewBag.BaseURL = "/Admin/Patient/Index";


            PatientContext PatientContext = new PatientContext();
            Entity.Patient obj = PatientContext.GetById(Id);

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