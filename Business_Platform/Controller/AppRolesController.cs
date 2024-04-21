using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Data;
using Business_Platform.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Business_Platform.ViewModel;

namespace Business_Platform.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppRolesController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AppRolesController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("assign")]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleModel model)
        {
            // Kullanıcıyı bul
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return NotFound("User Not Found.");
            }

            // Rolü bul
            var role = await _roleManager.FindByNameAsync(model.Role);
            if (role == null)
            {
                return NotFound("Role Not Found.");
            }

            // Kullanıcıya rol ata
            var result = await _userManager.AddToRoleAsync(user, model.Role);

            if (result.Succeeded)
            {
                return Ok($"Role '{model.Role}' Assigned to User '{user.Email}' Successfully.");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}