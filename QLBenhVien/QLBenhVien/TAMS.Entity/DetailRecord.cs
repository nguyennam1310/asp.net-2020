
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class DetailRecord
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string DiseaseName { get; set; }

        public string Note { get; set; }

        public string Result { get; set; }

        public bool Status { get; set; }

        public int DoctorId { get; set; }

        public int FacultyId { get; set; }

        [Required]
        public int Process { get; set; }

        public int RecordId { get; set; }

        public int DetailDoctorId { get; set; }
        public bool isEdit { get; set; }
    }
}
