using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NzWalks.Api.Models.DTO;

namespace NzWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        //user manager class to register a user
        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
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
    }
}
