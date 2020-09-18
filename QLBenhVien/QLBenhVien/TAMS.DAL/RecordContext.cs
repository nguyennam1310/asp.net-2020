using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{

    public class RecordContext : BaseContext
    {
        private static RecordContext _instance;
        public static RecordContext Instance()
        {
            if (null == _instance)
            {
                _instance = new RecordContext();
            }
            return _instance;
        }

       
  

        public void Update(Entity.Record obj)
        {
            
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_Record")
                .Parameter("Note", obj.Note)
                .Parameter("Result", obj.Result)
                .Parameter("Id", obj.Id)
                .Parameter("StatusRecord", obj.StatusRecord)
                .Parameter("DoctorId", obj.DoctorId)
                .Parameter("ModifiedDate", DateTime.Now)
                .Execute();
            }
        }
       



        public Entity.Record GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdRecord")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.Record>();
            }
        }


     
     

    }
    }
