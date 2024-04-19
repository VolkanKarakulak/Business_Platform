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
    public class RestaurantBranchCommentsController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public RestaurantBranchCommentsController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/RestaurantBranchComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantBranchComment>>> GetRestaurantBranchComments()
        {
          if (_context.RestaurantBranchComments == null)
          {
              return NotFound();
          }
            return await _context.RestaurantBranchComments.ToListAsync();
        }

        // GET: api/RestaurantBranchComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantBranchComment>> GetRestaurantBranchComment(int id)
        {
          if (_context.RestaurantBranchComments == null)
          {
              return NotFound();
          }
            var restaurantBranchComment = await _context.RestaurantBranchComments.FindAsync(id);

            if (restaurantBranchComment == null)
            {
                return NotFound();
            }

            return restaurantBranchComment;
        }

        // PUT: api/RestaurantBranchComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantBranchComment(int id, RestaurantBranchComment restaurantBranchComment)
        {
            if (id != restaurantBranchComment.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurantBranchComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantBranchCommentExists(id))
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

        // POST: api/RestaurantBranchComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RestaurantBranchComment>> PostRestaurantBranchComment(RestaurantBranchComment restaurantBranchComment)
        {
          if (_context.RestaurantBranchComments == null)
          {
              return Problem("Entity set 'Business_PlatformContext.RestaurantBranchComments'  is null.");
          }
            _context.RestaurantBranchComments.Add(restaurantBranchComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantBranchComment", new { id = restaurantBranchComment.Id }, restaurantBranchComment);
        }

        // DELETE: api/RestaurantBranchComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantBranchComment(int id)
        {
            if (_context.RestaurantBranchComments == null)
            {
                return NotFound();
            }
            var restaurantBranchComment = await _context.RestaurantBranchComments.FindAsync(id);
            if (restaurantBranchComment == null)
            {
                return NotFound();
            }

            _context.RestaurantBranchComments.Remove(restaurantBranchComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantBranchCommentExists(int id)
        {
            return (_context.RestaurantBranchComments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
