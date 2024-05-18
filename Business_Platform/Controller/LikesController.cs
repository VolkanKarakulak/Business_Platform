using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Business_Platform.DTOs.LikeDtos;
using Microsoft.CodeAnalysis;

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
        public async Task<ActionResult<List<LikeGetDto>>> GetUserLikes(int id)
        {
         
            var userLikes = await _context.Likes!.Where(like => like.AppUserId == id).ToListAsync();

            if (userLikes == null || userLikes.Count == 0)
            {
                return NotFound();
            }
      
            var likeDtos = userLikes.Select(like => new LikeGetDto
            {             
                OfficeCompanyName = like.OfficeCompany!.Name,
                OfficeProductName = like.OfficeProdBranchProduct!.Name,
                FoodCompanyName = like.FoodCompany!.Name,
                FoodProductName = like.RestaurantBranchFood!.Name

            }).ToList();

            return likeDtos;
        }

        // POST: api/Likes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Like>> PostLike(LikePostDto likePostDto)
        {
            if (_context.Likes == null)
            {
                return Problem("Entity set 'Business_PlatformContext.Likes' is null.");
            }

            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdString == null)
            {
                return Unauthorized();
            }

            if (!long.TryParse(userIdString, out var userId))
            {
                return Problem();
            }

            Like like = new Like { AppUserId = userId };

            if (likePostDto.ProductType == "Office")
            {
                var product = await _context.OfficeProdBranchProducts!.FindAsync(likePostDto.ProductId);
                if (product == null)
                {
                    return NotFound();
                }

                like.OfficeProductId = product.Id;
                like.OfficeCompanyId = product.OfficeCompanyId;
                like.OfficeProdBranchProductId = product.Id;
            }
            else if (likePostDto.ProductType == "Food")
            {
                var product = await _context.RestaurantBranchFoods!.FindAsync(likePostDto.ProductId);
                if (product == null)
                {
                    return NotFound();
                }

                like.RestaurantBranchFoodId = product.Id;
                like.FoodCompanyId = product.FoodCompanyId;
            }
            else
            {
                return BadRequest();
            }

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
