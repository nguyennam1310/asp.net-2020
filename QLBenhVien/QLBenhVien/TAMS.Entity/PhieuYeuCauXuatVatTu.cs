
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class PhieuYeuCauXuatVatTu
    {
        public int Id { get; set; }

        public DateTime? NgayYeuCau { get; set; }

        [StringLength(250)]
        public string NguoiNhan { get; set; }

        public double? TongTiem { get; set; }

        public string GhiChu { get; set; }

        public DateTime? NgayChot { get; set; }

        public int? MaBoPhanNhan { get; set; }

        public double? Thue { get; set; }
    }
}




