using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;

namespace TAMS.Areas.Admin.Controllers
{
    public class HangSanXuatController : Controller
    {
        // GET: Admin/HangSanXuat
        private const string KeyElement = "Hãng Sản Xuất";


        public ActionResult Index()
        {
            ViewBag.Feature = "Danh sách";
            ViewBag.Element = KeyElement;

            ViewBag.BaseURL = "/Admin/HangSanXuat/Index";


            HangSanXuatContext HangSanXuatContext = new HangSanXuatContext();
            List<Entity.HangSanXuat> obj = HangSanXuatContext.GetHangSanXuat();

            return View(obj);
        }

        [HttpPost]
        public JsonResult GetJson(int Id)
        {
            HangSanXuatContext HangSanXuatContext = new HangSanXuatContext();
            Entity.HangSanXuat HangSanXuat = HangSanXuatContext.GetById(Id);


            return HangSanXuat == default ?
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
                            HangSanXuat.Id,
                            HangSanXuat.Name,
                            HangSanXuat.Address,
                            HangSanXuat.Phone,
                            HangSanXuat.Note,
                            HangSanXuat.Country,
                            HangSanXuat.Fax,
                            HangSanXuat.Email

                        }
                    });

        }



        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEdit(Entity.HangSanXuat obj,bool isEdit)
        {
            try
            {
                if (isEdit) //update
                {

                    HangSanXuatContext HangSanXuatContext = new HangSanXuatContext();
                    HangSanXuatContext.Update(obj);
                    return Json(new { status = true, mess = "Cập nhật thành công " });

                }
                else //Thêm mới
                {

                    HangSanXuatContext HangSanXuatContext = new HangSanXuatContext();
                    HangSanXuatContext.Create(obj);
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
            HangSanXuatContext HangSanXuatContext = new HangSanXuatContext();
            HangSanXuatContext.Delete(Id);
            return Json(new { status = true, mess = "Xóa thành công " });

        }

    }
}