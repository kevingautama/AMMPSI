using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMMPSI.Models
{
    public class MovementItem : Audit
    {
        public int ID { get; set; }
        public int MovementID { get; set; }
        public int AssetID { get; set; }
        public bool IsMoved { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual Movement Movement { get; set; }

    }
}
