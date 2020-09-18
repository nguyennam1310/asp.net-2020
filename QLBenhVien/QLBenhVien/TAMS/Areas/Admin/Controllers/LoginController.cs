using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;

namespace TAMS.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CheckLogin(Entity.Account model)
        {

            AccountContext AccountContext = new AccountContext();
            int result = AccountContext.LoginAdmin(model);

            if (result == 1)
            {

                Entity.Account userSession = new Entity.Account();



                userSession.UserName = model.UserName;
                userSession.Password = model.Password;



                Session.Add(Common.USER_SESSION, userSession);

                return Json(new { status = true, mess = "Đăng nhập thành công" });
            }
            else 
            {
                return Json(new { status = false, mess = "Tên và mật khẩu không chính xác" });
            }



        }


    }
}