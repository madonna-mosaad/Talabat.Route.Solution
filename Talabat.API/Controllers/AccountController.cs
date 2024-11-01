using AutoMapper;
using Core.Layer.Models;
using Core.Layer.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talabat.API.DTO;
using Talabat.API.Extensions;
using Talabat.API.Response;

namespace Talabat.API.Controllers
{
    public class AccountController : TalabatBaseController
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<Users> userManager,SignInManager<Users> signInManager,IAuthService authService,IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
           _mapper = mapper;
        }
        [HttpPost("login")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(typeof(ApiResponse), 401)]
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
                DisplayNane = user.DisplayName,
                Email = user.Email,
                Token =  await _authService.CreateTokenAsync(user, _userManager)
            });
        }
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            //.Result.Value to make this async function done before CreateAsync start
            if (IsEmailExist(registerDTO.Email).Result.Value) 
            {
                return BadRequest(new ApiValidationErrorResponse()
                {
                    Errors = new string[] { "Email is exist" } 
                });
            }
            var user = new Users()
            {
                Email = registerDTO.Email,
                DisplayName = registerDTO.DisplayName,
                PhoneNumber = registerDTO.PhoneNumber,
                UserName = registerDTO.Email.Split('@')[0]
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded is false)
            {
                return BadRequest(new ApiResponse(400));
            }

            return Ok(new UserDTO()
            {
                DisplayNane = registerDTO.DisplayName,
                Email = registerDTO.Email,
                Token = await _authService.CreateTokenAsync(user, _userManager)
            });
        }

        [HttpGet("User")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<UserDTO>> GetUser()
        {
            var email =User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) 
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(new UserDTO()
            {
                DisplayNane = user.DisplayName,
                Email = email,
                Token =await _authService.CreateTokenAsync(user, _userManager)

            });
        }

        [HttpGet("UserAddress")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<AddressDTO>> GetAddress()
        {
            //to make the address has the value from database i must use the Include to Include the address (navigation property)
            //extention method to UserManger because i will use Include here and in another end point
            var user = await _userManager.FindUserWithAddressAsync(User);
            return Ok(_mapper.Map<Address,AddressDTO>(user.Address));
        }

        [HttpPut("UpdateAddress")]
        [ProducesResponseType(typeof(AddressDTO), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        //return address not address dto because i want to make sure that address is updated
        public async Task<ActionResult<AddressDTO>> UpdateAddress(AddressDTO addressDTO)
        {
            var address = _mapper.Map<AddressDTO, Address>(addressDTO);//id to addressDTO is 0 so address.Id=0
            var user = await _userManager.FindUserWithAddressAsync(User);

            address.Id = user.Address.Id;

            user.Address = address;

            var result=await _userManager.UpdateAsync(user);
            if (result.Succeeded) 
            {
                return Ok(addressDTO);
            }

            return BadRequest(new ApiResponse(400));
        }

        //to prevent register 2 person with same email
        [HttpGet("ExistEmail")]
        public async Task<ActionResult<bool>> IsEmailExist(string email)
        {
            //return true if exist 
            return await _userManager.FindByEmailAsync(email) is not null;
        }
    }
}
