using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model.Clothing;

namespace Business_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingCompaniesController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public ClothingCompaniesController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/ClothingCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothingCompany>>> GetClothingCompanies()
        {
          if (_context.ClothingCompanies == null)
          {
              return NotFound();
          }
            return await _context.ClothingCompanies.ToListAsync();
        }

        // GET: api/ClothingCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothingCompany>> GetClothingCompanies(int id)
        {
          if (_context.ClothingCompanies == null)
          {
              return NotFound();
          }
            var clothingCompany = await _context.ClothingCompanies.FindAsync(id);

            if (clothingCompany == null)
            {
                return NotFound();
            }

            return clothingCompany;
        }

        // PUT: api/ClothingCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothingCompanies(int id, ClothingCompany clothingCompany)
        {
            if (id != clothingCompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(clothingCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingCompaniesExists(id))
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

        // POST: api/ClothingCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClothingCompany>> PostClothingCompanies(ClothingCompany clothingCompany)
        {
          if (_context.ClothingCompanies == null)
          {
              return Problem("Entity set 'Business_PlatformContext.ClothingCompanies'  is null.");
          }
            _context.ClothingCompanies.Add(clothingCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothingCompanies", new { id = clothingCompany.Id }, clothingCompany);
        }

        // DELETE: api/ClothingCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothingCompanies(int id)
        {
            if (_context.ClothingCompanies == null)
            {
                return NotFound();
            }
            var clothingCompany = await _context.ClothingCompanies.FindAsync(id);
            if (clothingCompany == null)
            {
                return NotFound();
            }

            _context.ClothingCompanies.Remove(clothingCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothingCompaniesExists(int id)
        {
            return (_context.ClothingCompanies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
