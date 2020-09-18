
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class MedicalSupply
    {
        public int Id { get; set; }

        public DateTime DateOfHire { get; set; }

        public string Status { get; set; }

        public int Amount { get; set; }

        public int ItemId { get; set; }

        public int PatientId { get; set; }
        public string Name { get; set; }
    }
}
