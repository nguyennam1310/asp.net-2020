using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{
    public class CategoryContext : BaseContext
    {
        private static CategoryContext _instance;
        public static CategoryContext Instance()
        {
            if (null == _instance)
            {
                _instance = new CategoryContext();
            }
            return _instance;
        }

        public void Create(Entity.Category obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Create_Category")
               .Parameter("Name", obj.Name)
               .Parameter("Unit", obj.Unit)
               .Parameter("Description", obj.Description)
               .Execute();

            }

        }
        public void DeleteDuplicateCategory()
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_Duplicate_Category")
               .Execute();

            }

        }

        public void Update(Entity.Category obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_Category")

                .Parameter("Id", obj.Id)
                    .Parameter("Name", obj.Name)
               .Parameter("Unit", obj.Unit)
               .Parameter("Description", obj.Description)
                .Execute();

            }
        }


       
        public int Delete(int Id)
        {
            int check = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Delete_Category")
                      .ParameterOut("check", FluentData.DataTypes.Int32)
                     .Parameter("Id", Id);

                cmd.Execute();
                check = cmd.ParameterValue<int>("check");
            }
            return check;
        }
        public List<Entity.Category> GetCategory()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_Category")

                    .QueryMany<Entity.Category>();
            }
        }


        public Entity.Category GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdCategory")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.Category>();
            }
        }
    }
}
