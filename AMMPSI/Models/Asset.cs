using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMMPSI.Models
{
    public class Asset : Audit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public bool IsMoveable { get; set; }
        public string DepreciationDuration { get; set; }
        public int CategoryID { get; set; }
        public ICollection<MovementItem> MovementItem {get;set;}
        public ICollection<MovementLog> MovementLog { get; set; }
        public virtual Category Category { get; set; }
    }
}
