using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model.Office;
using Business_Platform.DTOs.OfficeProductCommentDtos;
using System.Security.Claims;

namespace Business_Platform.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeProductCommentsController : ControllerBase
    {
        private readonly Business_PlatformContext _context;

        public OfficeProductCommentsController(Business_PlatformContext context)
        {
            _context = context;
        }

        // GET: api/OfficeProductComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeProductCommentGet>>> GetOfficeProductComment()
        {
            var officeProductComment = await _context.OfficeProductComment!.Select(u => new OfficeProductCommentGet
            {
                Id = u.Id,
                AppUserId = u.AppUserId,
                AppUserName = u.AppUser!.Name,
                Comment = u.Comment,
                CommentDate = u.CommmentDate,
                OfficeProdBranchProductId = u.OfficeProdBranchProductId,
                OfficeProdBranchName = u.OfficeProdBranchProduct!.Name
            }).ToListAsync();

          if (officeProductComment == null)
          {
              return NotFound();
          }
            return officeProductComment;
        }

        // GET: api/OfficeProductComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeProductComment>> GetOfficeProductComment(int id)
        {
          if (_context.OfficeProductComment == null)
          {
              return NotFound();
          }
            var officeProductComment = await _context.OfficeProductComment.FindAsync(id);

            if (officeProductComment == null)
            {
                return NotFound();
            }

            return officeProductComment;
        }

        // PUT: api/OfficeProductComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficeProductComment(int id, OfficeProductComment officeProductComment)
        {
            if (id != officeProductComment.Id)
            {
                return BadRequest();
            }

            _context.Entry(officeProductComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeProductCommentExists(id))
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

        // POST: api/OfficeProductComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OfficeProductComment>> PostOfficeProductComment(OfficeProductCommentPost officeProductCommentPost)
        {
          if (_context.OfficeProductComment == null)
          {
              return Problem("Entity set 'Business_PlatformContext.OfficeProductComment'  is null.");
          }

            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (user == null)
            {
                return Unauthorized();
            }

            if (!long.TryParse(user, out var userId))
            {
                return Problem();
            }

            OfficeProductComment officeProductComment = new OfficeProductComment
            {
                AppUserId = userId,
                Comment = officeProductCommentPost.Comment,
                CommmentDate = officeProductCommentPost.CommentDate,
                OfficeProdBranchProductId = officeProductCommentPost.OfficeProdBranchProductId
            };
            
            _context.OfficeProductComment.Add(officeProductComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfficeProductComment", new { id = officeProductComment.Id }, officeProductComment);
        }

        // DELETE: api/OfficeProductComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficeProductComment(int id)
        {
            if (_context.OfficeProductComment == null)
            {
                return NotFound();
            }
            var officeProductComment = await _context.OfficeProductComment.FindAsync(id);
            if (officeProductComment == null)
            {
                return NotFound();
            }

            _context.OfficeProductComment.Remove(officeProductComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficeProductCommentExists(int id)
        {
            return (_context.OfficeProductComment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
