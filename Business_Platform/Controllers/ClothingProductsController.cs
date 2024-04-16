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
    public class ClothingProductsController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public ClothingProductsController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/ClothingProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothingProduct>>> GetClothingProduct()
        {
          if (_context.ClothingProduct == null)
          {
              return NotFound();
          }
            return await _context.ClothingProduct.ToListAsync();
        }

        // GET: api/ClothingProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothingProduct>> GetClothingProduct(int id)
        {
          if (_context.ClothingProduct == null)
          {
              return NotFound();
          }
            var clothingProduct = await _context.ClothingProduct.FindAsync(id);

            if (clothingProduct == null)
            {
                return NotFound();
            }

            return clothingProduct;
        }

        // PUT: api/ClothingProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothingProduct(int id, ClothingProduct clothingProduct)
        {
            if (id != clothingProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(clothingProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingProductExists(id))
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

        // POST: api/ClothingProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClothingProduct>> PostClothingProduct(ClothingProduct clothingProduct)
        {
          if (_context.ClothingProduct == null)
          {
              return Problem("Entity set 'Business_PlatformContext.ClothingProduct'  is null.");
          }
            _context.ClothingProduct.Add(clothingProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothingProduct", new { id = clothingProduct.Id }, clothingProduct);
        }

        // DELETE: api/ClothingProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothingProduct(int id)
        {
            if (_context.ClothingProduct == null)
            {
                return NotFound();
            }
            var clothingProduct = await _context.ClothingProduct.FindAsync(id);
            if (clothingProduct == null)
            {
                return NotFound();
            }

            _context.ClothingProduct.Remove(clothingProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothingProductExists(int id)
        {
            return (_context.ClothingProduct?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
