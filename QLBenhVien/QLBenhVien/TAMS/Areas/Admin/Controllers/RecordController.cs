using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;

namespace TAMS.Areas.Admin.Controllers
{
    public class RecordController : SessionController
    {
        public static class StatusRecord
        {
            public const int InpatientTreatment = 1;
            public const int OutPatientTreatment = 0;

            public static string GetText(int stt)
            {
                switch (stt)
                {
                    case 1:
                        return "Điều trị nội trú";

                    case 0:
                        return "Điều trị ngoại trú";

                    default:
                        return "Unknown";
                }
            }

            public static List<Entity.SelectListModel> GetDic()
            {
                return new List<Entity.SelectListModel>
                {
                    new Entity.SelectListModel
                    {
                        Value = 1, Text = "Điều trị nội trú"
                    },
                    new Entity.SelectListModel
                    {
                        Value = 0, Text = "Điều trị ngoại trú"
                    }
                };
            }
        }
        private readonly string KeyElement = "Bệnh án";
        // GET: Admin/Record
        public ActionResult Index(int Id)
        {
            ViewBag.Feature = "Bệnh án";
            ViewBag.Element = "Bệnh nhân";
            ViewBag.BaseURL = "/Admin/Patient/Index";
            ViewBag.Id = Id;
            FacultyContext FacultyContext = new FacultyContext();
            List<Entity.Faculty> faculties = FacultyContext.GetFaculty();
            ViewBag.Faculties = new SelectList(faculties, "Id", "Name");
            DoctorContext DoctorContext = new DoctorContext();
            List<Entity.Doctor> doctor = DoctorContext.GetDoctors();
            ViewBag.Doctors = new SelectList(doctor, "Id", "Name");
            var lstStatus = StatusRecord.GetDic();
            ViewBag.ListStatus = new SelectList(lstStatus, "Value", "Text");
            RecordContext RecordContext = new RecordContext();
            Entity.Record record = RecordContext.GetById(Id);
            PatientContext PatientContext = new PatientContext();
            Entity.Patient patient = PatientContext.GetById(Id);
            ViewBag.Record = record;
            ViewBag.Patient = patient;
            DetailRecordContext detailRecordContext = new DetailRecordContext();
            List<Entity.DetailRecord> obj = detailRecordContext.GetDetailRecord(Id);

            return View(obj);
        }
        [HttpPost]
        public JsonResult Update(Entity.Record obj)
        {
            RecordContext RecordContext = new RecordContext();
            RecordContext.Update(obj);
            return Json(new { status = true, mess = "Cập nhật thành công " });
        }
        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEdit(Entity.DetailRecord obj)
        {
            try
            {
                if (obj.isEdit) //update
                {
                    obj.DoctorId = obj.DetailDoctorId;
                    DetailRecordContext DetailRecordContext = new DetailRecordContext();
                    DetailRecordContext.Update(obj);
                  
                    return Json(new
                    {
                        status = true,
                        mess = "Cập nhập thành công ",
                        data = new
                        {
                            detailRecordId = obj.Id
                        }
                    });

                }
                else //Thêm mới
                {
                    obj.DoctorId = obj.DetailDoctorId;
                    DetailRecordContext DetailRecordContext = new DetailRecordContext();
                    DetailRecordContext.Create(obj);
                    
                    return Json(new
                    {
                        status = true,
                        mess = "Thêm thành công " + KeyElement,
                        data = new
                        {
                            detailRecordId = obj.Id
                        }
                    });
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
        public JsonResult GetJson(int Id)
        {

            DetailRecordContext DetailRecordContext = new DetailRecordContext();
            Entity.DetailRecord detailRecord = DetailRecordContext.GetById(Id);

            return detailRecord == null ?
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
                            detailRecord.Id,
                            detailRecord.DiseaseName,
                            detailRecord.FacultyId,
                            detailRecord.DoctorId,
                            detailRecord.Note,
                            detailRecord.Status,
                            detailRecord.Result,
                            detailRecord.Process
                        }
                    });
          
        }
        public JsonResult Delete(int Id)
        {

            DetailRecordContext DetailRecordContext = new DetailRecordContext();
            DetailRecordContext.Delete(Id);
            return Json(new { status = true, mess = "Xóa thành công " });

        }
        /*    public ActionResult GetById(int Id)
            {
                ViewBag.isEdit = true;
                ViewBag.Feature = "Cập nhật";
                ViewBag.Element = KeyElement;
                ViewBag.BaseURL = "/Admin/Record/Index";


                

                if (obj != null)
                {
                    return View("Create", obj);
                }
                else
                {
                    return RedirectToAction("Create", "Index");
                }

            }*/
    }
}