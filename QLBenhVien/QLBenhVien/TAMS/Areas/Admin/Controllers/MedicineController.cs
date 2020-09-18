using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;
using TAMS.Entity;

namespace TAMS.Areas.Admin.Controllers
{
    public class MedicineController : SessionController
    {
        // GET: Admin/Medicine
      
            // GET: Admin/Medicine
            private const string KeyElement = "Thuốc";


            public ActionResult Index()
            {
                ViewBag.Feature = "Danh sách";
                ViewBag.Element = KeyElement;

                ViewBag.BaseURL = "/Admin/Medicine/Index";


                MedicineContext MedicineContext = new MedicineContext();
                List<Entity.Medicine> obj = MedicineContext.GetMedicine();

                return View(obj);
            }

            [HttpPost]
            public JsonResult GetJson(int Id)
            {
                MedicineContext MedicineContext = new MedicineContext();
                Entity.Medicine medicine = MedicineContext.GetById(Id);


                return medicine == default ?
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
                                medicine.Id,
                                medicine.Name,
                                medicine.Description

                            }
                        });

            }

            

            [HttpPost, ValidateInput(false)]
            public JsonResult CreateOrEdit(Entity.Medicine obj, bool isEdit)
            {
                try
                {
                    if (isEdit) //update
                    {

                        MedicineContext MedicineContext = new MedicineContext();
                        MedicineContext.Update(obj);
                        return Json(new { status = true, mess = "Cập nhật thành công " });

                    }
                    else //Thêm mới
                    {

                        MedicineContext MedicineContext = new MedicineContext();
                        MedicineContext.Create(obj);
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
                MedicineContext MedicineContext = new MedicineContext();
                MedicineContext.Delete(Id);
                return Json(new { status = true, mess = "Xóa thành công " });

            }

        public JsonResult AddMedicineFromExcel(HttpPostedFileBase fileE)
        {

            if (fileE == null || fileE.ContentLength == 0)
            {
                return Json(new { status = false, mess = "Chưa chọn file" });
            }
            else
            {


                if (fileE.FileName.EndsWith("xls") || fileE.FileName.EndsWith("xlsx"))

                {
                    MedicineContext MedicineContext = new MedicineContext();
                    var count1 = MedicineContext.GetMedicine().Count();
                    var count2 = count1;
                    string fileName = Path.GetFileName(fileE.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/File/"), fileName);

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);

                    }
                    fileE.SaveAs(path);
                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(path); ;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = xlWorkBook.ActiveSheet;
                    Microsoft.Office.Interop.Excel.Range range = xlWorkSheet.UsedRange;
                    int rw = range.Rows.Count;

                    for (int row = 2; row <= rw; row++)
                    {
                        Medicine Medicine = new Medicine();
                        Medicine.Name = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 1]).Text;
                        Medicine.Description= ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 2]).Text;

                        MedicineContext.Create(Medicine);
                        MedicineContext.DeleteDuplicateMedicine();
                        count2 = MedicineContext.GetMedicine().Count();

                    }
                    var result = count2 - count1;
                    xlWorkBook.Close();
                    return Json(new { status = true, mess = "Thêm thành công " + result + " bản ghi" });
                }
                else
                {
                    return Json(new { status = false, mess = "File chưa đúng định dạng" });
                }
            }


        }
    }
    }
