using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMMPSI.Models
{
    public class AssetViewModel : Asset
    {
        public String CategoryName { get; set; }
        public string CurrentLocation { get; set; }
    }
}
