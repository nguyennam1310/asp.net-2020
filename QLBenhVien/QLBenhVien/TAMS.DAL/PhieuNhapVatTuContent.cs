using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{
    public class PhieuNhapVatTuContext : BaseContext
    {
        private static PhieuNhapVatTuContext _instance;
        public static PhieuNhapVatTuContext Instance()
        {
            if (null == _instance)
            {
                _instance = new PhieuNhapVatTuContext();
            }
            return _instance;
        }

        public int Create()
        {
            int result ;
            using (var context = MasterDBContext())
            {
               var cmd= context.StoredProcedure("dbo.Create_PhieuNhapVatTu")
               .Parameter("TongTien", 0)
               .ParameterOut("result", FluentData.DataTypes.Int32);
              cmd.Execute();
              result = cmd.ParameterValue<int>("result");
            }
            return result;
        }


        public void Update(Entity.PhieuNhapVatTu obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_PhieuNhapVatTu")

                .Parameter("Id", obj.Id)
                
                .Execute();

            }
        }


        public void Delete(int Id)
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_PhieuNhapVatTu")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }

        public List<Entity.PhieuNhapVatTuChiTiet> GetPhieuNhapVatTu(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_DetailPhieuNhapVatTu")
                    .Parameter("Id", Id)
                    .QueryMany<Entity.PhieuNhapVatTuChiTiet>();
            }
        }
        public List<Entity.PhieuNhapVatTu> GetPhieuNhapVatTus()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_PhieuNhapVatTus")
                    .QueryMany<Entity.PhieuNhapVatTu>();
            }
        }


        public Entity.PhieuNhapVatTu GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdPhieuNhapVatTu")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.PhieuNhapVatTu>();
            }
        }

    }
}
