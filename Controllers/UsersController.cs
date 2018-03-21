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

namespace NilamHutAPI.Controllers
{
    [Authorize(Policy = "ApiUser")]
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
        public async Task<IActionResult> PostUser([FromBody]UserViewModel user)
        {
            var getUserId = User.FindFirst("Id").Value;

            if(getUserId == null) return Challenge();

            if(ModelState.IsValid)
            {
                var result =  await _userService.AddUserAsync(user,getUserId);
                if(result) return Ok();
                else return new ObjectResult(result);
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var getUserId = User.FindFirst("Id").Value;

            if(getUserId == null) return Challenge();

            var result =  await _userService.GetUserAsync(getUserId);
            return Json(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditUser([FromBody] UserViewModel user)
        {
            var getUserId = User.FindFirst("Id").Value;

            if(getUserId == null) return Challenge();

            if(ModelState.IsValid)
            {
                var result =  await _userService.EditUserAsync(user,getUserId);
                if(result) return Ok();
                else return new ObjectResult(result);
            }

            return BadRequest(ModelState);
        }
    }
}