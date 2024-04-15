using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model;

namespace Business_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyCategoriesController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public CompanyCategoriesController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/CompanyCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyCategory>>> GetCompanyCategories()
        {
          if (_context.CompanyCategories == null)
          {
              return NotFound();
          }
            return await _context.CompanyCategories.ToListAsync();
        }

        // GET: api/CompanyCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyCategory>> GetCompanyCategories(int id)
        {
          if (_context.CompanyCategories == null)
          {
              return NotFound();
          }
            var companyCategory = await _context.CompanyCategories.FindAsync(id);

            if (companyCategory == null)
            {
                return NotFound();
            }

            return companyCategory;
        }

        // PUT: api/CompanyCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyCategories(int id, CompanyCategory companyCategory)
        {
            if (id != companyCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyCategoriesExists(id))
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

        // POST: api/CompanyCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyCategory>> PostCompanyCategories(CompanyCategory companyCategory)
        {
          if (_context.CompanyCategories == null)
          {
              return Problem("Entity set 'Business_PlatformContext.CompanyCategories'  is null.");
          }
            _context.CompanyCategories.Add(companyCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyCategories", new { id = companyCategory.Id }, companyCategory);
        }

        // DELETE: api/CompanyCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyCategories(int id)
        {
            if (_context.CompanyCategories == null)
            {
                return NotFound();
            }
            var companyCategory = await _context.CompanyCategories.FindAsync(id);
            if (companyCategory == null)
            {
                return NotFound();
            }

            _context.CompanyCategories.Remove(companyCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyCategoriesExists(int id)
        {
            return (_context.CompanyCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
