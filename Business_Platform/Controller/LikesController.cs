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
using System.Security.Policy;
using Business_Platform.Model.Office;

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
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Like>>> GetLikes()
        //{
        //  if (_context.Likes == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Likes.ToListAsync();
        //}

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
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Like>> PostLike(int categoryId, LikePostDto likePostDto)
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

            // Ürün kategorisini belirlemek için ürün tablosunu sorguluyoruz
            var officeBranchProduct = await _context.OfficeProdBranchProducts!.FindAsync(likePostDto.OfficeProdBranchProductId);
            if (officeBranchProduct != null && officeBranchProduct.CompanyCategoryId == categoryId)
            {
                like.OfficeProdBranchProductId = likePostDto.OfficeProdBranchProductId;
                like.CompanyCategoryId = (await _context.CompanyCategories.FirstOrDefaultAsync(c => c.Name == "OfficeProductCompany")).Id;
            }
            else
            {
                var restaurantBranchFood = await _context.RestaurantBranchFoods!.FindAsync(likePostDto.RestaurantBranchFoodId);
                if (restaurantBranchFood != null && restaurantBranchFood.CompanyCategoryId == categoryId)
                {
                    like.RestaurantBranchFoodId = likePostDto.RestaurantBranchFoodId;
                    like.CompanyCategoryId = (await _context.CompanyCategories.FirstOrDefaultAsync(c => c.Name == "FoodCompany")).Id;
                }
                else
                {
                    return NotFound("Product not found");
                }
            }

            _context.Likes.Add(like);
            await _context.SaveChangesAsync();

            return Ok("The product has been added to the favorites list");
        }

        // DELETE: api/Likes/5
        [HttpDelete("{id}")]
        [Authorize]
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

            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString == null || !long.TryParse(userIdString, out var userId))
            {
                return Unauthorized();
            }
            
            if (like.AppUserId != userId)
            {
                return Forbid();
            }      

            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();

            return Ok("The product has been removed from the favorites list");
        }
    }
}
