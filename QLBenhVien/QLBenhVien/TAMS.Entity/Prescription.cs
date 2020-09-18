
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class Prescription
    {
        public int Id { get; set; }

        public int DetailPrescriptionId { get; set; }

        public int DetailRecordId { get; set; }

 
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
