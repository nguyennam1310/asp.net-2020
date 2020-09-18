


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class PhieuLinhChiTiet
    {
        public int Id { get; set; }

        public int? MaPhieuLinh { get; set; }

        public int? MaVatTu { get; set; }

        public int? MaDonVi { get; set; }

        public int? SoLuongDeNghi { get; set; }

        public int? SoLuongDuyet { get; set; }
    }
}



