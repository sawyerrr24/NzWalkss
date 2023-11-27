using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NzWalks.Api.Models.DTO;
using NzWalks.Api.Repositories;

namespace NzWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        //user manager class to register a user
        public AuthController(UserManager<IdentityUser> userManager,ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }





        //POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityuser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };


           var identityResult = await userManager.CreateAsync(identityuser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                //Add roles to this user

                if(registerRequestDto.Roles!=null && registerRequestDto.Roles.Any())
                {
                  identityResult =  await userManager.AddToRolesAsync(identityuser, registerRequestDto.Roles);

                    if(identityResult.Succeeded)
                    {
                        return Ok("User was registered! You can login now.");
                        

                    }

                }

                

            }


            return BadRequest("Something went wrong");

        }


        //POST:/api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
           var user = await userManager.FindByEmailAsync(loginRequest.Username);

            if(user != null)
            {
               var checkPassword = await userManager.CheckPasswordAsync(user,loginRequest.Password);

                if (checkPassword)
                {
                    //Get Roles for this user
                  var roles = await userManager.GetRolesAsync(user);


                    if (roles != null)
                    {
                       var jwttoken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwttoken,
                        };

                        return Ok(jwttoken);
                    }

                    //Create Token
                    
                    
                }

            }


            return BadRequest("Username or password is incorrect");

        }

    }
}
