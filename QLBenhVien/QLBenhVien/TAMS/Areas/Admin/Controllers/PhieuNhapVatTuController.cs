using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;
using TAMS.Libs;

namespace TAMS.Areas.Admin.Controllers
{
    public class PhieuNhapVatTuController : Controller
    {
        // GET: Admin/PhieuNhapVatTu
        private const string KeyElement = "PhieuNhapVatTu";


        public ActionResult Index()
        {
          /*  ViewBag.Feature = "Danh sách";
            ViewBag.Element = KeyElement;

            ViewBag.BaseURL = "/Admin/PhieuNhapVatTu?categoryId=1";



            var categories = StatusVatTu.GetDic();
            ViewBag.Categories = new SelectList(categories, "Value", "Text");

            if (!categoryId.HasValue)
            {
                if (categories.Count > 0)
                {
                    categoryId = (int?)categories[0].Value;
                }
            }

            ViewBag.CategoryId = categoryId;

            PhieuNhapVatTuContext PhieuNhapVatTuContext = new PhieuNhapVatTuContext();
            List<Entity.PhieuNhapVatTu> obj = PhieuNhapVatTuContext.GetPhieuNhapVatTus();*/

            return View();
        }
       

            public ActionResult Create()
        {
            PhieuNhapVatTuContext phieuNhapVatTuContext = new PhieuNhapVatTuContext();
            var result=phieuNhapVatTuContext.Create();

            if (result > 0)
            {
                return RedirectToAction("Update", "PhieuNhapVatTu", new { Id = result });
            }
            return View("Index");
        }

        public ActionResult Update(int Id)
        {
            ViewBag.isEdit = true;
            ViewBag.isEdit1 = false;
            ViewBag.Feature = "Cập nhật";
            ViewBag.Element = KeyElement;
            ViewBag.BaseURL = "/Admin/PhieuNhapVatTu?Id=1";

            var categories = StatusVatTu.GetDic();
            ViewBag.Categories = new SelectList(categories, "Value", "Text");

            var dungcu = StatusDungCu.GetDic();
            ViewBag.DungCu = new SelectList(dungcu, "Value", "Text");
            var hoachat = StatusDungCu.GetDic();
            ViewBag.HoaChat = new SelectList(hoachat, "Value", "Text");
            var tinhtrang = StatusVatTuYTe.GetDic();
            ViewBag.TinhTrang = new SelectList(tinhtrang, "Value", "Text");

            DonViContext DonViContext = new DonViContext();
            List<Entity.DonVi> donvi = DonViContext.GetDonVi();
            ViewBag.DonVi = new SelectList(donvi, "Id", "Name");

            HangSanXuatContext HangSanXuatContext = new HangSanXuatContext();
            List<Entity.HangSanXuat> hangsanxuat = HangSanXuatContext.GetHangSanXuat();
            ViewBag.HangSanXuat = new SelectList(hangsanxuat, "Id", "Name");


            VatTuYTeContext VatTuYTeContext = new VatTuYTeContext();
            List<Entity.VatTuYTe> VatTuYTe = VatTuYTeContext.GetVatTuYTes();
            ViewBag.VatTuYTe = new SelectList(VatTuYTe, "Id", "Ten");


            PhieuNhapVatTuContext PhieuNhapVatTuContext = new PhieuNhapVatTuContext();
            Entity.PhieuNhapVatTu phieu = PhieuNhapVatTuContext.GetById(Id);

            ViewBag.Phieu = phieu;
            PhieuNhapVatTuChiTietContext PhieuNhapVatTuChiTietContext = new PhieuNhapVatTuChiTietContext();
            List<Entity.PhieuNhapVatTuChiTiet> obj = PhieuNhapVatTuChiTietContext.GetPhieuNhapVatTuChiTiet(Id);


            /* VatTuYTeContext VatTuYTeContext = new VatTuYTeContext();
             Entity.VatTuYTe obj = VatTuYTeContext.GetById(Id);*/
            /*ViewBag.NgayHetHan = obj.NgayHetHan.ToString("g");
            ViewBag.NgayNhap = obj.NgayNhap.ToString("g");*/
            return View(obj);

        }




    

        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEdit(Entity.PhieuNhapVatTu obj, bool isEdit)
        {
            try
            {

                
                if (isEdit) //update
                {

                    PhieuNhapVatTuContext PhieuNhapVatTuContext = new PhieuNhapVatTuContext();
                    PhieuNhapVatTuContext.Update(obj);
                    return Json(new { status = true, mess = "Cập nhật thành công " });



                }
                return Json(new { status = true, mess = "Cập nhật thành công " });
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
        public JsonResult CreateOrEdit1(Entity.PhieuNhapVatTuChiTiet obj, bool isEdit1)
        {
            try
            {
                if (isEdit1) //update
                {

                    PhieuNhapVatTuChiTietContext PhieuNhapVatTuChiTietContext = new PhieuNhapVatTuChiTietContext();
                    PhieuNhapVatTuChiTietContext.Update(obj);
                    return Json(new { status = true, mess = "Cập nhật thành công " });

                }
                else //Thêm mới
                {

                    PhieuNhapVatTuChiTietContext PhieuNhapVatTuChiTietContext = new PhieuNhapVatTuChiTietContext();
                    PhieuNhapVatTuChiTietContext.Create(obj);
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
            PhieuNhapVatTuContext PhieuNhapVatTuContext = new PhieuNhapVatTuContext();
            PhieuNhapVatTuContext.Delete(Id);

            return Json(new { status = true, mess = "Xóa thành công " });

        }
    }
}