using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMMPSI.Models
{
    public class MoveAssetViewModel
    {
        public DateTime MovementDate { get; set; }
        public int LocationID { get; set; }
        public string Description { get; set; }
        public List<int> ListAssetID { get; set; }
    }
}
