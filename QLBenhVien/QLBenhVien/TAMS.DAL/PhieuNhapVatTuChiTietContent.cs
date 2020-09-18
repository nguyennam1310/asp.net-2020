using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{
    public class PhieuNhapVatTuChiTietContext : BaseContext
    {
        private static PhieuNhapVatTuChiTietContext _instance;
        public static PhieuNhapVatTuChiTietContext Instance()
        {
            if (null == _instance)
            {
                _instance = new PhieuNhapVatTuChiTietContext();
            }
            return _instance;
        }

        public void Create(Entity.PhieuNhapVatTuChiTiet obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Create_PhieuNhapVatTuChiTiet")
               
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
               .Parameter("MaVatTu", obj.MaVatTu)
               .Parameter("MaPhieuNhap", obj.MaPhieuNhap)

               /*.Parameter("NamSX", obj.LoSanXuat)*/

               .Execute();

            }

        }


        public void Update(Entity.PhieuNhapVatTuChiTiet obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_PhieuNhapVatTuChiTiet")

                .Parameter("Id", obj.Id)
              /*  .Parameter("Amount", obj.Amount)
               .Parameter("Note", obj.Note)
               .Parameter("Unit", obj.Unit)
               .Parameter("MedicineId", obj.MedicineId)*/
                .Execute();

            }
        }


        public void Delete(int Id)
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_PhieuNhapVatTuChiTiet")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }

        public List<Entity.PhieuNhapVatTuChiTiet> GetPhieuNhapVatTuChiTiet(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_PhieuNhapVatTuChiTiet")
                    .Parameter("Id", Id)
                    .QueryMany<Entity.PhieuNhapVatTuChiTiet>();
            }
        }
        public List<Entity.PhieuNhapVatTuChiTiet> GetPhieuNhapVatTuChiTiets()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_PhieuNhapVatTuChiTiets")

                    .QueryMany<Entity.PhieuNhapVatTuChiTiet>();
            }
        }



        public Entity.PhieuNhapVatTuChiTiet GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdPhieuNhapVatTuChiTiet")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.PhieuNhapVatTuChiTiet>();
            }
        }

    }
}
