using Aqarak.Dtos;
using AqarakCore.IdentityEnities;
using AqarakCore.Iservice;
using AqarakService.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Aqarak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUserIdentity> _userManager;
        private readonly SignInManager<AppUserIdentity> _signInManager;
        private readonly ICreateToken _tokenService;

        public AccountController(UserManager<AppUserIdentity> userManager,
            SignInManager<AppUserIdentity> signInManager, ICreateToken tokenService)
        {
          _userManager = userManager;
          _signInManager = signInManager;
           _tokenService = tokenService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) { return Unauthorized(); }
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user,_userManager)

            });
        }
            [HttpPost("register")]
            public async Task<ActionResult<UserDto>> Register(RegisterDto model)
            {
          
                if (await _userManager.FindByEmailAsync(model.Email) != null)
                {
                    return BadRequest("Email is already in use");
                }

                var user = new AppUserIdentity
                {
                    DisplayName = model.DisplayName,
                    Email = model.Email,
                    UserName=model.DisplayName,
                    
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(new { Errors = errors });
                }

                

                return Ok(new UserDto
                {
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    Token = await _tokenService.CreateTokenAsync(user, _userManager)
                });
            }
           
        
       
    }
}
