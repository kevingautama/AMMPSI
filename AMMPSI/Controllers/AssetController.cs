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
    [Authorize]
    public class AssetController : Controller
    {
        private readonly AMContext _context;

        public AssetController(AMContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAssetTableData()
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




                List<AssetViewModel> AssetData = new List<AssetViewModel>();
                // getting all Proposal data 
                var AssetList = await _context.Asset.Where(a => a.DeletedDate == null).ToListAsync();
                var locationList = await _context.Location.ToListAsync();

                foreach (var item in AssetList)
                {
                    var category = await _context.Category.FindAsync(item.CategoryID);
                    var latestLog = await _context.MovementLog.Where(a => a.AssetID == item.ID).OrderBy(a => a.CreatedDate).LastOrDefaultAsync();
                    string lastLocation = "-";
                    if(latestLog != null)
                    {
                        lastLocation = locationList.Where(a => a.ID == latestLog.LocationID).FirstOrDefault().Name;
                    }
                    AssetData.Add(new AssetViewModel
                    {
                        ID = item.ID,
                        Name = item.Name,
                        CategoryName = category.Name,
                        CurrentLocation = lastLocation
                    });
                }

                //Sorting  
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    AssetData = AssetData.AsQueryable().OrderBy(sortColumn + " " + sortColumnDirection).ToList();
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    AssetData = AssetData.Where(m => m.Name.Contains(searchValue)).ToList();
                }

                //total number of rows counts   
                recordsTotal = AssetData.Count();
                //Paging   
                var data = AssetData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetAsset(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Asset = await _context.Asset.FindAsync(id);

            if (Asset == null)
            {
                return NotFound();
            }

            return Ok(Asset);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsset(Asset Asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Asset.CreatedDate = DateTime.Now;
            Asset.CreatedBy = User.Identity.Name;
            _context.Asset.Add(Asset);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsset", new { id = Asset.ID }, Asset);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsset(int id, Asset Asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Asset.ID)
            {
                return BadRequest();
            }

            Asset.UpdatedDate = DateTime.Now;
            Asset.UpdatedBy = User.Identity.Name;
            _context.Entry(Asset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
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
        public async Task<IActionResult> DeleteAsset(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Asset = _context.Asset.SingleOrDefault(m => m.ID == id);
            if (Asset == null)
            {
                return NotFound();
            }

            Asset.DeletedDate = DateTime.Now;
            Asset.DeletedBy = User.Identity.Name;
            _context.Entry(Asset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
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
        public async Task<IActionResult> GetAssetMovementLog(int assetId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<MovementLogViewModel> movementLogData = new List<MovementLogViewModel>();
            var movementLogList = await _context.MovementLog.Where(a => a.DeletedDate == null && a.AssetID == assetId).OrderByDescending(a => a.CreatedDate).ToListAsync();

            var locationList = await _context.Location.Where(a => a.DeletedDate == null).ToListAsync();

            foreach (var item in movementLogList)
            {
                movementLogData.Add(new MovementLogViewModel
                {
                    DateTime = item.CreatedDate.ToShortDateString() + " " + item.CreatedDate.ToShortTimeString(),
                    LocationName = locationList.Where(a => a.ID == item.LocationID).FirstOrDefault().Name,
                    MovedBy = item.MovedBy
                });
            }

            return Ok(movementLogData);
        }

        private bool AssetExists(int id)
        {
            return _context.Asset.Any(e => e.ID == id);
        }
    }
}