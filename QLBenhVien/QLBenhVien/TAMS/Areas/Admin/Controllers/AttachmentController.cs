using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;

namespace TAMS.Areas.Admin.Controllers
{
    public class AttachmentController : SessionController
    {
        // GET: Admin/Attachment
        private const string KeyElement = "Tệp đính kèm";


        public ActionResult Index(int detailRecordId)
        {
            ViewBag.Feature = "Danh sách";
            ViewBag.Element = KeyElement;

            ViewBag.BaseURL = "#";

            ViewBag.DetailRecordId = detailRecordId;

          

            AttachmentContext AttachmentContext = new AttachmentContext();
            List<Entity.Attachment> obj = AttachmentContext.GetAttachment(detailRecordId);

            return View(obj);
        }

        [HttpPost]
        public JsonResult GetJson(int Id)
        {
            AttachmentContext AttachmentContext = new AttachmentContext();
            Entity.Attachment detail = AttachmentContext.GetById(Id);


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
                         detail.Type,
                         detail.Name,
                         detail.Url
                     }
                 });

        }


        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEdit(Entity.Attachment obj, bool isEdit)
        {
            try
            {
                if (isEdit) //update
                {

                    AttachmentContext AttachmentContext = new AttachmentContext();
                    AttachmentContext.Update(obj);
                    return Json(new { status = true, mess = "Cập nhật thành công " });

                }
                else //Thêm mới
                {

                    AttachmentContext AttachmentContext = new AttachmentContext();
                    AttachmentContext.Create(obj);
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

        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEdit1(Entity.Attachment obj, bool isEdit)
        {
            try
            {
                if (isEdit) //update
                {

                    AttachmentContext AttachmentContext = new AttachmentContext();
                    AttachmentContext.Update1(obj);
                    return Json(new { status = true, mess = "Cập nhật thành công " });

                }
                else //Thêm mới
                {

                    AttachmentContext AttachmentContext = new AttachmentContext();
                    AttachmentContext.Create1(obj);
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
            AttachmentContext AttachmentContext = new AttachmentContext();
            AttachmentContext.Delete(Id);
            return Json(new { status = true, mess = "Xóa thành công " });

        }
    }
}