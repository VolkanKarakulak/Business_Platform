﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Model;
using Business_Platform.Data;


namespace BusinessPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        //private readonly BusinessPlatformContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly BusinessPlatformContext _context;

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
        public AppUsersController(SignInManager<AppUser> signInManager, BusinessPlatformContext context)
        {
            _signInManager = signInManager;
            _context = context;
        }

        // GET: api/AppUsers
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult<List<AppUser>> GetUsers(bool includePassive = true)
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

            if (User.IsInRole("Admin") == false)
            {
                if (User.FindFirstValue(ClaimTypes.NameIdentifier) != id.ToString())
                {
                    return Unauthorized();
                }
            }

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
        public ActionResult  PutAppUser(AppUser appUser)
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

           return Ok("User Account Created");

        }

        [HttpPut("ActivateUser")]
        //[Authorize(Roles = "Admin")]
        public ActionResult ActivateUser(long id)
        {
            AppUser? appUser = _signInManager.UserManager.FindByIdAsync(id.ToString()).Result;

            _signInManager.UserManager.UpdateAsync(appUser).Wait();
            return Ok("User Aktivated");
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
            if(!changePasswordResult.Succeeded)
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

        [HttpPost("Logout")]
        //[Authorize]
        public ActionResult LogOut()
        {
             _signInManager.SignOutAsync().Wait();

            return Ok("Successful Logout");
        }

    }
}