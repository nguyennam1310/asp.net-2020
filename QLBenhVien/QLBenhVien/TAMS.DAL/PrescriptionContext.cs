using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{
    public class PrescriptionContext : BaseContext
    {
        private static PrescriptionContext _instance;
        public static PrescriptionContext Instance()
        {
            if (null == _instance)
            {
                _instance = new PrescriptionContext();
            }
            return _instance;
        }

     /*   public void Create(Entity.Prescription obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Create_Prescription")
               .Parameter("Name", obj.Name)
               .Execute();

            }

        }


        public void Update(Entity.Prescription obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_Prescription")

                .Parameter("Id", obj.Id)
                 .Parameter("Name", obj.Name)
                .Execute();

            }
        }*/


        public void Delete(int Id)
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_Prescription")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }

        public List<Entity.DetailPrescription> GetPrescription(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_DetailPrescription")
                    .Parameter("Id", Id)
                    .QueryMany<Entity.DetailPrescription>();
            }
        }
        public List<Entity.Prescription> GetPrescriptions()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_Prescriptions")
                    .QueryMany<Entity.Prescription>();
            }
        }


        public Entity.Prescription GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdPrescription")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.Prescription>();
            }
        }

    }
}
