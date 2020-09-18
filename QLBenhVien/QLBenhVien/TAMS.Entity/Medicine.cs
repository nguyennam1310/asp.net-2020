
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class Medicine
    {

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
