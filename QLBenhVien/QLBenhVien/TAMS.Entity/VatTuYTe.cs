
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class VatTuYTe
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Ten { get; set; }

        [StringLength(250)]
        public string MaLoaiVatTu { get; set; }

        public int? MaHangSX { get; set; }
        public string HangSX { get; set; }
        public string HuongDanSuDung { get; set; }

        public DateTime NgayHetHan { get; set; }

        public int SoLuong { get; set; }

        public int? MaDonVi { get; set; }

        public string DonVi { get; set; }
        public string MoTa { get; set; }

        [StringLength(250)]
        public string ThanhPhan { get; set; }

        [StringLength(250)]
        public string HamLuong { get; set; }

        [StringLength(250)]
        public string NguonGoc { get; set; }

        public double GiaBan { get; set; }

        public DateTime NgayNhap { get; set; }

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



