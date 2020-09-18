using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TAMS.Controllers;
using TAMS.DAL;
using TAMS.Entity;
namespace TAMS.Areas.Admin.Controllers
{
    public class FacultyController : SessionController
    {
        // GET: Admin/Faculty
        private const string KeyElement = "Khoa";


        public ActionResult Index()
        {
            ViewBag.Feature = "Danh sách";
            ViewBag.Element = KeyElement;

            ViewBag.BaseURL = "/Admin/Faculty/Index";
    

            FacultyContext FacultyContext = new FacultyContext();
            List<Entity.Faculty> obj = FacultyContext.GetFaculty();
        
            return View(obj);
        }

        [HttpPost]
        public JsonResult GetJson(int Id)
        {
            FacultyContext FacultyContext = new FacultyContext();
            Entity.Faculty Faculty = FacultyContext.GetById(Id);


            return Faculty == default ?
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
                            Faculty.Id,
                            Faculty.Name
                          
                        }
                    });

        }

      

        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEdit(Entity.Faculty obj)
        {
            try
            {
                if (obj.isEdit) //update
                {

                    FacultyContext FacultyContext = new FacultyContext();
                    FacultyContext.Update(obj);
                    return Json(new { status = true, mess = "Cập nhật thành công " });

                }
                else //Thêm mới
                {

                    FacultyContext FacultyContext = new FacultyContext();
                    FacultyContext.Create(obj);
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
            FacultyContext FacultyContext = new FacultyContext();
            FacultyContext.Delete(Id);
            return Json(new { status = true, mess = "Xóa thành công " });

        }


        public JsonResult AddFacultyFromExcel(HttpPostedFileBase fileE)
        {

            if (fileE == null || fileE.ContentLength == 0)
            {
                return Json(new { status = false, mess = "Chưa chọn file" });
            }
            else {


                if (fileE.FileName.EndsWith("xls") || fileE.FileName.EndsWith("xlsx"))

                {
                    FacultyContext FacultyContext = new FacultyContext();
                    var count1 = FacultyContext.GetFaculty().Count();
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
                        Faculty faculty = new Faculty();
                        faculty.Name = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 1]).Text;


                        FacultyContext.Create(faculty);
                        FacultyContext.DeleteDuplicate();
                        count2 = FacultyContext.GetFaculty().Count();

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