﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model.Food;
using Microsoft.AspNetCore.Authorization;
using Business_Platform.DTOs.FoodCategoryDtos;

namespace Business_Platform.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "FoodCompanyAdmin")]
    public class FoodCategoriesController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public FoodCategoriesController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/FoodCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodCategoryGet>>> GetFoodCategories()
        {
            var foodCategories = await _context.FoodCategories!.Include(u => u.RestaurantFoods).Select(u => new FoodCategoryGet
            {
                Id = u.Id,
                Name = u.Name,
                Description = u.Description,
                State = u.State!.Name,
                RestaurantBranchName = u.RestaurantBranch!.Name,
                RestaurantFoodNames = u.RestaurantFoods!.Select(rf => rf.Name).ToList()
            }).ToListAsync();

            if (foodCategories == null || foodCategories.Count == 0)
            {
              return NotFound();
            }
            return foodCategories;
        }

        // GET: api/FoodCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodCategoryGet>> GetFoodCategory(int id)
        {
         
            var foodCategory = await _context.FoodCategories!.Include(u => u.State).Include(u => u.RestaurantBranch).FirstOrDefaultAsync(u => u.Id == id);

            if (foodCategory == null)
            {
                return NotFound();
            }
            var foodCategoryDto = new FoodCategoryGet
            {
                Id = foodCategory.Id,
                Name = foodCategory.Name,
                Description = foodCategory.Description,
                State = foodCategory.State?.Name,
                RestaurantBranchName = foodCategory.RestaurantBranch?.Name
            };
            return foodCategoryDto;
        }

        // PUT: api/FoodCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        //[Authorize(Roles = "MainCompanyAdmin, FoodCompanyAdmin")]
        public async Task<IActionResult> PutFoodCategory(FoodCategoryPut foodCategoryPut)
        {
            int id = foodCategoryPut.Id;

            FoodCategory? foodCategory = await _context.FoodCategories!.FindAsync(id);

            if (foodCategory == null)
            {
                return NotFound();
            }

            foodCategory.Name = foodCategoryPut.Name;
            foodCategory.Description = foodCategoryPut.Description;
            foodCategory.StateId = foodCategoryPut.StateId;
            foodCategory.RestaurantBranchId = foodCategoryPut.RestaurantBranchId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodCategoryExists(id))
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

        // POST: api/FoodCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "MainCompanyAdmin, FoodCompanyAdmin")]
        public async Task<ActionResult<FoodCategory>> PostFoodCategory(FoodCategoryPost foodCategoryPost)
        {
          if (_context.FoodCategories == null)
          {
              return Problem("Entity set 'Business_PlatformContext.FoodCategories'  is null.");
          }

            FoodCategory foodCategory = new FoodCategory
            {
                Name = foodCategoryPost.Name,
                Description = foodCategoryPost.Description,
                StateId = foodCategoryPost.StateId,
                RestaurantBranchId = foodCategoryPost.RestaurantBranchId
            };

            _context.FoodCategories.Add(foodCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodCategory", new { id = foodCategory.Id }, foodCategory);
        }

        // DELETE: api/FoodCategories/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "MainCompanyAdmin, FoodCompanyAdmin")]
        public async Task<IActionResult> DeleteFoodCategory(int id)
        {
            if (_context.FoodCategories == null)
            {
                return NotFound();
            }
            var foodCategory = await _context.FoodCategories.FindAsync(id);
            if (foodCategory == null)
            {
                return NotFound();
            }

            _context.FoodCategories.Remove(foodCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodCategoryExists(int id)
        {
            return (_context.FoodCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
