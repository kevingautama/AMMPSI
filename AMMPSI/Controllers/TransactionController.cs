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
                        CategoryName = category.Name,
                        CurrentLocation = "room1"
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

        [HttpPost]
        public async Task<IActionResult> GetMoveTableData()
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

                List<MoveViewModel> moveData = new List<MoveViewModel>();
                var moveList = await _context.Movement.Where(a => a.DeletedDate == null).ToListAsync();

                foreach (var item in moveList)
                {
                    var moveAssetList = await _context.MovementItem.Where(a => a.MovementID == item.ID && a.DeletedDate == null).ToListAsync();
                    moveData.Add(new MoveViewModel
                    {
                        ID = item.ID,
                        MoveDate = item.MovementDate.ToShortDateString(),
                        TotalAsset = moveAssetList.Any() ? moveAssetList.Count.ToString() : "0",
                        Status = item.Status
                    });
                }

                //Sorting  
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    moveData = moveData.AsQueryable().OrderBy(sortColumn + " " + sortColumnDirection).ToList();
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    moveData = moveData.Where(m => m.MovementDate.ToShortDateString().Contains(searchValue) || m.TotalAsset.Contains(searchValue) || m.Status.Contains(searchValue)).ToList();
                }

                //total number of rows counts   
                recordsTotal = moveData.Count();
                //Paging   
                var data = moveData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetMove(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var move = await _context.Movement.FindAsync(id);

            if (move == null)
            {
                return NotFound();
            }

            MoveViewModel data = new MoveViewModel();

            data.MoveDate = move.MovementDate.ToShortDateString();
            data.Status = move.Status;
            var location = await _context.Location.FindAsync(move.LocationID);
            if (location == null)
            {
                return NotFound();
            }
            data.LocationName = location.Name;
            data.Description = move.Description;
            data.ApprovedBy = move.ApprovedBy;
            data.MoveAssetList = new List<MoveItemViewModel>();
            var moveAssetList = await _context.MovementItem.Where(a => a.MovementID == move.ID && a.DeletedDate == null).ToListAsync();

            if (moveAssetList.Any())
            {
                foreach(var item in moveAssetList)
                {
                    var asset = await _context.Asset.FindAsync(item.AssetID);
                    var category = await _context.Category.FindAsync(asset.CategoryID);
                    data.MoveAssetList.Add(new MoveItemViewModel
                    {
                        Name = asset.Name,
                        CategoryName = category.Name,
                        CurrentLocation = "room1",
                        IsMoved = item.IsMoved
                    });
                }
                
            }

            return Ok(data);
        }
    }
}