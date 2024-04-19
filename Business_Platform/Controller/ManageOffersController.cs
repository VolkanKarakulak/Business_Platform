﻿using System;
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
    public class ManageOffersController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public ManageOffersController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/ManageOffers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManageOffer>>> GetManageOffers()
        {
          if (_context.ManageOffers == null)
          {
              return NotFound();
          }
            return await _context.ManageOffers.ToListAsync();
        }

        // GET: api/ManageOffers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManageOffer>> GetManageOffer(int id)
        {
          if (_context.ManageOffers == null)
          {
              return NotFound();
          }
            var manageOffer = await _context.ManageOffers.FindAsync(id);

            if (manageOffer == null)
            {
                return NotFound();
            }

            return manageOffer;
        }

        // PUT: api/ManageOffers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManageOffer(int id, ManageOffer manageOffer)
        {
            if (id != manageOffer.Id)
            {
                return BadRequest();
            }

            _context.Entry(manageOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManageOfferExists(id))
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

        // POST: api/ManageOffers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManageOffer>> PostManageOffer(ManageOffer manageOffer)
        {
          if (_context.ManageOffers == null)
          {
              return Problem("Entity set 'Business_PlatformContext.ManageOffers'  is null.");
          }
            _context.ManageOffers.Add(manageOffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManageOffer", new { id = manageOffer.Id }, manageOffer);
        }

        // DELETE: api/ManageOffers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManageOffer(int id)
        {
            if (_context.ManageOffers == null)
            {
                return NotFound();
            }
            var manageOffer = await _context.ManageOffers.FindAsync(id);
            if (manageOffer == null)
            {
                return NotFound();
            }

            _context.ManageOffers.Remove(manageOffer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManageOfferExists(int id)
        {
            return (_context.ManageOffers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
