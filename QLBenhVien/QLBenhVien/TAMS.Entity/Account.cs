
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TAMS.Entity
{
    public class Account
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string LinkAvatar { get; set; }

        public bool Gender { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        public int Role { get; set; }

        public int? PatientId { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PasswordNew { get; set; }

        public string PatientName { get; set; }

        public HttpPostedFileBase file { get; set; }

    }
}
