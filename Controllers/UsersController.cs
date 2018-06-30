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
using Microsoft.AspNetCore.Http;

namespace NilamHutAPI.Controllers
{
    //[Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
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
            if (ModelState.IsValid)
            {
                var result = await _userService.AddUserAsync(user);
                if (result == "SuccessFull") return Ok();
                else return BadRequest(Errors.AddErrorToModelState("Info Add Failure", result, ModelState));
            }

            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _userService.GetUserAsync(id);
            return new OkObjectResult(result);
        }

        [HttpGet("UserPosts/{id}")]
        public async Task<IActionResult> UserPosts(string id)
        {
            var result = await _userService.GetUserPosts(id);
            return new OkObjectResult(result);
        }

        [HttpGet("UserBids/{id}")]
        public async Task<IActionResult> UserBids(string id)
        {
            var result = await _userService.GetUserBids(id);
            return new OkObjectResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditUser([FromBody] UserViewModel user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _userService.EditUserAsync(user);
            if (!result) return BadRequest(Errors.AddErrorToModelState("Message", "Something Went Wrong.", ModelState));
            return new OkObjectResult(new { Message = "Profile Updated." });

        }
        [HttpPut("UploadImage")]
        public async Task<IActionResult> UpdateImage([FromForm] IFormFile image, string userId)
        {
            if (image == null || userId == null) BadRequest(Errors.AddErrorToModelState("Message", "All Field Required", ModelState));
            var result = await _userService.EditUserImageAsync(image, userId);
            if (!result) return BadRequest(Errors.AddErrorToModelState("Message", "Something Went Wrong.", ModelState));
            return new OkObjectResult(new { Message = "Profile Image Updated." });
        }

        [HttpPost("Updaterating")]
        public async Task<IActionResult> Updaterating([FromBody]RatingViewModel rating)
        {
            // return Json(rating);
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _userService.UpdateRating(rating);
           if (!result) return BadRequest(Errors.AddErrorToModelState("Message", "Something Went Wrong.", ModelState));
            return new OkObjectResult(new { Message = "Rating Added/Updated." });
        }
    }
}