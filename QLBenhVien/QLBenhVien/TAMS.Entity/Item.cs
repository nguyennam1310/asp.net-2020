
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public int Amount { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public bool HasValue { get; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
        public bool isEdit { get; set; }
        public string CategoryName { get; set; }
    }
}
