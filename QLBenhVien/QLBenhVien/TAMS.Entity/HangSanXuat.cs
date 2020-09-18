
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class HangSanXuat
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public string Phone { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        public string Note { get; set; }

        [StringLength(250)]
        public string Country { get; set; }

        [StringLength(250)]
        public string Fax { get; set; }

    }
}
