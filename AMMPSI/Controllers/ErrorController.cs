using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AMMPSI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Page404()
        {
            return View();
        }

        public IActionResult Page403()
        {
            return View();
        }

        public IActionResult Page500()
        {
            return View();
        }
    }
}