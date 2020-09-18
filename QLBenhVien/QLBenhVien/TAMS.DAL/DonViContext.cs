using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{
    public class DonViContext : BaseContext
    {
        private static DonViContext _instance;
        public static DonViContext Instance()
        {
            if (null == _instance)
            {
                _instance = new DonViContext();
            }
            return _instance;
        }

        public void Create(Entity.DonVi obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Create_DonVi")
               .Parameter("Name", obj.Name)
               .Parameter("Description", obj.Description)
               .Execute();

            }

        }


        public void Update(Entity.DonVi obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_DonVi")

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
                context.StoredProcedure("dbo.Delete_DonVi")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }
        public void DeleteDuplicate()
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_Duplicate_DonVi")
                .Execute();
            }
        }
        public List<Entity.DonVi> GetDonVi()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_DonVi")

                    .QueryMany<Entity.DonVi>();
            }
        }


        public Entity.DonVi GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdDonVi")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.DonVi>();
            }
        }

    }
}
