using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;

namespace TAMS.Areas.Admin.Controllers
{
    public class DonViController : Controller
    {
     
            // GET: Admin/DonVi
            private const string KeyElement = "Đơn Vị";


            public ActionResult Index()
            {
                ViewBag.Feature = "Danh sách";
                ViewBag.Element = KeyElement;

                ViewBag.BaseURL = "/Admin/DonVi/Index";


                DonViContext DonViContext = new DonViContext();
                List<Entity.DonVi> obj = DonViContext.GetDonVi();

                return View(obj);
            }

            [HttpPost]
            public JsonResult GetJson(int Id)
            {
                DonViContext DonViContext = new DonViContext();
                Entity.DonVi DonVi = DonViContext.GetById(Id);


                return DonVi == default ?
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
                                DonVi.Id,
                                DonVi.Name,
                                DonVi.Description

                            }
                        });

            }



            [HttpPost, ValidateInput(false)]
            public JsonResult CreateOrEdit(Entity.DonVi obj,bool isEdit)
            {
                try
                {
                    if (isEdit) //update
                    {

                        DonViContext DonViContext = new DonViContext();
                        DonViContext.Update(obj);
                        return Json(new { status = true, mess = "Cập nhật thành công " });

                    }
                    else //Thêm mới
                    {

                        DonViContext DonViContext = new DonViContext();
                        DonViContext.Create(obj);
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
                DonViContext DonViContext = new DonViContext();
                DonViContext.Delete(Id);
                return Json(new { status = true, mess = "Xóa thành công " });

            }

        }
    }