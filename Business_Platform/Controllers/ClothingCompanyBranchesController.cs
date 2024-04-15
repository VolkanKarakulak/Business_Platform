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
    public class ClothingCompanyBranchesController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public ClothingCompanyBranchesController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/ClothingCompanyBranches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothingCompanyBranch>>> GetClothingCompanyBranch()
        {
          if (_context.ClothingCompanyBranch == null)
          {
              return NotFound();
          }
            return await _context.ClothingCompanyBranch.ToListAsync();
        }

        // GET: api/ClothingCompanyBranches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothingCompanyBranch>> GetClothingCompanyBranch(int id)
        {
          if (_context.ClothingCompanyBranch == null)
          {
              return NotFound();
          }
            var clothingCompanyBranch = await _context.ClothingCompanyBranch.FindAsync(id);

            if (clothingCompanyBranch == null)
            {
                return NotFound();
            }

            return clothingCompanyBranch;
        }

        // PUT: api/ClothingCompanyBranches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothingCompanyBranch(int id, ClothingCompanyBranch clothingCompanyBranch)
        {
            if (id != clothingCompanyBranch.Id)
            {
                return BadRequest();
            }

            _context.Entry(clothingCompanyBranch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingCompanyBranchExists(id))
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

        // POST: api/ClothingCompanyBranches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClothingCompanyBranch>> PostClothingCompanyBranch(ClothingCompanyBranch clothingCompanyBranch)
        {
          if (_context.ClothingCompanyBranch == null)
          {
              return Problem("Entity set 'Business_PlatformContext.ClothingCompanyBranch'  is null.");
          }
            _context.ClothingCompanyBranch.Add(clothingCompanyBranch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothingCompanyBranch", new { id = clothingCompanyBranch.Id }, clothingCompanyBranch);
        }

        // DELETE: api/ClothingCompanyBranches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothingCompanyBranch(int id)
        {
            if (_context.ClothingCompanyBranch == null)
            {
                return NotFound();
            }
            var clothingCompanyBranch = await _context.ClothingCompanyBranch.FindAsync(id);
            if (clothingCompanyBranch == null)
            {
                return NotFound();
            }

            _context.ClothingCompanyBranch.Remove(clothingCompanyBranch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothingCompanyBranchExists(int id)
        {
            return (_context.ClothingCompanyBranch?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
