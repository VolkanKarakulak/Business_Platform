using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model.Office;
using Business_Platform.DTOs.OfficeProdBranchProductDtos;

namespace Business_Platform.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeProdBranchProductsController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public OfficeProdBranchProductsController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/OfficeProdBranchProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeProdBranchProductGet>>> GetOfficeProdBranchProducts()
        {
          var officeProdBranchProduct = await _context.OfficeProdBranchProducts!.Select(u => new OfficeProdBranchProductGet
          {
              Id = u.Id,
              Name = u.Name,
              Quantity = u.Quantity,
              OfficeProductId = u.OfficeProductId,
              OfficeCompanyBranchId = u.OfficeCompanyBranchId,
              OfficeCompanyBranchName = u.OfficeCompanyBranch!.Name,

          }).ToListAsync();

            if (officeProdBranchProduct == null)
            {
                return NotFound();
            }

            return officeProdBranchProduct;
        }

        // GET: api/OfficeProdBranchProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeProdBranchProductGet>> GetOfficeProdBranchProduct(int id)
        {
          
            var officeProdBranchProduct = await _context.OfficeProdBranchProducts!.Include(u => u.OfficeProduct)
                .Include(u => u.OfficeCompanyBranch).FirstOrDefaultAsync(u => u.Id == id);

            if (officeProdBranchProduct == null)
            {
                return NotFound();
            }

            var officeProdBranchProductGet = new OfficeProdBranchProductGet
            {
                Id = officeProdBranchProduct.Id,
                Name = officeProdBranchProduct.Name,
                Quantity = officeProdBranchProduct.Quantity,
                OfficeProductId = officeProdBranchProduct.OfficeProductId,
                OfficeCompanyBranchId = officeProdBranchProduct.OfficeCompanyBranchId,
                OfficeCompanyBranchName = officeProdBranchProduct.OfficeCompanyBranch!.Name,
            };

            return officeProdBranchProductGet;
        }

        // PUT: api/OfficeProdBranchProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficeProdBranchProduct(int id, OfficeProdBranchProduct officeProdBranchProduct)
        {
            if (id != officeProdBranchProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(officeProdBranchProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeProdBranchProductExists(id))
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

        // POST: api/OfficeProdBranchProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OfficeProdBranchProduct>> PostOfficeProdBranchProduct(OfficeProdBranchProductPost officeProdBranchProductPost)
        {
          if (_context.OfficeProdBranchProducts == null)
          {
              return Problem("Entity set 'Business_PlatformContext.OfficeProdBranchProducts'  is null.");
          }

            OfficeProdBranchProduct officeProdBranchProduct = new OfficeProdBranchProduct
            {
                Name = officeProdBranchProductPost.Name,
                Quantity = officeProdBranchProductPost.Quantity,
                Price = officeProdBranchProductPost.Price,
                Color = officeProdBranchProductPost.Color,
                Material = officeProdBranchProductPost.Material,
                StateId = officeProdBranchProductPost.StateId,
                OfficeProductTypeId = officeProdBranchProductPost.OfficeProductTypeId,
                OfficeCompanyId = officeProdBranchProductPost.OfficeCompanyId,
                OfficeProductId = officeProdBranchProductPost.OfficeProductId,
                OfficeCompanyBranchId = officeProdBranchProductPost.OfficeCompanyBranchId,
                CompanyCategoryId = officeProdBranchProductPost.CompanyCategoryId
            };

            _context.OfficeProdBranchProducts.Add(officeProdBranchProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfficeProdBranchProduct", new { id = officeProdBranchProduct.Id }, officeProdBranchProduct);
        }

        // DELETE: api/OfficeProdBranchProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficeProdBranchProduct(int id)
        {
            if (_context.OfficeProdBranchProducts == null)
            {
                return NotFound();
            }
            var officeProdBranchProduct = await _context.OfficeProdBranchProducts.FindAsync(id);
            if (officeProdBranchProduct == null)
            {
                return NotFound();
            }

            _context.OfficeProdBranchProducts.Remove(officeProdBranchProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficeProdBranchProductExists(int id)
        {
            return (_context.OfficeProdBranchProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
