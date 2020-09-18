using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TAMS.DAL
{
    public class PatientContext : BaseContext
    {
        private static PatientContext _instance;
        public static PatientContext Instance()
        {
            if (null == _instance)
            {
                _instance = new PatientContext();
            }
            return _instance;
        }

        public int Create(Entity.Patient obj)
        {
            string _FileName = Path.GetFileName(obj.file.FileName);
            string _path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/images"), _FileName);
            obj.file.SaveAs(_path);
            int  check = 0;
            using (var context = MasterDBContext())
            {

                var cmd = context.StoredProcedure("dbo.Create_Patient")
                   .Parameter("FullName", obj.FullName)
                .Parameter("DateOfBirth", obj.DateOfBirth)
                .Parameter("ImageProfile", _FileName)
                .Parameter("Address", obj.Address)
                .Parameter("Gender", obj.Gender)
                .Parameter("Phone", obj.Phone)
                .Parameter("Status", obj.Status)
                .Parameter("IndentificationCardId", obj.IndentificationCardId)             
                .Parameter("JoinDate", obj.JoinDate)
                .Parameter("IndentificationCardDate", obj.IndentificationCardDate)
                .Parameter("Job", obj.Job)
                .Parameter("WorkPlace", obj.WorkPlace)
                .Parameter("HistoryOfIllnessFamily", obj.HistoryOfIllnessFamily)
                .Parameter("HistoryOfIllnessYourself", obj.HistoryOfIllnessYourself)
                .Parameter("Email", obj.Email)
                .ParameterOut("check", FluentData.DataTypes.Int32);
                cmd.Execute();
                check = cmd.ParameterValue<int>("check");
            }
            return check;
        }
        public int Create1(Entity.Patient obj)
        {

            int check = 0;
            using (var context = MasterDBContext())
            {

                var cmd = context.StoredProcedure("dbo.Create_Patient1")
                .Parameter("FullName", obj.FullName)
                .Parameter("DateOfBirth", obj.DateOfBirth)
                .Parameter("Address", obj.Address)
                .Parameter("Gender", obj.Gender)
                .Parameter("Phone", obj.Phone)
                .Parameter("Status", obj.Status)
                .Parameter("IndentificationCardId", obj.IndentificationCardId)
                
                .Parameter("JoinDate", obj.JoinDate)
                .Parameter("IndentificationCardDate", obj.IndentificationCardDate)
                .Parameter("Job", obj.Job)
                .Parameter("WorkPlace", obj.WorkPlace)
                .Parameter("HistoryOfIllnessFamily", obj.HistoryOfIllnessFamily)
                .Parameter("HistoryOfIllnessYourself", obj.HistoryOfIllnessYourself)
                .Parameter("Email", obj.Email)
                 .ParameterOut("check", FluentData.DataTypes.Int32);
                cmd.Execute();
                check = cmd.ParameterValue<int>("check");
            }
            return check;
        }

        public int Update(Entity.Patient obj)
        {
            string _FileName = Path.GetFileName(obj.file.FileName);
            string _path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/images"), _FileName);
            obj.file.SaveAs(_path);
            int check = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Update_Patient")
                .Parameter("FullName", obj.FullName)
                .Parameter("DateOfBirth", obj.DateOfBirth)
                .Parameter("Id", obj.Id)
                .Parameter("ImageProfile", _FileName)
                .Parameter("Address", obj.Address)
                .Parameter("Gender", obj.Gender)
                .Parameter("Phone", obj.Phone)
                .Parameter("Status", obj.Status)
                .Parameter("IndentificationCardId", obj.IndentificationCardId)
                
                .Parameter("JoinDate", obj.JoinDate)
                .Parameter("IndentificationCardDate", obj.IndentificationCardDate)
                .Parameter("Job", obj.Job)
                .Parameter("WorkPlace", obj.WorkPlace)
                .Parameter("HistoryOfIllnessFamily", obj.HistoryOfIllnessFamily)
                .Parameter("HistoryOfIllnessYourself", obj.HistoryOfIllnessYourself)
                .Parameter("Email", obj.Email)
                .ParameterOut("check", FluentData.DataTypes.Int32);
                cmd.Execute();
                check = cmd.ParameterValue<int>("check");
            }
            return check;
        }
        public int Update1(Entity.Patient obj)
        {
            int check = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Update_Patient1")
                .Parameter("FullName", obj.FullName)
                .Parameter("DateOfBirth", obj.DateOfBirth)
                .Parameter("Id", obj.Id)
                .Parameter("Address", obj.Address)
                .Parameter("Gender", obj.Gender)
                .Parameter("Phone", obj.Phone)
                .Parameter("Status", obj.Status)
                .Parameter("IndentificationCardId", obj.IndentificationCardId)
                
                .Parameter("JoinDate", obj.JoinDate)
                .Parameter("IndentificationCardDate", obj.IndentificationCardDate)
                .Parameter("Job", obj.Job)
                .Parameter("WorkPlace", obj.WorkPlace)
                .Parameter("HistoryOfIllnessFamily", obj.HistoryOfIllnessFamily)
                .Parameter("HistoryOfIllnessYourself", obj.HistoryOfIllnessYourself)
                .Parameter("Email", obj.Email)
                .ParameterOut("check", FluentData.DataTypes.Int32);
               
                cmd.Execute();
                check = cmd.ParameterValue<int>("check");

            }
            return check;
        }

        public void Delete(int Id)
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_Patient")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }

        public List<Entity.Patient> GetPatient()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_Patient")

                    .QueryMany<Entity.Patient>();
            }
        }
        public List<Entity.Patient> GetPatientNew()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_PatientNew")

                    .QueryMany<Entity.Patient>();
            }
        }

        public Entity.Patient GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdPatient")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.Patient>();
            }
        }



    }
}
