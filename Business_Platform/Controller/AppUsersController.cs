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
using Business_Platform.ViewModel;

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
        public ActionResult<List<AppUser>> GetUsers()
        {
            IQueryable<AppUser> users = _signInManager.UserManager.Users;

            return users.AsNoTracking().ToList();
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        //[Authorize]
        public ActionResult<AppUser> GetAppUser(long id)
        {
            AppUser? appUser = null;

            //if (User.IsInRole("Admin") == false)
            //{
            //    if (User.FindFirstValue(ClaimTypes.NameIdentifier) != id.ToString())
            //    {
            //        return Unauthorized();
            //    }
            //}

            appUser = _signInManager.UserManager.Users.Where(u => u.Id == id).FirstOrDefault();


            if (appUser == null)
            {
                return NotFound();
            }

            return appUser;
        }

        // PUT: api/AppUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //[Authorize]
        public ActionResult PutAppUser(AppUser appUser)
        {
            AppUser? user = null;

            user = _signInManager.UserManager.Users.Where(u => u.Id == appUser.Id).AsNoTracking().FirstOrDefault(); // asnotricking olmaz burda,oku ve unut diyemeyiz

            _signInManager.UserManager.UpdateAsync(appUser);

            return Ok();
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


            _signInManager.UserManager.UpdateAsync(user).Wait();
            return Ok("User Deactivated");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new AppUser { Name = model.Name, UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber };

            var result = await _signInManager.UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Yeni kullanıcı oluşturuldu, ancak onay bekliyor.
                // Onay işlemi burada gerçekleştirilmemiştir, sadece "User" rolü atanmıştır.

                return Ok("User Created Successfully");
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
