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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Business_Platform.DTOs;

namespace Business_Platform.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly Business_PlatformContext _context;

        public struct LogInModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public struct ChangePasswordModel
        {
            public string UserName { get; set; }
            public string CurrentPassword { get; set; }
            public string NewPassword { get; set; }
        }
        public AppUsersController(SignInManager<AppUser> signInManager, Business_PlatformContext context)
        {
            _signInManager = signInManager;
            _context = context;
        }
        // GET: api/AppUsers
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult<List<UserGet>> GetUsers()
        {
            var users = _signInManager.UserManager.Users.Select(user => new UserGet
            {
                Id = user.Id,
                Name = user.Name,
                RegisterDate = user.RegisterDate,
                StateName = user.State!.Name, // Include State name
                OfficeCompanyName = user.OfficeCompany!.Name, // Include OfficeCompany name
                OfficeCompanyBranchName = user.OfficeCompanyBranch!.Name, // Include OfficeCompanyBranch name
                MainCompanyName = user.MainCompany!.Name, // Include MainCompany name
                FoodCompanyName = user.FoodCompany!.Name, // Include FoodCompany name
                RestaurantBranchName = user.RestaurantBranch!.Name, // Include RestaurantBranch name

                // ... (other properties if needed)
            }).AsNoTracking().ToList();

            return users;
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        //[Authorize]
        public ActionResult<UserGet> GetAppUser(long id)
        {
            var user = _signInManager.UserManager.Users
                .Include(u => u.State)  // Include State entity
                .Include(u => u.OfficeCompany) // Include OfficeCompany entity
                .Include(u => u.OfficeCompanyBranch)
                .Include(u => u.MainCompany)// Include OfficeCompanyBranch entity
                .Where(u => u.Id == id).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            var getUser = new UserGet
            {
                Id = user.Id,
                Name = user.Name,
                RegisterDate = user.RegisterDate,
                StateName = user.State?.Name, // Include State name
                OfficeCompanyName = user.OfficeCompany?.Name, // Include OfficeCompany name
                OfficeCompanyBranchName = user.OfficeCompanyBranch?.Name, // Include OfficeCompanyBranch name
                MainCompanyName = user.MainCompany?.Name, // Include MainCompany name
                FoodCompanyName = user.FoodCompany?.Name, // Include FoodCompany name
                RestaurantBranchName = user.RestaurantBranch?.Name, // Include RestaurantBranch name

                // ... (other properties if needed)
            };

            return getUser;
        }

        // PUT: api/AppUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //[Authorize]
        public ActionResult PutAppUser(int id, [FromBody] UserPut model)
        {
            var user = _signInManager.UserManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            user.RegisterDate = model.RegisterDate;
            user.StateId = model.StateId;
            user.OfficeCompanyBranchId = model.OfficeCompanyBranchId;
            user.OfficeCompanyId = model.OfficeCompanyId;
            user.FoodCompanyId = model.FoodCompanyId;
            user.RestaurantBranchId = model.RestaurantBranchId;
            user.MainCompanyId = model.MainCompanyId;

            var result = _signInManager.UserManager.UpdateAsync(user).Result;
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        // POST: api/AppUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<string> PostAppUser(AppUser appUser)
        {

            if (User.Identity!.IsAuthenticated == true)
            {
                return BadRequest();
            }

            IdentityResult identityResult = _signInManager.UserManager.CreateAsync(appUser, appUser.PassWord).Result;

            if (identityResult != IdentityResult.Success)
            {
                return identityResult.Errors.FirstOrDefault()!.Description;
            }
            return Ok("User Account Created");
        }

        [HttpPost("ChangePassword")]
        //[Authorize]
        public ActionResult<string> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            AppUser? appUser = _signInManager.UserManager.FindByNameAsync(changePasswordModel.UserName).Result;
            if (appUser == null)
            {
                return NotFound("User Not Found");
            }
            IdentityResult changePasswordResult = _signInManager.UserManager.ChangePasswordAsync(appUser, changePasswordModel.CurrentPassword, changePasswordModel.NewPassword).Result;
            if (!changePasswordResult.Succeeded)
            {
                return BadRequest("Password change failed");
            }
            return Ok("Password Changed Succesfully");
        }

        // DELETE: api/AppUsers/5
        [HttpDelete("{id}")]
        //[Authorize]
        public ActionResult<string> DeleteAppUser(long id)
        {
            AppUser? user = null;

            if (User.IsInRole("CustomerRepresentative") == false)
            {
                if (User.FindFirstValue(ClaimTypes.NameIdentifier) != id.ToString())
                {
                    return Unauthorized();
                }
            }
            user = _signInManager.UserManager.Users.Where(u => u.Id == id).FirstOrDefault();


            _signInManager.UserManager.UpdateAsync(user!).Wait();
            return Ok("User Deactivated");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new AppUser { Name = model.Name, UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber };

            var result = await _signInManager.UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
               
                return Ok("User Created Successfully. Wait For Authorization");
            }

            return BadRequest(result.Errors);
        }


        [HttpPost("Login")]
        public ActionResult LogIn(string eMail, string passWord)
        {
            Microsoft.AspNetCore.Identity.SignInResult signInResult;
            AppUser appUser = _signInManager.UserManager.FindByEmailAsync(eMail).Result;

            if (appUser == null)
            {
                return RedirectToAction("LogIn");
            }

            signInResult = _signInManager.PasswordSignInAsync(appUser, passWord, false, false).Result;
            if (!signInResult.Succeeded)
            {

                ModelState.AddModelError(string.Empty, "Invalid Username or Password");
                return BadRequest();
            }

            // Kullanıcı adını göster
            //HttpContext.Session.SetString("UserName", appUser.UserName);

            return Ok(new { Message = "Successful Login", UserName = appUser.UserName });
        }

        [HttpPost("Logout")]
        //[Authorize]
        public ActionResult LogOut()
        {
            _signInManager.SignOutAsync().Wait();

            return Ok("Successful Logout");
        }
        private bool AppUserExists(long id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
