using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{
    public class MedicalSupplyContext : BaseContext
    {
        private static MedicalSupplyContext _instance;
        public static MedicalSupplyContext Instance()
        {
            if (null == _instance)
            {
                _instance = new MedicalSupplyContext();
            }
            return _instance;
        }

        public void Create(Entity.MedicalSupply obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Create_MedicalSupply")
               .Parameter("Amount", obj.Amount)
               .Parameter("DateOfHire", obj.DateOfHire)
               .Parameter("Status", obj.Status)
               .Parameter("PatientId", obj.PatientId)
               .Parameter("ItemId", obj.ItemId)
               .Execute();

            }

        }


        public void Update(Entity.MedicalSupply obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_MedicalSupply")

                .Parameter("Id", obj.Id)
                .Parameter("Amount", obj.Amount)
               .Parameter("DateOfHire", obj.DateOfHire)
               .Parameter("Status", obj.Status)
               .Parameter("PatientId", obj.PatientId)
               .Parameter("ItemId", obj.ItemId)
                .Execute();

            }
        }


        public void Delete(int Id)
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_MedicalSupply")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }

        public List<Entity.MedicalSupply> GetMedicalSupply(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_MedicalSupply")
                    .Parameter("Id", Id)
                    .QueryMany<Entity.MedicalSupply>();
            }
        }


        public Entity.MedicalSupply GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdMedicalSupply")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.MedicalSupply>();
            }
        }
       
    }
   
}
