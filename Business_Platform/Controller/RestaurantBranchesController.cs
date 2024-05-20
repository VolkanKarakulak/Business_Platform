using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model.Food;
using Business_Platform.DTOs.RestaurantBranchDtos;

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
        public async Task<ActionResult<IEnumerable<RestaurantBranchGet>>> GetRestaurantBranches()
        {
            if (_context.RestaurantBranches == null)
            {
                return NotFound();
            }

            var restaurantBranches = await _context.RestaurantBranches!.Select(u => new RestaurantBranchGet
            {
              Id = u.Id,
              Name = u.Name,
              Address = u.Address,
              PhoneNumber = u.PhoneNumber,
              EMail = u.EMail,
              PostalCode = u.PostalCode,
              RegisterDate = u.RegisterDate,
              BranchCode = u.BranchCode,
              State = u.State!.Name,
              FoodCompanyId = u.FoodCompanyId,
              FoodCompany = u.FoodCompany!.Name,
              RestaurantFoodNames = u.RestaurantFoods!.Select(k => k.Name).ToList(),
              FoodCategoryNames = u.FoodCategories!.Select(l => l.Name).ToList(),
              RestaurantBranchComments = u.RestaurantBranchComments!.Select(m => m.Comment).ToList()
            }).ToListAsync();

            if (restaurantBranches == null)
            {
                return NotFound();
            }

            return restaurantBranches;
        }

        // GET: api/RestaurantBranches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantBranchGet>> GetRestaurantBranch(int id)
        {        
            var restaurantBranch = await _context.RestaurantBranches!
                .Include(u => u.State)
                .Include(u => u.FoodCompany)
                .Include(u => u.RestaurantFoods)
                .Include(u => u.FoodCategories)
                .Include(u => u.FoodCategories)
                .Include(u => u.RestaurantBranchComments).FirstOrDefaultAsync(u => u.Id == id);

          if (restaurantBranch == null)
          {
              return NotFound();
          }

            var restaurantBranchDto = new RestaurantBranchGet
            {
                Id = restaurantBranch!.Id,
                Name = restaurantBranch.Name,
                Address = restaurantBranch.Address,
                City = restaurantBranch.City,
                BranchCode = restaurantBranch.BranchCode,
                PhoneNumber = restaurantBranch.PhoneNumber,
                EMail = restaurantBranch.EMail,
                PostalCode = restaurantBranch.PostalCode,
                RegisterDate = restaurantBranch.RegisterDate,
                State = restaurantBranch.State?.Name,
                FoodCompany = restaurantBranch.FoodCompany?.Name,
                FoodCompanyId = restaurantBranch.FoodCompanyId,
                RestaurantFoodNames = restaurantBranch.RestaurantFoods?.Select(u => u.Name).ToList(),
                FoodCategoryNames = restaurantBranch.FoodCategories?.Select(u => u.Name).ToList(),
                RestaurantBranchComments = restaurantBranch.RestaurantBranchComments?.Select(u => u.Comment).ToList()
            };

            return restaurantBranchDto;
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
        public async Task<ActionResult<RestaurantBranch>> PostRestaurantBranch(RestaurantBranchPost restaurantBranchpost)
        {
          if (_context.RestaurantBranches == null)
          {
              return Problem("Entity set 'Business_PlatformContext.RestaurantBranches'  is null.");
          }

            RestaurantBranch restaurantBranch = new RestaurantBranch
            {
                Name = restaurantBranchpost.Name,
                Address = restaurantBranchpost.Address,
                RegisterDate = restaurantBranchpost.RegisterDate,
                PostalCode = restaurantBranchpost.PostalCode,
                PhoneNumber = restaurantBranchpost.PhoneNumber,
                EMail = restaurantBranchpost.EMail,
                City = restaurantBranchpost.City,
                BranchCode = restaurantBranchpost.BranchCode,
                StateId = restaurantBranchpost.StateId,
                FoodCompanyId = restaurantBranchpost.FoodCompanyId,
            };

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
