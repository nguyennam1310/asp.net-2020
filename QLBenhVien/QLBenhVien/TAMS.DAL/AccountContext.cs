using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TAMS.Entity;

namespace TAMS.DAL
{
   public  class AccountContext:BaseContext
    {

        private static AccountContext _instance;
        public static AccountContext Instance()
        {
            if (null == _instance)
            {
                _instance = new AccountContext();
            }
            return _instance;
        }
        public int Login(Entity.Account obj)

        {
            var Password = Md5.MD5Hash(obj.Password);
            int a = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Login")
                   .Parameter("UserName", obj.UserName)
                   .Parameter("Password", Password)
                   .ParameterOut("Total", FluentData.DataTypes.Int32);
                cmd.Execute();

                a = cmd.ParameterValue<int>("Total");
            }
            return a;
        }
        public int LoginAdmin(Entity.Account obj)

        {
            var Password = Md5.MD5Hash(obj.Password);
            int a = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.LoginAdmin")
                   .Parameter("UserName", obj.UserName)
                   .Parameter("Password", Password)
                   .ParameterOut("Total", FluentData.DataTypes.Int32);
                cmd.Execute();

                a = cmd.ParameterValue<int>("Total");
            }
            return a;
        }
        public void Resgister(Entity.Account obj)

        {
            var Password = Md5.MD5Hash(obj.Password);
         
            using (var context = MasterDBContext())
            {
                     context.StoredProcedure("dbo.Register")
                   .Parameter("UserName", obj.UserName)
                   .Parameter("Password", Password)
                   .Parameter("FullName", obj.FullName)
                   .Parameter("Gender", obj.Gender)
                   .Parameter("Role", 1)
                   .Parameter("Phone", obj.Phone)
                   .Parameter("LinkAvatar", obj.LinkAvatar)
                   .Parameter("Email", obj.Email)
                   .Parameter("DateOfBirth", obj.DateOfBirth)
                  
                   .Execute();

            }
           
        }
        public int Create(Entity.Account obj)

        {
            var Password = Md5.MD5Hash(obj.Password);
            int check=0;
            using (var context = MasterDBContext())
            {
                var cmd =   context.StoredProcedure("dbo.CreateAcc")
                   .Parameter("UserName", obj.UserName)
                   .Parameter("Password", Password)
                   .Parameter("FullName", obj.FullName)
                   .Parameter("Gender", obj.Gender)
                   .Parameter("Role", obj.Role)
                   .Parameter("Phone", obj.Phone)
                    .ParameterOut("Total", FluentData.DataTypes.Int32);
                   cmd.Execute();
                check = cmd.ParameterValue<int>("Total");
            }
            return check;
        }
        public int Update(Entity.Account obj)

        {
            var Password = Md5.MD5Hash(obj.Password);
            var PasswordNew = Md5.MD5Hash(obj.PasswordNew);
            int check = 0;
            using (var context = MasterDBContext())
            {
            var cmd= context.StoredProcedure("dbo.UpdateAcc")
                     .Parameter("UserName", obj.UserName)
                    .Parameter("Id", obj.Id)
                   .Parameter("Password", Password)
                   .Parameter("PasswordNew", PasswordNew)
                   .Parameter("FullName", obj.FullName)
                   .Parameter("Gender", obj.Gender)
                   .Parameter("Role", obj.Role)
                   .Parameter("Phone", obj.Phone)
                    .ParameterOut("Total", FluentData.DataTypes.Int32);
                cmd.Execute();

                check = cmd.ParameterValue<int>("Total");
            }
            return check;
        }
        public void Update1(Entity.Account obj)

        {
            var Password = Md5.MD5Hash(obj.Password);

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.UpdateAcc")
                       .Parameter("Id", obj.Id)
                      .Parameter("FullName", obj.FullName)
                      .Parameter("Gender", obj.Gender)
                      .Parameter("Role", obj.Role)
                      .Parameter("Phone", obj.Phone)
                       .Execute();

            }

        }
        public Entity.Account GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdAcc")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.Account>();
            }
        }
        public List<Entity.Account> GetAccount()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_Acc")

                    .QueryMany<Entity.Account>();
            }
        }
        public void UpdateProfile(Entity.Account obj)

        {
            string _FileName = Path.GetFileName(obj.file.FileName);
            string _path = Path.Combine(HttpContext.Current.Server.MapPath("~/adminlte/dist/img"), _FileName);
            obj.file.SaveAs(_path);
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.UpdateProfile")
                    .Parameter("UserName", obj.UserName)
                    .Parameter("Avatar", _FileName)
                    .Execute();


            }

        }
        public Entity.Account GetDataProfile(String UserName)

        {

            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetDataProfile")
                    .Parameter("UserName", UserName)
                    .QuerySingle<Entity.Account>();


            }

        }

        public int Delete(int Id)
        {
            int check = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Delete_Acc")
                      .ParameterOut("check", FluentData.DataTypes.Int32)
                     .Parameter("Id", Id);

                cmd.Execute();
                check = cmd.ParameterValue<int>("check");
            }
            return check;
        }
        public void ChangePassword(Entity.Account obj)

        {
            var Password = Md5.MD5Hash(obj.Password);
            var PasswordNew = Md5.MD5Hash(obj.PasswordNew);

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.ChangePassword")
                    .Parameter("Password", Password)
                    .Parameter("PassWordNew", PasswordNew)
                    .Execute();


            }

        }



    }

}
