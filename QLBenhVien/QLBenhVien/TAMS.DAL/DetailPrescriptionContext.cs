using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{
  
        public class DetailPrescriptionContext : BaseContext
        {
            private static DetailPrescriptionContext _instance;
            public static DetailPrescriptionContext Instance()
            {
                if (null == _instance)
                {
                    _instance = new DetailPrescriptionContext();
                }
                return _instance;
            }

        public void Create(Entity.DetailPrescription obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Create_DetailPrescription")
               .Parameter("Amount", obj.Amount)
               .Parameter("DetailRecordId", obj.DetailRecordId)
               .Parameter("Note", obj.Note)
               .Parameter("Unit", obj.Unit)
               .Parameter("MedicineId", obj.MedicineId)

               .Execute();

            }

        }


        public void Update(Entity.DetailPrescription obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_DetailPrescription")

                .Parameter("Id", obj.Id)
                .Parameter("Amount", obj.Amount)
               .Parameter("Note", obj.Note)
               .Parameter("Unit", obj.Unit)
               .Parameter("MedicineId", obj.MedicineId)
                .Execute();

            }
        }


        public void Delete(int Id)
            {
                using (var context = MasterDBContext())
                {
                    context.StoredProcedure("dbo.Delete_DetailPrescription")
                         .Parameter("Id", Id)
                         .Execute();
                }
            }

            public List<Entity.DetailPrescription> GetDetailPrescription(int Id)
            {
                using (var context = MasterDBContext())
                {
                    return context.StoredProcedure("dbo.Read_DetailPrescription")
                        .Parameter("Id", Id)
                        .QueryMany<Entity.DetailPrescription>();
                }
            }
        public List<Entity.DetailPrescription> GetDetailPrescriptions()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_DetailPrescriptions")
             
                    .QueryMany<Entity.DetailPrescription>();
            }
        }



        public Entity.DetailPrescription GetById(int Id)
            {
                using (var context = MasterDBContext())
                {
                    return context.StoredProcedure("dbo.GetByIdDetailPrescription")
                        .Parameter("Id", Id)
                        .QuerySingle<Entity.DetailPrescription>();
                }
            }

        }
    
}
