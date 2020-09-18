
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace TAMS.Entity
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        public bool Gender { get; set; }

        [Required]
        [StringLength(12)]
        public string IndentificationCardId { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        public int? RecordId { get; set; }

        public bool Status { get; set; }

        public string ImageProfile { get; set; }

        [Required]
        public string PatientCode { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime JoinDate { get; set; }

        public DateTime IndentificationCardDate { get; set; }

        public string Job { get; set; }

        public string WorkPlace { get; set; }

        public string HistoryOfIllnessFamily { get; set; }

        public string HistoryOfIllnessYourself { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }
        public HttpPostedFileBase file { get; set; }
    }
}
