using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;
using TAMS.Libs;

namespace TAMS.Areas.Admin.Controllers
{
    public class VatTuYTeController : Controller
    {
        // GET: Admin/VatTuYTe
        private const string KeyElement = "Vật tư y tế";


        public ActionResult Index(int? categoryId)
        {
            ViewBag.Feature = "Danh sách";
            ViewBag.Element = KeyElement;

            ViewBag.BaseURL = "/Admin/VatTuYTe?categoryId=1";

          
           
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

            VatTuYTeContext VatTuYTeContext = new VatTuYTeContext();
            List<Entity.VatTuYTe> obj = VatTuYTeContext.GetVatTuYTe((int)categoryId);

            return View(obj);
        }
        public ActionResult Create()
        {
            ViewBag.Feature = "Thêm mới";
            ViewBag.Element = KeyElement;
            ViewBag.BaseURL = "/Admin/VatTuYTe?categoryId=1";

            ViewBag.IsEdit = false;
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
             

            return View();
        }

        public ActionResult Update(int Id)
        {
            ViewBag.isEdit = true;
            ViewBag.Feature = "Cập nhật";
            ViewBag.Element = KeyElement;
            ViewBag.BaseURL = "/Admin/VatTuYTe?categoryId=1";

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
            Entity.VatTuYTe obj = VatTuYTeContext.GetById(Id);

            ViewBag.NgayHetHan = obj.NgayHetHan.ToString("g");
            ViewBag.NgayNhap = obj.NgayNhap.ToString("g");
            ViewBag.NgayKetThucBaoHanh = obj.NgayKetThucBaoHanh.ToString("g");
            ViewBag.NgayBatDauBaoHanh = obj.NgayBatDauBaoHanh.ToString("g");
            ViewBag.NamSX = obj.NamSX.ToString("g");
           
            if (obj != null)
            {
                return View("Create", obj);
            }
            else
            {
                return RedirectToAction("Create", "VatTuYTe", new { categoryId = 10 });
            }

        }


        [HttpPost]
        public JsonResult GetJson(int Id)
        {
            VatTuYTeContext VatTuYTeContext = new VatTuYTeContext();
            Entity.VatTuYTe VatTuYTe = VatTuYTeContext.GetById(Id);


            return VatTuYTe == default ?
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
                            VatTuYTe.Id,
                            VatTuYTe.Ten,
                            VatTuYTe.MaLoaiVatTu,
                            VatTuYTe.MaHangSX,
                            VatTuYTe.HuongDanSuDung,
                            NgayHetHans=VatTuYTe.NgayHetHan.ToString("g"),
                            VatTuYTe.SoLuong,
                            VatTuYTe.MaDonVi,
                            VatTuYTe.MoTa,
                            VatTuYTe.ThanhPhan,
                            VatTuYTe.HamLuong,
                            VatTuYTe.NguonGoc,
                            VatTuYTe.GiaBan,
                            NgayNhaps=VatTuYTe.NgayNhap.ToString("g"),
                            VatTuYTe.CongDung,
                            VatTuYTe.ChatLieu,
                            VatTuYTe.LoaiDungCu,
                            VatTuYTe.LoaiHoaChat,
                            VatTuYTe.TinhTrang,
                            NgayBatDauBaoHanhs=VatTuYTe.NgayBatDauBaoHanh.ToString("g"),
                            NgayKetThucBaoHanhs=VatTuYTe.NgayKetThucBaoHanh.ToString("g"),
                            NamSXs=VatTuYTe.NamSX.ToString("g")

                        }
                    });

        }


        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEdit(Entity.VatTuYTe obj,bool isEdit)
        {
            try
            {
                if (isEdit) //update
                {

             
                    
                    DateTime today = DateTime.Now;
                    var date = new DateTime(1, 1, 1, 0, 0, 0);
                    int a = DateTime.Compare(date, obj.NgayBatDauBaoHanh);
                    int b = DateTime.Compare(date, obj.NgayKetThucBaoHanh);
                    int c = DateTime.Compare(date, obj.NgayHetHan);
                    int d = DateTime.Compare(date, obj.NamSX);
                    int e = DateTime.Compare(date, obj.NgayNhap);
                    
                    if (a == 0)
                    {
                        obj.NgayBatDauBaoHanh = today;
                        a = DateTime.Compare(date, obj.NgayBatDauBaoHanh);
                    }
                    if (b == 0)
                    {
                        obj.NgayKetThucBaoHanh = today.AddYears(1);
                        b = DateTime.Compare(date, obj.NgayKetThucBaoHanh);
                    }
                    if (c == 0)
                    {
                        obj.NgayHetHan = today.AddYears(1);
                        c = DateTime.Compare(date, obj.NgayHetHan);

                    }
                    if (d == 0)
                    {
                        obj.NamSX = today;
                        d = DateTime.Compare(date, obj.NamSX);
                    }
                    if (e == 0)
                    {
                        obj.NgayNhap = today;
                        e = DateTime.Compare(date, obj.NgayNhap);
                    }
                    if (a != 0 && b != 0 && c != 0 && d != 0 && e != 0)
                    {





                        VatTuYTeContext VatTuYTeContext = new VatTuYTeContext();
                        VatTuYTeContext.Update(obj);
                        return Json(new { status = true, mess = "Cập nhật thành công ", data = new { obj.MaLoaiVatTu } });
                    }
                    return Json(new { status = true, data = new { obj.MaLoaiVatTu } });
                }
                else //Thêm mới
                {
                    DateTime today = DateTime.Now;
                    var date = new DateTime(1,1,1,0,0,0);
                    int a = DateTime.Compare(date, obj.NgayBatDauBaoHanh);
                    int b = DateTime.Compare(date, obj.NgayKetThucBaoHanh);
                    int c = DateTime.Compare(date, obj.NgayHetHan);
                    int d = DateTime.Compare(date, obj.NamSX);
                    int e= DateTime.Compare(date, obj.NgayNhap);
                    if (a == 0)
                    {
                        obj.NgayBatDauBaoHanh = today;
                        a = DateTime.Compare(date, obj.NgayBatDauBaoHanh);
                    }
                    if (b == 0)
                    {
                        obj.NgayKetThucBaoHanh = today.AddYears(1);
                        b = DateTime.Compare(date, obj.NgayKetThucBaoHanh);
                    }
                    if (c == 0)
                    {
                        obj.NgayHetHan = today.AddYears(1);
                        c = DateTime.Compare(date, obj.NgayHetHan);

                    }
                    if (d == 0)
                    {
                        obj.NamSX = today;
                        d = DateTime.Compare(date, obj.NamSX);
                    }
                    if (e == 0)
                    {
                        obj.NgayNhap = today;
                        e = DateTime.Compare(date, obj.NgayNhap);
                    }
                    if (a != 0 && b != 0 &&c != 0&&d!=0&&e!=0)
                    {
                        
                       
                       
                       
                        
                        VatTuYTeContext VatTuYTeContext = new VatTuYTeContext();
                        VatTuYTeContext.Create(obj);
                        return Json(new { status = true, mess = "Thêm thành công ", data = new { obj.MaLoaiVatTu } });
                    }

                    return Json(new { status = true, mess = "Thêm thành công ", data = new { obj.MaLoaiVatTu } });
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
            VatTuYTeContext VatTuYTeContext = new VatTuYTeContext();
            VatTuYTeContext.Delete(Id);

            return Json(new { status = true, mess = "Xóa thành công " });

        }
    }
    }
