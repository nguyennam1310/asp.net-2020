using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{
    public class FacultyContext : BaseContext
    {
        private static FacultyContext _instance;
        public static FacultyContext Instance()
        {
            if (null == _instance)
            {
                _instance = new FacultyContext();
            }
            return _instance;
        }

        public void Create(Entity.Faculty obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Create_Faculty")
               .Parameter("Name", obj.Name)
               .Execute();

            }

        }


        public void Update(Entity.Faculty obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_Faculty")

                .Parameter("Id", obj.Id)
                 .Parameter("Name", obj.Name)
                .Execute();

            }
        }


        public void Delete(int Id)
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_Faculty")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }
        public void DeleteDuplicate()
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_Duplicate_Faculty")
                .Execute();
            }
        }
        public List<Entity.Faculty> GetFaculty()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_Faculty")

                    .QueryMany<Entity.Faculty>();
            }
        }


        public Entity.Faculty GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdFaculty")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.Faculty>();
            }
        }

    }
}
