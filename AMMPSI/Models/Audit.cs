using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMMPSI.Models
{
    public class Audit
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
