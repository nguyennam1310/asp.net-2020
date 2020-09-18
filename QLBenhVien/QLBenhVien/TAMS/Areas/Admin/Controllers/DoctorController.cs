using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;
namespace TAMS.Areas.Admin.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Admin/Doctor
     
        private const string KeyElement = "Bác sĩ";

     
        public ActionResult Index()
        {
            ViewBag.Feature = "Danh sách";
            ViewBag.Element = KeyElement;

            ViewBag.BaseURL = "/Admin/Doctor/Index";
            DoctorContext DoctorContext = new DoctorContext();
            List<Entity.Doctor> obj = DoctorContext.GetDoctors();

            FacultyContext FacultyContext = new FacultyContext();
            List<Entity.Faculty> faculties = FacultyContext.GetFaculty();
            ViewBag.Faculties = new SelectList(faculties, "Id", "Name");
            return View(obj);
        }

        [HttpPost]
        public JsonResult GetJson(int Id)
        {
            DoctorContext DoctorContext = new DoctorContext();
            Entity.Doctor doctor = DoctorContext.GetById(Id);


            return doctor == default ?
                    Json(new
                    {
                        status = false,
                        mess = "Có lỗi xảy ra: "
                    }) :
                    Json(new
                    {
                        status = true,
                        mess = "Lấy thành công " + KeyElement,
                        data = new
                        {
                            doctor.Id,
                            doctor.Name,
                            doctor.Address,
                            doctor.Email,
                            doctor.Phone,
                            doctor.FacultyId,
                            doctor.Gender
                        }
                    });
            
        }

        [HttpPost]
        public JsonResult GetDoctors(int facultyId)
        {

            DoctorContext DoctorContext = new DoctorContext();
            List<Entity.Doctor> obj = DoctorContext.GetDoctor(facultyId);
           
                return
                    Json(new
                    {
                        status = true,
                        mess = "Lấy thành công " + KeyElement,
                        data = obj.Select(x => new
                        {
                            x.Id,
                            x.Name
                        })
                    });
           
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEdit(Entity.Doctor obj, bool isEdit)
        {
            try
            {
                if (isEdit) //update
                {
                  
                    DoctorContext DoctorContext = new DoctorContext();
                    DoctorContext.Update(obj);
                    return Json(new { status = true, mess = "Cập nhật thành công " });

                }
                else //Thêm mới
                {
                   
                    DoctorContext DoctorContext = new DoctorContext();
                    DoctorContext.Create(obj);
                    return Json(new { status = true, mess = "Thêm thành công " });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    mess = "Có lỗi xảy ra: " + ex.Message
                });
            }
        }

        [HttpPost]
        public JsonResult Del(int Id)
        {
            DoctorContext DoctorContext = new DoctorContext();
            DoctorContext.Delete(Id);
            return Json(new { status = true, mess = "Xóa thành công " });

        }
    }
}