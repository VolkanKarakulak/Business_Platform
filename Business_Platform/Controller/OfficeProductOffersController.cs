using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model.Office;
using Business_Platform.DTOs.OfficeProductOfferDtos;

namespace Business_Platform.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeProductOffersController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public OfficeProductOffersController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/OfficeProductOffers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeProductOffer>>> GetOfficeProductOffers()
        {
          if (_context.OfficeProductOffers == null)
          {
              return NotFound();
          }
            return await _context.OfficeProductOffers.ToListAsync();
        }

        // GET: api/OfficeProductOffers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeProductOffer>> GetOfficeProductOffer(int id)
        {
          if (_context.OfficeProductOffers == null)
          {
              return NotFound();
          }
            var officeProductOffer = await _context.OfficeProductOffers.FindAsync(id);

            if (officeProductOffer == null)
            {
                return NotFound();
            }

            return officeProductOffer;
        }

        // PUT: api/OfficeProductOffers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficeProductOffer(int id, OfficeProductOffer officeProductOffer)
        {
            if (id != officeProductOffer.Id)
            {
                return BadRequest();
            }

            _context.Entry(officeProductOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeProductOfferExists(id))
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

        // POST: api/OfficeProductOffers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OfficeProductOffer>> PostOfficeProductOffer(OfficeProductOfferPost officeProductOfferPost)
        {
            if (officeProductOfferPost == null)
            {
                return BadRequest();
            }

            var officeProductOffer = new OfficeProductOffer
            {
                ProductId = officeProductOfferPost.OfficeProdBranchProductId,
                OfferPrice = officeProductOfferPost.OfferPrice,
                OfferDate = officeProductOfferPost.OfferDate,
                UserId = officeProductOfferPost.UserId,
                OfficeCompanyBranchId = officeProductOfferPost.OfficeCompanyBranchId
            };

            _context.OfficeProductOffers!.Add(officeProductOffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfficeProductOffer", new { id = officeProductOffer.Id }, officeProductOffer);
        }

        // DELETE: api/OfficeProductOffers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficeProductOffer(int id)
        {
            if (_context.OfficeProductOffers == null)
            {
                return NotFound();
            }
            var officeProductOffer = await _context.OfficeProductOffers.FindAsync(id);
            if (officeProductOffer == null)
            {
                return NotFound();
            }

            _context.OfficeProductOffers.Remove(officeProductOffer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficeProductOfferExists(int id)
        {
            return (_context.OfficeProductOffers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
