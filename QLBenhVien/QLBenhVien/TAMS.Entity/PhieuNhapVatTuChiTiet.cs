
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class PhieuNhapVatTuChiTiet
    {
        public int Id { get; set; }

        public int? MaPhieuNhap { get; set; }

        public DateTime? NgayNhap { get; set; }

        public int? MaVatTu { get; set; }

        public int? MaDonVi { get; set; }

        public double? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public double? ThanhTien { get; set; }

        [StringLength(250)]
        public string LoSanXuat { get; set; }

        public DateTime? HanSuDung { get; set; }

        public DateTime? NgayChot { get; set; }


        [StringLength(250)]
        public string Ten { get; set; }

        [StringLength(250)]
        public string MaLoaiVatTu { get; set; }

        public int? MaHangSX { get; set; }
        public string HangSX { get; set; }
        public string HuongDanSuDung { get; set; }

        public DateTime NgayHetHan { get; set; }


        public string DonVi { get; set; }
        public string MoTa { get; set; }

        [StringLength(250)]
        public string ThanhPhan { get; set; }

        [StringLength(250)]
        public string HamLuong { get; set; }

        [StringLength(250)]
        public string NguonGoc { get; set; }

        public double GiaBan { get; set; }



        [StringLength(250)]
        public string CongDung { get; set; }

        public string ChatLieu { get; set; }
        public string LoaiDungCu { get; set; }
        public string LoaiHoaChat { get; set; }

        public string TinhTrang { get; set; }
        public DateTime NgayBatDauBaoHanh { get; set; }
        public DateTime NgayKetThucBaoHanh { get; set; }

        public DateTime NamSX { get; set; }








    }
}


