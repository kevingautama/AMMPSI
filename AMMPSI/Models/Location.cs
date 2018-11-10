using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMMPSI.Models
{
    public class Location : Audit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Movement> Movement { get; set; }
        public ICollection<MovementLog> MovementLog { get; set; }
    }
}
