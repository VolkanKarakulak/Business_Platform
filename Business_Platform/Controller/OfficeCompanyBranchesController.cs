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
                Id = u.Id,
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
        public async Task<ActionResult<OfficeCompanyBranchGet>> GetOfficeCompanyBranch(int id)
        {
          
            var officeCompanyBranch = await _context.OfficeCompanyBranches!.Include(u => u.State).Include(u => u.OfficeCompany).FirstOrDefaultAsync(u => u.Id == id);

            if (officeCompanyBranch == null)
            {
                return NotFound();
            }

            var officeCompanyBranchGet = new OfficeCompanyBranchGet
            {
                Id = officeCompanyBranch.Id,
                Name = officeCompanyBranch.Name,
                Address = officeCompanyBranch.Address,
                RegisterDate = officeCompanyBranch.RegisterDate,
                PostalCode = officeCompanyBranch.PostalCode,
                PhoneNumber = officeCompanyBranch.PhoneNumber,
                EMail = officeCompanyBranch.EMail,
                City = officeCompanyBranch.City!,
                BranchCode = officeCompanyBranch.BranchCode,
                State = officeCompanyBranch.State!.Name,
                OfficeCompanyName = officeCompanyBranch.OfficeCompany!.Name
            };
            return officeCompanyBranchGet;
        }

        // PUT: api/OfficeCompanyBranches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficeCompanyBranch(int id, OfficeCompanyBranchPut officeCompanyBranchPut)
        {
            if (id != officeCompanyBranchPut.Id)
            {
                return BadRequest();
            }

            OfficeCompanyBranch? officeCompanyBranch = await _context.OfficeCompanyBranches!.FindAsync(id);

            if (officeCompanyBranch == null)
            {
                return NotFound();
            }

            officeCompanyBranch.Name = officeCompanyBranchPut.Name;
            officeCompanyBranch.Address = officeCompanyBranchPut.Address;
            officeCompanyBranch.PhoneNumber = officeCompanyBranchPut.PhoneNumber;
            officeCompanyBranch.PostalCode = officeCompanyBranchPut.PostalCode;
            officeCompanyBranch.EMail = officeCompanyBranchPut.EMail;
            officeCompanyBranch.City = officeCompanyBranchPut.City;
            officeCompanyBranch.BranchCode = officeCompanyBranchPut.BranchCode;
            officeCompanyBranch.StateId = officeCompanyBranchPut.StateId;
            officeCompanyBranch.OfficeCompanyId = officeCompanyBranchPut.OfficeCompanyId;

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
        public async Task<ActionResult<OfficeCompanyBranch>> PostOfficeCompanyBranch(OfficeCompanyBranchPost officeCompanyBranchPost)
        {
          if (_context.OfficeCompanyBranches == null)
          {
              return Problem("Entity set 'Business_PlatformContext.OfficeCompanyBranches'  is null.");
          }
            OfficeCompanyBranch officeCompanyBranch = new OfficeCompanyBranch
            {
                Name = officeCompanyBranchPost.Name,
                Address = officeCompanyBranchPost.Address,
                PhoneNumber = officeCompanyBranchPost.PhoneNumber,
                EMail = officeCompanyBranchPost.EMail,
                PostalCode = officeCompanyBranchPost.PostalCode,
                OfficeCompanyId = officeCompanyBranchPost.OfficeCompanyId, // Dikkat: modellerde nullable yaptık. Yapmalı mıyız?
                StateId = officeCompanyBranchPost.StateId // Dikkat: Modellerde nullable yapmadık. Yapmalı mıyız?
            };

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
