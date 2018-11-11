using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMMPSI.Data;
using AMMPSI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace AMMPSI.Controllers
{
    public class LocationController : Controller
    {
        private readonly AMContext _context;

        public LocationController(AMContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetLocationTableData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

                // Skip number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();

                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();

                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][data]"].FirstOrDefault();

                // Sort Column Direction (asc, desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10, 20, 50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;

                int skip = start != null ? Convert.ToInt32(start) : 0;

                int recordsTotal = 0;




                List<LocationViewModel> locationData = new List<LocationViewModel>();
                // getting all Proposal data 
                var locationList = await _context.Location.ToListAsync();

                foreach(var item in locationList)
                {
                    locationData.Add(new LocationViewModel
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Floor = item.Floor,
                        TotalAsset = "Infinity"
                    });
                }

                //Sorting  
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    locationData = locationData.AsQueryable().OrderBy(sortColumn + " " + sortColumnDirection).ToList();
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    locationData = locationData.Where(m => m.Name.Contains(searchValue) || m.Floor.Contains(searchValue)).ToList();
                }

                //total number of rows counts   
                recordsTotal = locationData.Count();
                //Paging   
                var data = locationData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetLocation(int id)
        {
            var data = await _context.Location.FindAsync(id);

            return Ok(data);
        }
    }
}