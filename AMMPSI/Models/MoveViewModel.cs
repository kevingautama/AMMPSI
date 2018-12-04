using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMMPSI.Models
{
    public class MoveViewModel : Movement
    {
        public string MoveDate { get; set; }
        public string LocationName { get; set; }
        public string TotalAsset { get; set; }
        public List<MoveItemViewModel> MoveAssetList { get; set; }
    }
}
