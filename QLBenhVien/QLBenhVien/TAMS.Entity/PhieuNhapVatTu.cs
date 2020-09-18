

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class PhieuNhapVatTu
    {
        public int Id { get; set; }
  
        public int? MaNhaCungCap { get; set; }

        [StringLength(250)]
        public string NguoiGiaoHang { get; set; }

        [StringLength(250)]
        public string NguoiNhan { get; set; }

        public DateTime? NgayNhap { get; set; }

   
        public double? TongTien { get; set; }

        public DateTime? NgayChot { get; set; }

        public string GhiChu { get; set; }

        [StringLength(250)]
        public string NguonNhap { get; set; }

        public double? Thue { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(250)]
        public string DienThoai { get; set; }




 




    }
}


