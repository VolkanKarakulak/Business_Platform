using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model.Office;
using Business_Platform.DTOs.OfficeCompanyBranchDtos;

namespace Business_Platform.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeCompanyBranchesController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public OfficeCompanyBranchesController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/OfficeCompanyBranches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeCompanyBranchGet>>> GetOfficeCompanyBranches()
        {
            var officeCompanyBranches = await _context.OfficeCompanyBranches!.Select(u => new OfficeCompanyBranchGet
            {
                Name = u.Name,
                Address = u.Address,
                RegisterDate = u.RegisterDate,
                PostalCode = u.PostalCode,
                PhoneNumber = u.PhoneNumber,
                EMail = u.EMail,
                City = u.City!,
                BranchCode = u.BranchCode,
                State = u.State!.Name,
                OfficeCompanyName = u.OfficeCompany!.Name

            }).ToListAsync();

            if (officeCompanyBranches == null )
            {
                return NotFound();
            }
            return officeCompanyBranches;
        }

        // GET: api/OfficeCompanyBranches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeCompanyBranch>> GetOfficeCompanyBranch(int id)
        {
          if (_context.OfficeCompanyBranches == null)
          {
              return NotFound();
          }
            var officeCompanyBranch = await _context.OfficeCompanyBranches.FindAsync(id);

            if (officeCompanyBranch == null)
            {
                return NotFound();
            }

            return officeCompanyBranch;
        }

        // PUT: api/OfficeCompanyBranches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficeCompanyBranch(int id, OfficeCompanyBranch officeCompanyBranch)
        {
            if (id != officeCompanyBranch.Id)
            {
                return BadRequest();
            }

            _context.Entry(officeCompanyBranch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeCompanyBranchExists(id))
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

        // POST: api/OfficeCompanyBranches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OfficeCompanyBranch>> PostOfficeCompanyBranch(OfficeCompanyBranch officeCompanyBranch)
        {
          if (_context.OfficeCompanyBranches == null)
          {
              return Problem("Entity set 'Business_PlatformContext.OfficeCompanyBranches'  is null.");
          }
            _context.OfficeCompanyBranches.Add(officeCompanyBranch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfficeCompanyBranch", new { id = officeCompanyBranch.Id }, officeCompanyBranch);
        }

        // DELETE: api/OfficeCompanyBranches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficeCompanyBranch(int id)
        {
            if (_context.OfficeCompanyBranches == null)
            {
                return NotFound();
            }
            var officeCompanyBranch = await _context.OfficeCompanyBranches.FindAsync(id);
            if (officeCompanyBranch == null)
            {
                return NotFound();
            }

            _context.OfficeCompanyBranches.Remove(officeCompanyBranch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficeCompanyBranchExists(int id)
        {
            return (_context.OfficeCompanyBranches?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
