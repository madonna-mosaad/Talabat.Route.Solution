using Core.Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.DTO;
using Talabat.API.Response;

namespace Talabat.API.Controllers
{
    public class AccountController : TalabatBaseController
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public AccountController(UserManager<Users> userManager,SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                return Unauthorized(new ApiResponse(401));
            }
            var pass=await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password,false);
            if(pass.Succeeded is false)
            {
                return Unauthorized(new ApiResponse(401));
            }
            return Ok(new UserDTO()
            {
                DisplayNane=user.DisplayName,
                Email=user.Email,
                Token="none"
            });
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            var user = await _userManager.CreateAsync(new Users()
            {
                Email = registerDTO.Email,
                DisplayName = registerDTO.DisplayName,
                PhoneNumber = registerDTO.PhoneNumber,
                UserName = registerDTO.Email.Split('@')[0]
            }, registerDTO.Password);

            if (user.Succeeded is false)
            {
                return BadRequest(new ApiResponse(400));
            }
            
            return Ok(new UserDTO()
            {
                DisplayNane = registerDTO.DisplayName,
                Email = registerDTO.Email,
                Token = "none"
            });
        }
    }
}
