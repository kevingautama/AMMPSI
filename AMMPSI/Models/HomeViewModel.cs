using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMMPSI.Models
{
    public class HomeViewModel
    {
        public int[] MonthlyMoveRequest { get; set; }
        public int[] MonthlyApprovalRequest { get; set; }
        public int[] MonthlyTask { get; set; }
    }
}
