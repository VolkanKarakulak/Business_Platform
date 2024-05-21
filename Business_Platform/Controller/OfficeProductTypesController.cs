using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model.Office;
using Business_Platform.DTOs.OfficeProductTypeDtos;

namespace Business_Platform.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeProductTypesController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public OfficeProductTypesController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/OfficeProductTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.Office.OfficeProductType>>> GetOfficeProductType()
        {
          if (_context.OfficeProductType == null)
          {
              return NotFound();
          }
            return await _context.OfficeProductType.ToListAsync();
        }

        // GET: api/OfficeProductTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model.Office.OfficeProductType>> GetOfficeProductType(int id)
        {
          if (_context.OfficeProductType == null)
          {
              return NotFound();
          }
            var officeProductType = await _context.OfficeProductType.FindAsync(id);

            if (officeProductType == null)
            {
                return NotFound();
            }

            return officeProductType;
        }

        // PUT: api/OfficeProductTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficeProductType(int id, OfficeProductTypePut officeProductTypePut)
        {
            if (id != officeProductTypePut.Id)
            {
                return BadRequest();
            }

            OfficeProductType? officeProductType = await _context.OfficeProductType!.FindAsync(id); 

            if (officeProductType == null)
            {
                return NotFound();
            }

            officeProductType.TypeName = officeProductTypePut.TypeName;
            officeProductType.Description = officeProductTypePut.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeProductTypeExists(id))
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

        // POST: api/OfficeProductTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OfficeProductType>> PostOfficeProductType(OfficeProductTypePost officeProductTypePost)
        {
          if (_context.OfficeProductType == null)
          {
              return Problem("Entity set 'Business_PlatformContext.OfficeProductType'  is null.");
          }

            OfficeProductType officeProductType = new OfficeProductType
            {
                TypeName = officeProductTypePost.TypeName,
                Description = officeProductTypePost.Description
            };

            _context.OfficeProductType.Add(officeProductType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfficeProductType", new { id = officeProductType.Id }, officeProductType);
        }

        // DELETE: api/OfficeProductTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficeProductType(int id)
        {
            if (_context.OfficeProductType == null)
            {
                return NotFound();
            }
            var officeProductType = await _context.OfficeProductType.FindAsync(id);
            if (officeProductType == null)
            {
                return NotFound();
            }

            _context.OfficeProductType.Remove(officeProductType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficeProductTypeExists(int id)
        {
            return (_context.OfficeProductType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
