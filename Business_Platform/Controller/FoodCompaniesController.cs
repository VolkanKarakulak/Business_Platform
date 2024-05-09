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
            var foodCompanies = await _context.FoodCompanies!
            .Include(fc => fc.RestaurantBranches)
            .Include(fc => fc.RestaurantFoods)
            .Include(fc => fc.AppUsers)
            .Select(u => new FoodCompanyGet
            {
                Id = u.Id,
                Name = u.Name,
                Address = u.Address,
                PhoneNumber = u.PhoneNumber,
                EMail = u.EMail,
                PostalCode = u.PostalCode,
                RegisterDate = u.RegisterDate,
                CompanyCategoryName = u.CompanyCategory!.Name,
                StateName = u.State!.Name,
                RestaurantBranchNames = u.RestaurantBranches!.Select(rb => rb.Name).ToList(),
                RestaurantFoodNames = u.RestaurantFoods!.Select(rf => rf.Name).ToList(),
                AppUserNames = u.AppUsers!.Select(au => au.Name).ToList()
            })
            .ToListAsync();

            if (_context.FoodCompanies == null)
          {
              return NotFound();
          }
            return foodCompanies;
        }

        // GET: api/FoodCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodCompany>> GetFoodCompany(int id)
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

            return foodCompany;
        }

        // PUT: api/FoodCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodCompany(int id, FoodCompany foodCompany)
        {
            if (id != foodCompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(foodCompany).State = EntityState.Modified;

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
        public async Task<ActionResult<FoodCompany>> PostFoodCompany(FoodCompany foodCompany)
        {
          if (_context.FoodCompanies == null)
          {
              return Problem("Entity set 'Business_PlatformContext.FoodCompanies'  is null.");
          }
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
