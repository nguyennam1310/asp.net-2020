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
    public class CategoryController : SessionController
    {
        // GET: Admin/Category
        private const string KeyElement = "Danh mục";


        public ActionResult Index()
        {
            ViewBag.Feature = "Danh sách";
            ViewBag.Element = KeyElement;

            ViewBag.BaseURL = "/Admin/Category/Index";


            CategoryContext CategoryContext = new CategoryContext();
            List<Entity.Category> obj = CategoryContext.GetCategory();

            return View(obj);
        }

        [HttpPost]
        public JsonResult GetJson(int Id)
        {
            CategoryContext CategoryContext = new CategoryContext();
            Entity.Category Category = CategoryContext.GetById(Id);


            return Category == default ?
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
                            Category.Id,
                            Category.Name,
                            Category.Unit,
                            Category.Description

                        }
                    });

        }

     

        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEdit(Entity.Category obj)
        {
            try
            {
                if (obj.isEdit) //update
                {

                    CategoryContext CategoryContext = new CategoryContext();
                    CategoryContext.Update(obj);
                    return Json(new { status = true, mess = "Cập nhật thành công " });

                }
                else //Thêm mới
                {

                    CategoryContext CategoryContext = new CategoryContext();
                    CategoryContext.Create(obj);
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
            CategoryContext CategoryContext = new CategoryContext();
            
           
            int check = CategoryContext.Delete(Id);
            if (check == 1)
            {
                return Json(new { status = true, mess = "Xóa thành công " });
            }
            else
            {
                return Json(new { status = false, mess = "Bạn không được xóa bản ghi này " });
            }
        }
        public JsonResult AddCategoryFromExcel(HttpPostedFileBase fileE)
        {

            if (fileE == null || fileE.ContentLength == 0)
            {
                return Json(new { status = false, mess = "Chưa chọn file" });
            }
            else
            {


                if (fileE.FileName.EndsWith("xls") || fileE.FileName.EndsWith("xlsx"))

                {
                    CategoryContext CategoryContext = new CategoryContext();
                    var count1 = CategoryContext.GetCategory().Count();
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
                        Category Category = new Category();
                        Category.Name = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 1]).Text;
                        Category.Unit = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 2]).Text;
                        Category.Description = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 3]).Text;

                        CategoryContext.Create(Category);
                        CategoryContext.DeleteDuplicateCategory();
                        count2 = CategoryContext.GetCategory().Count();

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