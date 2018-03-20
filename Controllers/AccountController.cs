using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NilamHutAPI.ViewModels;
using NilamHutAPI.Models;
using NilamHutAPI.Data;

namespace NilamHutAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _appDbContext = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
               var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
               var result = await _userManager.CreateAsync(user, model.Password);
            }
            else{
                return BadRequest(ModelState);
            }

            return new OkObjectResult("Account created");
        }
    }
}