using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;
namespace TAMS.Areas.Admin.Controllers
{
    public class PrescriptionController : SessionController
    {
        // GET: Admin/DetailPrescription
        // GET: Admin/DetailPrescription
        private const string KeyElement = "Đơn thuốc";


        public ActionResult Index(int detailRecordId)
        {
            ViewBag.Feature = "Danh sách";
            ViewBag.Element = KeyElement;

            ViewBag.BaseURL = "#";
          
            ViewBag.DetailRecordId = detailRecordId;

            MedicineContext MedicineContext = new MedicineContext();
            List<Entity.Medicine> medicines = MedicineContext.GetMedicine();
            ViewBag.Medicines = new SelectList(medicines, "Id", "Name");

            DetailPrescriptionContext DetailPrescriptionContext = new DetailPrescriptionContext();
            List<Entity.DetailPrescription> obj = DetailPrescriptionContext.GetDetailPrescription(detailRecordId);

            return View(obj);
        }

        [HttpPost]
        public JsonResult GetJson(int Id)
        {
            DetailPrescriptionContext DetailPrescriptionContext = new DetailPrescriptionContext();
            Entity.DetailPrescription detail = DetailPrescriptionContext.GetById(Id);


            return detail == default ?
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
                         detail.Id,
                         detail.MedicineId,
                         detail.Amount,
                         detail.Unit,
                         detail.Note
                     }
                 });

        }


        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEdit(Entity.DetailPrescription obj, bool isEdit)
        {
            try
            {
                if (isEdit) //update
                {

                    DetailPrescriptionContext DetailPrescriptionContext = new DetailPrescriptionContext();
                    DetailPrescriptionContext.Update(obj);
                    return Json(new { status = true, mess = "Cập nhật thành công " });

                }
                else //Thêm mới
                {

                    DetailPrescriptionContext DetailPrescriptionContext = new DetailPrescriptionContext();
                    DetailPrescriptionContext.Create(obj);
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
            DetailPrescriptionContext DetailPrescriptionContext = new DetailPrescriptionContext();
            DetailPrescriptionContext.Delete(Id);
            return Json(new { status = true, mess = "Xóa thành công " });

        }
    }
}