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
    public class OfficeStocksController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public OfficeStocksController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/OfficeStocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeStock>>> GetOfficeStocks()
        {
          if (_context.OfficeStocks == null)
          {
              return NotFound();
          }
            return await _context.OfficeStocks.ToListAsync();
        }

        // GET: api/OfficeStocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeStock>> GetOfficeStock(int id)
        {
          if (_context.OfficeStocks == null)
          {
              return NotFound();
          }
            var officeStock = await _context.OfficeStocks.FindAsync(id);

            if (officeStock == null)
            {
                return NotFound();
            }

            return officeStock;
        }

        // PUT: api/OfficeStocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficeStock(int id, OfficeStock officeStock)
        {
            if (id != officeStock.Id)
            {
                return BadRequest();
            }

            _context.Entry(officeStock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeStockExists(id))
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

        // POST: api/OfficeStocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OfficeStock>> PostOfficeStock(OfficeStock officeStock)
        {
          if (_context.OfficeStocks == null)
          {
              return Problem("Entity set 'Business_PlatformContext.OfficeStocks'  is null.");
          }
            _context.OfficeStocks.Add(officeStock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfficeStock", new { id = officeStock.Id }, officeStock);
        }

        // DELETE: api/OfficeStocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficeStock(int id)
        {
            if (_context.OfficeStocks == null)
            {
                return NotFound();
            }
            var officeStock = await _context.OfficeStocks.FindAsync(id);
            if (officeStock == null)
            {
                return NotFound();
            }

            _context.OfficeStocks.Remove(officeStock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficeStockExists(int id)
        {
            return (_context.OfficeStocks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
