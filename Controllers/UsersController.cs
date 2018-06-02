using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NilamHutAPI.Services;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using NilamHutAPI.Helpers;

namespace NilamHutAPI.Controllers
{
    //[Authorize(Policy = "ApiUser")]
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromForm]UserViewModel user)
        {
            if(ModelState.IsValid)
            {
                var result =  await _userService.AddUserAsync(user);
                if(result == "SuccessFull") return Ok();
                else return BadRequest(Errors.AddErrorToModelState("Info Add Failure", result , ModelState));
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string userId)
        {
            var result =  await _userService.GetUserAsync(userId);
            return Json(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditUser([FromForm] UserViewModel user)
        {
            if(ModelState.IsValid)
            {
                var result =  await _userService.EditUserAsync(user);
                if(result) return Ok();
                else return new ObjectResult(result);
            }

            return BadRequest(ModelState);
        }
    }
}