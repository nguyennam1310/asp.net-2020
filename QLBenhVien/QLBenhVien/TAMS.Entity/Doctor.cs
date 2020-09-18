
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TAMS.Entity
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public bool Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int FacultyId { get; set; }

        public string FacultyName { get; set; }
    }
}
