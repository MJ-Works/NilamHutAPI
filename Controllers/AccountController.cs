using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NilamHutAPI.ViewModels;
using NilamHutAPI.Models;
using NilamHutAPI.Data;
using NilamHutAPI.Auth;
using Microsoft.Extensions.Options;
using NilamHutAPI.Helpers;
using Newtonsoft.Json;
using NilamHutAPI.Services;

namespace NilamHutAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IUserService _userService;
        public AccountController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
                                IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions,
                                IUserService userService)
        {
            _appDbContext = context;
            _userManager = userManager;
             _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
               var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
               var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded) return new ObjectResult(result);
                else
                    await _userManager.AddToRoleAsync(user, Constants.Strings.UserRoles.SimpleUser);

                //add null userInfo Table

                ApplicationUser getUser = await _userManager.FindByNameAsync(model.UserName);

                var addUserInfo = new UserViewModel
                {
                    ApplicationUserId = getUser.Id
                };

                bool isInfoAdded = await _userService.AddUserAsync(addUserInfo);

                if(!isInfoAdded)
                {
                    //delete the added user from database
                    await _userManager.DeleteAsync(getUser);
                    return BadRequest();
                }
                else return Ok();
            }
            else{
                return BadRequest(ModelState);
            }

           // return new OkObjectResult("Account created");
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]CredentialsViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = await GetClaimsIdentity(credentials.UserName, credentials.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }

          var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, credentials.UserName, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
          return new OkObjectResult(jwt);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(await _jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}