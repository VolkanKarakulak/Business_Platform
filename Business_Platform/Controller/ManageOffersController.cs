using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model.Office;
using Microsoft.AspNetCore.Authorization;
using Business_Platform.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Business_Platform.DTOs;

namespace Business_Platform.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageOffersController : ControllerBase
    {
        private readonly Business_PlatformContext _context;
        private readonly SignInManager<AppUser> _signInManager;

        public ManageOffersController(Business_PlatformContext context, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        // GET: api/ManageOffers
        [HttpGet]
        //[Authorize(Roles = "OfficeCompanyAdmin")]
        public async Task<ActionResult<IEnumerable<ManageOfferDto>>> GetManageOffers()
        {
            //if (User.HasClaim("OfficeCompanyAdminId", manageOffer.OfficeCompanyId.ToString()) == false)
            //{
            //    return Unauthorized();
            //}

            var managerOffers = await _context.ManageOffers!.Select(u => new ManageOfferDto
            {
                OfferDate = u.OfferDate,
                OfferPrice = u.OfferPrice,
                Status = u.Status!,
                //OfficeProductOffer = u.OfficeProductOffer.OfferDate
                AppUserName = u.AppUser!.Name,
                OfficeProdBranchProductName = u.OfficeProdBranchProduct!.Name,
                OfficeCompanyName = u.OfficeCompany!.Name,
                OfficeCompanyBranchName = u.OfficeCompanyBranch!.Name


            }).ToListAsync();

            if (_context.ManageOffers == null)
          {
              return NotFound();
          }
            return managerOffers;
        }

        // GET: api/ManageOffers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManageOfferDto>> GetManageOffer(int id)
        {
            var manageOffer = await _context.ManageOffers!
                .Include(o => o.OfficeProdBranchProduct)
                .Include(o => o.OfficeCompanyBranch)
                .Include(o => o.AppUser)
                .Include(o => o.OfficeCompany) 
                .FirstOrDefaultAsync(o => o.Id == id);

            if (manageOffer == null)
            {
                return NotFound();
            }

            var viewModel = new ManageOfferDto
            {
                OfferDate = manageOffer.OfferDate,
                OfferPrice = manageOffer.OfferPrice,
                Status = manageOffer.Status,
                //OfficeProductOffer = manageOffer.OfficeProductOfferId,
                //OfficeProdBranchProductName = manageOffer.OfficeProdBranchProduct != null ? manageOffer.OfficeProdBranchProduct.Name : null
                AppUserName = manageOffer.AppUser!.Name,
                OfficeCompanyName = manageOffer.OfficeCompany!.Name,
                OfficeCompanyBranchName = manageOffer.OfficeCompanyBranch!.Name,
                OfficeProdBranchProductName = manageOffer.OfficeProdBranchProduct!.Name,
            };

            return viewModel;
        }

        // PUT: api/ManageOffers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutManageOffer(ManageOffer manageOffer)
        {
            int id = manageOffer.Id;

            ManageOffer? manageOff = await _context.ManageOffers!.FindAsync(id);

            if (manageOff == null) 
            {
                return NotFound();
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
