using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TAMS.Entity
{
    public class Record
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public int? DoctorId { get; set; }

        public string Note { get; set; }

        public string Result { get; set; }

        public int StatusRecord { get; set; }
       /* public string FullName { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; }
        public string Job { get; set; }
        public string ImageProfile { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateOfBirth { get; set; }

        public int PatientId { get; set; }

        public string Name { get; set; }*/

    }
}
