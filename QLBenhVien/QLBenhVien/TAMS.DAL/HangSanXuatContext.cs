using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{
    public class HangSanXuatContext : BaseContext
    {
        private static HangSanXuatContext _instance;
        public static HangSanXuatContext Instance()
        {
            if (null == _instance)
            {
                _instance = new HangSanXuatContext();
            }
            return _instance;
        }

        public void Create(Entity.HangSanXuat obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Create_HangSanXuat")
               .Parameter("Name", obj.Name)
               .Parameter("Email", obj.Email)
               .Parameter("Address", obj.Address)
               .Parameter("Country", obj.Country)
               .Parameter("Fax", obj.Fax)
               .Parameter("Phone", obj.Phone)
               .Parameter("Note", obj.Note)
               .Execute();

            }

        }


        public void Update(Entity.HangSanXuat obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_HangSanXuat")

                .Parameter("Id", obj.Id)
                 .Parameter("Name", obj.Name)
                 .Parameter("Email", obj.Email)
               .Parameter("Address", obj.Address)
               .Parameter("Country", obj.Country)
               .Parameter("Fax", obj.Fax)
               .Parameter("Phone", obj.Phone)
               .Parameter("Note", obj.Note)
                .Execute();

            }
        }


        public void Delete(int Id)
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_HangSanXuat")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }
        public void DeleteDuplicate()
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_Duplicate_HangSanXuat")
                .Execute();
            }
        }
        public List<Entity.HangSanXuat> GetHangSanXuat()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_HangSanXuat")

                    .QueryMany<Entity.HangSanXuat>();
            }
        }


        public Entity.HangSanXuat GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdHangSanXuat")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.HangSanXuat>();
            }
        }

    }
}
