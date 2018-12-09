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
    public class CategoryController : Controller
    {
        private readonly AMContext _context;

        public CategoryController(AMContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetCategoryTableData()
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

                List<CategoryViewModel> categoryData = new List<CategoryViewModel>();
                // getting all Proposal data 
                var categoryList = await _context.Category.Where(a => a.DeletedDate == null).ToListAsync();

                foreach (var item in categoryList)
                {
                    var countAsset = _context.Asset.Where(a => a.CategoryID == item.ID).Count().ToString();
                    categoryData.Add(new CategoryViewModel
                    {
                        ID = item.ID,
                        Name = item.Name,
                        TotalAsset = countAsset
                    });
                }

                //Sorting  
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    categoryData = categoryData.AsQueryable().OrderBy(sortColumn + " " + sortColumnDirection).ToList();
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    categoryData = categoryData.Where(m => m.Name.Contains(searchValue)).ToList();
                }

                //total number of rows counts   
                recordsTotal = categoryData.Count();
                //Paging   
                var data = categoryData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetCategory(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var category = await _context.Category.Where(x => x.DeletedDate == null).ToListAsync();

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            category.CreatedDate = DateTime.Now;
            category.CreatedBy = User.Identity.Name;
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.ID }, category);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.ID)
            {
                return BadRequest();
            }

            category.UpdatedDate = DateTime.Now;
            category.UpdatedBy = User.Identity.Name;
            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = _context.Category.SingleOrDefault(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }

            category.DeletedDate = DateTime.Now;
            category.DeletedBy = User.Identity.Name;
            _context.Entry(category).State = EntityState.Modified;

            var assetList = await _context.Asset.Where(a => a.DeletedDate == null && a.CategoryID == category.ID).ToListAsync();

            foreach(var asset in assetList)
            {
                asset.DeletedBy = User.Identity.Name;
                asset.DeletedDate = DateTime.Now;
                _context.Entry(asset).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.ID == id);
        }
    }
}