using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AMMPSI.Data;
using AMMPSI.Models;

namespace AMMPSI.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class APIController : Controller
    {
        private readonly AMContext _context;

        public APIController(AMContext context)
        {
            _context = context;
        }

        #region Category
        [HttpGet]
        [Route("Category")]
        public IActionResult GetCategory()
        {
            return Ok(_context.Category);
        }

        [HttpGet("Category/{id}")]
        public IActionResult GetCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category =  _context.Category.SingleOrDefault(m => m.ID == id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        [HttpPut("Category/{id}")]
        public IActionResult PutCategory([FromRoute] int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.ID)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
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
        [Route("Category")]
        public IActionResult PostCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Category.Add(category);
            _context.SaveChanges();

            return CreatedAtAction("GetCategory", new { id = category.ID }, category);
        }

        [HttpDelete("Category/{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
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

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
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
        #endregion

        #region Asset
        [HttpGet]
        [Route("Asset")]
        public IActionResult GetAsset()
        {
            return Ok(_context.Asset);
        }

        [HttpGet("Asset/{id}")]
        public IActionResult GetAsset([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asset = _context.Asset.SingleOrDefault(m => m.ID == id);

            if (asset == null)
            {
                return NotFound();
            }

            return Ok(asset);
        }


        [HttpPut("Asset/{id}")]
        public IActionResult PutAsset([FromRoute] int id, [FromBody] Asset Asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Asset.ID)
            {
                return BadRequest();
            }

            _context.Entry(Asset).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
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
        [Route("Asset")]
        public IActionResult PostAsset([FromBody] Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Asset.Add(asset);
            _context.SaveChanges();

            return CreatedAtAction("GetAsset", new { id = asset.ID }, asset);
        }

        [HttpDelete("Asset/{id}")]
        public IActionResult DeleteAsset([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asset = _context.Category.SingleOrDefault(m => m.ID == id);
            if (asset == null)
            {
                return NotFound();
            }

            _context.Entry(asset).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
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

        private bool AssetExists(int id)
        {
            return _context.Asset.Any(e => e.ID == id);
        }

        #endregion

        #region Location
        [HttpGet]
        [Route("Location")]
        public IActionResult GetLocation()
        {
            return Ok(_context.Location);
        }

        [HttpGet("Location/{id}")]
        public IActionResult GetLocation([FromRoute] int id)
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

            return Ok(location);
        }


        [HttpPut("Location/{id}")]
        public IActionResult PutLocation([FromRoute] int id, [FromBody] Location Location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Location.ID)
            {
                return BadRequest();
            }

            _context.Entry(Location).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
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
        [Route("Location")]
        public IActionResult PostLocation([FromBody] Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Location.Add(location);
            _context.SaveChanges();

            return CreatedAtAction("GetLocation", new { id = location.ID }, location);
        }

        [HttpDelete("Location/{id}")]
        public IActionResult DeleteLocation([FromRoute] int id)
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

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
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

        private bool LocationExists(int id)
        {
            return _context.Location.Any(e => e.ID == id);
        }

        #endregion

    }
}