using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{
    public class DetailRecordContext : BaseContext
    {
        private static DetailRecordContext _instance;
        public static DetailRecordContext Instance()
        {
            if (null == _instance)
            {
                _instance = new DetailRecordContext();
            }
            return _instance;
        }

        public void Create(Entity.DetailRecord obj)
        {

            using (var context = MasterDBContext())
            {
                 context.StoredProcedure("dbo.Create_DetailRecord")
                 .Parameter("DiseaseName", obj.DiseaseName)
                .Parameter("Status", obj.Status)
                .Parameter("Note", obj.Note)
                .Parameter("Result", obj.Result)
                .Parameter("Process", obj.Process)
                .Parameter("RecordId", obj.RecordId)
                .Parameter("DoctorId", obj.DoctorId)
                .Parameter("FacultyId", obj.FacultyId)
                .Execute();
             
            }
        
        }


        public void Update(Entity.DetailRecord obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_DetailRecord")

                .Parameter("Id", obj.Id)
                 .Parameter("DiseaseName", obj.DiseaseName)
                .Parameter("Status", obj.Status)
                .Parameter("Note", obj.Note)
                .Parameter("Result", obj.Result)
                .Parameter("Process", obj.Process)
                .Parameter("RecordId", obj.RecordId)
                .Parameter("DoctorId", obj.DoctorId)
                .Parameter("FacultyId", obj.FacultyId)
                .Execute();
            }
        }


        public void Delete(int Id)
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_DetailRecord")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }

        public List<Entity.DetailRecord> GetDetailRecord(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_DetailRecord")
                    .Parameter("Id", Id)
                    .QueryMany<Entity.DetailRecord>();
            }
        }


        public Entity.DetailRecord GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdDetailRecord")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.DetailRecord>();
            }
        }

    }
}
