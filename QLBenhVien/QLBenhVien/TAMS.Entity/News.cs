using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TAMS.Entity
{
    public class News
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Avatar { get; set; }

        public string Sapo { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

       

        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }

        public string Name { get; set; }

        public HttpPostedFileBase file { get; set; }
    }

}
