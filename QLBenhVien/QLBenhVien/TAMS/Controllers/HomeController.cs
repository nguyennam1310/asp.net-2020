using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TAMS.DAL;

namespace TAMS.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Department()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult Doctors()
        {
            return View();
        }

        public ActionResult a()
        {
            return View();
        }
        public ActionResult Login()
        {
           
            return View();
            
        }
        [HttpPost]
        public JsonResult Verify(Entity.Account obj)

        {


            AccountContext AccountContext = new AccountContext();
            int result = AccountContext.Login(obj);

            if (result == 0)
            {

                
                return Json(new { status = false, mess = "Tên và mật khẩu không chính xác" });
            }
            else
            {
                Session["Username"] = obj.UserName;
                return Json(new { status = true, mess = "Đăng nhập thành công" });
               
            }


        }
        public ActionResult Index()
        {

            if (Session["Username"] != null)
            {
                ViewData["user"] = Session["Username"];

            }
            else
            {
                ViewData["user"] = 1;
            }
            return View();
        }
            

        public JsonResult Register(Entity.Account obj)

        {
                AccountContext AccountContext = new AccountContext();
                AccountContext.Resgister(obj);

                
                return Json(obj);

            
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
        /*      public IEnumerable GetDataProfile(String UserName)
              {
                  LoginAdminContext loginAdminContext = new LoginAdminContext();

                  return JsonConvert.SerializeObject(loginAdminContext.GetDataProfile(UserName));
              }
              public ActionResult Profile(String UserName)
              {
                  ViewData["user"] = UserName;
                  return View();
              }
              public void UpdateProfile(Entity.LoginAdmin obj)
              {
                  LoginAdminContext loginAdminContext = new LoginAdminContext();

                  loginAdminContext.UpdateProfile(obj);
              }
              public void ChangePassword(Entity.LoginAdmin obj)
              {
                  LoginAdminContext loginAdminContext = new LoginAdminContext();

                  loginAdminContext.ChangePassword(obj);
              }
              public ActionResult CategoryQuestion()
              {
                  return View();
              }
              public void AddCategoryQuestion(Entity.CategoryQuestion obj)
              {
                  AdminContext adminContext = new AdminContext();
                  adminContext.AddCategoryQuestion(obj);
              }
              public void UpdateCategory(Entity.CategoryQuestion obj)
              {
                  AdminContext adminContext = new AdminContext();
                  adminContext.UpdateCategory(obj);

              }

              public IEnumerable GetDataCategory()
              {
                  AdminContext adminContext = new AdminContext();
                  return JsonConvert.SerializeObject(adminContext.GetDataCategory());


              }
              public IEnumerable GetByIdCategory(int Id)
              {
                  AdminContext adminContext = new AdminContext();
                  return JsonConvert.SerializeObject(adminContext.GetByIdCategory(Id));


              }
              public void DeleteCategory(int Id)
              {
                  AdminContext adminContext = new AdminContext();
                  adminContext.DeleteCategory(Id);
              }
              public ActionResult Question()
              {
                  return View();
              }
              public IEnumerable AddQuestion(Entity.Question obj)
              {
                  AdminContext adminContext = new AdminContext();

                  adminContext.AddQuestion(obj);
                  return JsonConvert.SerializeObject(obj);

              }
              [HttpPost]
              public IEnumerable AddAnswer(List<Entity.Answer> obj)
              {
                  AdminContext adminContext = new AdminContext();
                  adminContext.AddAnswer(obj);
                  return JsonConvert.SerializeObject(obj);

              }
              public ActionResult ManageQuestion()
              {
                  return View();
              }
              public IEnumerable GetDataQuestion(int Id)
              {
                  AdminContext adminContext = new AdminContext();

                  return JsonConvert.SerializeObject(adminContext.GetDataQuestion(Id));
              }
              public void DeleteQuestion(int Id)
              {
                  AdminContext adminContext = new AdminContext();
                  adminContext.DeleteQuestion(Id);
              }
              public void DeleteAnswer(int IdQuestion)
              {
                  AdminContext adminContext = new AdminContext();
                  adminContext.DeleteAnswer(IdQuestion);
              }
              public IEnumerable GetByIdQuestion(int Id)
              {
                  AdminContext adminContext = new AdminContext();

                  return JsonConvert.SerializeObject(adminContext.GetByIdQuestion(Id));
              }
              public IEnumerable GetByIdAnswer(int IdQuestion)
              {
                  AdminContext adminContext = new AdminContext();

                  return JsonConvert.SerializeObject(adminContext.GetByIdAnswer(IdQuestion));

              }
              public IEnumerable UpdateQuestion(Entity.Question obj)
              {
                  AdminContext adminContext = new AdminContext();
                  adminContext.UpdateQuestion(obj);
                  return JsonConvert.SerializeObject(obj);
              }
              public IEnumerable UpdateAnswer(List<Entity.Answer> obj)
              {
                  AdminContext adminContext = new AdminContext();
                  adminContext.UpdateAnswer(obj);
                  return JsonConvert.SerializeObject(obj);
              }
              public IEnumerable CountAnswer(int IdQuestion)
              {
                  AdminContext adminContext = new AdminContext();

                  return JsonConvert.SerializeObject(adminContext.CountAnswer(IdQuestion));
              }
              public IEnumerable CountQuestion()
              {
                  AdminContext adminContext = new AdminContext();

                  return JsonConvert.SerializeObject(adminContext.CountQuestion());
              }*/
    }
}