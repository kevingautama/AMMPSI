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

        public IActionResult MoveTask()
        {
            return View();
        }

        public IActionResult MoveLog()
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
                CreatedBy = User.Identity.Name,
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
                    CreatedBy = User.Identity.Name,
                    CreatedDate = DateTime.Now
                };

                _context.MovementItem.Add(movementItem);
            }
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMove", new { id = movement.ID }, movement);
        }

        [HttpPost]
        public async Task<IActionResult> GetAssetMoveableTableData(string locationId)
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
                var locationList = await _context.Location.ToListAsync();

                foreach (var item in assetList)
                {
                    var category = await _context.Category.FindAsync(item.CategoryID);
                    var latestLog = await _context.MovementLog.Where(a => a.AssetID == item.ID).OrderBy(a => a.CreatedDate).LastOrDefaultAsync();
                    string lastLocation = "-";
                    if (latestLog != null)
                    {
                        if (!String.IsNullOrWhiteSpace(locationId))
                        {
                            if (latestLog.LocationID == int.Parse(locationId))
                            {
                                continue;
                            }
                        }

                        lastLocation = locationList.Where(a => a.ID == latestLog.LocationID).FirstOrDefault().Name;
                    }

                    assetData.Add(new AssetViewModel
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
        public async Task<IActionResult> GetTaskTableData()
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
                var moveList = await _context.Movement.Where(a => a.Status == "Accept" && a.DeletedDate == null).ToListAsync();

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
        public async Task<IActionResult> GetMovementLogTableData()
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

                List<MovementLogViewModel> movementLogData = new List<MovementLogViewModel>();
                var movementLogList = await _context.MovementLog.Where(a => a.DeletedDate == null).OrderBy(a => a.CreatedDate).ToListAsync();

                var locationList = await _context.Location.Where(a => a.DeletedDate == null).ToListAsync();

                foreach (var item in movementLogList)
                {
                    var asset = await _context.Asset.FindAsync(item.AssetID);
                    movementLogData.Add(new MovementLogViewModel
                    {
                        DateTime = item.CreatedDate,
                        AssetName = asset.Name,
                        LocationName = locationList.Where(a => a.ID == item.LocationID).FirstOrDefault().Name,
                        MovedBy = item.MovedBy
                    });
                }

                //total number of rows counts   
                recordsTotal = movementLogData.Count();
                //Paging   
                var data = movementLogData.Skip(skip).Take(pageSize).ToList();
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
            data.ID = move.ID;
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
                        ID = item.ID,
                        Name = asset.Name,
                        CategoryName = category.Name,
                        CurrentLocation = "room1",
                        IsMoved = item.IsMoved
                    });
                }
                
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AcceptMove(int id)
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

            if (await ChangeMoveStatus(move, "Accept"))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> RejectMove(int id)
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

            if (await ChangeMoveStatus(move, "Reject"))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> MoveSingleAsset(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movementItem = await _context.MovementItem.FindAsync(id);

            if (movementItem == null)
            {
                return NotFound();
            }

            var movement = await _context.Movement.FindAsync(movementItem.MovementID);

            if(movement == null)
            {
                return NotFound();
            }

            if (await MoveItem(movementItem, movement.LocationID))
            {
                await IsMoveDone(movement);
                return NoContent();
            }
            
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> MoveAllAsset(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movement = await _context.Movement.FindAsync(id);

            if (movement == null)
            {
                return NotFound();
            }

            var movementItem = await _context.MovementItem.Where(a => a.DeletedDate == null && a.MovementID == movement.ID && a.IsMoved == false).ToListAsync();

            if (movementItem == null)
            {
                return NotFound();
            }

            bool flag = true;

            foreach(var item in movementItem)
            {
                if (!await MoveItem(item, movement.LocationID))
                {
                    flag = false;
                    break;
                    
                }
            }

            if (flag)
            {
                await IsMoveDone(movement);
                return NoContent();
            }

            return NotFound();
        }

        public async Task<bool> MoveItem(MovementItem item,int locationId)
        {
            item.UpdatedDate = DateTime.Now;
            item.IsMoved = true;
            _context.Entry(item).State = EntityState.Modified;

            MovementLog log = new MovementLog
            {
                AssetID = item.AssetID,
                LocationID = locationId,
                MovedBy = User.Identity.Name,
                CreatedBy = User.Identity.Name,
                CreatedDate = DateTime.Now
            };

            _context.MovementLog.Add(log);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovementItemExists(item.ID))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> ChangeMoveStatus(Movement move,string status)
        {
            move.UpdatedDate = DateTime.Now;
            move.Status = status;
            _context.Entry(move).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoveExists(move.ID))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task IsMoveDone(Movement move)
        {

            var movementItem = await _context.MovementItem.Where(a => a.DeletedDate == null && a.MovementID == move.ID).ToListAsync();

            bool flag = true;

            foreach(var item in movementItem)
            {
                if(item.IsMoved == false)
                {
                    flag = false;
                }
            }

            if (flag)
            {
                move.Status = "Done";
                _context.Entry(move).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
        }

        private bool MoveExists(int id)
        {
            return _context.Movement.Any(e => e.ID == id);
        }

        private bool MovementItemExists(int id)
        {
            return _context.MovementItem.Any(e => e.ID == id);
        }
    }
}