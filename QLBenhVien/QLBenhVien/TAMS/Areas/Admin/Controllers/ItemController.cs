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
    public class ItemController : SessionController
    {
        // GET: Admin/Item
        private const string KeyElement = "Thiết bị";
  
      
        public ActionResult Index(int? categoryId)
        {
            ViewBag.Feature = "Danh sách";
            ViewBag.Element = KeyElement;

            ViewBag.BaseURL = "/Admin/Item?categoryId=10";
            

            CategoryContext CategoryContext = new CategoryContext();
            List<Entity.Category> categories = CategoryContext.GetCategory();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            if (!categoryId.HasValue)
            {
                if (categories.Count > 0)
                {
                    categoryId = categories[0].Id;
                }
            }

            ViewBag.CategoryId = categoryId;

            ItemContext ItemContext = new ItemContext();
            List<Entity.Item> obj = ItemContext.GetItem((int)categoryId);

            return View(obj);
        }
        public ActionResult Create()
        {
            ViewBag.Feature = "Thêm mới";
            ViewBag.Element = KeyElement;
            ViewBag.BaseURL = "/Admin/Item?categoryId=10";

            ViewBag.IsEdit = false;
            CategoryContext CategoryContext = new CategoryContext();
            List<Entity.Category> categories = CategoryContext.GetCategory();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");


            return View();
        }

        public ActionResult Update(int Id)
        {
            ViewBag.isEdit = true;
            ViewBag.Feature = "Cập nhật";
            ViewBag.Element = KeyElement;
            ViewBag.BaseURL = "/Admin/Item?categoryId=10";

            CategoryContext CategoryContext = new CategoryContext();
            List<Entity.Category> categories = CategoryContext.GetCategory();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");


            ItemContext ItemContext = new ItemContext();
            Entity.Item obj = ItemContext.GetById(Id);


            if (obj != null)
            {
                return View("Create", obj);
            }
            else
            {
                return RedirectToAction("Create", "Item",new {  categoryId=10});
            }
          
        }
     
 



        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEdit(Entity.Item obj)
        {
            try
            {
                if (obj.isEdit) //update
                {

                    ItemContext ItemContext = new ItemContext();
                    ItemContext.Update(obj);
                    return Json(new { status = true, mess = "Cập nhật thành công ", data = new { obj.CategoryId } });

                }
                else //Thêm mới
                {

                    ItemContext ItemContext = new ItemContext();
                    ItemContext.Create(obj);
                    return Json(new { status = true, mess = "Thêm thành công ", data = new { obj.CategoryId } });
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
            ItemContext ItemContext = new ItemContext();
            ItemContext.Delete(Id);
            
                return Json(new { status = true, mess = "Xóa thành công " });
           
        }
        public JsonResult AddItemFromExcel(HttpPostedFileBase fileE)
        {

            if (fileE == null || fileE.ContentLength == 0)
            {
                return Json(new { status = false, mess = "Chưa chọn file" });
            }
            else
            {


                if (fileE.FileName.EndsWith("xls") || fileE.FileName.EndsWith("xlsx"))

                {
                    ItemContext ItemContext = new ItemContext();
                    var count1 = ItemContext.GetItems().Count();
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
                        Item Item = new Item();
                        Item.Name = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 1]).Text;
                        Item.Amount = (int)((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 2]).Value2;
                        Item.Description = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 3]).Text;
                        Item.CategoryName = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 4]).Text;

                        ItemContext.Create1(Item);
                        ItemContext.DeleteDuplicateItem();
                        count2 = ItemContext.GetItems().Count();

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