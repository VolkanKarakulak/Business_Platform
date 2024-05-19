using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model.Food;

namespace Business_Platform.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantBranchesController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public RestaurantBranchesController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/RestaurantBranches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantBranch>>> GetRestaurantBranches()
        {
          if (_context.RestaurantBranches == null)
          {
              return NotFound();
          }
            return await _context.RestaurantBranches.ToListAsync();
        }

        // GET: api/RestaurantBranches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantBranch>> GetRestaurantBranch(int id)
        {
          if (_context.RestaurantBranches == null)
          {
              return NotFound();
          }
            var restaurantBranch = await _context.RestaurantBranches.FindAsync(id);

            if (restaurantBranch == null)
            {
                return NotFound();
            }

            return restaurantBranch;
        }

        // PUT: api/RestaurantBranches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantBranch(int id, RestaurantBranch restaurantBranch)
        {
            if (id != restaurantBranch.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurantBranch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantBranchExists(id))
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

        // POST: api/RestaurantBranches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RestaurantBranch>> PostRestaurantBranch(RestaurantBranch restaurantBranch)
        {
          if (_context.RestaurantBranches == null)
          {
              return Problem("Entity set 'Business_PlatformContext.RestaurantBranches'  is null.");
          }
            _context.RestaurantBranches.Add(restaurantBranch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantBranch", new { id = restaurantBranch.Id }, restaurantBranch);
        }

        // DELETE: api/RestaurantBranches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantBranch(int id)
        {
            if (_context.RestaurantBranches == null)
            {
                return NotFound();
            }
            var restaurantBranch = await _context.RestaurantBranches.FindAsync(id);
            if (restaurantBranch == null)
            {
                return NotFound();
            }

            _context.RestaurantBranches.Remove(restaurantBranch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantBranchExists(int id)
        {
            return (_context.RestaurantBranches?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
