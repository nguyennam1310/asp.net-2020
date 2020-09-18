
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.Entity
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        public string Description { get; set; }
        public bool isEdit { get; set; }
    }
}
