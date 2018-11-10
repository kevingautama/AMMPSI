using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMMPSI.Models
{
    public class MovementLog : Audit
    {
        public int ID { get; set; }
        public int AssetID { get; set; }
        public int LocationID { get; set; }
        public string MovedBy { get; set; }
        public virtual Location Location { get; set; }
        public virtual Asset Asset { get; set; }

    }
}
    