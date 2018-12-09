using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMMPSI.Models
{
    public class MovementLogViewModel : MovementLog
    {
        public string DateTime { get; set; }
        public string AssetName { get; set; }
        public string LocationName { get; set; }
    }
}
