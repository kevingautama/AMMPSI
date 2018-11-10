using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMMPSI.Models
{
    public class Movement : Audit
    {
        public int ID { get; set; }
        public DateTime MovementDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ApprovedBy { get; set; }
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }
        public ICollection<MovementItem> MovementItem { get; set; }
    }
}
