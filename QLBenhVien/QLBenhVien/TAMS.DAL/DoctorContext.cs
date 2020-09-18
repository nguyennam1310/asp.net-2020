using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{
    public class DoctorContext : BaseContext
    {
        private static DoctorContext _instance;
        public static DoctorContext Instance()
        {
            if (null == _instance)
            {
                _instance = new DoctorContext();
            }
            return _instance;
        }

        public void Create(Entity.Doctor obj)
        {
           /* string _FileName = Path.GetFileName(obj.file.FileName);
            string _path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/images"), _FileName);
            obj.file.SaveAs(_path);
            int check = 0;*/
            using (var context = MasterDBContext())
            {
                 context.StoredProcedure("dbo.Create_Doctor")
                .Parameter("Name", obj.Name)
                .Parameter("Address", obj.Address)
                .Parameter("Gender", obj.Gender)
                .Parameter("Phone", obj.Phone)
                .Parameter("FacultyId", obj.FacultyId)
                .Parameter("Email", obj.Email)
                .Execute();
               
            }
       
        }


        public void Update(Entity.Doctor obj)
        {
          /*  string _FileName = Path.GetFileName(obj.file.FileName);
            string _path = Path.Combine(HttpContext.Current.Server.MapPath("~/Img"), _FileName);
            obj.file.SaveAs(_path);*/
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_Doctor")
                
                .Parameter("Id", obj.Id)
                 .Parameter("Name", obj.Name)
                .Parameter("Address", obj.Address)
                .Parameter("Gender", obj.Gender)
                .Parameter("Phone", obj.Phone)
                .Parameter("FacultyId", obj.FacultyId)
                .Parameter("Email", obj.Email)
                .Execute();
             
            }
        }


        public void Delete(int Id)
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_Doctor")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }

        public List<Entity.Doctor> GetDoctors()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_Doctors")

                    .QueryMany<Entity.Doctor>();
            }
        }
        public List<Entity.Doctor> GetDoctor(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_Doctor")
                    .Parameter("Id", Id)
                    .QueryMany<Entity.Doctor>();
            }
        }

        public Entity.Doctor GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdDoctor")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.Doctor>();
            }
        }

    }
    }
