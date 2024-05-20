using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model.Food;
using Business_Platform.DTOs.FoodCompanyDtos;

namespace Business_Platform.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCompaniesController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public FoodCompaniesController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/FoodCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodCompanyGet>>> GetFoodCompanies()
        {
            var foodCompanies = await _context.FoodCompanies!.Select(u => new FoodCompanyGet
            {
                Id = u.Id, // u, burada foodCompanies'i temsil ediyor
                Name = u.Name,
                Address = u.Address,
                PhoneNumber = u.PhoneNumber,
                EMail = u.EMail,
                PostalCode = u.PostalCode,
                RegisterDate = u.RegisterDate,
                CompanyCategoryName = u.CompanyCategory!.Name,
                State = u.State!.Name,
                RestaurantBranchNames = u.RestaurantBranches!.Select(rb => rb.Name).ToList(),
                RestaurantFoodNames = u.RestaurantFoods!.Select(rf => rf.Name).ToList(),
                AppUserNames = u.AppUsers!.Select(au => au.Name).ToList()
            }).ToListAsync();

          if (foodCompanies == null || foodCompanies.Count == 0)
          {
              return NotFound();
          }
            return foodCompanies;
        }

        // GET: api/FoodCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodCompanyGet>> GetFoodCompany(int id)
        {

          var foodCompany = await _context.FoodCompanies!
            .Include(fc => fc.CompanyCategory)
            .Include(fc => fc.State)
            .Include(fc => fc.RestaurantBranches)
            .Include(fc => fc.RestaurantFoods)
            .Include(fc => fc.AppUsers)
            .FirstOrDefaultAsync(fc => fc.Id == id);

            if (foodCompany == null)
            {
              return NotFound();
            }

            var foodCompanyDto = new FoodCompanyGet
            {
                Id = foodCompany.Id,
                Name = foodCompany.Name,
                Address = foodCompany.Address,
                PhoneNumber = foodCompany.PhoneNumber,
                EMail = foodCompany.EMail,
                PostalCode = foodCompany.PostalCode,
                RegisterDate = foodCompany.RegisterDate,
                CompanyCategoryName = foodCompany.CompanyCategory?.Name,
                State = foodCompany.State?.Name,
                RestaurantBranchNames = foodCompany.RestaurantBranches?.Select(rb => rb.Name).ToList(),
                RestaurantFoodNames = foodCompany.RestaurantFoods?.Select(rf => rf.Name).ToList(),
                AppUserNames = foodCompany.AppUsers?.Select(au => au.Name).ToList()
            };

            return foodCompanyDto;
        }

        // PUT: api/FoodCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodCompany(int id, FoodCompanyPut foodCompanyPut)
        {
            if (id != foodCompanyPut.Id)
            {
                return BadRequest();
            }

            FoodCompany? foodCompany = await _context.FoodCompanies!.FindAsync(id);

            if (foodCompany == null)
            {
                return NotFound();
            }

            foodCompany.Name = foodCompanyPut.Name;
            foodCompany.Address = foodCompanyPut.Address;
            foodCompany.PhoneNumber = foodCompanyPut.PhoneNumber;
            foodCompany.EMail = foodCompanyPut.EMail;
            foodCompany.PostalCode = foodCompanyPut.PostalCode;
            foodCompany.CompanyCategoryId = foodCompanyPut.CompanyCategoryId;
            foodCompany.StateId = foodCompanyPut.StateId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodCompanyExists(id))
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

        // POST: api/FoodCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodCompany>> PostFoodCompany(FoodCompanyPost foodCompanyPost)
        {
          if (_context.FoodCompanies == null)
          {
              return Problem("Entity set 'Business_PlatformContext.FoodCompanies'  is null.");
          }

            FoodCompany foodCompany = new FoodCompany
            {
                Name = foodCompanyPost.Name,
                Address = foodCompanyPost.Address,
                PhoneNumber = foodCompanyPost.PhoneNumber,
                EMail = foodCompanyPost.EMail,
                PostalCode = foodCompanyPost.PostalCode,
                RegisterDate = foodCompanyPost.RegisterDate,
                CompanyCategoryId = foodCompanyPost.CompanyCategoryId,
                StateId = foodCompanyPost.StateId

            };
            _context.FoodCompanies.Add(foodCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodCompany", new { id = foodCompany.Id }, foodCompany);
        }

        // DELETE: api/FoodCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodCompany(int id)
        {
            if (_context.FoodCompanies == null)
            {
                return NotFound();
            }
            var foodCompany = await _context.FoodCompanies.FindAsync(id);
            if (foodCompany == null)
            {
                return NotFound();
            }

            _context.FoodCompanies.Remove(foodCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodCompanyExists(int id)
        {
            return (_context.FoodCompanies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
