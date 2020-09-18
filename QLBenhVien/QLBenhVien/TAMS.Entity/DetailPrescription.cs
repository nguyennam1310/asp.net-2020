
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TAMS.Entity
{
    public class DetailPrescription
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        [Required]
        public string Note { get; set; }

        public int MedicineId { get; set; }

        public string Name { get; set; }
        public bool isEdit { get; set; }

        public int DetailRecordId { get; set; }
    }
}
