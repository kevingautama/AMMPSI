using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMMPSI.Models
{
    public class RoleViewModel
    {
        public String RoleId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public String RoleName { get; set; }
    }
}
