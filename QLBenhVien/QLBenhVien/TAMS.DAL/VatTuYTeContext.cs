using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{
    public class VatTuYTeContext : BaseContext
    {
        private static VatTuYTeContext _instance;
        public static VatTuYTeContext Instance()
        {
            if (null == _instance)
            {
                _instance = new VatTuYTeContext();
            }
            return _instance;
        }

       


        public void Create(Entity.VatTuYTe obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Create_VatTuYTe")
                  .Parameter("Ten", obj.Ten)
               .Parameter("MaLoaiVatTu", obj.MaLoaiVatTu)
               .Parameter("MaHangSX", obj.MaHangSX)
               .Parameter("HuongDanSuDung", obj.HuongDanSuDung)
               .Parameter("NgayHetHan", obj.NgayHetHan)
               .Parameter("SoLuong", obj.SoLuong)
               .Parameter("MaDonVi", obj.MaDonVi)
               .Parameter("MoTa", obj.MoTa)
               .Parameter("ThanhPhan", obj.ThanhPhan)
               .Parameter("HamLuong", obj.HamLuong)
               .Parameter("CongDung", obj.CongDung)
               .Parameter("NguonGoc", obj.NguonGoc)
               .Parameter("GiaBan", obj.GiaBan)
               .Parameter("ChatLieu", obj.ChatLieu)
               .Parameter("NgayNhap", obj.NgayNhap)
               .Parameter("LoaiDungCu", obj.LoaiDungCu)
               .Parameter("LoaiHoaChat", obj.LoaiHoaChat)
               .Parameter("NgayBatDauBaoHanh", obj.NgayBatDauBaoHanh)
               .Parameter("NgayKetThucBaoHanh", obj.NgayKetThucBaoHanh)
               .Parameter("NamSX", obj.NamSX)
               .Parameter("TinhTrang", obj.TinhTrang)
               .Execute();

            }

        }
       
        public void DeleteDuplicateVatTuYTe()
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_Duplicate_VatTuYTe")
                .Execute();
            }
        }
        public void Update(Entity.VatTuYTe obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_VatTuYTe")

               .Parameter("Id", obj.Id)
               .Parameter("Ten", obj.Ten)
               .Parameter("MaLoaiVatTu", obj.MaLoaiVatTu)
               .Parameter("MaHangSX", obj.MaHangSX)
               .Parameter("HuongDanSuDung", obj.HuongDanSuDung)
               .Parameter("NgayHetHan", obj.NgayHetHan)
               .Parameter("SoLuong", obj.SoLuong)
               .Parameter("MaDonVi", obj.MaDonVi)
               .Parameter("MoTa", obj.MoTa)
               .Parameter("ThanhPhan", obj.ThanhPhan)
               .Parameter("HamLuong", obj.HamLuong)
               .Parameter("CongDung", obj.CongDung)
               .Parameter("NguonGoc", obj.NguonGoc)
               .Parameter("GiaBan", obj.GiaBan)
               .Parameter("ChatLieu", obj.ChatLieu)
               .Parameter("NgayNhap", obj.NgayNhap)
               .Parameter("LoaiDungCu", obj.LoaiDungCu)
               .Parameter("LoaiHoaChat", obj.LoaiHoaChat)
               .Parameter("NgayBatDauBaoHanh", obj.NgayBatDauBaoHanh)
               .Parameter("NgayKetThucBaoHanh", obj.NgayKetThucBaoHanh)
               .Parameter("NamSX", obj.NamSX)
               .Parameter("TinhTrang", obj.TinhTrang)

                .Execute();

            }
        }


        public void Delete(int Id)
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_VatTuYTe")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }

        public int Count1(int Id)
        {
            int num = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Count_VatTuYTe1")
                      .Parameter("Id", Id)
                      .ParameterOut("Num", FluentData.DataTypes.Int32);
                cmd.Execute();
                num = cmd.ParameterValue<int>("num");
            }
            return num;
        }
        public int Count2(int Id)
        {
            int num = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Count_VatTuYTe2")
                      .Parameter("Id", Id)
                      .ParameterOut("Num", FluentData.DataTypes.Int32);
                cmd.Execute();
                num = cmd.ParameterValue<int>("num");
            }
            return num;
        }
        public int Count3(int Id)
        {
            int num = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Count_VatTuYTe3")
                      .Parameter("Id", Id)
                      .ParameterOut("Num", FluentData.DataTypes.Int32);
                cmd.Execute();
                num = cmd.ParameterValue<int>("num");
            }
            return num;
        }
        public int Count4(int Id)
        {
            int num = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Count_VatTuYTe4")
                      .Parameter("Id", Id)
                      .ParameterOut("Num", FluentData.DataTypes.Int32);
                cmd.Execute();
                num = cmd.ParameterValue<int>("num");
            }
            return num;
        }
        public int Count5(int Id)
        {
            int num = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Count_VatTuYTe5")
                      .Parameter("Id", Id)
                      .ParameterOut("Num", FluentData.DataTypes.Int32);
                cmd.Execute();
                num = cmd.ParameterValue<int>("num");
            }
            return num;
        }
        public List<Entity.VatTuYTe> GetVatTuYTe(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_VatTuYTe")
                    .Parameter("Id", Id)
                    .QueryMany<Entity.VatTuYTe>();
            }
        }
        public List<Entity.VatTuYTe> GetVatTuYTes()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_VatTuYTes")
                    .QueryMany<Entity.VatTuYTe>();
            }
        }


        public Entity.VatTuYTe GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdVatTuYTe")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.VatTuYTe>();
            }
        }
    }
}
