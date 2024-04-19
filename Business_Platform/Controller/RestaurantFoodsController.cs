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
    public class RestaurantFoodsController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public RestaurantFoodsController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/RestaurantFoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantFood>>> GetRestaurantFoods()
        {
          if (_context.RestaurantFoods == null)
          {
              return NotFound();
          }
            return await _context.RestaurantFoods.ToListAsync();
        }

        // GET: api/RestaurantFoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantFood>> GetRestaurantFood(int id)
        {
          if (_context.RestaurantFoods == null)
          {
              return NotFound();
          }
            var restaurantFood = await _context.RestaurantFoods.FindAsync(id);

            if (restaurantFood == null)
            {
                return NotFound();
            }

            return restaurantFood;
        }

        // PUT: api/RestaurantFoods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantFood(int id, RestaurantFood restaurantFood)
        {
            if (id != restaurantFood.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurantFood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantFoodExists(id))
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

        // POST: api/RestaurantFoods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RestaurantFood>> PostRestaurantFood(RestaurantFood restaurantFood)
        {
          if (_context.RestaurantFoods == null)
          {
              return Problem("Entity set 'Business_PlatformContext.RestaurantFoods'  is null.");
          }
            _context.RestaurantFoods.Add(restaurantFood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantFood", new { id = restaurantFood.Id }, restaurantFood);
        }

        // DELETE: api/RestaurantFoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantFood(int id)
        {
            if (_context.RestaurantFoods == null)
            {
                return NotFound();
            }
            var restaurantFood = await _context.RestaurantFoods.FindAsync(id);
            if (restaurantFood == null)
            {
                return NotFound();
            }

            _context.RestaurantFoods.Remove(restaurantFood);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantFoodExists(int id)
        {
            return (_context.RestaurantFoods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
