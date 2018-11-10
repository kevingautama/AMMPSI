using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMMPSI.Models
{
    public class Category : Audit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Asset> Asset { get; set; }
    }
}
