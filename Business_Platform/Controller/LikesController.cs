using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model;
using Business_Platform.DTOs;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Business_Platform.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public LikesController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/Likes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Like>>> GetLikes()
        {
          if (_context.Likes == null)
          {
              return NotFound();
          }
            return await _context.Likes.ToListAsync();
        }

        // GET: api/Likes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Like>> GetLike(int id)
        {
          if (_context.Likes == null)
          {
              return NotFound();
          }
            var like = await _context.Likes.FindAsync(id);

            if (like == null)
            {
                return NotFound();
            }

            return like;
        }

        // POST: api/Likes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Like>> PostLike(LikePostDto likePostDto)
        {
          if (_context.Likes == null)
          {
              return Problem("Entity set 'Business_PlatformContext.Likes'  is null.");
          }

            var userIdstring = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdstring == null)
            {
                return Unauthorized();
            }

            if (!long.TryParse(userIdstring, out var userId))
            {
                return Problem("Kullanıcı kimliği geçersiz.");
            }

            Like like = new Like
            {
                
                OfficeCompanyId = likePostDto.OfficeCompanyId,
                OfficeProductId = likePostDto.OfficeProductId,
                OfficeProdBranchProduct = likePostDto.OfficeProdBranchProduct,
                FoodCompanyId = likePostDto.FoodCompanyId,
                RestaurantFoodId = likePostDto.RestaurantFoodId,
                AppUserId = userId
            };

            _context.Likes.Add(like);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLike", new { id = like.Id }, like);
        }

        // DELETE: api/Likes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLike(int id)
        {
            if (_context.Likes == null)
            {
                return NotFound();
            }
            var like = await _context.Likes.FindAsync(id);
            if (like == null)
            {
                return NotFound();
            }

            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LikeExists(int id)
        {
            return (_context.Likes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
