using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMMPSI.Data;
using AMMPSI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AMMPSI.Controllers
{
    [Authorize(Roles = "Admin,Manager,Employee")]
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
                var movementLog = await _context.MovementLog.Where(a => a.DeletedDate == null).ToListAsync();
                var moveLogGroupByAsset = movementLog.GroupBy(a => a.AssetID);
                var locationList = await _context.Location.Where(a => a.DeletedDate == null).ToListAsync();

                foreach(var item in locationList)
                {
                    int assetCount = 0;

                    foreach(var log in moveLogGroupByAsset)
                    {
                        if(_context.Asset.FindAsync(log.First().AssetID).Result.DeletedDate == null)
                        {
                            if (log.OrderBy(a => a.CreatedDate).LastOrDefault().LocationID == item.ID)
                            {
                                assetCount = assetCount + 1;
                            }
                        }
                    }

                    locationData.Add(new LocationViewModel
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Floor = item.Floor,
                        TotalAsset = assetCount.ToString()
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

        [HttpGet]
        public async Task<IActionResult> GetLocationAutoComplete(string searchText)
        {
            var location = await _context.Location.Where(x => x.DeletedDate == null).ToListAsync();

            if (location == null)
            {
                return NotFound();
            }

            if (!String.IsNullOrWhiteSpace(searchText))
            {
                location = location.Where(a => a.Name.ToUpper().Contains(searchText.ToUpper())).ToList();
            }

            return Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> GetLocation(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var location = await _context.Location.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation(Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            location.CreatedDate = DateTime.Now;
            location.CreatedBy = User.Identity.Name;
            _context.Location.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = location.ID }, location);
        }

        [HttpPost]
        public async Task<IActionResult> EditLocation(int id, Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != location.ID)
            {
                return BadRequest();
            }

            location.UpdatedDate = DateTime.Now;
            location.UpdatedBy= User.Identity.Name;
            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var location = _context.Location.SingleOrDefault(m => m.ID == id);
            if (location == null)
            {
                return NotFound();
            }

            location.DeletedDate = DateTime.Now;
            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetLocationAsset(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movementLog = await _context.MovementLog.Where(a => a.DeletedDate == null).ToListAsync();
            var moveLogGroupByAsset = movementLog.GroupBy(a => a.AssetID);

            List<AssetViewModel> assetList = new List<AssetViewModel>(); 
                
            foreach (var log in moveLogGroupByAsset)
            {
                var asset = await _context.Asset.FindAsync(log.First().AssetID);
                if (asset.DeletedDate == null)
                {
                    if (log.OrderBy(a => a.CreatedDate).LastOrDefault().LocationID == id)
                    {
                        var category = await _context.Category.FindAsync(asset.CategoryID);
                        assetList.Add(new AssetViewModel
                        {
                            Name = asset.Name,
                            CategoryName = category.Name
                        });
                    }
                }
            }

            return Ok(assetList);
        }

        private bool LocationExists(int id)
        {
            return _context.Location.Any(e => e.ID == id);
        }
    }
}