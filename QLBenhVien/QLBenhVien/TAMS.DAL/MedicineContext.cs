using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{
    public class MedicineContext : BaseContext
    {
        private static MedicineContext _instance;
        public static MedicineContext Instance()
        {
            if (null == _instance)
            {
                _instance = new MedicineContext();
            }
            return _instance;
        }

        public void Create(Entity.Medicine obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Create_Medicine")
               .Parameter("Name", obj.Name)
               .Parameter("Description", obj.Description)
              
               .Execute();

            }

        }


        public void Update(Entity.Medicine obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_Medicine")

                .Parameter("Id", obj.Id)
                 .Parameter("Name", obj.Name)
                    .Parameter("Description", obj.Description)

                .Execute();

            }
        }


        public void Delete(int Id)
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_Medicine")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }

        public List<Entity.Medicine> GetMedicine()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_Medicine")

                    .QueryMany<Entity.Medicine>();
            }
        }

        public void DeleteDuplicateMedicine()
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_Duplicate_Medicine")
                .Execute();
            }
        }
        public Entity.Medicine GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdMedicine")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.Medicine>();
            }
        }

    }
}
