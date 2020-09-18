using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TAMS.Entity
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public int DetailRecordId { get; set; }
        public HttpPostedFileBase file { get; set; }
    }
}