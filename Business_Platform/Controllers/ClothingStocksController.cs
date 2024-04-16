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
    public class ClothingStocksController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public ClothingStocksController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/ClothingStocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothingStock>>> GetClothingStocks()
        {
          if (_context.ClothingStocks == null)
          {
              return NotFound();
          }
            return await _context.ClothingStocks.ToListAsync();
        }

        // GET: api/ClothingStocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothingStock>> GetClothingStock(int id)
        {
          if (_context.ClothingStocks == null)
          {
              return NotFound();
          }
            var clothingStock = await _context.ClothingStocks.FindAsync(id);

            if (clothingStock == null)
            {
                return NotFound();
            }

            return clothingStock;
        }

        // PUT: api/ClothingStocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothingStock(int id, ClothingStock clothingStock)
        {
            if (id != clothingStock.Id)
            {
                return BadRequest();
            }

            _context.Entry(clothingStock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingStockExists(id))
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

        // POST: api/ClothingStocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClothingStock>> PostClothingStock(ClothingStock clothingStock)
        {
          if (_context.ClothingStocks == null)
          {
              return Problem("Entity set 'Business_PlatformContext.ClothingStocks'  is null.");
          }
            _context.ClothingStocks.Add(clothingStock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothingStock", new { id = clothingStock.Id }, clothingStock);
        }

        // DELETE: api/ClothingStocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothingStock(int id)
        {
            if (_context.ClothingStocks == null)
            {
                return NotFound();
            }
            var clothingStock = await _context.ClothingStocks.FindAsync(id);
            if (clothingStock == null)
            {
                return NotFound();
            }

            _context.ClothingStocks.Remove(clothingStock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothingStockExists(int id)
        {
            return (_context.ClothingStocks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
