using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TAMS.DAL;
using TAMS.Libs;

namespace TAMS.Areas.Admin.Controllers
{
    public class AccountController : SessionController
    {
        // GET: Account

        private readonly string KeyElement = "Tài khoản";

        public ActionResult Index()
        {
            ViewBag.Feature = "Danh sách";
            ViewBag.Element = KeyElement;

            if (Request.Url != null) ViewBag.BaseURL = Request.Url.LocalPath;

            var lstRole = RoleKey.GetDic();
            ViewBag.Roles = new SelectList(lstRole, "Value", "Text");

            ViewBag.isEdit = false;
            AccountContext accountContext = new AccountContext();
            List<Entity.Account> listData = accountContext.GetAccount();

            return View(listData);

        }

        [HttpPost]
        public JsonResult GetJson(int Id)
        {
            AccountContext accountContext = new AccountContext();
            Entity.Account account = accountContext.GetById(Id);


            return account == default ?
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
                            account.Id,
                            account.FullName,
                            account.PatientName,
                            account.Phone,
                            account.UserName,
                            account.Gender,
                            account.Role
                        }
                    });
            
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult CreateOrEdit(Entity.Account input, bool isEdit, string rePassword)
        {
            try
            {
                if (isEdit) //update
                {


                    if ((!string.IsNullOrEmpty(input.Password)) || (!string.IsNullOrEmpty(input.PasswordNew)))
                    {
                        if (input.PasswordNew == "" || input.Password == "" || rePassword == "")
                        {
                            return Json(new { status = false, mess = "Không được để trống" });
                        }

                        if (input.PasswordNew != rePassword)
                        {
                            return Json(new { status = false, mess = "Mật khẩu không khớp" });
                        }

                    }

                   
                        AccountContext accountContext = new AccountContext();

                        int check = accountContext.Update(input);
                        if (check == 0)
                        {
                            return Json(new { status = false, mess = "Mật khẩu sai" });
                        }
                        else
                        {
                            return Json(new { status = true, mess = "Cập nhập thành công " });

                        }
                 
                    



                }
                else //Thêm mới
                {

                    if (input.PasswordNew != rePassword)
                    {
                        return Json(new { status = false, mess = "Mật khẩu không khớp" });
                    }

                    else
                    {
                        AccountContext accountContext = new AccountContext();

                        int check = accountContext.Create(input);
                        if (check == 1)
                        {
                            return Json(new { status = false, mess = "Tên đăng nhập đã tồn tại" });
                        }


                        else
                        {
                            return Json(new { status = true, mess = "Thêm thành công " + KeyElement });
                        }
                    }
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
        public JsonResult CreateOrEdit1(Entity.Account input, bool isEdit, string rePassword)
        {
            try
            {
                if (isEdit) //update
                {

                   
                    AccountContext accountContext = new AccountContext();
                     accountContext.Update1(input);

                    return Json(new { status = true, mess = "Cập nhập thành công " });


                    




                }
                else //Thêm mới
                {
               
                    if (input.PasswordNew != rePassword)
                    {
                        return Json(new { status = false, mess = "Mật khẩu không khớp" });
                    }
                    else
                    {
                        AccountContext accountContext = new AccountContext();

                        int check = accountContext.Create(input);
                        if (check == 1)
                        {
                            return Json(new { status = false, mess = "Tên đăng nhập đã tồn tại" });
                        }


                        else
                        {
                            return Json(new { status = true, mess = "Thêm thành công " + KeyElement });
                        }
                    }
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
            AccountContext AccountContext = new AccountContext();


            int check = AccountContext.Delete(Id);
            if (check == 1)
            {
                return Json(new { status = true, mess = "Xóa thành công " });
            }
            else
            {
                return Json(new { status = false, mess = "Bạn không được xóa bản ghi này " });
            }
        }
    }
}