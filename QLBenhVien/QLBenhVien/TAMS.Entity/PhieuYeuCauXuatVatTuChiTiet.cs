
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class PhieuYeuCauXuatVatTuChiTiet
    {
        public int Id { get; set; }

        public int? MaPhieuYeuCau { get; set; }

        public DateTime? NgayYeuCau { get; set; }

        public int? MaVatTu { get; set; }

        public int? MaDonVi { get; set; }

        public double? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public double? ThanhTien { get; set; }

        [StringLength(250)]
        public string LoSanXuat { get; set; }

        public DateTime? HanSuDung { get; set; }

        public string GhiChu { get; set; }

        public DateTime? NgayChot { get; set; }
    }
}


