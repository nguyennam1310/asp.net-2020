using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;

namespace TAMS.Areas.Admin.Controllers
{
    public class MedicalSupplyController : Controller
    {
        // GET: Admin/MedicalSupply
        private const string KeyElement = "Cấp vật tư";

       

       
        public ActionResult Index(int patientId)
        {
            ViewBag.Feature = "Danh sách";
            ViewBag.Element = KeyElement;

            ViewBag.BaseURL = "#";

            ViewBag.patientId = patientId;

            ItemContext ItemContext = new ItemContext();
            List<Entity.Item> Items = ItemContext.GetItems();
            ViewBag.Items = new SelectList(Items, "Id", "Name");

           

            MedicalSupplyContext MedicalSupplyContext = new MedicalSupplyContext();
            List<Entity.MedicalSupply> obj = MedicalSupplyContext.GetMedicalSupply(patientId);

            return View(obj);
        }

        [HttpPost]
        public JsonResult GetJson(int Id)
        {
            MedicalSupplyContext MedicalSupplyContext = new MedicalSupplyContext();
            Entity.MedicalSupply detail = MedicalSupplyContext.GetById(Id);


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
                         DateHide = detail.DateOfHire.ToString("g"),
                         detail.Amount,
                         detail.PatientId,
                         detail.ItemId,
                         detail.Status
                     }
                 });

        }


        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEdit(Entity.MedicalSupply obj, bool isEdit)
        {
            /*try
            */
                if (isEdit) //update
                {

                    MedicalSupplyContext MedicalSupplyContext = new MedicalSupplyContext();
                    MedicalSupplyContext.Update(obj);
                    return Json(new { status = true, mess = "Cập nhật thành công " });

                }
                else //Thêm mới
                {

                    MedicalSupplyContext MedicalSupplyContext = new MedicalSupplyContext();
                    MedicalSupplyContext.Create(obj);
                    return Json(new { status = true, mess = "Thêm thành công " });
                }
            }
           /* catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    mess = "Có lỗi xảy ra: " + ex.Message
                });
            }*/
        

        [HttpPost]
        public JsonResult Del(int Id)
        {
            MedicalSupplyContext MedicalSupplyContext = new MedicalSupplyContext();
            MedicalSupplyContext.Delete(Id);
            return Json(new { status = true, mess = "Xóa thành công " });

        }
    }
}