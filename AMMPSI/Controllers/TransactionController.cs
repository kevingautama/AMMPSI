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
    public class TransactionController : Controller
    {
        private readonly AMContext _context;

        public TransactionController(AMContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MoveAsset()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMoveAssetRequest(MoveAssetViewModel moveRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movement movement = new Movement
            {
                MovementDate = moveRequest.MovementDate,
                Description = moveRequest.Description,
                Status = "Order",
                LocationID = moveRequest.LocationID,
                ApprovedBy = null,
                CreatedBy = "",
                CreatedDate = DateTime.Now
            };

            _context.Movement.Add(movement);

            foreach(var item in moveRequest.ListAssetID)
            {
                MovementItem movementItem = new MovementItem
                {
                    MovementID = movement.ID,
                    AssetID = item,
                    IsMoved = false,
                    CreatedBy = "",
                    CreatedDate = DateTime.Now
                };

                _context.MovementItem.Add(movementItem);
            }
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMove", new { id = movement.ID }, movement);
        }

        [HttpPost]
        public async Task<IActionResult> GetAssetMoveableTableData()
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




                List<AssetViewModel> assetData = new List<AssetViewModel>();
                // getting all Proposal data 
                var assetList = await _context.Asset.Where(a => a.DeletedDate == null).ToListAsync();

                foreach (var item in assetList)
                {
                    var category = await _context.Category.FindAsync(item.CategoryID);
                    assetData.Add(new AssetViewModel
                    {
                        ID = item.ID,
                        Name = item.Name,
                        CategoryName = category.Name
                    });
                }

                //Sorting  
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    assetData = assetData.AsQueryable().OrderBy(sortColumn + " " + sortColumnDirection).ToList();
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    assetData = assetData.Where(m => m.Name.Contains(searchValue) || m.CategoryName.Contains(searchValue)).ToList();
                }

                //total number of rows counts   
                recordsTotal = assetData.Count();
                //Paging   
                var data = assetData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}