using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model.Office;

namespace Business_Platform.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeProductsController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public OfficeProductsController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/OfficeProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeProduct>>> GetOfficeProducts()
        {
          if (_context.OfficeProducts == null)
          {
              return NotFound();
          }
            return await _context.OfficeProducts.ToListAsync();
        }

        // GET: api/OfficeProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeProduct>> GetOfficeProduct(int id)
        {
          if (_context.OfficeProducts == null)
          {
              return NotFound();
          }
            var officeProduct = await _context.OfficeProducts.Include(o => o.ProductComments).FirstOrDefaultAsync(m => m.Id == id);

            if (officeProduct == null)
            {
                return NotFound();
            }

            return officeProduct;
        }

        // PUT: api/OfficeProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficeProduct(int id, OfficeProduct officeProduct)
        {
            if (id != officeProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(officeProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeProductExists(id))
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

        // POST: api/OfficeProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OfficeProduct>> PostOfficeProduct(OfficeProduct officeProduct)
        {
          if (_context.OfficeProducts == null)
          {
              return Problem("Entity set 'Business_PlatformContext.OfficeProducts'  is null.");
          }
            _context.OfficeProducts.Add(officeProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfficeProduct", new { id = officeProduct.Id }, officeProduct);
        }

        // DELETE: api/OfficeProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficeProduct(int id)
        {
            if (_context.OfficeProducts == null)
            {
                return NotFound();
            }
            var officeProduct = await _context.OfficeProducts.FindAsync(id);
            if (officeProduct == null)
            {
                return NotFound();
            }

            _context.OfficeProducts.Remove(officeProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficeProductExists(int id)
        {
            return (_context.OfficeProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
