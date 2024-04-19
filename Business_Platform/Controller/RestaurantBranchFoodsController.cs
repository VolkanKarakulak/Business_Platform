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
    public class RestaurantBranchFoodsController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public RestaurantBranchFoodsController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/RestaurantBranchFoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantBranchFood>>> GetRestaurantBranchFoods()
        {
          if (_context.RestaurantBranchFoods == null)
          {
              return NotFound();
          }
            return await _context.RestaurantBranchFoods.ToListAsync();
        }

        // GET: api/RestaurantBranchFoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantBranchFood>> GetRestaurantBranchFood(int id)
        {
          if (_context.RestaurantBranchFoods == null)
          {
              return NotFound();
          }
            var restaurantBranchFood = await _context.RestaurantBranchFoods.FindAsync(id);

            if (restaurantBranchFood == null)
            {
                return NotFound();
            }

            return restaurantBranchFood;
        }

        // PUT: api/RestaurantBranchFoods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantBranchFood(int id, RestaurantBranchFood restaurantBranchFood)
        {
            if (id != restaurantBranchFood.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurantBranchFood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantBranchFoodExists(id))
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

        // POST: api/RestaurantBranchFoods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RestaurantBranchFood>> PostRestaurantBranchFood(RestaurantBranchFood restaurantBranchFood)
        {
          if (_context.RestaurantBranchFoods == null)
          {
              return Problem("Entity set 'Business_PlatformContext.RestaurantBranchFoods'  is null.");
          }
            _context.RestaurantBranchFoods.Add(restaurantBranchFood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantBranchFood", new { id = restaurantBranchFood.Id }, restaurantBranchFood);
        }

        // DELETE: api/RestaurantBranchFoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantBranchFood(int id)
        {
            if (_context.RestaurantBranchFoods == null)
            {
                return NotFound();
            }
            var restaurantBranchFood = await _context.RestaurantBranchFoods.FindAsync(id);
            if (restaurantBranchFood == null)
            {
                return NotFound();
            }

            _context.RestaurantBranchFoods.Remove(restaurantBranchFood);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantBranchFoodExists(int id)
        {
            return (_context.RestaurantBranchFoods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
