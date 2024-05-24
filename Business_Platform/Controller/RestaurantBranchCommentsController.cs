using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model.Food;
using Business_Platform.DTOs.RestaurantBranchComment;
using System.Security.Claims;

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
        public async Task<ActionResult<IEnumerable<RestaurantBranchCommentGet>>> GetRestaurantBranchComments()
        {
          var restaurantBranchComment = await _context.RestaurantBranchComments!.Select(u => new RestaurantBranchCommentGet
          {
              UserId = u.UserId,
              UserName = u.AppUser!.Name,
              Comment = u.Comment,
              CommentDate = u.CommmentDate,
              RestaurantBranchId = u.RestaurantBranchId,
              RestaurantBranchName = u.RestaurantBranch!.Name
          }).ToListAsync();

          if (restaurantBranchComment == null)
          {
              return NotFound();
          }
            return restaurantBranchComment;
        }

        // GET: api/RestaurantBranchComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantBranchCommentGet>> GetRestaurantBranchComment(int id)
        {
          var restaurantBranchCommnet = await  _context.RestaurantBranchComments!.Include(u => u.AppUser).Include(u => u.RestaurantBranch).FirstOrDefaultAsync(u  => u.Id == id);

          if (restaurantBranchCommnet == null)
          {
              return NotFound();
          }
            var restaurantBranchCommentGet = new RestaurantBranchCommentGet
            {
                UserId = restaurantBranchCommnet.UserId,
                UserName = restaurantBranchCommnet.AppUser!.Name,
                Comment = restaurantBranchCommnet.Comment,
                CommentDate = restaurantBranchCommnet.CommmentDate,
                RestaurantBranchId = restaurantBranchCommnet.RestaurantBranchId,
                RestaurantBranchName = restaurantBranchCommnet.RestaurantBranch!.Name
            };

            if (restaurantBranchCommentGet == null)
            {
                return NotFound();
            }

            return restaurantBranchCommentGet;
        }

        // PUT: api/RestaurantBranchComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantBranchComment(int id, RestaurantBranchCommentPut restaurantBranchCommentPut)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId == null) 
            {
                return NotFound(); 
            }
            if (!long.TryParse(userId,out var longUserId))
            {
                return Problem();
            }

            RestaurantBranchComment? restaurantBranchComment = await _context.RestaurantBranchComments!.FindAsync(id);
            if (restaurantBranchComment == null) 
            {
                return NotFound();
            }
            if(restaurantBranchComment.UserId != longUserId)
            {
                return Forbid();
            }

            restaurantBranchComment.Comment = restaurantBranchCommentPut.Commnet;

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
        public async Task<ActionResult<RestaurantBranchComment>> PostRestaurantBranchComment(RestaurantBranchCommentPost restaurantBranchCommentPost)
        {
          if (_context.RestaurantBranchComments == null)
          {
              return Problem("Entity set 'Business_PlatformContext.RestaurantBranchComments'  is null.");
          }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }
            if (!long.TryParse(userId, out var longUserId))
            {
                return Problem();
            }

            RestaurantBranchComment comment = new RestaurantBranchComment
            {
                UserId = longUserId,
                Comment = restaurantBranchCommentPost.Comment,
                CommmentDate = restaurantBranchCommentPost.CommentDate,
                RestaurantBranchId = restaurantBranchCommentPost.RestaurantBranchId
            };

            _context.RestaurantBranchComments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantBranchComment", new { id = comment.Id }, comment);
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
