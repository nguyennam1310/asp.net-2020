

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class PhieuLinhVatTu
    {
        public int Id { get; set; }

        public int? MaBoPhanNhan { get; set; }

        public DateTime? NgayLinh { get; set; }
    }
}
